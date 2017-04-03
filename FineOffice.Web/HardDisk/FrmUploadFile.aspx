<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmUploadFile.aspx.cs" Inherits="HardDisk_FrmUploadFile" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../swfupload/Css/SwfUploadPanel.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmUploadFile" runat="server">
    <x:PageManager ID="pageManager" runat="server" AutoSizePanelID="pnlForm" />
    <x:Panel ID="pnlForm" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        EnableBackgroundColor="true">
        <Items>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hiddenFolderID" runat="server" />
    <x:HiddenField ID="hiddenTabID" runat="server" />
    <x:HiddenField ID="hiddenIsPublic" runat="server" />
    </form>
</body>
</html>
<script src="../Swfupload/ext-grid.js" type="text/javascript"></script>
<script type="text/javascript" src="../Swfupload/SwfUploadPanel.js"></script>
<script type="text/javascript" src="../Swfupload/SwfUpload.js"></script>
<script type="text/javascript">
    Ext.onReady(function () {
        var hiddenFolderID = Ext.getCmp(Ctrls.hiddenFolderID);
        var hiddenTabID = Ext.getCmp(Ctrls.hiddenTabID);
        var hiddenIsPublic = Ext.getCmp(Ctrls.hiddenIsPublic);
        var pnlForm = Ext.getCmp(Ctrls.pnlForm);

        var dlg = new Ext.ux.SwfUploadPanel({
            title: '上传组件',
            width: 500
			, height: 300
			, border: false
			, upload_url: '<%=GetServerUri() %>HardDisk/UploadFileHandler.ashx'
			, post_params: {
			    folderid: hiddenFolderID.getValue(),			   
			    personnelid: '<%=this.CookiePersonnel.ID %>',
			    ispublic: hiddenIsPublic.getValue()
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
        pnlForm.items.add(dlg);
        pnlForm.doLayout();
    });
</script>
