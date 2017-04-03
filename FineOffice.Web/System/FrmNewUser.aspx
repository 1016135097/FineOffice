<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmNewUser.aspx.cs" Inherits="System_FrmNewUser" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmNewUser" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </x:Button>
                    <x:Button ID="btnSave" Text="保存" runat="server" ValidateForms="frmUser" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click">
                    </x:Button>
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlForm" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:SimpleForm ID="frmUser" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <x:TextBox ID="txtUserName" Label="用户账号" Required="true" runat="server" />
                            <x:HiddenField ID="hiddenPersonnel" runat="server" />
                            <x:TriggerBox ID="txtPersonnel" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                Required="true" Label="使&nbsp;&nbsp;用&nbsp;人" runat="server" />
                            <x:TextBox ID="txtPassword1" Label="密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码" TextMode="Password"
                                Required="true" runat="server" />
                            <x:TextBox ID="txtPassword2" Label="重复密码" TextMode="Password" Required="true" runat="server"
                                CompareOperator="Equal" CompareMessage="两次密码不一致！" CompareControl="txtPassword1" />
                            <x:CheckBox ID="chkStop" runat="server" Checked="true" Text="" Label="是否可用" />
                            <x:TextArea ID="txtRemark" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" runat="server" />
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="selectPersonWin" Title="选择使用人" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Find"
        Width="710px" Height="420px" EnableIFrame="true">
    </x:Window>
    </form>
</body>
</html>
