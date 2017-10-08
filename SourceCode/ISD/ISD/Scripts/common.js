var common = (function () {
    var common = {};
    common.ajax = function (url, data, type) {// khai bao voi 3 tham so truyen vao
        $.blockUI();//hien message please wait...
        var d = $.Deferred();// sync trong js
        if (!data) data = {};
        if (typeof data === 'object') data = JSON.stringify(data);
        if (!type) type = "post";// type undefine-> post
        $.ajax({// aj chinh
            url: url,
            contentType: 'application/json',
            type: type,
            data: data,
            dataType: 'json'
        }).done(function (res) {
            d.resolve(res); // cua  var d = $.Deferred();
        }).fail(function (res) {
            d.reject(res);
        }).always(function () { 
            $.unblockUI();// tắt  $.blockUI();//hien message please wait... đi
        });
        return d.promise();
    };
    return common;
})();