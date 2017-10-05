﻿function ScreenModel() {
    var self = this;
    self.userName = ko.observable(""); // khai bao knockout js đc sử dụng ở html.
    self.password = ko.observable("");
    self.canLogin = ko.observable(true);
}
// xử lý sự kiện login
ScreenModel.prototype.login = function () {//prototype gọi đến đối tượng cha (ở đây là ScreenModel). Ở đây dùng để khai báo function 
    var self = this;
    self.canLogin(false);
    service.login(self.userName(), self.password()).done(function (data) {
        if (!data.status){
            self.canLogin(true);
            toastr.error(data.message);
        }  
        else
            location.href = "Home/GetSession?id=" + parseInt(data.message);
    });
}
