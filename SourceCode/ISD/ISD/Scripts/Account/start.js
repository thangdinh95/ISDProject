var vm = {};
$(function () {
    vm = new ScreenModel();
    InitAction();
    ko.applyBindings(vm);
    vm.start();
});
function InitAction() {
    $('#birthday').datepicker({
        changeYear: true,
        changeMonth: true,
        yearRange: '1930:2016'
    });

    //vẽ bảng hiện thị thông tin danh sách các tài khoản
    $("#grid").igGrid({
        primaryKey: "adminId",//dữ liệu được lấy khi mà click vào 1 dòng trong bảng
        width: '600px',
        height: '500px',
        columns: [
            { headerText: "Admin Id", key: "adminId", dataType: "number", width: "15%", hidden: true },
            { headerText: "Name", key: "name", dataType: "string", width: "25%" },
            { headerText: "Account", key: "account", dataType: "string", width: "25%" },       
            { headerText: "Address", key: "address", dataType: "address", width: "35%" }
        ],
        features: [
            {
                name: "Sorting",
                sortingDialogContainment: "window"
            },
            {
                name: "Filtering",
                type: "local",
                columnSettings: [
                    {
                        columnKey: "mail",
                        allowFiltering: false
                    }
                ]
            }, {
                name: 'RowSelectors',
                enableCheckBoxes: false,
               
            },
                {
                    name: 'Selection'
                     // sư kiện khi lựa chọn 1 dòng trong bảng
                    ,rowSelectionChanging: gridcheckboxStateChanging
                },
            {
                name: "Paging",
                pageSize: 10
            }
        ]
    });
}
function gridcheckboxStateChanging(evt, ui) {
    var id = ui.row.id;
    vm.getById(id);
};
