var service = function () {
    var parentPath = "/api/admin/accountMN/";
    var path = {
        getAll: "find/getAll",
        getById: "find/getById",
        checkAccountExist: "find/accountExist",
        create: "command/create",
        update: "command/update",
        remove: "command/remove"
    };
    var service = {};
    service.checkAccountExist = function (account) {
        return common.ajax(parentPath + path.checkAccountExist + "?account=" + account, null, "post");
    }
    service.getAll = function () {
        return common.ajax(parentPath + path.getAll, null, "post");
    }

    service.getDataById = function (admindId) {
        var id = { id: admindId };
        return common.ajax(parentPath + path.getById + "?id=" + admindId, null, "post")
    }

    service.create = function (obj) {
        return common.ajax(parentPath + path.create, obj, "post");
    }

    service.update = function (obj) {
        return common.ajax(parentPath + path.update, obj, "post");
    }

    service.remove = function (obj) {
        return common.ajax(parentPath + path.remove, obj, "post")
    }

    return service;
}();