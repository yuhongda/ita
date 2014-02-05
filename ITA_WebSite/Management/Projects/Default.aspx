﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Manage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Management_Projects_Default" ValidateRequest="false" Theme="DataWebControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    $(function () {

    });
    function formvalidate() {
        var result = true;
        $(".required").each(function () {
            if (!($.trim($("#<%=lblID.ClientID %>").text()) != "" && $(this).hasClass("editskip"))) {
                if ($.trim($(this).val()) == "") {
                    $(this).parent().children(".red").text("* required!");
                    result = false;
                }
                else {
                    $(this).parent().children(".red").text("*");
                }
            }
        });
        return result;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<h1>Project Management</h1>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        onrowcommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("ProjectID").ToString() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("ProjectName").ToString() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Logo">
                        <ItemTemplate>
                            <asp:Image ID="imgLogo" runat="server" ImageUrl='<%# ResolveUrl(Eval("ProjectLogo").ToString()) %>' Width="150" />
                            <asp:HiddenField ID="hidProjectLogo" runat="server" Value='<%# Eval("ProjectLogo").ToString() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("ProjectDescription").ToString() %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%#Convert.ToDateTime(Eval("ProjectDate")).ToString("yyyy/MM/dd") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <asp:Label ID="lblCategoryName" runat="server" Text='<%#Eval("CategoryName").ToString() %>'></asp:Label>
                            <asp:HiddenField ID="hidCategoryID" Value='<%#Eval("CategoryID").ToString() %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="文字位置">
                        <ItemTemplate>
                            <asp:Label ID="lblTextPos" runat="server" Text='<%#Eval("TextPos")!=DBNull.Value?(Eval("TextPos").ToString().ToInt()==0?"左":"右"):string.Empty %>'></asp:Label>
                            <asp:HiddenField ID="hidPos" Value='<%#Eval("TextPos").ToString() %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnEditWork" CommandName="MOD_WORK" runat="server">Works</asp:LinkButton>
                            <asp:LinkButton ID="lbtnEdit" CommandName="MOD" runat="server">Modity</asp:LinkButton>
                            <asp:LinkButton ID="lbtnDelete" CommandName="DEL" runat="server" OnClientClick="javascript:return confirm('确认删除么？');">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
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
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" 
                Text="ADD Project" />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                <table style="height: 198px; width: 554px">
                    <tr>
                        <td>ID:</td>
                        <td><asp:Label ID="lblID" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Name:</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="required"></asp:TextBox><span class="red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td>Logo:</td>
                        <td>
                            <asp:Image ID="imgLogo" runat="server" />
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="required editskip" /><span class="red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td>Description:</td>
                        <td>
                            <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Date:</td>
                        <td><asp:Label ID="lblDate" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>文字位置:</td>
                        <td>
                            <asp:DropDownList ID="ddlPos" runat="server">
                                <asp:ListItem Text="左" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="右" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Category:</td>
                        <td>
                            <asp:DropDownList ID="ddlCategories" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" OnClientClick="javascript:return formvalidate();" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" />
                <br />
                <br />
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </asp:Panel>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

