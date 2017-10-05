
var ScreenModel = function () {
    var self = this;
   
    self.lstAccount = ko.observableArray([]);
    self.subcribeValue = ko.observable();
    self.admin = ko.observable(new Admins());
    self.canRemove = ko.observable(false);
    self.isCreate = ko.observable(true);
    self.roleOptions = ko.observableArray([
        { id: 1, name: "Super admin" },
        { id: 2, name: "Admin" }
    ]);
    
}


ScreenModel.prototype.start = function () {
    var self = this;
    service.getAll().done(function (data) {
        self.lstAccount(data);
        $("#grid").igGrid("option", "dataSource", self.lstAccount());
        self.admin().modifiedBy(parseInt($("#modifiedBy").val()));
    });
}

ScreenModel.prototype.getById = function (id) {
    var self = this;
    service.getDataById(id).done(function(data){
        self.setData(data);
        self.canRemove(true);
        self.isCreate(false);
    });
};

ScreenModel.prototype.create = function () {
    var self = this;
    self.setData({});
    self.isCreate(true);
}

ScreenModel.prototype.register = function () {
    var self = this;
    var obj = ko.toJSON(self.admin());
    var correctRequired = checkRequired(obj);
    if (correctRequired) {
        if (self.isCreate()) {
            service.checkAccountExist(self.admin().account()).done(function (data) {
                if (data.status)
                    toastr.error(data.message);
                else {
                    service.create(obj).done(function (data) {
                        if (data.status) {
                            toastr.success(data.message);
                            self.start();
                            self.create();
                        }
                        else toastr.error(data.message);
                    }).fail(function (res) {
                        toastr.error(res.respondText);
                    });
                }
            });
        }
        else service.update(obj).done(function (data) {
            if (data.status) {
                toastr.success(data.message);
                self.start();
            }
            else toastr.error(data.message);
        }).fail(function (res) {
            toastr.error(res.respondText);
        });
    } else toastr.error("All fields are required!");
}

ScreenModel.prototype.remove = function () {
    var accept = confirm("Are you sure to remove this account?");
    var self = this;
    if (accept) {
        var obj = ko.toJSON(self.admin());
        service.remove(obj).done(function (data) {
            if (!data.status) {
                toastr.error(data.message);
            } else {
                self.start();
                self.create();
            }
        });
        
    }
       
}

ScreenModel.prototype.setData = function (data) {
    if (data) {
        var self = this;
        self.admin().adminId(data.adminId ? data.adminId : -1);
        self.admin().account(data.account ? data.account : "");
        self.admin().password(data.password ? data.password : "");
        self.admin().name(data.name ? data.name : "");
        self.admin().birthday(data.birthday ? formateDate(data.birthday) : "");
        self.admin().phone(data.phone ? data.phone : "");
        self.admin().mail(data.mail ? data.mail : "");
        self.admin().address(data.address ? data.address : "");
        self.admin().role(data.role ? data.role : 2);
        self.admin().modifiedBy(parseInt($("#modifiedBy").val()));
    }
}

function Admins(){
    var self = this;
    self.adminId = ko.observable();
    self.account = ko.observable("");
    self.password = ko.observable("");
    self.name = ko.observable("");
    self.birthday = ko.observable("");
    self.phone = ko.observable("");
    self.mail = ko.observable("");
    self.address = ko.observable("");
    self.role = ko.observable();
    self.modifiedBy = ko.observable();
}

function formateDate(date) {
    var date = new Date(date);
    return ((date.getMonth() + 1) < 10 ? "0" + (date.getMonth() + 1) : (date.getMonth() + 1))
        + "/" + (date.getDate() < 10 ? "0" + date.getDate() : date.getDate()) + "/" + date.getFullYear();
}

function checkRequired(obj) {
    for (var key in obj) {
        if (obj.hasOwnProperty(key)) {
            if (obj[key] == "") {                
                return false;
            }
        }
    }
    return true;
}