<%@ Page Title="" Language="C#" MasterPageFile="~/Management/Manage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Management_Works_Default" ValidateRequest="false" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="<%=ResolveUrl("~/Scripts/default.css") %>" type="text/css" />
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/swfupload/handlers.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/Scripts/swfupload/swfupload.js") %>"></script>
    <script language="javascript" type="text/javascript">
        var swfu;
        window.onload = function () {
            swfu = new SWFUpload({
                // Backend Settings
                upload_url: '<%=ResolveUrl("~/Management/Works/upload.aspx") %>',
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                // File Upload Settings
                file_size_limit: "2 MB",
                file_types: "*.jpg;*.gif",
                file_types_description: "Images",
                file_upload_limit: "0",    // Zero means unlimited

                // Event Handler Settings - these functions as defined in Handlers.js
                //  The handlers are not part of SWFUpload but are part of my website and control how
                //  my website reacts to the SWFUpload events.
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: uploadSuccess,
                upload_complete_handler: uploadComplete,

                // Button settings
                button_image_url: '<%=ResolveUrl("~/Scripts/swfupload/images/XPButtonNoText_160x22.png") %>',
                button_placeholder_id: "spanButtonPlaceholder",
                button_width: 160,
                button_height: 22,
                button_text: '<span class="button">选择照片<span class="buttonSmall">(单文件 2 MB)</span></span>',
                button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 12px; }',
                button_text_top_padding: 1,
                button_text_left_padding: 5,

                // Flash Settings
                flash_url: '<%=ResolveUrl("~/Scripts/swfupload/swfupload.swf") %>', // Relative to this file

                custom_settings: {
                    upload_target: "divFileProgressContainer"
                },

                // Debug Settings
                debug: false
            });
        }

        function formvalidate() {
            var result = true;
            $(".required").each(function () {
                if ($.trim($(this).val()) == "") {
                    $(this).next().text("* required!");
                    result = false;
                }
                else {
                    $(this).next().text("*");
                }
            });
            return result;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>Work Management</h1>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="ddlProjects" runat="server" CssClass="required">
            </asp:DropDownList>
            <span class="red">*</span>
            <div id="uploader">
                <span id="spanButtonPlaceholder"></span>
            </div>
            <div id="divFileProgressContainer" style="height: 75px;"></div>
            <div id="thumbnails" style="display:none;padding:10px; background-color:#f0f5ff; border:1px solid #cee2f2;width:700px;margin-top:20px;">
                <div id="file_list" style="display:none;margin-bottom:20px;font-weight:bold;">上传图片列表</div>
            </div>
            <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" OnClientClick="javascript:return formvalidate();" />
            <asp:Panel ID="panelMessage" runat="server" style="display:none; color:Red; margin:20px 0;"></asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

