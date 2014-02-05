/// <summary>
/// jQuery Format Plugin
/// author:hongda.yu@jrj.com.cn
///</summary>
(function ($) {
    $.loading = function (params) {
        var settings = $.extend({
            selector: '.progress-bar',
            callback: null
        }, params);

        var loaded = 0,
            number_of_media = $("body img").length;

        if (number_of_media <= 0) {
            animateLoader('100%');
        } else {
            $("img").load(function () {
                loaded++;
                var percentage = (loaded / number_of_media) * 100;
                animateLoader(percentage + '%');
            });
        }

        function animateLoader(width) {

            $(".progress-bar").width(width);

            if (loaded == number_of_media) {
                if (settings.callback) {
                    settings.callback();
                }
            }
        }
    }
})(jQuery);
