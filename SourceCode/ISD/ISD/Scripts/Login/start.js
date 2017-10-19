$(function () {
    var screenModel = new ScreenModel();
    ko.applyBindings(screenModel);///khai báo đối tượng binding trong knockout js
    $(window).keyup(function (e) {//cho phep người dùng sử dụng phim enter thay vì click chuột vào nut login
        if (e.which == 13) {
            screenModel.login();
        }
    });
});

