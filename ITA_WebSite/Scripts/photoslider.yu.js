jQuery.fn.photoslider = function (settings) {
    settings = jQuery.extend({
        currentPagerImg: "images/photoslider_pager_current.jpg",
        pagerImg: "images/photoslider_pager.jpg",
        pagesize: 3,
        delay: 3000,
        speed: 1000,
        auto: true
    }, settings);

    var $this = $(this);
    var scrollTimer;

    //    $(this).find('img[data-src]').each(function () { $(this).attr('src', $(this).attr('data-src')).removeAttr('data-src'); }); //?????????

    $this.find("ul:first").find("li").css({ "float": "left" });
    var pagesize = settings.pagesize;
    var pageCount = $this.find("ul:first").find("li").length % pagesize == 0 ? $this.find("ul:first").find("li").length / pagesize : Math.ceil($this.find("ul:first").find("li").length / pagesize);
    var currentPage = 1;
    var itemWidth = $this.find("ul:first").find("li:first").outerWidth(true);
    $this.find("ul:first").width(itemWidth * $this.find("ul:first").find("li").length + settings.pagesize * 2);
    $this.css({ overflow: "hidden" }).width(itemWidth * pagesize);


    //生成翻页
    if (pageCount > 1) {
        $this.find(".photoslider_pager").empty();
        for (var i = 1; i <= pageCount; i++) {
            if (i == 1) {
                $this.find(".photoslider_pager").append($('<a href="#" class="current" rel="' + i + '"><img src="' + settings.currentPagerImg + '" border="0"/></a>'));
            }
            else {
                $this.find(".photoslider_pager").append($('<a href="#" rel="' + i + '"><img src="' + settings.pagerImg + '" border="0"/></a>'));
            }
        }
        $this.find(".photoslider_pager").children("a").css({ "margin-right": "5px" });
        $this.find(".photoslider_pager").children("a").click(function (e) {
            e.preventDefault();
            if (settings.auto) clearInterval(scrollTimer);
            $this.find(".photoslider_pager").children("a").removeClass("current").children("img").attr({ "src": settings.pagerImg });
            $(this).addClass("current").children("img").attr({ "src": settings.currentPagerImg });
            var clickpager = $(this);
            $this.find("ul:first").animate({ "left": -(itemWidth * pagesize * ($(this).attr("rel") - 1)) + "px" }, 1000, function () {
                currentPage = (clickpager.attr("rel") >= pageCount ? 0 : clickpager.attr("rel"));
                if (settings.auto) {
                    scrollTimer = setInterval(function () {
                        photoslider($this);
                    }, settings.delay);
                }
            });
        });

        if (settings.auto) {
            scrollTimer = setInterval(function () {
                photoslider($this);
            }, settings.delay);
        }
    }
    else {
        $this.find(".photoslider_pager").empty();
    }

    function photoslider(obj) {
        var $self = obj.find("ul:first");
        $self.animate({ "left": -(itemWidth * pagesize * currentPage) + "px" }, settings.speed, function () {
            currentPage++;
            $this.find(".photoslider_pager").children("a").removeClass("current").children("img").attr({ "src": settings.pagerImg });
            $this.find(".photoslider_pager").find('a[rel="' + currentPage + '"]').addClass("current").children("img").attr({ "src": settings.currentPagerImg });
            if (currentPage + 1 > pageCount)
                currentPage = 0;
        });
    }


    return this;
};