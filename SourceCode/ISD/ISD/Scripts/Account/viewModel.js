var ScreenModel = function () {
    var self = this;
    self.lstAccount = ko.observableArray([]);
    self.subcribeValue = ko.observable();
    self.subcribeValue.subscribe = function (value) {
        alert(value);
    }
     $("#grid").igGrid({
        columns: [
            { headerText: "", key: "adminId", dataType: "number" },
            { headerText: "Name", key: "name", dataType: "string" },
            { headerText: "Account", key: "account", dataType: "string" },
            { headerText: "Email", key: "mail", dataType: "string" }
        ],
        width: "500px",
        primaryKey: 'adminId',
        multiple: true,
        value: self.subcribeValue,
        features: [{
            name: "Hiding",
            columnSettings: [
                { columnKey: "adminId", allowHiding: true, hidden: true }
            ]
        },
        {
            name: "Paging",
            type: "local",
            pageSize: 5
        },
        {
            name: "Filtering"
        }
        ]
    });
}
ScreenModel.prototype.start = function () {
    var self = this;
    service.getAll().done(function (data) {
        self.lstAccount(data);
        $("#grid").igGrid("option", "dataSource", self.lstAccount());
    });
}
