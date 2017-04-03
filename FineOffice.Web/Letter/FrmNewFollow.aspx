<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmNewFollow.aspx.cs" Inherits="Letter_FrmNewFollow" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="_FrmNewFollow" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <x:Button ID="btnSave" Text="保存" runat="server" ValidateForms="frmFollow" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click" />
                    <x:ToolbarFill  runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlForm" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:SimpleForm ID="frmFollow" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <x:TextBox ID="txtLinkman" Label="联&nbsp;&nbsp;系&nbsp;人" runat="server" />
                            <x:TextBox ID="txtMoblie" Label="联系方式" runat="server" />
                            <x:Form ID="frmVisitTime" ShowBorder="false" ShowHeader="false" AutoScroll="true"
                                EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                                <Rows>
                                    <x:FormRow runat="server" ColumnWidths="280 90">
                                        <Items>
                                            <x:DatePicker runat="server" Required="true" Label="处理时间" ID="dtpDate" Width="170px" />
                                            <x:TimePicker ID="dtpTime" Increment="5" ShowLabel="false" Required="true" runat="server"
                                                Width="75px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                            <x:DropDownList ID="ddlHandleDepartment" Label="部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门"
                                runat="server" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="ddlHandleDepartment_SelectedIndexChanged" />
                            <x:DropDownList ID="ddlHandler" Label="处&nbsp;&nbsp;理&nbsp;人" runat="server" Width="250px" />
                            <x:TextArea ID="txtMatter" Label="跟进内容" Required="false" runat="server" />
                            <x:TextArea ID="txtResult" Label="跟进结果" runat="server" />
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hiddenLetterID" runat="server" />
    </form>
</body>
</html>
