jQuery.fn.photoslider2 = function (settings) {
    settings = jQuery.extend({
        delay: 3000,
        speed: 1000,
        auto: true,
        btnNext: ".next",
        btnPrev: ".prev"
    }, settings);

    var $this = $(this),
        count = $this.find("ul li").length,
        current = 0,
        _timer = null,
        isAnimating = false;

    $this.find(settings.btnNext).click(function () {

    });

    $this.mouseenter(function () {
        clearInterval(_timer);
        $this.find(settings.btnNext).fadeIn();
        $this.find(settings.btnPrev).fadeIn();
    }).mouseleave(function () {
        setTimer();
        $this.find(settings.btnNext).fadeOut();
        $this.find(settings.btnPrev).fadeOut();
    });

    $this.find(settings.btnNext).click(function () {
        if (!isAnimating) {
            if (++current >= count) {
                current = 0;
            }
            photoslider(current);
        }
    });
    $this.find(settings.btnPrev).click(function () {
        if (!isAnimating) {
            if (--current < 0) {
                current = count - 1;
            }
            photoslider(current);
        }
    });

    if (settings.auto) {
        setTimer();
    }

    function setTimer() {
        _timer = setInterval(function () {
            photoslider(current);
            if (++current >= count) {
                current = 0;
            }

        }, settings.delay);
    }

    (function init() {
        $this.find("ul li").animate({ opacity: 0 }, 0, function () {
            $($this.find("ul li").get(0)).stop().animate({ opacity: 1 }, 0);
        });
        $this.find(settings.btnNext).hide();
        $this.find(settings.btnPrev).hide();
    })();

    function photoslider(cur) {
        isAnimating = true;
        $this.find("ul li").animate({ opacity: 0 }, settings.speed);
        $($this.find("ul li").get(cur)).stop().animate({ opacity: 1 }, settings.speed, function () {
            isAnimating = false;
        });
    }


    return this;
};