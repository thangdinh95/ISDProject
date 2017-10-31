using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace ISD.Helper
{
    public class ExcelPrint
    {
        #region print excel list
        public static byte[] PrintList(PrintingParamObject par)
        {
            #region 
            // If using Professional version, put your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            int numOfColumn = par.headerName.Length;
            int i, j, sheetNum = 1;
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add(par.sheetName);
            
            ws.Cells[0, 0].Value = par.title;
            ws.Cells[0, 0].Style.Font.Weight = ExcelFont.BoldWeight;
            ws.Cells[0, 0].Style.Font.Size = 18 * 20;
            ws.Cells[0, 0].Style.Font.Color = Color.Black;
            ws.Cells.GetSubrangeAbsolute(0, 0,0, (numOfColumn-1)).Merged = true;
            ws.Cells.GetSubrangeAbsolute(0, 0, 0, (numOfColumn - 1)).Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            ws.Cells.GetSubrangeAbsolute(0, 0, 0, (numOfColumn - 1)).Style.VerticalAlignment = VerticalAlignmentStyle.Center;
            #endregion

            #region header
            createHeader(ws, par, numOfColumn);
            #endregion

            int contentRowNum = 0;
            #region fill data
            for (i = 0; i < par.lstObj.Count; i++)
            {
                if (i > 0 && i % 80 == 0)
                {
                    contentRowNum = 0;
                    ws = ef.Worksheets.Add(par.sheetName + (++sheetNum).ToString());
                    createHeader(ws, par, numOfColumn);
                }
                string[] content = par.lstObj[i];
                for (j = 0; j < content.Length; j++)
                {
                    ExcelCell cell = ws.Cells[contentRowNum + 4, j];

                    cell.Value = content[j];

                    if (contentRowNum % 2 == 0)
                        cell.Style.FillPattern.SetSolid(Color.LightSkyBlue);
                    else
                        cell.Style.FillPattern.SetSolid(Color.FromArgb(210, 210, 230));

                    cell.Style.Borders[IndividualBorder.Right].LineStyle = LineStyle.Thin;
                }
                contentRowNum++;
            }
            #endregion


            ws.PrintOptions.FitWorksheetWidthToPages = 1;

            byte[] fileContents;

            var options = SaveOptions.XlsxDefault;


            using (var stream = new MemoryStream())
            {
                ef.Save(stream, options);

                fileContents = stream.ToArray();
            }
            return fileContents;
        }
        #endregion

        private static void createHeader(ExcelWorksheet ws, PrintingParamObject par, int numOfColumn)
        {
            // Column width of num... characters. 
            int[] widthHeader = par.headerWith;

            for (int id = 0; id < numOfColumn; id++)
            {
                ws.Columns[id].Width = widthHeader[id] * 256;
            }
            int i, j;
            // Write header data to Excel cells.
            string[] headerName = par.headerName;
            for (j = 0; j < numOfColumn; j++)
            {
                ws.Cells[3, j].Value = headerName[j];
                ws.Cells.GetSubrangeAbsolute(2, j, 3, j).Merged = true;
            }
            CellStyle tmpStyle = new CellStyle();
            tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
            tmpStyle.FillPattern.SetSolid(Color.Chocolate);
            tmpStyle.Font.Weight = ExcelFont.BoldWeight;
            tmpStyle.Font.Color = Color.White;
            tmpStyle.WrapText = true;
            tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
            ws.Cells.GetSubrangeAbsolute(2, 0, 3, (numOfColumn - 1)).Style = tmpStyle;
            tmpStyle = new CellStyle();
            tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
            tmpStyle.Font.Weight = ExcelFont.BoldWeight;
        }
    }
}