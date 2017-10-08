var service = function () {
    var path = "api/login";//Khai báo đường link tới web service
    var service = {};
    service.login = function (account, password) {
        var loginInfo = {//data được dùng khi gửi request bằng ajax
            account: account,
            password: password
        };//
        return common.ajax(path, loginInfo, "post");//override ajax
    }
    return service;
}();