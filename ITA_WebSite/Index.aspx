<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="<%=ResolveUrl("~/css/ui-lightness/jquery-ui-1.8.18.custom.css") %>" type="text/css" />
    <style>
        body{background:#000 url(images/bg.png) repeat;}
    </style>
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/jquery-ui-1.8.18.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/jquery.ulslide.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/photoslider2.yu.js") %>"></script>
    <script type="text/javascript">
        $(function () {


            //$(".pngfixer").pngfixer({ shim: 'images/blank.gif' });

            $('#photo_slider').photoslider2().find('.prev,.next').mouseenter(function () {
                $(this).addClass('cur');
            }).mouseleave(function () {
                $(this).removeClass('cur');
            });

            var info = $('#info'),
                _index = 2;
            setInterval(function () {
                info.fadeOut(500, function () {
                    info.attr({ src: 'images/' + _index + '.png' }).fadeIn();
                });
                if (++_index > 3) {
                    _index = 1;
                }
            }, 3000);
        });

        $(window).load(function () {
            
        });

        window.onload = function () {

        };
        window.onunload = function () { };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="wrapper">
        <div class="layer1">
            <div id="photo_slider">
                <ul>
                    <li>
                        <a href="http://www.itadesign.cn/case/11">
                            <img alt="letv" src="images/index_1.jpg" border="0" />
                        </a>
                    </li>
                    <li>
                        <a href="http://www.itadesign.cn/case/10">
                            <img alt="丰田" src="images/index_1_2.jpg" border="0" />
                        </a>
                    </li>
                </ul>
                <a class="prev"></a>
                <a class="next"></a>
            </div>
        </div>
        <%--<div class="layer2 clearfix">
            <div class="picblock">
                <a><img src="images/index_2.jpg" /></a>
                <p class="title">Disney X31 pooh手机</p>
                <p>2011年为迪斯尼概念手机设计卡通风格的手机系统应用，将迪斯尼的各种卡通形象融合在手机的操作系统界面和⋯⋯</p>
            </div>
            <div class="picblock right">
                <a><img src="images/index_3.jpg" /></a>
                <p class="title">Disney X31 pooh手机</p>
                <p>2011年为迪斯尼概念手机设计卡通风格的手机系统应用，将迪斯尼的各种卡通形象融合在手机的操作系统界面和⋯⋯</p>
            </div>
        </div>--%>
        <div class="layer3 clearfix">
            <div class="picblock">
                <a href="http://www.itadesign.cn/case/9"><img src="images/index_4.jpg" /></a>
                <p class="title">Disney X31 pooh手机</p>
                <p>2011年为迪斯尼概念手机设计卡通风格的手机系统应用，将迪斯尼的各种卡通形象融合在手机的操作系统界面和⋯⋯</p>
            </div>
            <div class="picblock">
                <a href="http://www.itadesign.cn/case/42"><img src="images/index_5.jpg" /></a>
                <p class="title">丰田智能车载导航系统-Space</p>
                <p>2012年，我们以太空元素为主导，为丰田设计了极具现代科技感的产品解决方案。</p>
            </div>
            <div class="picblock last">
                <a href="http://www.itadesign.cn/case/11"><img src="images/index_6.jpg" /></a>
                <p class="title">letv 1.0 桌面系统</p>
                <p>2012年，我们结合乐视TV产品的特点和遥控器的控制方式，设计了专门适用于机顶盒用户</p>
            </div>
        </div>
        <%--<div class="tc">
            <a href="<%=ResolveUrl("~/case") %>" class="more">更多平台案例</a>
        </div>--%>
    </div>
    <%--<div class="layer4_wrap">
        <div class="wrapper">
            <div class="bg"></div>
            <div class="layer4 clearfix">
                <div class="intro">
                    <div class="icon icon1"></div>
                    <div class="text">
                        <p class="title">设计咨询</p>
                        <p>为您的产品提供专业的需求分析和产品原型策划，并结合市场需求定制产品研发方向和未来运营模式。</p>
                    </div>
                </div>
                <div class="intro">
                    <div class="icon icon2"></div>
                    <div class="text">
                        <p class="title">交互设计</p>
                        <p>为您的产品提供专业的需求分析和产品原型策划，并结合市场需求定制产品研发方向和未来运营模式。</p>
                    </div>
                </div>
                <div class="intro">
                    <div class="icon icon3"></div>
                    <div class="text">
                        <p class="title">视觉设计</p>
                        <p>为您的产品提供专业的需求分析和产品原型策划，并结合市场需求定制产品研发方向和未来运营模式。</p>
                    </div>
                </div>
                <div class="tc">
                    <a href="<%=ResolveUrl("~/services") %>" class="more2">更多服务内容</a>
                </div>
            </div>
        </div>
    </div>--%>
    <div class="wrapper">
        <div class="layer4_wrap">
            <div class="bg"></div>
            <div class="layer4 clearfix tc">
                <img src="images/1.png" id="info" />
            </div>
        </div>
    </div>
    <div class="layer5_wrap">
        <div class="wrapper">
            <div class="layer5 clearfix">
                <img src="images/index_7.jpg" />
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
</asp:Content>

