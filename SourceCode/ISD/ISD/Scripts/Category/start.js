var vm = {};
$(function () {
    vm = new ScreenModel();
    InitAction();
    ko.applyBindings(vm);
    vm.start();
});
function InitAction() {
    $("#grid").igGrid({
        primaryKey: "categoryId",
        width: '600px',
        height: '500px',
        columns: [
            { headerText: "", key: "categoryId", dataType: "number", width: "15%", hidden: true },
            { headerText: "Name", key: "name", dataType: "string", width: "25%" },
            { headerText: "Description", key: "description", dataType: "string", width: "65%" }
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
                        columnKey: "description",
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
