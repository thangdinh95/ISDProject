using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISD.CommonEntity;
using ISD.Areas.ProductManagement.Models.ProductRepositoryFolder;
using ISD.Areas.ProductManagement.Models.ProductStatusRepositoryFolder;
using ISD.Areas.ProductManagement.Models.ImageRepositoryFolder;
using ISD.Helper;
using System.Data.SqlClient;
using System.Data;

namespace ISD.Areas.ProductManagement.Models.ProductBusinessRepository
{
    public class ProductBuzRepositoryImpl : ProductBuzRepository
    {
        #region declare repository
        private ProductRepository productRepository = new ProductRepositoryImpl();
        private ProductStatusRepository productStatusRepository = new ProductStatusRepositoryImpl();
        private ImageRepository imageRepository = new ImageRepositoryImpl();
        private SqlConnection con = null;
        #endregion

        #region create
        public RespondingRequest create(ProductBusinessObject obj)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            con = SqlHelper.getConection();
            using (IDbTransaction tran = con.BeginTransaction()) {
                try
                {
                    productRepository.create(obj.product);
                    productStatusRepository.create(obj.product);
                    foreach (Images img in obj.lstImages)
                        imageRepository.create(img);
                    tran.Commit();
                    respondingRequest.status = true;
                    respondingRequest.message = "Successful!";
                }
                catch 
                {
                    tran.Rollback();
                    respondingRequest.status = false;
                    respondingRequest.message = "Fail. Please check again!";
                }
            }
            return respondingRequest;
        }
        #endregion

        #region remove
        public RespondingRequest remove(ProductBusinessObject obj)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            con = SqlHelper.getConection();
            using (IDbTransaction tran = con.BeginTransaction())
            {
                try
                {
                    foreach (Images img in obj.lstImages)
                        imageRepository.remove(img);
                    productStatusRepository.remove(obj.product.productId);
                    productRepository.remove(obj.product);
                    tran.Commit();
                    respondingRequest.status = true;
                    respondingRequest.message = "Successful!";
                }
                catch
                {
                    tran.Rollback();
                    respondingRequest.status = false;
                    respondingRequest.message = "Fail. Please check again!";
                }
            }
            return respondingRequest;
        }
        #endregion

        #region update
        public RespondingRequest update(ProductBusinessObject obj)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            con = SqlHelper.getConection();
            using (IDbTransaction tran = con.BeginTransaction())
            {
                try
                {
                    productRepository.update(obj.product);
                    productStatusRepository.update(obj.product);
                    imageRepository.removeByProductId(obj.product.productId);
                    foreach (Images img in obj.lstImages)
                        imageRepository.create(img);
                    tran.Commit();
                    respondingRequest.status = true;
                    respondingRequest.message = "Successful!";
                }
                catch
                {
                    tran.Rollback();
                    respondingRequest.status = false;
                    respondingRequest.message = "Fail. Please check again!";
                }
            }
            return respondingRequest;
        }
        #endregion
    }
}