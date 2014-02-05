function encode(input) {
    return $("<div/>").text(input).html();
}

function dncode(input) {
    return $("<div/>").html(input).text();
}


function getPara(paraName) {
    var str = window.location.href;
    if (str.indexOf(paraName) != -1) {
        var pos_start = str.indexOf(paraName) + paraName.length + 1;
        var pos_end = str.indexOf("&", pos_start);
        if (pos_end == -1) {
            return str.substring(pos_start);
        }
        else {
            return str.substring(pos_start, pos_end)
        }
    }
    else {
        return '';
    }
}


$(function () {
    // go top
    var gotop = $(".gotop"),
        windowHeight = $(window).height(),
        isShow = false,
        isAnimating = false;
    $(window).scroll(function () {
        if (!isAnimating) {
            if ($(document).scrollTop() > 300 && !isShow) {
                gotop.animate({ bottom: '45%', opacity: 1 }, 1000, function () {
                    $(this).addClass('gotopshow');
                    isShow = true;
                });
            }
            else if ($(document).scrollTop() == 0 && isShow) {
                gotop.removeClass('gotopshow');
                gotop.delay(1000).animate({ bottom: '150%' }, 1000, function () {
                    $(this).css({ bottom: '-100px', opacity: 0 });
                    $(this).css({ 'background-position': '0 0' });
                    isShow = false;
                });
            }
        }
    });
    gotop.mouseenter(function () {
        $(this).css({ 'background-position': '-128px 0' });
    }).mouseleave(function () {
        $(this).css({ 'background-position': '0 0' });
    });

    gotop.click(function (e) {
        e.preventDefault();
        isAnimating = true;
        $(this).addClass('gotop_sprite');
        $(this).sprite({ fps: 8, no_of_frames: 4 });

        var _this = this,
            op = $.browser.opera ? $("html") : $("html, body");

        op.animate({ scrollTop: 0 }, 500, function () {
            $(_this).removeClass('gotopshow');
            $(_this).delay(1000).animate({ bottom: '150%' }, 1000, function () {
                $(this).css({ bottom: '-100px', opacity: 0 });
                gotop.destroy();
                $(this).removeClass('gotop_sprite');
                $(this).css({ 'background-position': '0 0' });
                isShow = false;
                isAnimating = false;
            });
        });
    });
});