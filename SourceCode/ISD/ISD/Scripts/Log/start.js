var vm = {};
$(function () {
    vm = new ScreenModel();
    InitAction();
    ko.applyBindings(vm);
    vm.start();
});
function InitAction() {
    $("#grid").igGrid({
        width: '1024px',
        height: '550px',
        columns: [
            { headerText: "Type", key: "type", dataType: "string", width: "20%"},
            { headerText: "Content", key: "content", dataType: "string", width: "60%" },
            { headerText: "Date", key: "createdDate", dataType: "date", width: "20%" }
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
                        columnKey: "content",
                        allowFiltering: false
                    }
                ]
            }, 
            {
                name: "Paging",
                pageSize: 10
            }
        ]
    });
}