using ISD.Areas.LogManagement.Models;
using ISD.Areas.ProductManagement.Models;
using ISD.Areas.ProductManagement.Models.ImageRepositoryFolder;
using ISD.Areas.ProductManagement.Models.ProductBusinessRepository;
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
        private ProductBuzRepository productBuzRepository = new ProductBuzRepositoryImpl();
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
        public ProductBusinessObject getAllImages(int productId)
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

        #region create
        [HttpPost]
        [Route("command/create")]
        public RespondingRequest create(ProductBusinessObject command)
        {
            return productBuzRepository.create(command);
        }
        #endregion

        #region update
        [HttpPost]
        [Route("command/update")]
        public RespondingRequest update(ProductBusinessObject command)
        {
            return productBuzRepository.update(command);
        }
        #endregion

        #region remove
        [HttpPost]
        [Route("command/remove")]
        public RespondingRequest remove(ProductBusinessObject command)
        {
            return productBuzRepository.remove(command);
        }
        #endregion

    }
}
