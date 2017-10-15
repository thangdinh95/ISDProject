using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISD.CommonEntity;
using System.Data;
using ISD.Helper;
using System.Data.SqlClient;
using ISD.Areas.ProductManagement.Models.ProductStatusRepositoryFolder;

namespace ISD.Areas.ProductManagement.Models.ProductRepositoryFolder
{
    public class ProductRepositoryImpl : ProductRepository
    {
        #region declare query string
        private const string GET_DATA = "SELECT p.*, c.NAME AS CATEGORYNAME, ps.QUANTITY, ps.NUMOFSOLD, ps.NUMOFVIEW,"
            + " aA.ACCOUNT AS CREATEDBYACCOUNT, aB.ACCOUNT AS MODIFIEDBYACCOUNT FROM PRODUCTS p"
            + " LEFT JOIN CATEGORIES c ON P.CATEGORYID = c.CATEGORYID"
            + " LEFT JOIN PRODUCTSTATUS ps ON p.PRODUCTID = ps.PRODUCTID"
            + " LEFT JOIN ADMINS aA ON p.CREATEDBY = aA.ADMINID"
            + " LEFT JOIN ADMINS aB ON p.MODIFIEDBY = aB.ADMINID";
        private const string GET_DATA_BY_ID = GET_DATA + " WHERE p.PRODUCTID = @PRODUCTID";
        private const string CREATE= "INSERT INTO PRODUCTS(CATEGORYID, NAME, INPRICE, OUTPRICE, [DESCRIPTION], CREATEDBY, CREATEDDATE)"
            + " VALUES(@CATEGORYID, @NAME, @INPRICE, @OUTPRICE, @DESCRIPTION, @CREATEDBY, @CREATEDDATE);"
            + " SELECT SCOPE_IDENTITY();";
        private const string UPDATE= "UPDATE PRODUCTS SET NAME = @NAME, INPRICE = @INPRICE, OUTPRICE = @OUTPRICE, [DESCRIPTION] = @DESCRIPTION,"
            + " MODIFIEDBY = @MODIFIEDBY, MODIFIEDDATE = @MODIFIEDDATE"
            + " WHERE PRODUCTID = @PRODUCTID";
        private const string REMOVE = "DELETE PRODUCTS WHERE PRODUCTID = @PRODUCTID";

        private const string CREATEPS = "INSERT INTO PRODUCTSTATUS(PRODUCTID, QUANTITY, NUMOFSOLD, NUMOFVIEW)"
            + " VALUES(@PRODUCTID, @QUANTITY, @NUMOFSOLD, @NUMOFVIEW)";
        private const string UPDATEPS = "UPDATE PRODUCTSTATUS SET QUANTITY = @QUANTITY, NUMOFSOLD = @NUMOFSOLD,"
            + " NUMOFVIEW = @NUMOFVIEW WHERE PRODUCTID = @PRODUCTID";
        private const string REMOVEPS = "DELETE PRODUCTSTATUS WHERE PRODUCTID = @PRODUCTID";
        private ProductStatusRepository productStatusRepository = new ProductStatusRepositoryImpl();
        #endregion

        #region create product
        public int create(Products product)
        {
            object result = null;
            SqlConnection con = SqlHelper.getConection();
            if (con.State != ConnectionState.Open) con.Open();
            using (SqlTransaction tran = con.BeginTransaction())
            {
                try
                {
                    result = SqlHelper.exeScalar(CREATE, tran,
                    new SqlParameter("@CATEGORYID", product.categoryId),
                    new SqlParameter("@NAME", product.name),
                    new SqlParameter("@INPRICE", product.inPrice),
                    new SqlParameter("@OUTPRICE", product.outPrice),
                    new SqlParameter("@DESCRIPTION", product.description),
                    new SqlParameter("@CREATEDBY", product.createdBy),
                    new SqlParameter("@CREATEDDATE", product.createdDate));
                    if (result != null)
                    {
                        product.productId = Int16.Parse(result.ToString());
                        product.status.numOfSold = 0;
                        product.status.numOfView = 0;
                        SqlHelper.update(CREATEPS, tran,
                            new SqlParameter("@PRODUCTID", product.productId),
                            new SqlParameter("@QUANTITY", product.status.quantity),
                            new SqlParameter("@NUMOFSOLD", product.status.numOfSold),
                            new SqlParameter("@NUMOFVIEW", product.status.numOfView));
                        tran.Commit();
                    }
                    
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
                
            return result == null ? -1 : Int16.Parse(result.ToString());
        }
        #endregion

        #region get all product
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
        #endregion

        #region get product by id
        public Products getDataById(int id)
        {
            DataTable dt = SqlHelper.getData(GET_DATA_BY_ID,
                new SqlParameter("@PRODUCTID", id));
            return toObject(dt.Rows[0]);
        }
        #endregion

        #region remove
        public RespondingRequest update(Products product)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            SqlConnection con = SqlHelper.getConection();
            if (con.State == ConnectionState.Closed) con.Open();
            using (SqlTransaction tran = con.BeginTransaction())
            {
                try
                {
                    respondingRequest = SqlHelper.update(UPDATE, tran,
                        new SqlParameter("@NAME", product.name),
                        new SqlParameter("@INPRICE", product.inPrice),
                        new SqlParameter("@OUTPRICE", product.outPrice),
                        new SqlParameter("@DESCRIPTION", product.description),
                        new SqlParameter("@MODIFIEDBY", product.modifiedBy),
                        new SqlParameter("@MODIFIEDDATE", product.modifiedDate),
                        new SqlParameter("@PRODUCTID", product.productId));
                    if (respondingRequest.status)
                    {
                        respondingRequest = SqlHelper.update(UPDATEPS, tran,
                            new SqlParameter("@PRODUCTID", product.productId),
                            new SqlParameter("@QUANTITY", product.status.quantity),
                            new SqlParameter("@NUMOFSOLD", product.status.numOfSold),
                            new SqlParameter("@NUMOFVIEW", product.status.numOfView));
                        tran.Commit();
                    }
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
                
            }
            return respondingRequest;
        }
        #endregion

        #region update
        public RespondingRequest remove(Products product)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            SqlConnection con = SqlHelper.getConection();
            if (con.State == ConnectionState.Closed) con.Open();
            using (SqlTransaction tran = con.BeginTransaction())
            {
                try
                {
                    respondingRequest = SqlHelper.update(REMOVE, tran,
                             new SqlParameter("@PRODUCTID", product.productId));
                   
                    if (respondingRequest.status)
                    {
                        respondingRequest = SqlHelper.update(REMOVEPS, tran,
                        new SqlParameter("@PRODUCTID", product.productId));
                        tran.Commit();
                    }
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
            return respondingRequest;
        }
        #endregion

        #region to object
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
        #endregion
       
    }
}