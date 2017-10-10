using GemBox.Spreadsheet;
using ISD.Areas.LogManagement.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISD.Areas.LogManagement.Controllers
{
    public class LogController : Controller
    {
 
        // GET: LogManagement/Home
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Index", "Login", new { area = "" });
            else return View();
        }

        public ActionResult print()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Index", "Login", new { area = "" });

            #region Khai báo Gembox.Spreadsheet
            // If using Professional version, put your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add("Log detail");

            ws.Cells[0, 0].Value = "Log detail";// hiển thị 
            ws.Cells[0, 0].Style.Font.Weight = ExcelFont.BoldWeight;
            ws.Cells[0, 0].Style.Font.Size = 18 * 20;
            ws.Cells[0, 0].Style.Font.Color = Color.GreenYellow;
            #endregion

            // lấy dữ liệu trong db
            LogRepository logRepository = new LogRepositoryImpl();
            List<Logs> lstLogs = logRepository.getData();

            #region header
            // Column width of 8, 20, 100, 20, 20 characters.
            ws.Columns[0].Width = 8 * 256;//no
            ws.Columns[1].Width = 20 * 256;//type
            ws.Columns[2].Width = 100 * 256;//content
            ws.Columns[3].Width = 20 * 256;//date
            ws.Columns[4].Width = 25 * 256;//account
            int i, j;
            // Write header data to Excel cells.
            string[] header = { "No", "Type", "Content", "Account", "Date" };
            for (j = 0; j < 5; j++)
                ws.Cells[3, j].Value = header[j];
            ws.Cells.GetSubrangeAbsolute(2, 0, 3, 0).Merged = true;
            ws.Cells.GetSubrangeAbsolute(2, 1, 3, 1).Merged = true;
            ws.Cells.GetSubrangeAbsolute(2, 2, 3, 2).Merged = true;
            ws.Cells.GetSubrangeAbsolute(2, 3, 3, 3).Merged = true;
            ws.Cells.GetSubrangeAbsolute(2, 4, 3, 4).Merged = true;
            CellStyle tmpStyle = new CellStyle();
            tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
            tmpStyle.FillPattern.SetSolid(Color.Chocolate);
            tmpStyle.Font.Weight = ExcelFont.BoldWeight;
            tmpStyle.Font.Color = Color.White;
            tmpStyle.WrapText = true;
            tmpStyle.Borders.SetBorders(MultipleBorders.Right | MultipleBorders.Top, Color.Black, LineStyle.Thin);
            ws.Cells.GetSubrangeAbsolute(2, 0, 3, 4).Style = tmpStyle;
            tmpStyle = new CellStyle();
            tmpStyle.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            tmpStyle.VerticalAlignment = VerticalAlignmentStyle.Center;
            tmpStyle.Font.Weight = ExcelFont.BoldWeight;
            #endregion


            #region fill data
            for (i = 0; i < lstLogs.Count; i++)
            {
                string[] content = { (i+1).ToString(), lstLogs[i].type.ToString(),
                    lstLogs[i].content, lstLogs[i].createdByAccount, lstLogs[i].createdDate.ToString()
                };
                for (j = 0; j < 5; j++)
                {
                    ExcelCell cell = ws.Cells[i + 4, j];

                    cell.Value = content[j];

                    if (i % 2 == 0)
                        cell.Style.FillPattern.SetSolid(Color.LightSkyBlue);
                    else
                        cell.Style.FillPattern.SetSolid(Color.FromArgb(210, 210, 230));

                    cell.Style.Borders[IndividualBorder.Right].LineStyle = LineStyle.Thin;
                }
            }
            #endregion


            ws.PrintOptions.FitWorksheetWidthToPages = 1;

            byte[] fileContents;

            var options = SaveOptions.XlsxDefault;

            // Save spreadsheet to XLSX format in byte array.
            using (var stream = new MemoryStream())
            {
                ef.Save(stream, options);

                fileContents = stream.ToArray();
            }

            // Stream spreadsheet to browser in XLSX format.
            return File(fileContents, options.ContentType, "Log detail.xlsx");
        }
    }
}