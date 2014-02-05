<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Case.aspx.cs" Inherits="Case" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#case").load('<%=GetCaseUrl() + "index.html" %>', function () {
                $(this).find(".project").find("img").each(function () {
                    var _src = $(this).attr("src"),
                        _original = $(this).attr("data-original");
                    $(this).attr({ src: '<%=ResolveUrl("~/") %>' + _src, "data-original": '<%=GetCaseUrl() %>' + _original });
                });
                $("img.lazy").lazyload({ effect: "fadeIn" });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="projects wrapper">
        <%----%>
        <%--<div class="project">
            <asp:Image ID="projectLogo" runat="server" />
            <asp:Panel ID="info" runat="server">
                <p class="title">
                    <asp:Literal ID="projectName" runat="server"></asp:Literal></p>
                <p class="desc">
                    <asp:Literal ID="projectDesc" runat="server"></asp:Literal></p>
            </asp:Panel>
        </div>--%>
        <div id="case">
            
        </div>
    </div>
</asp:Content>

