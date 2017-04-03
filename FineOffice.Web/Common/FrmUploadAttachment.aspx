<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmUploadAttachment.aspx.cs"
    Inherits="Common_FrmUploadAttachment" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../swfupload/Css/SwfUploadPanel.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmUploadAttachment" runat="server">
    <x:PageManager ID="pageManager" runat="server" AutoSizePanelID="pnlMain" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        EnableBackgroundColor="true">
        <Items>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hiddenFollowID" runat="server" />
    <x:HiddenField ID="hiddenRunProcess" runat="server" />
    <x:HiddenField ID="hiddenContractID" runat="server" />
    <x:HiddenField ID="hiddenTabID" runat="server" />
    </form>
</body>
</html>
<script src="../Swfupload/ext-grid.js" type="text/javascript"></script>
<script type="text/javascript" src="../Swfupload/SwfUploadPanel.js"></script>
<script type="text/javascript" src="../Swfupload/SwfUpload.js"></script>
<script type="text/javascript">
    Ext.onReady(function () {
        var hiddenTabID = Ext.getCmp(Ctrls.hiddenTabID);
        var hiddenFollowID = Ext.getCmp(Ctrls.hiddenFollowID);
        var hiddenContractID = Ext.getCmp(Ctrls.hiddenContractID);
        var hiddenRunProcess = Ext.getCmp(Ctrls.hiddenRunProcess);
        var pnlMain = Ext.getCmp(Ctrls.pnlMain);

        var dlg = new Ext.ux.SwfUploadPanel({
            title: '上传组件',
            width: 500
			, height: 300
			, border: false
			, upload_url: '<%=GetServerUri() %>Handle/UploadAttachmentHandler.ashx'
			, post_params: {
			    FollowID: hiddenFollowID.getValue(),
			    ContractID: hiddenContractID.getValue(),
			    runprocessid: hiddenRunProcess.getValue(),
			    PersonnelID: '<%=this.CookiePersonnel.ID %>'
			}
			, file_types: "*.*"
			, file_types_description: "所有文件"
			, flash_url: "../swfupload/swfupload.swf"
			, single_file_select: false
			, confirm_delete: false
			, remove_completed: true
            , header: false
            , listeners: {
                fileUploadSuccess: function () {
                    parent.refreshAttach(hiddenTabID.getValue());
                }
            }
        });
        pnlMain.items.add(dlg);
        pnlMain.doLayout();
    });
</script>
