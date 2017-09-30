var ScreenModel = function () {
    var self = this;
    self.lstCategories = ko.observableArray([]);
    self.category = ko.observable(new Categories());
    self.canRemove = ko.observable(false);
    self.isCreate = ko.observable(true);
}


ScreenModel.prototype.start = function () {
    var self = this;
    service.getAll().done(function (data) {
        self.lstCategories(data);
        $("#grid").igGrid("option", "dataSource", self.lstCategories());
        self.category().modifiedBy(parseInt($("#modifiedBy").val()));
    });
}

ScreenModel.prototype.getById = function (id) {
    var self = this;
    service.getDataById(id).done(function (data) {
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
    if (self.category().name() != "") {
        var obj = ko.toJSON(self.category());
        if (self.isCreate()) {
            service.checkCtgNameExist(self.category().name()).done(function (data) {
                if(data.status)
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
    } else toastr.error("Name is required!");
}

ScreenModel.prototype.remove = function () {
    var accept = confirm("Are you sure to remov this catogory?");
    var self = this;
    if (accept) {
        var obj = ko.toJSON(self.category());
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
        self.category().categoryId(data.categoryId ? data.categoryId : -1);
        self.category().name(data.name ? data.name : "");
        self.category().description(data.description ? data.description : "");
        self.category().modifiedBy($("#modifiedBy").val());
    }
}

function Categories() {
    var self = this;
    self.categoryId = ko.observable();
    self.name = ko.observable("");
    self.description = ko.observable("");
    self.modifiedBy = ko.observable();
}
