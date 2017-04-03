<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmModifyFlowForm.aspx.cs"
    Inherits="WorkRun_FrmModifyFlowForm" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="frmModifyFlowForm" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlForm" runat="server" />
    <x:Panel ID="pnlForm" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <x:Button ID="btnSave" Text="保存" runat="server" ValidateForms="simpleForm" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click">
                    </x:Button>
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlMain" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:SimpleForm ID="simpleForm" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <x:HiddenField ID="hiddenFlowForm" runat="server" />
                            <x:Label ID="lblFormName" runat="server"  Label="表单名称"/>
                            <x:TextBox ID="txtTitle" Label="表单标题" Required="true" runat="server" />
                            <x:CheckBox ID="chkEdit" runat="server"  Label="编辑表单"  Checked="true"/>
                            <x:TextArea ID="txtRemark" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" runat="server" />
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
