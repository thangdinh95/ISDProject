var service = function () {
    var path = "api/login";
    var service = {};
    service.login = function (account, password) {
        var loginInfo = {
            account: account,
            password: password
        };//
        return common.ajax(path, loginInfo, "post");//override ajax
    }
    return service;
}();