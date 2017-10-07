//
var ScreenModel = function () {
    var self = this;

    self.lstProducts = ko.observableArray([]);
    self.lstCategories = ko.observableArray([]);
    self.lstImages = ko.observable();
    self.image = ko.observable(new Image());
    
    self.product = ko.observable(new Product());
    self.productBusiness = ko.observable(new ProductBusiness());
    self.canRemove = ko.observable(false);
    self.isCreate = ko.observable(true);
    $("#getImage").click(function () {
        var ckFinder = new CKFinder();
        ckFinder.selectActionFunction = function (url) {
            self.image().link(url);
            var arr = _.map(self.lstImages(), function (item) {
                if (item.imageId == self.image().imageId())
                    item.link = self.image().link();
                return item;
            });
            self.lstImages([]);
            self.lstImages(arr);
            $("#imageGrid").igGrid("option", "dataSource", self.lstImages());
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

ScreenModel.prototype.getProductById = function (id) {
    var self = this;
    service.getProductById(id).done(function (data) {
        self.setData(data.product, data.lstImages);
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
    console.log(self.lstImages());
}

ScreenModel.prototype.remove = function () {
    var accept = confirm("Are you sure to remove this account?");
    var self = this;
    if (accept) {
    }
}

ScreenModel.prototype.setData = function (product, lstImages) {
    var self = this;
    if (product) {
        self.product().productId(product.productId ? product.productId : -1);
        self.product().categoryId(product.categoryId ? product.categoryId : -1);
        self.product().name(product.name ? product.name : "");
        self.product().inPrice(product.inPrice ? product.inPrice : "");
        self.product().outPrice(product.outPrice ? product.outPrice : "");
        self.product().status().quantity(product.status.quantity ? product.status.quantity : null);
        self.product().description(product.description ? product.description : "");
        self.product().modifiedBy(parseInt($("#modifiedBy").val()));
    }
    if (lstImages) {
        self.lstImages(lstImages);
        $("#imageGrid").igGrid("option", "dataSource", self.lstImages());
    }
}

function Product() {
    var self = this;
    self.productId = ko.observable();
    self.categoryId = ko.observable();
    self.name = ko.observable();
    self.inPrice = ko.observable();
    self.outPrice = ko.observable();
    self.status = ko.observable(new ProductStatus());
    self.description = ko.observable();
    self.modifiedBy = ko.observable();
}

function ProductStatus() {
    var self = this;
    self.quantity = ko.observable();
}

function Image() {
    var self = this;
    self.imageId = ko.observable();
    self.productId = ko.observable();
    self.name = ko.observable();
    self.link = ko.observable();
    self.priority = ko.observable();
    self.getImageById = function (id) {
        service.getImageById(id).done(function (data) {
            self.setData(data);
        });
    }
    self.setData = function (data) {
        if (data) {
            self.imageId(data.imageId?data.imageId: -1);
            self.name(data.name?data.name: "");
            self.link(data.link?data.link: "");
            self.priority(data.priority?data.priority: 0);
        }
    }
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