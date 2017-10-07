using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISD.CommonEntity;
using System.Data;
using ISD.Helper;
using System.Data.SqlClient;

namespace ISD.Areas.ProductManagement.Models.ProductRepositoryFolder
{
    public class ProductRepositoryImpl : ProductRepository
    {
        private const string GET_DATA = "SELECT p.*, c.NAME AS CATEGORYNAME, ps.QUANTITY, ps.NUMOFSOLD, ps.NUMOFVIEW,"
            + " aA.ACCOUNT AS CREATEDBYACCOUNT, aB.ACCOUNT AS MODIFIEDBYACCOUNT FROM PRODUCTS p"
            + " LEFT JOIN CATEGORIES c ON P.CATEGORYID = c.CATEGORYID"
            + " LEFT JOIN PRODUCTSTATUS ps ON p.PRODUCTID = ps.PRODUCTID"
            + " LEFT JOIN ADMINS aA ON p.CREATEDBY = aA.ADMINID"
            + " LEFT JOIN ADMINS aB ON p.MODIFIEDBY = aB.ADMINID";
        private const string GET_DATA_BY_ID = GET_DATA + " WHERE p.PRODUCTID = @PRODUCTID";
        private const string CREATE= "INSERT INTO PRODUCTS(CATEGORYID, NAME, INPRICE, OUTPRICE, [DESCRIPTION], CREATEDBY, CREATEDDATE)"
            + " VALUES(@CATEGORYID, @NAME, @INPRICE, @OUTPRICE, @DESCRIPTION, @CREATEDBY, @CREATEDDATE)";
        private const string UPDATE= "UPDATE PRODUCTS SET NAME = @NAME, INTPRICE = @INPRICE, OUTPRICE = @OUTPRICE, [DESCRIPTION] = @DESCRIPTION,"
            + " MODIFIEDBY = @MODIFIEDBY, MODIFIEDDATE = @MODIFIEDDATE"
            + " WHERE PRODUCTID = @PRODUCTID";
        private const string REMOVE = "DELETE PRODUCTS WHERE PRODUCTID = @PRODUCTID";
        public RespondingRequest create(Products product)
        {
            return SqlHelper.update(CREATE, 
                new SqlParameter("@CATEGORYID", product.categoryId),
                new SqlParameter("@NAME", product.name),
                new SqlParameter("@INPRICE", product.inPrice),
                new SqlParameter("@OUTPRICE", product.outPrice),
                new SqlParameter("@DESCRIPTION", product.description),
                new SqlParameter("@CREATEDBY", product.createdBy),
                new SqlParameter("@CREATEDDATE", product.createdDate));
        }

        public List<Products> getData()
        {
            List<Products> lstProduct = new List<Products>();
            DataTable dt = SqlHelper.getData(GET_DATA);
            foreach(DataRow dr in dt.Rows)
            {
                lstProduct.Add(toObject(dr));
            }
            return lstProduct;
        }

        public Products getDataById(int id)
        {
            DataTable dt = SqlHelper.getData(GET_DATA_BY_ID,
                new SqlParameter("@PRODUCTID", id));
            return toObject(dt.Rows[0]);
        }

        public RespondingRequest remove(Products product)
        {
            return SqlHelper.update(UPDATE,
                new SqlParameter("@NAME", product.name),
                new SqlParameter("@INPRICE", product.inPrice),
                new SqlParameter("@OUTPRICE", product.outPrice),
                new SqlParameter("@DESCRIPTION", product.description),
                new SqlParameter("@MODIFIEDBY", product.modifiedBy),
                new SqlParameter("@MODIFIEDDATE", product.modifiedDate),
                new SqlParameter("@PRODUCTID", product.productId));
        }

        public RespondingRequest update(Products product)
        {
            return SqlHelper.update(REMOVE,
                new SqlParameter("@PRODUCTID", product.productId));
        }

        private Products toObject(DataRow dr)
        {
            return new Products() {
                productId = Int16.Parse(dr["PRODUCTID"].ToString()),    
                categoryId = Int16.Parse(dr["CATEGORYID"].ToString()),
                categoryName = dr["CATEGORYNAME"].ToString(),
                name = dr["NAME"].ToString(),
                inPrice = Double.Parse(dr["INPRICE"].ToString()),
                outPrice = Double.Parse(dr["OUTPRICE"].ToString()),
                status = new ProductStatus() {
                    quantity = Int16.Parse(dr["QUANTITY"].ToString()),
                    numOfView = Int16.Parse(dr["NUMOFVIEW"].ToString()),
                    numOfSold = Int16.Parse(dr["NUMOFSOLD"].ToString())
                },
                description = !dr.IsNull("DESCRIPTION")?dr["DESCRIPTION"].ToString(): "",
                createdBy = Int16.Parse(dr["CREATEDBY"].ToString()),
                createdByAccount = dr["CREATEDBYACCOUNT"].ToString(),
                createdDate = DateTime.Parse(dr["CREATEDDATE"].ToString()),
                modifiedBy = !dr.IsNull("MODIFIEDBY")?Int16.Parse(dr["MODIFIEDBY"].ToString()):-1,
                modifiedByAccount = !dr.IsNull("MODIFIEDBYACCOUNT") ?dr["MODIFIEDBYACCOUNT"].ToString(): "",
                modifiedDate = !dr.IsNull("MODIFIEDDATE")?DateTime.Parse(dr["MODIFIEDDATE"].ToString()): DateTime.Now
            };
        }
    }
}