﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISD.CommonEntity;
using System.Data;
using ISD.Helper;
using System.Data.SqlClient;

namespace ISD.Areas.CategoryManagement.Models
{
    public class CategoryRepositoryImpl : CategoryRepository
    {
        #region declare
        private const string GET_ALL = "SELECT C.*, A.ACCOUNT AS CREATEDBYACCOUNT, B.ACCOUNT AS MODIFIEDBYACCOUNT" 
            + " FROM CATEGORIES C LEFT JOIN ADMINS A ON C.CREATEDBY = A.ADMINID"
            + " LEFT JOIN ADMINS B ON C.MODIFIEDBY = B.ADMINID";
        private const string GET_ALL_BY_ID = "SELECT C.*, A.ACCOUNT AS CREATEDBYACCOUNT, B.ACCOUNT AS MODIFIEDBYACCOUNT"
            + " FROM CATEGORIES C LEFT JOIN ADMINS A ON C.CREATEDBY = A.ADMINID"
            + " LEFT JOIN ADMINS B ON C.MODIFIEDBY = B.ADMINID"
            + " WHERE C.CATEGORYID = @CATEGORYID";
        private const string CREATE = "INSERT INTO CATEGORIES (NAME, [DESCRIPTION], CREATEDBY, CREATEDDATE)"
            + " VALUES(@NAME, @DESCRIPTION, @CREATEDBY, @CREATEDDATE)";
        private const string UPDATE = "UPDATE CATEGORIES SET NAME = @NAME, [DESCRIPTION] = @DESCRIPTION,"
            + " MODIFIEDBY = @MODIFIEDBY, MODIFIEDDATE = @MODIFIEDDATE WHERE CATEGORYID = @CATEGORYID";
        private const string COUNT_PRODUCT_IN_CATEGORY = "SELECT COUNT(*) FROM PRODUCTS WHERE CATEGORYID = @CATEGORYID";
        private const string REMOVE = "DELETE CATEGORIES WHERE CATEGORYID = @CATEGORYID";
        private const string CHECK_CTG_NAME_EXIST = "SELECT COUNT(*) FROM CATEGORIES WHERE NAME = @NAME AND NOT(NAME = @CURRENTNAME)";// so sanh name cua 4 cai con lai
        #endregion

        #region Create
        public RespondingRequest create(Categories category)
        {
            return SqlHelper.update(CREATE, 
                new SqlParameter("@NAME", category.name),
                new SqlParameter("@DESCRIPTION", category.description),
                new SqlParameter("@CREATEDBY", category.createdBy),
                new SqlParameter("@CREATEDDATE", category.createdDate));
        }
        #endregion

        #region get all
        public List<Categories> getAll()
        {
            List<Categories> lstCategory = new List<Categories>();
            DataTable dt = SqlHelper.getData(GET_ALL);
            foreach (DataRow dr in dt.Rows)
                lstCategory.Add(toObject(dr));
            return lstCategory;
        }
        #endregion

        #region get data by id
        public Categories getDataById(int id)
        {
            DataTable dt = SqlHelper.getData(GET_ALL_BY_ID,
                new SqlParameter("@CATEGORYID", id));
            return toObject(dt.Rows[0]);
        }
        #endregion

        #region remove
        public RespondingRequest remove(int categoryId)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            DataTable dt = SqlHelper.getData(COUNT_PRODUCT_IN_CATEGORY,
                new SqlParameter("@CATEGORYID", categoryId));
            if(Int16.Parse(dt.Rows[0][0].ToString()) > 0)
            {
                respondingRequest.status = false;
                respondingRequest.message = "Can not remove: Category still contains products.";
            }
            else
                respondingRequest =  SqlHelper.update(REMOVE,
                new SqlParameter("@CATEGORYID", categoryId));
            return respondingRequest;
        }
        #endregion

        #region update
        public RespondingRequest update(Categories category)
        {
            return SqlHelper.update(UPDATE,
                new SqlParameter("@NAME", category.name),
                new SqlParameter("@DESCRIPTION", category.description),
                new SqlParameter("@MODIFIEDBY", category.modifiedBy),
                new SqlParameter("@MODIFIEDDATE", category.modifiedDate),
                new SqlParameter("@CATEGORYID", category.categoryId));
        }
        #endregion

        #region to object
        private Categories toObject(DataRow dr)
        {
            return new Categories() {
                categoryId = Int16.Parse(dr["CATEGORYID"].ToString()),
                name = dr["NAME"].ToString(),
                description = !dr.IsNull("DESCRIPTION") ? dr["DESCRIPTION"].ToString() : "",
                createdBy = !dr.IsNull("CREATEDBY") ? Int16.Parse(dr["CREATEDBY"].ToString()) : -1,
                createdDate = !dr.IsNull("CREATEDDATE") ? DateTime.Parse(dr["CREATEDDATE"].ToString()) : DateTime.Now,
                createdByAccount = !dr.IsNull("CREATEDBYACCOUNT") ? dr["CREATEDBYACCOUNT"].ToString() : "",
                modifiedBy = !dr.IsNull("MODIFIEDBY") ? Int16.Parse(dr["MODIFIEDBY"].ToString()) : -1,
                modifiedDate = !dr.IsNull("MODIFIEDDATE") ? DateTime.Parse(dr["MODIFIEDDATE"].ToString()) : DateTime.Now,
                modifiedByAccount = !dr.IsNull("MODIFIEDBYACCOUNT") ? dr["MODIFIEDBYACCOUNT"].ToString() : ""
            };
        }
        #endregion

        #region check category name exist
        public RespondingRequest checkCtgNameExist(string ctgName, string currentName)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            DataTable dt = SqlHelper.getData(CHECK_CTG_NAME_EXIST,
                new SqlParameter("@NAME", ctgName),
                 new SqlParameter("@CURRENTNAME", currentName));
            respondingRequest.status = Int16.Parse(dt.Rows[0][0].ToString()) > 0;
            if (respondingRequest.status)
                respondingRequest.message = "Category name has already been existed!";
            return respondingRequest;
        }
        #endregion
    }
}