<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Work.aspx.cs" Inherits="Work" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $contentLoadTriggered = false;
            var projects = $(".projects"),
                current = 0;
            $(window).scroll(function () {
                if ($(window).scrollTop() >= ($(document).height() - $(window).height()-60) && $contentLoadTriggered == false) {
                    $contentLoadTriggered = true;
                    loadProjects();
                }
            });

            function loadProjects() {
                $.ajax({
                    type: "POST",
                    url: '<%=ResolveUrl("~/handlers/ProjectHandler.ashx") %>',
                    data: { skip: current },
                    dataType: "json",
                    async: true,
                    cache: false,
                    success: function (data) {
                        if (data.length > 0) {
                            $.each(data, function (k, v) {
                                var logo = v.ProjectLogo.replace("~/", ""),
                                    project = $('<div class="project" style="display:none;"><img src="<%=ResolveUrl("' + logo + '") %>" alt="' + v.ProjectName + '" /><div class="info c_fff ' + (v.TextPos == 0 ? 'left' : 'right') + '"><p class="title">' + encode(v.ProjectName) + '</p><p class="desc">' + encode(v.ProjectDescription) + '</p><a data-url="<%=ResolveUrl("~/case/' + v.ProjectID + '") %>" class="detail pngfixer">详细</a></div></div>');

                                project.appendTo(projects).fadeIn('slow');
                            });
                            current += data.length;
                        }
                        $contentLoadTriggered = false;
                    },
                    error: function (x, e) {
                        console.log("The call to the server side failed. " + x.responseText);
                    }
                });
            }
            loadProjects();

            $('a.detail').live('click', function () {
                window.location.href = '<%=Utils.GetRootURI() %>'+$(this).data('url');
            });
        });

        $(window).load(function () {
            // photo slider
            //$("#projects").photoslider({ currentPagerImg: '<%=ResolveUrl("~/images/photoslider_pager_current.jpg") %>', pagerImg: '<%=ResolveUrl("~/images/photoslider_pager.jpg") %>', pagesize: 5, delay: 5000, speed: 1500, auto: false });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="projects wrapper">
        <%--<div id="1" class="project">
            <img src="images/sample1.jpg" />
            <div class="info right">
                <p class="title">迪斯尼 X32 pooh手机</p>
                <p class="desc">2011年为迪斯尼概念手机设计卡通风格的手机系统应用，将迪斯尼的各种卡通形象融合在手机的操作系统界面和⋯⋯</p>
                <a class="detail pngfixer">详细</a>
            </div>
        </div>
        <div id="2" class="project">
            <img src="images/sample2.jpg" />
            <div class="info left">
                <p class="title">迪斯尼 X32 pooh手机</p>
                <p class="desc">2011年为迪斯尼概念手机设计卡通风格的手机系统应用，将迪斯尼的各种卡通形象融合在手机的操作系统界面和⋯⋯</p>
                <a class="detail pngfixer">详细</a>
            </div>
        </div>--%>
    </div>
</asp:Content>

