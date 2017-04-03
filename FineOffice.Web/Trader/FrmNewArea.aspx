<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmNewArea.aspx.cs" Inherits="Trader_FrmNewArea" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmNewArea" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose"/>
                    <x:Button ID="btnSave" Text="保存" runat="server" ValidateForms="frmArea" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click"/>
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlArea" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:SimpleForm ID="frmArea" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <x:TextBox ID="txtArea" Label="地区名称" Required="true" runat="server" />
                            <x:HiddenField ID="hiddenParentID" runat="server" />
                            <x:TriggerBox ID="txtParent" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                Label="所属地区" runat="server" />
                            <x:TextBox ID="txtOrdering" Label="排&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序" Required="true"
                                Text="0" runat="server" RegexPattern="NUMBER" />
                            <x:TextArea ID="txtRemark" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" runat="server" />
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="selectAreaWin" Title="选择地区" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="Find" Width="310px"
        Height="435px" EnableIFrame="true">
    </x:Window>
    </form>
</body>
</html>
