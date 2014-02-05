jQuery.fn.gallery = function (settings) {
    settings = jQuery.extend({

}, settings);

var switchitems = this.children(".switch_item");
var desc = this.children("a.pic_title");
var title = this.children(".subtitle").children("span");
desc.text(switchitems.filter(".current").children("img").attr("alt"));
title.text(switchitems.filter(".current").children("img").attr("title"));
switchitems.click(function (e) {
    if ($(this).hasClass("current")) {
        //do something here...(maybe popup the picture)
    }
    else {
        e.preventDefault();
        var current_a_settings = { top: switchitems.filter(".current").css("top"), left: switchitems.filter(".current").css("left") };
        var current_img_settings = { width: 444, height: 180 };
        var this_a_settings = { top: $(this).css("top"), left: $(this).css("left") };
        var this_img_settings = { width: 120, height: 49 };

        switchitems.filter(".current").animate(this_a_settings, 500, function () {
            switchitems.filter(".current").children("img").animate(this_img_settings, 300, function () { });
            switchitems.filter(".current").removeClass("current");
        });
        $(this).animate(current_a_settings, 500, function () {
            $(this).children("img").animate(current_img_settings, 300, function () { });
            $(this).addClass("current");
            var clicked_obj = $(this);
            desc.fadeOut("slow", function () { desc.text(clicked_obj.children("img").attr("alt")).fadeIn(); });
            title.fadeOut("slow", function () { title.text(clicked_obj.children("img").attr("title")).fadeIn(); });
        });
    }
});

return this;
};