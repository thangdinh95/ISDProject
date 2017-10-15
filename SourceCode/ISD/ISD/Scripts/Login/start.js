$(function () {
    var screenModel = new ScreenModel();
    ko.applyBindings(screenModel);
    $(window).keyup(function (e) {
        if (e.which == 13) {
            screenModel.login();
        }
    });
});

