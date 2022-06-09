using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace IcarusLib
{
    public class ExcelUsingOpenXML
    {
        public static Row FindRow(Worksheet sheet, uint rindex)
        {
            var data = sheet.GetFirstChild<SheetData>();
            var row = data?.Elements<Row>().FirstOrDefault(r => (r?.RowIndex ?? 0) == rindex);
            if (row == null)
            {
                row = new Row() { RowIndex = rindex };
                data?.Append(row);
            }
            return row;
        }
        public static Cell FindCell(Row row, string col)
        {
            string cellref = $"{col}{row.RowIndex}";
            var cells = row.Elements<Cell>();
            int icomp(string a, string b) => string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
            bool eq(string a, string b) => icomp(a, b) == 0;
            bool gr(string a, string b) => icomp(a, b) > 0;
            Cell findcell(Func<string, string, bool> comp) => cells.FirstOrDefault(c => comp(c.CellReference.Value ?? "", cellref));

            var cell = findcell(eq);
            if (cell == null)
            {
                cell = new Cell() { CellReference = cellref };
                var after = findcell(gr);
                row.InsertBefore(cell, after);
            }
            return cell;
        }
        public static Cell FindCell(Worksheet sheet, string col, uint rowindex) => FindCell(FindRow(sheet, rowindex), col);

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
        public static string CellColumnName(int idx)
        {
            string colname = "";
            do
            {
                idx = Math.DivRem(idx, alphas.Length, out var rem) - 1;
                colname = alphas[rem].ToString() + colname;
            } while (idx >= 0);
            return colname;
        }

        public static T CreateExcelFileWithOneSheet<T>(string path, string sheet_name, Func<Worksheet, T>doit)
        {           
            using (var docu = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
            {
                var wbpart = docu.AddWorkbookPart();
                wbpart.Workbook = new Workbook();
                var sheetpart = wbpart.AddNewPart<WorksheetPart>();
                var wsheet = new Worksheet(new SheetData());
                sheetpart.Worksheet = wsheet;
                Sheets? sheets = docu.WorkbookPart?.Workbook.AppendChild<Sheets>(new Sheets());
                if (sheets != null)
                {
                    var sheet = new Sheet()
                    {
                        Id = docu.WorkbookPart?.GetIdOfPart(sheetpart),
                        SheetId = 1,
                        Name = sheet_name, // $"ICARUS WhatDoYouNeed"
                    };
                    sheets.Append(sheet);
                }

                var ret = doit(wsheet);
                wbpart.Workbook.Save();
                return ret;
            }
        }

        public static void CreateExcelFileWithOneSheet(string path, string sheet_name, Action<Worksheet> doit)
                => CreateExcelFileWithOneSheet<int>(path, sheet_name, ws => { doit(ws); return 0; });
    }

}
