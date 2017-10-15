//
var ScreenModel = function () {
    var self = this;

    self.lstProducts = ko.observableArray([]);
    self.lstCategories = ko.observableArray([]);
    self.lstImages = ko.observableArray([]);
    self.image = ko.observable(new Image()); 
    self.product = ko.observable(new Product());
    self.productBusiness = ko.observable(new ProductBusiness());
    self.canRemove = ko.observable(false);
    self.isCreate = ko.observable(true);
    $("#getImage").click(function () {
        var ckFinder = new CKFinder();
        ckFinder.selectActionFunction = function (url) {
            self.image().link(url);
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

ScreenModel.prototype.createProduct = function () {
    var self = this;
    self.setData({});
    self.isCreate(true);
    self.canRemove(false);
    $("#grid").igGridSelection("selectRow", self.lstProducts().length);
}



ScreenModel.prototype.registerProduct = function () {
    var self = this;
    var obj = ko.toJSON(self.product());
    if (checkRequired(self.product())) {
        if (self.isCreate()) {
            service.createProduct(obj).done(function (data) {
                var productId = parseInt(data);
                if (productId > 0) {
                    
                    self.start();
                    self.product().productId(productId);
                    var index = _.findIndex(self.lstProducts(), function (item) { return parseInt(item.productId) = parseInt(self.product().productId()); });
                    $("#grid").igGridSelection("selectRow", index);
                } else {
                    toastr.error("Add product fail!");
                }
            });
        } else {
            service.updateProduct(obj).done(function (data) {
                if (data.status) {//1. true: thành công 2. false: lỗi
                    toastr.success(data.message);
                    self.start();
                    var index = _.findIndex(self.lstProducts(), function (item) { return parseInt(item.productId) = parseInt(self.product().productId()); });
                    $("#grid").igGridSelection("selectRow", index);
                }
                else toastr.error(data.message);
            });
        }
       
    } else toastr.error("Required fields or nagative number!");
}

ScreenModel.prototype.removeProduct = function () {
    var accept = confirm("Are you sure to remove this account?");
    var self = this;
    var obj = ko.toJSON(self.product());
    if (accept) {
        service.removeProduct(obj).done(function (data) {
            if (data.status) {//1. true: thành công 2. false: lỗi
                toastr.success(data.message);
                self.start();
                var index = _.findIndex(self.lstProducts(), function (item) { return parseInt(item.productId) = parseInt(self.product().productId()); });
                $("#grid").igGridSelection("selectRow", index);
            }
            else toastr.error(data.message);
        });
    }
}

ScreenModel.prototype.createImage = function () {
    var self = this;
    self.image().isCreate(true);
    self.image().setData({});
    self.image().canRemove(false);
}

ScreenModel.prototype.registerImage = function () {
    var self = this;
    if (self.image().link() == "" || !self.image().link()) {
        toastr.error("Please input image!");
    } else {
        var imageObject = {
            imageId: self.image().imageId(),
            name: self.image().name(),
            link: self.image().link()
        };
        if (self.image().isCreate()) {
            //create
            self.lstImages().push(imageObject);
        } else {
            //update
            var index = _.findIndex(self.lstImages(), function (item) { item.imageId = imageObject.imageId; });
            self.lstImages().splice(index, 1, imageObject);
        }
        $("#imageGrid").igGrid("option", "dataSource", self.lstImages());
    }
}

ScreenModel.prototype.removeImage = function () {
    var ok = confirm("Are you sure to remove this image?");
    if (ok) {
        var self = this;
        var imageId = self.image().imageId();
        _.remove(self.lstImages(), function (image) { return image.imageId == imageId; });
        console.log(self.lstImages());
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
        self.product().status().quantity(product.status? product.status.quantity : "");
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
    self.productId = ko.observable("");
    self.categoryId = ko.observable("");
    self.name = ko.observable("");
    self.inPrice = ko.observable("");
    self.outPrice = ko.observable("");
    self.status = ko.observable(new ProductStatus());
    self.description = ko.observable("");
    self.modifiedBy = ko.observable("");
}

function ProductStatus() {
    var self = this;
    self.quantity = ko.observable("");
}

function Image() {
    var self = this;
    self.imageId = ko.observable();
    self.name = ko.observable();
    self.link = ko.observable();
    self.isCreate = ko.observable(true);
    self.canRemove = ko.observable(false);
    
    

    self.getImageById = function (id) {
        service.getImageById(id).done(function (data) {
            self.setData(data);
            self.canRemove(true);
        });
    }

    self.setData = function (data) {
        if (data) {
            self.imageId(data.imageId?data.imageId: -1);
            self.name(data.name?data.name: "");
            self.link(data.link?data.link: "");
        }
    }
}

function ProductBusiness() {
    var self = this;
    self.product = ko.observable(new Product());
    self.image = ko.observableArray([]);
}

function checkRequired(obj) {
    if (obj.categoryId() !="" && obj.name() != "" && obj.inPrice() != "" && obj.outPrice() != "" && obj.status().quantity() != "") {
        if (parseInt(obj.inPrice()) > 0 && parseInt(obj.outPrice()) > 0 && parseInt(obj.status().quantity()) > 0)
            return true;
        else return false;
    }
    else return false;
}