using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

using IcarusLib;

namespace Icarus
{
    internal class Export
    {
        private static Row FindRow(Worksheet sheet, uint rindex)
        {
            var data = sheet.GetFirstChild<SheetData>();
            var row = data.Elements<Row>().FirstOrDefault(r => r.RowIndex == rindex);
            if (row == null)
            {
                row = new Row() { RowIndex = rindex };
                data.Append(row);
            }
            return row;
        }
        private static Cell FindCell(Row row, string col)
        {
            string cellref = $"{col}{row.RowIndex}";
            var cells = row.Elements<Cell>();
            int icomp(string a, string b) => string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
            bool eq(string a, string b) => icomp(a, b) == 0;
            bool gr(string a, string b) => icomp(a, b) > 0;
            Cell findcell(Func<string, string, bool> comp) => cells.FirstOrDefault(c => comp(c.CellReference, cellref));

            var cell = findcell(eq);
            if (cell == null)
            {
                cell = new Cell() { CellReference = cellref };
                var after = findcell(gr);
                row.InsertBefore(cell, after);
            }
            return cell;
        }
        private static Cell FindCell(Worksheet sheet, string col, uint rowindex) => FindCell(FindRow(sheet, rowindex), col);

#if USE_STYLE_SHEET
        private static Stylesheet MakeStyleSheet(WorkbookPart wpart)
        {
            var spart = wpart.AddNewPart<WorkbookStylesPart>();
            var st = new Stylesheet();
            spart.Stylesheet = st;

            st.Fonts = new Fonts() { Count = 1 };
            st.Fonts.AppendChild(new Font());

            var fills = new Fills();
            st.Fills = fills;
            fills.AppendChild(new Fill() { PatternFill = new PatternFill() { PatternType = PatternValues.None } });
            fills.AppendChild(new Fill() { PatternFill = new PatternFill() { PatternType = PatternValues.Gray125 } });

            var solidRed = new PatternFill()
            {
                PatternType = PatternValues.Solid,
                ForegroundColor = new ForegroundColor() { Rgb = new HexBinaryValue("FFFF0000") },
                BackgroundColor = new BackgroundColor() { Indexed = 64 }
            };
            fills.AppendChild(new Fill() { PatternFill = solidRed });
            fills.Count = 3;

            st.Borders = new Borders();
            st.Borders.Count = 1;
            st.AppendChild(new Border());

            st.CellStyleFormats = new CellStyleFormats();
            st.CellStyleFormats.Count = 1;
            st.CellStyleFormats.AppendChild(new CellFormat());

            st.CellFormats = new CellFormats();
            st.CellFormats.AppendChild(new CellFormat());
            st.CellFormats.AppendChild(new CellFormat()
            {
                FormatId = 0,
                FontId = 0,
                ApplyFont = true,
                BorderId = 0,
                FillId = 2,
                ApplyFill = true,
                NumberFormatId = 4,
                ApplyNumberFormat = BooleanValue.FromBoolean(true),
            });

            st.CellFormats.Count = new UInt32Value((uint)st.CellFormats.Count());
            st.Save();
            return st;
        }

#endif
        private static char[] alphas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static string CellColumnName(int idx)
        {
            string colname = "";
            do
            {
                idx = Math.DivRem(idx, alphas.Length, out var rem) - 1;
                colname = alphas[rem].ToString() + colname;
            } while (idx >= 0);
            return colname;
        }

        private static void MakeSheet(Worksheet wsheet, IEnumerable<ResultOne> recipes, ResultOne total)
        {
            var total_dic = new Dictionary<string, (int idx, string cref, decimal vol)>();
            var rindex = 1u;
            {
                var colindex = 1;
                foreach (var st in total.Recipe.stuffs
                                            .Select(oi => (obj: new IcrObject(oi.Name), oi.Volume))
                                            .OrderBy(o => o.obj.Name))
                {
                    var colref = CellColumnName(colindex);
                    total_dic[st.obj.Key] = (colindex, colref, st.Volume);
                    var cell = FindCell(wsheet, colref, rindex);
                    cell.CellValue = new CellValue(st.obj.Name);                   
                    cell.DataType = new EnumValue<CellValues>(CellValues.String);
                    colindex++;
                }
                rindex++;
            }

            foreach (var rcp in recipes.OrderBy(r => r.Target.Name))
            {
                var row = FindRow(wsheet, rindex);
                var AX = FindCell(row, "A");
                AX.CellValue = new CellValue(rcp.Target.Name);
                AX.DataType = new EnumValue<CellValues>(CellValues.String);
                foreach (var st in rcp.Recipe.stuffs
                                    .Select(oi => (obj: new IcrObject(oi.Name), oi.Volume))
                                    .OrderBy(o => o.obj.Name))
                {
                    var entry = total_dic[st.obj.Key];
                    var cell = FindCell(row, entry.cref);
                    cell.CellValue = new CellValue(st.Volume);
                }
                rindex++;
            }
            var trow = FindRow(wsheet, rindex);
            var TX = FindCell(trow, "A");
            TX.CellValue = new CellValue("TOTAL");
            TX.DataType = new EnumValue<CellValues>(CellValues.String);
            foreach (var entry in total_dic.Values)
            {
                var cell = FindCell(trow, entry.cref);
                cell.CellValue = new CellValue(entry.vol);
            }

            //var A1 = FindCell(wsheet, "A", 1);
            //A1.CellValue = new CellValue(10);
            //// A1.DataType = new EnumValue<CellValues>(CellValues.Number);

            //var A2 = FindCell(wsheet, "A", 2);
            //A2.CellValue = new CellValue(20);

            //var A3 = FindCell(wsheet, "A", 3);
            //A3.CellFormula = new CellFormula("=SUM(A1, A2)");

        }


        public static void CreateSample(string path, IEnumerable<ResultOne> recipes, ResultOne total)
        {
            using (var docu = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
            {
                var wbpart = docu.AddWorkbookPart();
                wbpart.Workbook = new Workbook();
                var sheetpart = wbpart.AddNewPart<WorksheetPart>();
                var wsheet = new Worksheet(new SheetData());
                sheetpart.Worksheet = wsheet;
                var sheets = docu.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                var sheet = new Sheet()
                {
                    Id = docu.WorkbookPart.GetIdOfPart(sheetpart),
                    SheetId = 1,
                    Name = $"ICARUS WhatDoYouNeed"
                };
                sheets.Append(sheet);

                MakeSheet(wsheet, recipes, total);



                wbpart.Workbook.Save();
            }
        }
    }
}
