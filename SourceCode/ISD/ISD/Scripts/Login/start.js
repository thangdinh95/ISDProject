$(function () {
    var screenModel = new ScreenModel();
    ko.applyBindings(screenModel);///khai báo đối tượng binding trong knockout js
    $(window).keyup(function (e) {
        if (e.which == 13) {
            screenModel.login();
        }
    });
});

