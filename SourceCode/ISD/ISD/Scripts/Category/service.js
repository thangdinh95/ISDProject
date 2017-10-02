var service = function () {
    var parentPath = "/api/admin/categoryMN/";
    var path = {
        getAll: "find/getAll",
        getById: "find/getById",
        create: "command/create",
        update: "command/update",
        remove: "command/remove",
        checkCtgNameExist: "find/checkCtgNameExist"
    };
    var service = {};
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
        return common.ajax(parentPath + path.remove, obj, "post");
    }

    service.checkCtgNameExist = function(ctgName){
        return common.ajax(parentPath + path.checkCtgNameExist + "?ctgName=" + ctgName, null, "post");
    }
    return service;
}();