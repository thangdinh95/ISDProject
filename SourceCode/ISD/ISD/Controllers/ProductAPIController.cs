using ISD.Areas.AccountManagement.Models;
using ISD.Areas.LogManagement.Models;
using ISD.Areas.ProductManagement.Models;
using ISD.Areas.ProductManagement.Models.ImageRepositoryFolder;
using ISD.Areas.ProductManagement.Models.ProductRepositoryFolder;
using ISD.Areas.ProductManagement.Models.ProductStatusRepositoryFolder;
using ISD.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISD.Controllers
{
    [RoutePrefix("api/admin/productMN")]
    public class ProductAPIController : ApiController
    {

        #region declare repository
        private ProductRepository productRepository = new ProductRepositoryImpl();       
        private AdminRepository adminRepository = new AdminRepositoryImpl();
        private ImageRepository imageRepository = new ImageRepositoryImpl();
        private LogRepository logRepository = new LogRepositoryImpl();
        #endregion

        #region get all product
        [HttpPost]
        [Route("find/getAllProducts")]
        public List<Products> getAllProducts()
        {
            return productRepository.getData();
        }
        #endregion

        #region getDataById
        [HttpPost]
        [Route("find/getProductById")]
        public ProductBusinessObject getProductById(int productId)
        {
            ProductBusinessObject productBusinessObject = new ProductBusinessObject();
            productBusinessObject.lstImages = imageRepository.getAll(productId);
            productBusinessObject.product = productRepository.getDataById(productId);
            return productBusinessObject;
        }
        #endregion

        #region get image by id
        [HttpPost]
        [Route("find/getImageById")]
        public Images getAllImageById(int imageId)
        {
            Images image = imageRepository.getDataById(imageId);
            return image;
        }
        #endregion

        #region create product
        [HttpPost]
        [Route("command/product/create")]
        public int createProduct(Products command)
        {
            
            command.createdBy = command.modifiedBy;
            command.createdDate = DateTime.Now;
            int productId = productRepository.create(command);
            //write log
            if (productId > 0)
            {
                Admins staff = adminRepository.getDataById(command.modifiedBy);
                logRepository.create(new Logs()
                {
                    type = LOGTYPE.CREATE,
                    content = logRepository.logContent(LOGTYPE.CREATE, "Product " + command.name, staff.account),
                    createdBy = staff.adminId,
                    createdDate = DateTime.Now
                });
            }
            return productId;
        }
        #endregion

        #region update product
        [HttpPost]
        [Route("command/product/update")]
        public RespondingRequest updateProduct(Products command)
        {
            RespondingRequest respondingRequest = new RespondingRequest();
            command.modifiedDate = DateTime.Now;
            respondingRequest = productRepository.update(command);

            //write log
            if (respondingRequest.status)
            {             
                Admins staff = adminRepository.getDataById(command.modifiedBy);
                logRepository.create(new Logs()
                {
                    type = LOGTYPE.UPDATE,
                    content = logRepository.logContent(LOGTYPE.CREATE, "Product " + command.name, staff.account),
                    createdBy = staff.adminId,
                    createdDate = DateTime.Now
                });
            }
            return respondingRequest;
        }
        #endregion

        #region remove product
        [HttpPost]
        [Route("command/product/remove")]
        public RespondingRequest removeProduct(Products command)
        {
            
            RespondingRequest respondingRequest = new RespondingRequest();
            respondingRequest = productRepository.remove(command);

            //write log
            if (respondingRequest.status)
            {
                Admins staff = adminRepository.getDataById(command.modifiedBy);
                logRepository.create(new Logs()
                {
                    type = LOGTYPE.REMOVE,
                    content = logRepository.logContent(LOGTYPE.REMOVE, "Category " + command.name, staff.account),
                    createdBy = staff.adminId,
                    createdDate = DateTime.Now
                });
            }
            return respondingRequest;
        }
        #endregion

        #region create image
        [HttpPost]
        [Route("command/image/create")]
        public RespondingRequest createImage(Images command)
        {
            return imageRepository.create(command);
        }
        #endregion

        #region create image
        [HttpPost]
        [Route("command/image/update")]
        public RespondingRequest updateImage(Images command)
        {
            return imageRepository.update(command);
        }
        #endregion

        #region create image
        [HttpPost]
        [Route("command/image/remove")]
        public RespondingRequest removeImage(Images command)
        {
            return imageRepository.remove(command);
        }
        #endregion

    }
    public class ProductBusinessObject
    {
        public Products product { get; set; }
        public List<Images> lstImages { get; set; }
    }
}
