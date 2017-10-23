function ScreenModel() {
    var self = this;
<<<<<<< HEAD
    self.userName = ko.observable(""); 
=======
    self.userName = ko.observable(""); //khai bao knockout js đc sử dụng ở html.
>>>>>>> de28096d38dc0ef9dc130eb3083a604841bb6429
    self.password = ko.observable("");
    self.canLogin = ko.observable(true);
}

ScreenModel.prototype.login = function () { 
    var self = this;  
    if (self.canLogin()) {
        self.canLogin(false);
<<<<<<< HEAD
        service.login(self.userName(), self.password())
            .done(function (data)
=======
        service.login(self.userName(), self.password())// send request
            .done(function (data)// receive response sync
>>>>>>> de28096d38dc0ef9dc130eb3083a604841bb6429
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
