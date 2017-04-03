<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmNewWorkRun.aspx.cs" Inherits="WorkRun_FrmNewWorkRun" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmNewWorkRun" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <x:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" OnClick="btnSave_Click"
                        ValidateForms="frmNewWork" ValidateMessageBox="false" />
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlWork" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:SimpleForm ID="frmNewWork" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <x:HiddenField ID="txtFlowID" runat="server" />
                            <x:TextBox ID="txtFlowName" Readonly="true" Label="流程名称" runat="server" />
                            <x:TextBox ID="txtWorkNO" Label="工作编号" runat="server" />
                            <x:TextBox ID="txtWorkName" Label="工作标题" Required="true" runat="server" />
                            <x:DatePicker runat="server" Required="true" Label="选择日期" ID="dtpDate" />
                            <x:TimePicker ID="dtpTime" Label="选择时间" Increment="5" Required="true" runat="server" />
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
