<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Manage.master" AutoEventWireup="true"
    CodeFile="UserList.aspx.cs" Inherits="Management_Users_UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:Repeater ID="rptPageFliper" runat="server">
                <ItemTemplate>
                    <span style='<%#(((PageNumberItem)Container.DataItem).IsCurrentPage) ? "text-align:center;width:25px;height:20px;background-color:#01439c; color:#ffffff; display:-moz-inline-box; display:inline-block; float:left;line-height:20px; margin-left:5px;": "text-align:center;width:25px;height:20px;background-color:#f1fbfd; color:#000000;display:-moz-inline-box; display:inline-block; float:left;line-height:20px; margin-left:5px;"%>'
                        class="paging">
                        <asp:LinkButton ID="lbtnPager" runat="server" CommandName="<%# ((PageNumberItem)Container.DataItem).PageNumberCommand%>"
                            Text="<%# ((PageNumberItem)Container.DataItem).PageNumberText%>" Enabled='<%# !(((PageNumberItem)Container.DataItem).IsCurrentPage) %>'
                            Style='<%#(((PageNumberItem)Container.DataItem).IsCurrentPage) ? "color:#ffffff;": "color:#000000;"%>'
                            Font-Underline="false"></asp:LinkButton>
                    </span>
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
