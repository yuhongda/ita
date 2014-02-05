$(function () {
    var list = $('.list');
    $(window).scroll(function () {
        swingIn();
    });
    var swingIn = function () {
        var _scrollTop = $(document).scrollTop();
        list.each(function () {
            if (!$(this).hasClass('swing-in')) {
                if (($(this).offset().top - $(window).height() +100) < _scrollTop) {
                    $(this).addClass('swing-in');
                }
            }
        });
    };

});