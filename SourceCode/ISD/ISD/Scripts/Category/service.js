var service = function () {
    var parentPath = "/api/admin/categoryMN/";
    var path = { //lay link trong server
        getAll: "find/getAll",
        getById: "find/getById",
        create: "command/create",
        update: "command/update",
        remove: "command/remove",
        checkCtgNameExist: "find/checkCtgNameExist"// k dc lap lai trong cate
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

    service.checkCtgNameExist = function (ctgName, currentName) {
        var command = {
            ctgName: ctgName,
            currentName: currentName
        };
        return common.ajax(parentPath + path.checkCtgNameExist, command, "post");
    }
    return service;
}();