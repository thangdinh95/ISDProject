
var ScreenModel = function () {
    var self = this;
    self.lstLogs = ko.observableArray([]);// ko là từ khóa trong knockout
}


ScreenModel.prototype.start = function () {// goij đến đối tượng cha
    var self = this;
    service.getAll()// send request
        .done(function (data) {// receive response

        var lst = _.map(data, function (item) //chuyển [a, b, c, d] -> [1, 2, 3, 4]//  lodash -> thư viện xử lý array
        {
            var type = item.type, returnType = "";
            if (type == 1) returnType = "LOGIN";// gán lại giá trị theo dạng string
            else if (type == 2) returnType = "CREATE";
            else if (type == 3) returnType = "UPDATE";
            else if (type == 4) returnType = "REMOVE";
            else if (type == 5) returnType = "PRINT";
            else if (type == 6) returnType = "OTHER";
            return { type: returnType, content: item.content, createdDate: item.createdDate };
        });
       
        self.lstLogs(lst);// fill data to list
        //fill data to table
        $("#grid").igGrid("option", "dataSource", self.lstLogs());//thư viện xử lý bảng trong js
    });
}


