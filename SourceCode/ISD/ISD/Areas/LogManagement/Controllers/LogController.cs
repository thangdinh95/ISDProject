using GemBox.Spreadsheet;
using ISD.Areas.LogManagement.Models;
using ISD.Helper;
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

            LogRepository logRepository = new LogRepositoryImpl();
            List<Logs> lstLogs = logRepository.getData();

            #region Set parameter
            PrintingParamObject printingParamObject = new PrintingParamObject();
            printingParamObject.sheetName = "Log detail";
            printingParamObject.title = "Log detail";
            printingParamObject.headerWith = new int[5] { 8, 20, 100, 20, 30 };
            printingParamObject.headerName = new string[5] { "No", "Type", "Content", "Account", "Date" };
            for (int i = 0; i < lstLogs.Count; i++)
            {
                string[] content = { (i+1).ToString(), lstLogs[i].type.ToString(),
                    lstLogs[i].content, lstLogs[i].createdByAccount, lstLogs[i].createdDate.ToString()
                };
                printingParamObject.lstObj.Add(content);
            }
            #endregion

            #region write excel
            byte[] fileContents = ExcelPrint.PrintList(printingParamObject);
            #endregion

            var options = SaveOptions.XlsxDefault;

           
            return File(fileContents, options.ContentType, "Log detail.xlsx");
        }
    }
}