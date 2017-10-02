using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISD.CommonEntity;

namespace ISD.Areas.ProductManagement.Models
{
    public class ImageRepositoryImpl:ImageRepository
    {
        private const string GET_DATA = "SELECT * FROM IMAGES WHERE PRODUCTID = @PRODUCTID";
        private const string GET_DATA_BY_ID = "SELECT * FROM IMAGES WHERE IMAGEID = @IMAGEID";
        private const string CREATE = "INSERT INTO IMAGES (PRODUCTID, NAME, LINK, [PRIORITY])"
            + " VALUES(@PRODUCTID, @NAME, @LINK, @PRIORITY)";
        private const string UPDATE = "UPDATE IMAGES SET NAME = @NAME, LINK = @LINK," 
            + " [PRIORITY] = @PRIORITY WHERE IMAGEID = @IMAGEID";
        private const string REMOVE = "DELETE IMAGES WHERE IMAGEID = @IMAGEID";

        public List<Images> getAll(int pId)
        {
            throw new NotImplementedException();
        }

        public Images getDataById(int imageId)
        {
            throw new NotImplementedException();
        }

        public RespondingRequest create(Images image)
        {
            throw new NotImplementedException();
        }

        public RespondingRequest update(Images image)
        {
            throw new NotImplementedException();
        }

        public RespondingRequest remove(Images image)
        {
            throw new NotImplementedException();
        }
    }
}