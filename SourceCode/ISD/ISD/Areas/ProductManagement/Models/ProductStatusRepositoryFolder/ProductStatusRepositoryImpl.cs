using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISD.CommonEntity;
using ISD.Helper;
using System.Data.SqlClient;

namespace ISD.Areas.ProductManagement.Models.ProductStatusRepositoryFolder
{
    public class ProductStatusRepositoryImpl : ProductStatusRepository
    {
        private const string CREATE = "INSERT INTO PRODUCTSTATUS(PRODUCTID, QUANTITY, NUMOFSOLD, NUMOFVIEW)"
            + " VALUES(@PRODUCTID, @QUANTITY, @NUMOFSOLD, @NUMOFVIEW)";
        private const string UPDATE = "UPDATE PRODUCTSTATUS SET QUANTITY = @QUANTITY, NUMOFSOLD = @NUMOFSOLD,"
            + " NUMOFVIEW = @NUMOFVIEW WHERE PRODUCTID = @PRODUCTID";
        private const string REMOVE = "DELETE PRODUCTSTATUS WHERE PRODUCTID = @PRODUCTID";
        public RespondingRequest create(Products ps)
        {
            return SqlHelper.update(CREATE,
                new SqlParameter("@PRODUCTID", ps.productId),
                new SqlParameter("@QUANTITY", ps.status.quantity),
                new SqlParameter("@NUMOFSOLD", ps.status.numOfSold),
                new SqlParameter("@NUMOFVIEW", ps.status.numOfView));
        }

        public RespondingRequest remove(int productId)
        {
            return SqlHelper.update(REMOVE,
                new SqlParameter("@PRODUCTID", productId));
        }

        public RespondingRequest update(Products ps)
        {
            return SqlHelper.update(UPDATE,
                new SqlParameter("@PRODUCTID", ps.productId),
                new SqlParameter("@QUANTITY", ps.status.quantity),
                new SqlParameter("@NUMOFSOLD", ps.status.numOfSold),
                new SqlParameter("@NUMOFVIEW", ps.status.numOfView));
        }
    }
}