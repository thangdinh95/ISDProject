$(function () {
    var screenModel = new ScreenModel();
<<<<<<< HEAD
    ko.applyBindings(screenModel);
    $(window).keyup(function (e) {
=======
    ko.applyBindings(screenModel);///khai báo đối tượng binding trong knockout js
    $(window).keyup(function (e) {//cho phep người dùng sử dụng phim enter thay vì click chuột vào nut login
>>>>>>> de28096d38dc0ef9dc130eb3083a604841bb6429
        if (e.which == 13) {
            screenModel.login();
        }
    });
});

