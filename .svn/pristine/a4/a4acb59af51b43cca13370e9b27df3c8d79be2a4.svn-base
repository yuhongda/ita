<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/gallery.yu.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/photoslider.yu.js") %>"></script>
    <script type="text/javascript">
        $(function () {


            // banner遮罩
            var masklayers = $(".mask_layer");
            masklayers.mouseenter(function () {
                masklayers.removeClass("hover").addClass("masked");
                $(this).removeClass("masked").addClass("hover");
            }).mouseleave(function () {
                masklayers.removeClass("hover").addClass("masked");
            });
            $("#banner").mouseleave(function () { masklayers.removeClass("masked").addClass("hover"); });


            // gallery图片切换
            $("#gallery1").gallery();
            $("#gallery2").gallery();
            $("#gallery3").gallery();
            $("#gallery4").gallery();



            //联系方式 - 样式调节
            $(".contact_l").each(function () {
                var h = $(this).parent().height() - 20;
                $(this).height(h)
                    .css({ "line-height": h + "px" });
                var h2 = $(this).next().children(".contact_text_wrap").height();
                $(this).next().children(".contact_text_wrap").css({ "margin-top": ($(this).parent().height() - h2) / 2 - 10 });
            });


            //$(".pngfixer").pngfixer({ shim: 'images/blank.gif' });
        });

        $(window).load(function () {
            // photo slider
            $("#photo_slider").photoslider();
        });

        window.onload = function () {

        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="banner" class="mask_block">
        <asp:HyperLink ID="hlinkBanner1" runat="server" CssClass="mask_item" style="top:0px;left:0px;">
            <asp:Image ID="imgBanner1" runat="server" Width="650" Height="308" BorderWidth="0" />
            <div class="mask_layer" style="width:650px;height:308px;"></div>
        </asp:HyperLink>
        <asp:HyperLink ID="hlinkBanner2" runat="server" CssClass="mask_item" style="top:0px;left:650px;">
            <asp:Image ID="imgBanner2" runat="server" Width="250" Height="154" BorderWidth="0" />
            <div class="mask_layer" style="width:250px;height:154px;"></div>
        </asp:HyperLink>
        <asp:HyperLink ID="hlinkBanner3" runat="server" CssClass="mask_item" style="top:154px;left:650px;">
            <asp:Image ID="imgBanner3" runat="server" Width="250" Height="154" BorderWidth="0" />
            <div class="mask_layer" style="width:250px;height:154px;"></div>
        </asp:HyperLink>
    </div>
    <div id="gallery1" class="gallery">
        <div class="title"><asp:Literal ID="literCategoryName1" runat="server"></asp:Literal></div>
        <div class="subtitle">
            <span class="float_l">丰田RAV4多媒体导航系统</span>
            <a href="<%=ResolveUrl("~/work") %>" class="more">&gt;MORE</a>
            <div class="clear"></div>
        </div>
        <asp:Repeater ID="rptGallery1" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="hlnkProject" runat="server" CssClass="switch_item" NavigateUrl='<%#ResolveUrl("~/work/"+Eval("CategoryID").ToString()) %>'>
                    <asp:Image ID="imgProject" runat="server" ImageUrl='<%#ResolveUrl(Eval("ProjectLogo").ToString()) %>' AlternateText='<%#Eval("ProjectDescription").ToString() %>' ToolTip='<%#Eval("ProjectName").ToString() %>' BorderWidth="0" />
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
        <a href="#" class="pic_title" style="top:40px;left:466px;"></a>
    </div>
    <div id="gallery2" class="gallery">
        <div class="title"><asp:Literal ID="literCategoryName2" runat="server"></asp:Literal></div>
        <div class="subtitle">
            <span class="float_l">丰田RAV4多媒体导航系统</span>
            <a href="<%=ResolveUrl("~/work") %>" class="more">&gt;MORE</a>
            <div class="clear"></div>
        </div>
        <asp:Repeater ID="rptGallery2" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="hlnkProject" runat="server" CssClass="switch_item" NavigateUrl='<%#ResolveUrl("~/work/"+Eval("CategoryID").ToString()) %>'>
                    <asp:Image ID="imgProject" runat="server" ImageUrl='<%#ResolveUrl(Eval("ProjectLogo").ToString()) %>' AlternateText='<%#Eval("ProjectDescription").ToString() %>' ToolTip='<%#Eval("ProjectName").ToString() %>' BorderWidth="0" />
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
        <a href="#" class="pic_title" style="top:40px;left:466px;"></a>
    </div>
    <div id="gallery3" class="gallery">
        <div class="title"><asp:Literal ID="literCategoryName3" runat="server"></asp:Literal></div>
        <div class="subtitle">
            <span class="float_l">丰田RAV4多媒体导航系统</span>
            <a href="<%=ResolveUrl("~/work") %>" class="more">&gt;MORE</a>
            <div class="clear"></div>
        </div>
        <asp:Repeater ID="rptGallery3" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="hlnkProject" runat="server" CssClass="switch_item" NavigateUrl='<%#ResolveUrl("~/work/"+Eval("CategoryID").ToString()) %>'>
                    <asp:Image ID="imgProject" runat="server" ImageUrl='<%#ResolveUrl(Eval("ProjectLogo").ToString()) %>' AlternateText='<%#Eval("ProjectDescription").ToString() %>' ToolTip='<%#Eval("ProjectName").ToString() %>' BorderWidth="0" />
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
        <a href="#" class="pic_title" style="top:40px;left:466px;"></a>
    </div>
    <div id="gallery4" class="gallery">
        <div class="title"><asp:Literal ID="literCategoryName4" runat="server"></asp:Literal></div>
        <div class="subtitle">
            <span class="float_l">丰田RAV4多媒体导航系统</span>
            <a href="<%=ResolveUrl("~/work") %>" class="more">&gt;MORE</a>
            <div class="clear"></div>
        </div>
        <asp:Repeater ID="rptGallery4" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="hlnkProject" runat="server" CssClass="switch_item" NavigateUrl='<%#ResolveUrl("~/work/"+Eval("CategoryID").ToString()) %>'>
                    <asp:Image ID="imgProject" runat="server" ImageUrl='<%#ResolveUrl(Eval("ProjectLogo").ToString()) %>' AlternateText='<%#Eval("ProjectDescription").ToString() %>' ToolTip='<%#Eval("ProjectName").ToString() %>' BorderWidth="0" />
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
        <a href="#" class="pic_title" style="top:40px;left:466px;"></a>
    </div>
    <div>
        <div id="photo_slider">
            <div class="title">New Icon</div>
            <ul>
                <li>
                    <a href="<%=ResolveUrl("~/work") %>">
                        <img alt="呵呵" src="images/sample6.jpg" border="0" />
                    </a>
                </li>
                <li>
                    <a href="<%=ResolveUrl("~/work") %>">
                        <img alt="呵呵" src="images/sample7.jpg" border="0" />
                    </a>
                </li>
                <li>
                    <a href="<%=ResolveUrl("~/work") %>">
                        <img alt="呵呵" src="images/sample8.jpg" border="0" />
                    </a>
                </li>
                <li>
                    <a href="<%=ResolveUrl("~/work") %>">
                        <img alt="呵呵" src="images/sample6.jpg" border="0" />
                    </a>
                </li>
                <li>
                    <a href="<%=ResolveUrl("~/work") %>">
                        <img alt="呵呵" src="images/sample8.jpg" border="0" />
                    </a>
                </li>
                <li>
                    <a href="<%=ResolveUrl("~/work") %>">
                        <img alt="呵呵" src="images/sample6.jpg" border="0" />
                    </a>
                </li>
                <li>
                    <a href="<%=ResolveUrl("~/work") %>">
                        <img alt="呵呵" src="images/sample7.jpg" border="0" />
                    </a>
                </li>
                <li>
                    <a href="<%=ResolveUrl("~/work") %>">
                        <img alt="呵呵" src="images/sample6.jpg" border="0" />
                    </a>
                </li>
                <li>
                    <a href="<%=ResolveUrl("~/work") %>">
                        <img alt="呵呵" src="images/sample7.jpg" border="0" />
                    </a>
                </li>
                <div class="clear"></div>
            </ul>
            <div class="photoslider_pager"></div>
        </div>
        <div id="contacts">
            <div class="contact">
                <div class="contact_l">Email</div>
                <div class="contact_r">
                    <div class="contact_text_wrap">
                        ita-design@ita.com
                    </div>
                </div>
                <div class="contact_img_wrap"><img alt="" src='<%=ResolveUrl("~/images/contact_arrow.jpg") %>' border="0" /></div>
            </div>
            <div class="contact">
                <div class="contact_l">QQ</div>
                <div class="contact_r">
                    <div class="contact_text_wrap">
                        <div>63366736</div>
                        <div>81094582</div>
                        <div>67404958</div>
                    </div>
                </div>
                <div class="contact_img_wrap"><img alt="" src='<%=ResolveUrl("~/images/contact_arrow.jpg") %>' border="0" /></div>
            </div>
            <div class="contact">
                <div class="contact_l">MSN</div>
                <div class="contact_r">
                    <div class="contact_text_wrap">
                        ita-design@ita.com
                    </div>
                </div>
                <div class="contact_img_wrap"><img alt="" src='<%=ResolveUrl("~/images/contact_arrow.jpg") %>' border="0" /></div>
            </div>
            <div class="contact">
                <div class="contact_l">TEL</div>
                <div class="contact_r">
                    <div class="contact_text_wrap">
                        <div>186-0005-9136</div>
                        <div>186-1028-9776</div>
                        <div>134-8865-5530</div>
                    </div>
                </div>
                <div class="contact_img_wrap"><img alt="" src='<%=ResolveUrl("~/images/contact_arrow.jpg") %>' border="0" /></div>
            </div>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>

