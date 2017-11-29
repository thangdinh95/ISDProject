$(function () {
    new WOW().init();

	$(window).scroll(function () {
                if ($(window).scrollTop() == 0) {
                    $('#top').stop(false, true).fadeOut(600);
                } else {
                    $('#top').stop(false, true).fadeIn(600);
                }

                if ($(window).scrollTop() >= 450) {
                	$('nav').addClass('menuchange');
                } else {
                	$('nav').removeClass('menuchange');
                }
            });


	$('#top').click(function() {
		event.preventDefault();
		var body = $("html, body");
		body.stop().animate({ scrollTop: 0 }, 2000, 'easeOutSine');
	});

	if ($('body').scrollTop() == 0) {
		$('#top').css("display", "none");
	} else {
	    console.log($('body').scrollTop());
		$('#top').css("display", "block");
	}

    var bookday = " ";
    for(var i = 1; i < 32; i++){
        bookday += "<option value='" + i + "'>" + i + "</option>";
    };
    $('.book-day').html(bookday);

    var bookmonth = " ";
    for(var i = 1; i < 13; i++){
        bookmonth += "<option value='" + i + "'>" + i + "</option>";
    };
    $('.book-month').html(bookmonth);

    var bookHour = " ";
    for(var i = 1; i < 25; i++){
        bookHour += "<option value='" + i + "'>" + i + "</option>";
    };
    $('.book-hour').html(bookHour);

    var bookMinute = " ";
    for(var i = 0; i < 61; i++){
        bookMinute += "<option value='" + i + "'>" + i + "</option>";
    };
    $('.book-minute').html(bookMinute);


    var today = new Date();
        var day = today.getDate();
        var month = today.getMonth();
        var hour = today.getHours();
        var minute = today.getMinutes();
    $('.book-day option[value=' + day + ']').prop('selected',true);
    $('.book-month option[value=' + (month+1) + ']').prop('selected', true);
    $('.book-hour option[value=' + hour + ']').prop('selected', true);
    $('.book-minute option[value=' + minute + ']').prop('selected', true);

});
