using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

using static IcarusLib.ExcelUsingOpenXML;
using IcarusLib;

namespace Icarus
{
    internal class Export
    {
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

        public static void ExportXlsx(string path, IEnumerable<ResultOne> recipes, ResultOne total)
           => CreateExcelFileWithOneSheet(path, "ICARUS WhatDoYouNeed", ws => MakeSheet(ws, recipes, total));
    }
}
