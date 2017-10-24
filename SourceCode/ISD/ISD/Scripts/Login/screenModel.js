function ScreenModel() {
    var self = this;
    self.userName = ko.observable(""); //khai bao knockout js đc sử dụng ở html.
    self.password = ko.observable("");
    self.canLogin = ko.observable(true);
}

ScreenModel.prototype.login = function () { 
    var self = this;  
    if (self.canLogin()) {
        self.canLogin(false);

        service.login(self.userName(), self.password())// send request
            .done(function (data)// receive response sync

            {
            if (data.status == false) {
                self.canLogin(true);
                toastr.error(data.message);
            }
            else
                location.href = "Home/GetSession?id=" + parseInt(data.message);
        });
    }
}
