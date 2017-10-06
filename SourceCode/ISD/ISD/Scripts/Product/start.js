//
var vm = {};
$(function () {
    vm = new ScreenModel();
    InitAction();
    ko.applyBindings(vm);
    vm.start();
});
function InitAction() {
    $("#grid").igGrid({
        primaryKey: "productId",
        width: '600px',
        height: '700px',
        columns: [
            { headerText: "Id", key: "productId", dataType: "number", width: "15%", hidden: true },
            { headerText: "Category name", key: "categoryName", dataType: "string", width: "25%" },
            { headerText: "Name", key: "name", dataType: "string", width: "25%" },
            { headerText: "Price", key: "price", dataType: "address", width: "25%" }
        ],
        autoCommit: true,
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
                        columnKey: "price",
                        allowFiltering: false
                    }
                ]
            }, {
                name: 'RowSelectors',
                enableCheckBoxes: false,

            },
                {
                    name: 'Selection'
                    , rowSelectionChanging: gridcheckboxStateChanging
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