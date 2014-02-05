<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/curvycorners.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/jquery.parallax.min.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/jquery.watermark.min.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/jquery.blink.min.js") %>"></script>
    <script type="text/javascript">
        $(function () {

            //teammate animation
            var animations = {
                animation1: function () {
                    var pos = { x1: 50, x2: 235, x3: 420, x4: 605, x5: 790 };
                    $(".tm1").show().animate({ left: pos.x1 + "px", opacity: 1 }, 500, function () { $(".tm2").show(); });
                    $(".tm2").delay(250).animate({ left: pos.x2 + "px", opacity: 1 }, 500, function () { $(".tm3").show(); });
                    $(".tm3").delay(500).animate({ left: pos.x3 + "px", opacity: 1 }, 500, function () { $(".tm4").show(); });
                    $(".tm4").delay(750).animate({ left: pos.x4 + "px", opacity: 1 }, 500, function () { $(".you").show(); });
                    $(".you").delay(2000).animate({ left: pos.x5 + "px", opacity: 1 }, 1000, function () {
                        $(this).find('span').fadeIn('slow');
                    });
                }
            };

            // team遮罩
            var masklayers = $(".mask_layer");
            masklayers.mouseenter(function () {
                masklayers.removeClass("hover").addClass("masked");
                $(this).removeClass("masked").addClass("hover");
            }).mouseleave(function () {
                masklayers.removeClass("hover").addClass("masked");
            });
            $(".mask_block").mouseleave(function () { masklayers.removeClass("masked").addClass("hover"); });


            $(window).scroll(function () {
                //teammate动画
//                if ($(window).scrollTop() >= $(".teammates").offset().top - $(window).height()) {
//                    animations.animation1();
//                }
            });

            jQuery('.parallax').parallax({ mouseport: jQuery('.animate2') });

            $(".info_types a.checkbox").click(function () {
                $(this).toggleClass("checked");
            });

            $("#txtName").watermark("您的姓名");
            $("#txtCompany").watermark("公司名称");
            $("#txtEmail").watermark("您的邮箱地址");
            $("#txtPhone").watermark("您的联系电话");
            $("#txtWebsite").watermark("贵公司网站地址");
            $("#txtDesc").watermark("详细需求描述：项目类型、时间安排、数量、软件平台、分辨率等");


            //发送邮件
            $("#btnsend").click(function () {

                if (formvalidate()) {
                    //loaging...
                    var loading = $('<img alt="loading..." src="<%=ResolveUrl("~/images/loading.gif") %>" />'),
                        _this = $(this);
                    $(this).hide().parent().append(loading);


                    var mailArray = [];
                    var checkeditems = [];

                    mailArray.push({ "name": $("#txtName").val(), "company": $("#txtCompany").val(), "email": $("#txtEmail").val(), "phone": $("#txtPhone").val(), "website": $("#txtWebsite").val(), "desc": encode($("#txtDesc").val().replace(new RegExp("\n", "g"), "<br/>")) });

                    var mail = JSON.stringify(mailArray[0]);
                    var request = $.ajax({
                        url: '<%=ResolveUrl("~/handlers/MailHandler.ashx") %>',
                        type: "POST",
                        data: { maildata: mail },
                        dataType: "json"
                    });

                    request.done(function (msg) {
                        if (msg.Status.toLowerCase() == "true") {
                            loading.remove();
                            $("<span>发送成功，我们会及时与您联系。</span>").appendTo(_this.parent());
                        }
                        else {
                            loading.remove();
                            $("<span>发送失败，请重试。</span>").appendTo(_this.parent()).delay(2000).fadeOut(function () {
                                _this.fadeIn();
                            });
                        }
                    });

                    request.fail(function (jqXHR, textStatus) {
                        loading.remove();
                        $("<span style=\"color:red;\">发送失败，请重试。</span>").appendTo($("#btnsend_wrapper")).fadeOut(100).fadeIn(100).delay(2000).fadeOut(function () {
                            $("#btnsend_wrapper #btnsend").fadeIn();
                        });
                    });
                }
            });

            function formvalidate() {
                var result = true;
                $(".required").each(function () {
                    if ($.trim($(this).val()) == "") {
                        var errmask = $(this).next();
                        errmask.fadeIn('fast').blink({
                            speed: 150,
                            callback: function () {
                                errmask.fadeOut('fast');
                            }
                        });
                        result = false;
                    }
                });

                return result;
            }

            $('#begin').click(function () {
            });
            function flicker() {
                $('#text').fadeOut(500).fadeIn(500);
            }


            addEvent(window, 'load', initCorners);

            function initCorners() {
                var tag_settings = {
                    tl: { radius: 10 },
                    tr: { radius: 10 },
                    bl: { radius: 10 },
                    br: { radius: 10 },
                    antiAlias: true
                };

                curvyCorners(tag_settings, ".contactus");

            }

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="wrapper">
        <div class="ita_banner_wrap">
            <div class="banner tc"><img src="images/contact_1.jpg" /></div>
            <p class="slogan2">ITA自成立以来长期专注于用户使用方式、视觉感受和习惯性思维的用户体验，专注于产品对系统性能细微改变和未来升级预期的性能体验，专注于产品适应市场环境带来不可预知因素的环境体验，是中国最专业的用户体验交互设计团队之一。</p>
        </div>
    </div>
    <div class="wrapper">
        <div class="teammates">
            <div class="title">ITA TEAM</div>
            <div class="mask_block" style="width:902px; height:332px;">
                <a class="mask_item" style="top:0px;left:0px;">
                    <span class="mask_layer" style="width:324px;height:332px;"></span>
                </a>
                <a class="mask_item" style="top:0px;left:324px;">
                    <span class="mask_layer" style="width:146px;height:332px;"></span>
                </a>
                <a class="mask_item" style="top:0px;left:469px;">
                    <span class="mask_layer" style="width:144px;height:167px;"></span>
                </a>
                <a class="mask_item" style="top:167px;left:469px;">
                    <span class="mask_layer" style="width:144px;height:165px;"></span>
                </a>
                <a class="mask_item" style="top:0px;left:613px;">
                    <span class="mask_layer" style="width:145px;height:332px;"></span>
                </a>
                <a class="mask_item" style="top:0px;left:759px;">
                    <span class="mask_layer" style="width:143px;height:332px;"></span>
                </a>
            </div>
            <%--<ul>
                <li class="teammate tm1"></li>
                <li class="teammate tm2"></li>
                <li class="teammate tm3"></li>
                <li class="teammate tm4"></li>
                <li class="teammate you"><span>YOU</span></li>
            </ul>--%>
        </div>
    </div>
    <div class="wrapper">
        <div class="split"></div>
    </div>
    <div class="wrapper" style="padding:20px 0;">
        <p class="slogan tc">ITA将自身定位于企业的合作伙伴，而非简单的执行公司，<br />
因此我们致力于通过独具特色的策划、严格的流程把控、透彻的行业分析、丰富的设<br />
计经验，切实帮助客户提升品牌知名度、推进实际业务增长和长期利益共赢。</p>
    </div>
    <div class="animate2 wrapper">
        <div class="parallax parallax1"><div class="ball b1"></div></div>
        <div class="parallax parallax2"><div class="ball b2"></div></div>
        <div class="parallax parallax3"><div class="ball b3"></div></div>
    </div>
    <div class="wrapper">
    <div class="contactus_wrap">
        <div class="contactus">
            <div class="title">联系我们</div>
            <div class="padding20 clearfix">
                <div id="info_l">
                    <div class="input_wrapper" style="width: 350px;height:25px;line-height:25px;">
                        <input id="txtName" type="text" style="width: 340px;line-height:25px;" class="required" title="您的姓名" />
                        <div class="errmask"></div>
                    </div>
                    <div class="input_wrapper" style="width: 350px;height:25px;line-height:25px;">
                        <input id="txtCompany" type="text" style="width: 340px;line-height:25px;" class="required" title="公司名称" />
                        <div class="errmask"></div>
                    </div>
                    <div class="input_wrapper" style="width: 350px;height:25px;line-height:25px;">
                        <input id="txtEmail" type="text" style="width: 340px;line-height:25px;" class="required" title="您的邮箱地址" />
                        <div class="errmask"></div>
                    </div>
                    <div class="input_wrapper" style="width: 350px;height:25px;line-height:25px;">
                        <input id="txtPhone" type="text" style="width: 340px;line-height:25px;" class="required" title="您的联系电话" />
                        <div class="errmask"></div>
                    </div>
                    <div class="input_wrapper" style="width: 350px;height:25px;line-height:25px;">
                        <input id="txtWebsite" type="text" style="width: 340px;line-height:25px;" class="required" title="贵公司网站地址" />
                        <div class="errmask"></div>
                    </div>
                </div>
                <div id="info_r">
                    <textarea id="txtDesc" style="width: 540px; height:180px;" class="required" title="详细需求描述"></textarea>
                    <div class="errmask"></div>
                </div>
                <div class="tc" style="clear:both;"><a id="btnsend" class="btnsend"></a></div>
            </div>
        </div>
    </div>
    </div>
    <div class="wrapper">
        <div class="layer6_wrap">
            <div class="layer6 clearfix">
                <img src="images/map.jpg" />
            </div>
        </div>
    </div>
        <%--<div class="address_wrap">
            <span>地址：北京市朝阳区望京阜通东大街6号方恒国际中心D座1912室</span>
            <span>商务合作：service@itadesign.cn</span>
            <span>电话：010-84783909</span>
        </div>--%>

    
    <div class="clear"></div>
</asp:Content>

