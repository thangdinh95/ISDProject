var service = function () {
    var path = "/api/admin/logMN/find/getAll";

    var service = {};
    service.getAll = function () {
        return common.ajax(path, null, "post");
    }

    return service;
}();