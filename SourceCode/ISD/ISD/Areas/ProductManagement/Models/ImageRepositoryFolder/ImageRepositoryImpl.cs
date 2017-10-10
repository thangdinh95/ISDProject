using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISD.CommonEntity;
using System.Data;
using ISD.Helper;
using System.Data.SqlClient;

namespace ISD.Areas.ProductManagement.Models.ImageRepositoryFolder
{
    public class ImageRepositoryImpl:ImageRepository
    {

        #region declare sql query
        private const string GET_DATA = "SELECT * FROM IMAGES WHERE PRODUCTID = @PRODUCTID";
        private const string GET_DATA_BY_ID = "SELECT * FROM IMAGES WHERE IMAGEID = @IMAGEID";
        private const string CREATE = "INSERT INTO IMAGES (PRODUCTID, NAME, LINK, [PRIORITY] = )"
            + " VALUES(@PRODUCTID, @NAME, @LINK, @PRIORITY)";
        private const string UPDATE = "UPDAET PRODUCTS SET NAME = @NAME, LINK = @LINK, [PRIORITY] = @PRIORITY)"
            + " WHERE IMAGEID = @IMAGEID";
        private const string REMOVE_BY_RPODUCT_ID = "DELETE IMAGES WHERE PRODUCTID = @PRODUCTID";
        private const string REMOVE = "DELETE IMAGES WHERE IMAGEID = @IMAGEID";
        #endregion

        #region get all
        public List<Images> getAll(int pId)
        {
            List<Images> lstImages = new List<Images>();
            DataTable dt = SqlHelper.getData(GET_DATA,
                new SqlParameter("@PRODUCTID", pId));
            foreach (DataRow dr in dt.Rows)
                lstImages.Add(toObject(dr));
            return lstImages;
        }
        #endregion

        #region get data by id
        public Images getDataById(int imageId)
        {
            DataTable dt = SqlHelper.getData(GET_DATA_BY_ID,
                new SqlParameter("@IMAGEID", imageId));
            return toObject(dt.Rows[0]);
        }
        #endregion

        #region create
        public RespondingRequest create(Images image)
        {
            return SqlHelper.update(CREATE,
                new SqlParameter("@PRODUCTID", image.productId), 
                new SqlParameter("@NAME", image.name),
                new SqlParameter("@LINK", image.link),
                new SqlParameter("@PRIORITY", image.priority));
        }
        #endregion

        #region update
        public RespondingRequest update(Images image)
        {
            return SqlHelper.update(UPDATE,
                new SqlParameter("@IMAGEID", image.imageId),
                new SqlParameter("@NAME", image.name),
                new SqlParameter("@LINK", image.link),
                new SqlParameter("@PRIORITY", image.priority));
        }
        #endregion

        #region remove by productId
        public RespondingRequest removeByProductId(int productId)
        {
            return SqlHelper.update(REMOVE_BY_RPODUCT_ID,
                new SqlParameter("@PRODUCTID", productId));
        }
        #endregion

        #region remove
        public RespondingRequest remove(Images image)
        {
            return SqlHelper.update(REMOVE,
                new SqlParameter("@IMAGEID", image.imageId));
        }
        #endregion

        #region to object
        private Images toObject(DataRow dr)
        {
            return new Images()
            {
                imageId = Int16.Parse(dr["IMAGEID"].ToString()),
                productId = Int16.Parse(dr["PRODUCTID"].ToString()),
                name = !dr.IsNull("NAME") ? dr["NAME"].ToString() : "",
                link = dr["LINK"].ToString(),
                priority = Int16.Parse(dr["PRIORITY"].ToString())
            };
        }      
        #endregion
    }
}