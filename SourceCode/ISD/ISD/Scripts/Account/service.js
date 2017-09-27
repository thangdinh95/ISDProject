var service = function () {
    var parentPath = "/api/admin/accountMN/";
    var path = {
        getAll: "find/getAll",
        getById: "find/getById",
        create: "command/create",
        update: "command/update",
        remove: "command/remove"
    };
    var service = {};
    service.getAll = function () {
        return common.ajax(parentPath + path.getAll, null, "post");
    }

    service.getDataById = function (id) {
        return common.ajax(parentPath + path.getById, id, "post")
    }

    service.create = function (obj) {
        return common.ajax(parentPath + path.create, obj, "post");
    }

    service.update = function (obj) {
        return common.ajax(parentPath + path.update, obj, "post");
    }

    service.remove = function (id) {
        return common.ajax(parentPath + path.remove, id, "post")
    }

    return service;
}();