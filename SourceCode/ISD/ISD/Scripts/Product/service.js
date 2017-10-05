var service = function () {
    var parentPath = "api/admin/productMN";
    var path = {
        getAllProducts: "find/getAllProducts",
        getAllImages: "find/getAllImages",
        create: "command/create",
        update: "command/update",
        remove: "command/remove"
    };
    var service = {};
    service.getAllProducts = function () {
        return common.ajax(parent + path.getAllProducts, null, "post");
    }
    service.getAllImages = function (productId) {
        return common.ajax(parentPath + path.getAllImages + "?productId=" + productId, null, "post");
    }
    service.create = function (obj) {
        return common.ajax(parentPath + path.create, null, "post");
    }
    service.update = function (obj) {
        return common.ajax(parentPath + path.update, null, "post");
    }
    service.remove = function (obj) {
        return common.ajax(parentPath + path.remove, null, "post");
    }
    return service;
}();