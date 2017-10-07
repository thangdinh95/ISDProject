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
            { headerText: "In price (VND)", key: "inPrice", dataType: "number", width: "25%" },
            { headerText: "Out price (VND)", key: "outPrice", dataType: "number", width: "25%" }
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
    $("#imageGrid").igGrid({
        primaryKey: "imageId",
        width: '230px',
        height: '265px',
        columns: [
            { headerText: "Id", key: "imageId", dataType: "number", width: "15%", hidden: true },
            { headerText: "Image", key: "link", dataType: "string", width: "35%", formatter: imageShow },
            { headerText: "Name", key: "name", dataType: "string", width: "55%" }
        ],
        features: [
            {
                name: 'RowSelectors',
                enableCheckBoxes: false,

            },
                {
                    name: 'Selection'
                    , rowSelectionChanging: imageSelection
                }
        ]
    });
}
function gridcheckboxStateChanging(evt, ui) {
    var id = ui.row.id;
    vm.getProductById(id);
};

function imageSelection(evt, ui) {
    var id = ui.row.id;
    vm.image().getImageById(id);
};

function imageShow(item) {
    return "<img src='" + item + "' width='35' height='35'/> ";
}