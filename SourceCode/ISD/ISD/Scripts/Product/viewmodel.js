//
var ScreenModel = function () {
    var self = this;

    self.lstProducts = ko.observableArray([]);
    self.lstCategories = ko.observableArray([]);
    self.categoryId = ko.observable();
    self.product = ko.observable(new Product());
    self.productBusiness = ko.observable(new ProductBusiness());
    self.canRemove = ko.observable(false);
    self.isCreate = ko.observable(true);
    self.link = ko.observable("");
    $("#getImage").click(function () {
        var ckFinder = new CKFinder();
        ckFinder.selectActionFunction = function (url) {
            self.link(url);
        }
        ckFinder.popup();
    });
   
}


ScreenModel.prototype.start = function () {
    var self = this;
    service.getAllProducts().done(function (data) {
        self.lstProducts(data);
        $("#grid").igGrid("option", "dataSource", self.lstProducts());
        self.product().modifiedBy(parseInt($("#modifiedBy").val()));
    });
    service.getAllCategory().done(function (data) {
        self.lstCategories(data);
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
    console.log(self.categoryId());
}

ScreenModel.prototype.remove = function () {
    var accept = confirm("Are you sure to remove this account?");
    var self = this;
    if (accept) {
    }
}

ScreenModel.prototype.setData = function (data) {
    if (data) {
        var self = this;
        self.product().productId(data.productId ? data.productId : -1);
        self.product().categoryId(data.categoryId ? data.categoryId : -1);
        self.product().name(data.name ? data.name : "");
        self.product().price(data.price ? data.price : "");
        self.product().status(data.status ? data.start : null);
        self.product().description(data.description ? data.description : "");
        self.product().modifiedBy(parseInt($("#modifiedBy").val()));
    }
}

function Product() {
    var self = this;
    self.productId = ko.observable();
    self.categoryId = ko.observable();
    self.name = ko.observable();
    self.price = ko.observable();
    self.status = ko.observable();
    self.description = ko.observable();
    self.modifiedBy = ko.observable();
}
function Image() {
    var self = this;
    self.imageId = ko.observable();
    self.productId = ko.observable();
    self.name = ko.observable();
    self.link = ko.observable();
    self.priority = ko.observable();
}

function ProductBusiness() {
    var self = this;
    self.product = ko.observable(new Product());
    self.image = ko.observableArray([]);
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