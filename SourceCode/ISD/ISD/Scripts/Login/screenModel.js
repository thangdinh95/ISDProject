﻿function ScreenModel() {
    var self = this;
    self.userName = ko.observable(""); 
    self.password = ko.observable("");
    self.canLogin = ko.observable(true);
}

ScreenModel.prototype.login = function () { 
    var self = this;  
    if (self.canLogin()) {
        self.canLogin(false);
        service.login(self.userName(), self.password())
            .done(function (data)
            {
            if (!data.status) {
                self.canLogin(true);
                toastr.error(data.message);
            }
            else
                location.href = "Home/GetSession?id=" + parseInt(data.message);
        });
    }
}
