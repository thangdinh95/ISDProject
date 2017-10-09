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
            // If using Professional version, put your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add("Writing");
            ws.Cells[0, 0].Value = "Log detail";
            ws.Cells[0, 0].Style.Font.Weight = ExcelFont.BoldWeight;
            ws.Cells[0, 0].Style.Font.Size = 18 * 20;
            ws.Cells[0, 0].Style.Font.Color = Color.GreenYellow;
            // Tabular sample data for writing into an Excel file.
            LogRepository logRepository = new LogRepositoryImpl();
            List<Logs> lstLogs = logRepository.getData();
            //object[,] skyscrapers = new object[21, 5]
            //{
            //{"No", "Type", "Content", "Account", "Date"},
            //{ 1, "Taipei 101", "Taipei", 509, 1671},
            //{ 2, "Petronas Tower 1", "Kuala Lumpur", 452, 1483},
            //{ 3, "Petronas Tower 2", "Kuala Lumpur", 452, 1483},
            //{ 4, "Sears Tower", "Chicago", 442, 1450},
            //{ 5, "Jin Mao Tower", "Shanghai", 421, 1380},
            //{ 6, "2 International Finance Centre", "Hong Kong", 415, 1362},
            //{ 7, "CITIC Plaza", "Guangzhou", 391, 1283},
            //{ 8, "Shun Hing Square", "Shenzhen", 384, 1260},
            //{ 9, "Empire State Building", "New York City", 381, 1250},
            //{10, "Central Plaza", "Hong Kong", 374, 1227},
            //{11, "Bank of China Tower", "Hong Kong", 367, 1205},
            //{12, "Emirates Office Tower", "Dubai", 355, 1163},
            //{13, "Tuntex Sky Tower", "Kaohsiung", 348, 1140},
            //{14, "Aon Center", "Chicago", 346, 1136},
            //{15, "The Center", "Hong Kong", 346, 1135},
            //{16, "John Hancock Center", "Chicago", 344, 1127},
            //{17, "Ryugyong Hotel", "Pyongyang", 330, 1083},
            //{18, "Burj Al Arab", "Dubai", 321, 1053},
            //{19, "Chrysler Building", "New York City", 319, 1046},
            //{20, "Bank of America Plaza", "Atlanta", 312, 1023}
            //};
            
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


            // Write and format sample data to Excel cells.
            //for (i = 0; i < lstLogs.Count; i++)
            //{
            //    ExcelCell cell0 = ws.Cells[i + 4, 0];
            //    cell0.Value = i+1;
            //    ExcelCell cell1 = ws.Cells[i + 4, 1];
            //    cell1.Value = lstLogs[i].type.ToString();
            //}
            for (i = 0; i < lstLogs.Count; i++)
            {
                string[] content = { i.ToString(), lstLogs[i].type.ToString(),
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
            return File(fileContents, options.ContentType, "Spreadsheet.xlsx");
        }
    }
}