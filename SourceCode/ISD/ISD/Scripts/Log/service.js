var service = function () {
    var path = "/api/admin/logMN/find/getAll";
    var printPath = "/api/admin/logMN/print/getAll";

    var service = {};
    service.getAll = function () {
        return common.ajax(path, null, "post");
    }

    service.print = function () {
        return common.ajax(printPath, null, "post");
    }
    return service;
}();