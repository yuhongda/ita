<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/curvycorners.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/jwplayer/jwplayer.js") %>"></script>
    <script type="text/javascript">
    $(function () {

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


    addEvent(window, 'load', initCorners);

    function initCorners() {
        var tag_settings = {
            tl: { radius: 10 },
            tr: { radius: 10 },
            bl: { radius: 10 },
            br: { radius: 10 },
            antiAlias: true
        };

        curvyCorners(tag_settings, ".intro2_wrap");

    }
        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="wrapper" style="padding:20px 0;">
        <div class="video_wrapper">
            <div id="mediaplayer"></div>
        </div>
        <p class="slogan tc">ITA是国内领先的产品设计解决方案提供商,拥有一批适应本土需求的顶尖品牌策划团队，<br />
    众多精英组成的专家视觉设计团队，为企业定制真正具有实效的产品设计解决方案。</p>
        <p class="tc"><img src="images/service_1.jpg" /></p>
    </div>
    <div class="wrapper">
        <div class="layer4_wrap">
            <div class="bg"></div>
            <div class="layer4 clearfix tc">
                <img src="images/1.png" id="info" />
            </div>
        </div>
    </div>
    <div class="layer5_wrap" >
        <div class="wrapper" style="border-bottom:1px solid #ebeae8;">
            <div class="layer5 clearfix tc">
                <img src="images/index_8.jpg" />
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

    <script type="text/javascript">
        jwplayer("mediaplayer").setup({
            flashplayer: '<%=ResolveUrl("~/Scripts/jwplayer/player.swf") %>',
            file: '<%=ResolveUrl("~/UploadFiles/Video/ita.flv") %>',
            image: '<%=ResolveUrl("~/UploadFiles/Video/preview.jpg") %>',
            width: '766',
		    height: '432'
        });
    </script>
</asp:Content>

