<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Manage.master" AutoEventWireup="true" CodeFile="WorkList.aspx.cs" Inherits="Management_Works_WorkList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>Work Management</h1>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="picblock">
                        <div>
                            <asp:HyperLink ID="hlnkUrl" runat="server" NavigateUrl='<%#ResolveUrl(Eval("FilePath").ToString()) %>' ToolTip='<%#Eval("FilePath").ToString() %>' BorderWidth="0" Target="_blank">
                                <img src='<%#ResolveUrl(Eval("FilePath").ToString()) %>' alt='<%#Eval("WorkName").ToString() %>' width="200" height="200" border="0" />
                            </asp:HyperLink>
                        </div>
                        <p class="dot"><asp:CheckBox ID="chkCheck" runat="server" /><%#Eval("WorkName").ToString()%></p>
                        <asp:HiddenField ID="hidWorkID" Value='<%#Eval("WorkID").ToString() %>' runat="server" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptPageFliper" runat="server">
                <ItemTemplate>
                    <span style='<%#(((PageNumberItem)Container.DataItem).IsCurrentPage) ? "text-align:center;width:25px;height:20px;background-color:#444; color:#eee; display:-moz-inline-box; display:inline-block; float:left;line-height:20px; margin-left:5px;": "text-align:center;width:25px;height:20px;background-color:#0f0f0f; color:#eee;display:-moz-inline-box; display:inline-block; float:left;line-height:20px; margin-left:5px;"%>'
                        class="paging">
                        <asp:LinkButton ID="lbtnPager" runat="server" CommandName="<%# ((PageNumberItem)Container.DataItem).PageNumberCommand%>"
                            Text="<%# ((PageNumberItem)Container.DataItem).PageNumberText%>" Enabled='<%# !(((PageNumberItem)Container.DataItem).IsCurrentPage) %>'
                            Style='<%#(((PageNumberItem)Container.DataItem).IsCurrentPage) ? "color:#eee;": "color:#eee;"%>'
                            Font-Underline="false"></asp:LinkButton>
                    </span>
                </ItemTemplate>
            </asp:Repeater>
            <div class="margin10_tb" style="clear:both;">
                <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn" onclick="lbtnDelete_Click" OnClientClick="javascript:return confirm('确认删除么？');">删除选中的图片</asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

