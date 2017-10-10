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
        private ProductStatusRepository productStatusRepository = new ProductStatusRepositoryImpl();
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
        public RespondingRequest createProduct(Products command)
        {
            return productRepository.create(command);
        }
        #endregion

        #region update product
        [HttpPost]
        [Route("command/product/update")]
        public RespondingRequest updateProduct(Products command)
        {
            return productRepository.update(command);
        }
        #endregion

        #region remove product
        [HttpPost]
        [Route("command/product/remove")]
        public RespondingRequest removeProduct(Products command)
        {
            return productRepository.remove(command);
        }
        #endregion

        #region create image
        [HttpPost]
        [Route("command/image/create")]
        public RespondingRequest updateImage(Images command)
        {
            return imageRepository.create(command);
        }
        #endregion

    }
    public class ProductBusinessObject
    {
        public Products product { get; set; }
        public List<Images> lstImages { get; set; }
    }
}
