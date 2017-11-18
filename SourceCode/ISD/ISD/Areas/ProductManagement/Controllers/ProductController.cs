using GemBox.Spreadsheet;
using ISD.Areas.ProductManagement.Models;
using ISD.Areas.ProductManagement.Models.ProductRepositoryFolder;
using ISD.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISD.Areas.ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductManagement/Home
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Index", "Login", new { area = "" });
            else return View();
        }

        public ActionResult PrintListByExcel()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Index", "Login", new { area = "" });

            ProductRepository productRepository = new ProductRepositoryImpl();
            List<Products> lstProducts = productRepository.getData().OrderByDescending(x => x.createdDate).ToList();

            #region Set parameter
            PrintingParamObject printingParamObject = new PrintingParamObject();
            printingParamObject.sheetName = "Product list";
            printingParamObject.title = "Product list";
            printingParamObject.headerWith = new int[6] { 8, 40, 40, 20, 30, 30 };
            printingParamObject.headerName = new string[6] { "No", "Category", "Name", "Price($)", "Created by", "Created date" };
            for (int i = 0; i < lstProducts.Count; i++)
            {
                string[] content = { (i+1).ToString(), lstProducts[i].categoryName,
                    lstProducts[i].name, lstProducts[i].outPrice.ToString(),
                    lstProducts[i].createdByAccount.ToString(), lstProducts[i].createdDate.ToString()
                };
                printingParamObject.lstObj.Add(content);
            }
            #endregion

            #region write excel
            byte[] fileContents = ExcelPrint.PrintList(printingParamObject);
            #endregion

            var options = SaveOptions.XlsxDefault;


            return File(fileContents, options.ContentType, "Product list.xlsx");
        }
    }
}