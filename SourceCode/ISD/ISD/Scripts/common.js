﻿var common = (function () {
    var common = {};
    common.ajax = function (url, data, type) {
        $.blockUI();
        var d = $.Deferred();
        if (!data) data = {};
        if (typeof data === 'object') data = JSON.stringify(data);
        if (!type) type = "post";
        $.ajax({
            url: url,
            contentType: 'application/json',
            type: type,
            data: data,
            dataType: 'json'
        }).done(function (res) {
            d.resolve(res);
        }).fail(function (res) {
            d.reject(res);
        }).always(function () {
            $.unblockUI();
        });
        return d.promise();
    };
    return common;
})();