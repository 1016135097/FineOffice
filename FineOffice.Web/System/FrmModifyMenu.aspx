﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmModifyMenu.aspx.cs" Inherits="System_FrmModifyMenu" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmModifyMenu" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <x:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" ValidateForms="frmMenu"
                        ValidateMessageBox="false" OnClick="btnSave_Click" />
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlMenu" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:SimpleForm ID="frmMenu" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <x:HiddenField ID="hiddenID" runat="server" />
                            <x:TextBox ID="txtText" Label="菜单标题" Required="true" runat="server" />
                            <x:RadioButtonList ID="rdbMenuType" runat="server" OnSelectedIndexChanged="rdbMenuType_SelectedIndexChanged"
                                AutoPostBack="true">
                                <x:RadioItem Value="IsModule" Text="模块菜单" Selected="true" />
                                <x:RadioItem Value="IsFunction" Text="功能菜单" />
                            </x:RadioButtonList>
                            <x:GroupPanel ID="grpSetMenu" Title="设置菜单" runat="server">
                                <Items>
                                    <x:TextBox ID="txtAuthorityValue" Label="选项卡ID" runat="server" />
                                    <x:TextBox ID="txtNavigateUrl" Label="菜单地址" runat="server" />
                                </Items>
                            </x:GroupPanel>
                            <x:HiddenField ID="hiddenParentID" runat="server" />
                            <x:TriggerBox ID="txtParent" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                Label="父级菜单" runat="server" />
                            <x:TextBox ID="txtIcon" Label="图&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;标" Required="true"
                                runat="server" />
                            <x:TextBox ID="txtOrdering" Label="排&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序" Required="true"
                                runat="server" RegexPattern="NUMBER" Text="0" />
                            <x:CheckBox ID="chkStop" runat="server" Checked="true" Text="" Label="是否可用" />
                            <x:TextArea ID="txtRemark" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" runat="server" />
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="wdnSelectMenu" Title="选择父级菜单" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="Find" Width="310px"
        Height="435px" EnableIFrame="true">
    </x:Window>
    </form>
</body>
</html>
