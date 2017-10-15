//
var service = function () {
    var parentPath = "/api/admin/productMN/";
    var path = {
        getAllProducts: "find/getAllProducts",
        getProductById: "find/getProductById",
        getImageById:"find/getImageById",
        createProduct: "command/product/create",
        updateProduct: "command/product/update",
        removeProduct: "command/product/remove",
        updateImages: "command/image/update",
        getAllCategory: "/api/admin/categoryMN/find/getAll"
    };
    var service = {};
    service.getAllProducts = function () {
        return common.ajax(parentPath + path.getAllProducts, null, "post");
    }
    service.getProductById = function (productId) {
        return common.ajax(parentPath + path.getProductById + "?productId=" + productId, null, "post");
    }
    service.getImageById = function (imageId) {
        return common.ajax(parentPath + path.getImageById + "?imageId=" + imageId, null, "post");
    }
    service.createProduct = function (obj) {
        return common.ajax(parentPath + path.createProduct, obj, "post");
    }
    service.updateProduct = function (obj) {
        return common.ajax(parentPath + path.updateProduct, obj, "post");
    }
    service.removeProduct = function (obj) {
        return common.ajax(parentPath + path.removeProduct, obj, "post");
    }
    service.updateImage = function (obj) {
        return common.ajax(parentPath + path.updateImages, obj, "post");
    }
    service.getAllCategory = function(){
        return common.ajax(path.getAllCategory, null, "post");
    }
    return service;
}();