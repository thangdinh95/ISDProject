function ScreenModel() {
    var self = this;
    self.userName = ko.observable("");
    self.password = ko.observable("");
}
ScreenModel.prototype.login = function () {
    var self = this;
    service.login(self.userName(), self.password()).done(function (data) {
        if (!data.status)
            toastr.error(data.message);
        else
            location.href = "Home/AdminPage?id=" + parseInt(data.message);
    });
   
}