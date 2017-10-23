var common = (function () {
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
<<<<<<< HEAD
            d.resolve(res);
=======
            d.resolve(res); // thực thiện khi request gửi thành công
>>>>>>> de28096d38dc0ef9dc130eb3083a604841bb6429
        }).fail(function (res) {
            d.reject(res); // thực hiện khi request lỗi
        }).always(function () { 
            $.unblockUI();
        });
        return d.promise();
    };
    return common;
})();