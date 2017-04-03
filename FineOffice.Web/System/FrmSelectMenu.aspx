<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmSelectMenu.aspx.cs" Inherits="System_FrmSelectMenu" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="_FrmSelectMenu" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" ShowBorder="false" Layout="Fit" BoxConfigAlign="Stretch"
        BoxConfigPosition="Start" BoxConfigPadding="0" ShowHeader="false">
        <Toolbars>
            <x:Toolbar ID="tsbMain" runat="server">
                <Items>
                    <x:Button ID="btnEnter" Icon="SystemSaveNew" Text="确定" OnClick="btnEnter_Click" runat="server" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnCancel" Icon="SystemClose" Text="取消选择" runat="server" OnClick="btnCancel_Click" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnExpandAll" Icon="Folder" Text="展开" OnClick="btnExpandAll_Click"
                        runat="server" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnCollapseAll" Icon="FolderUp" Text="收起" OnClick="btnCollapseAll_Click"
                        runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Tree runat="server" ID="tvwMenu" AutoScroll="true" EnableIcons="false" Expanded="true"
                Title="系统菜单" ShowHeader="false" ShowBorder="false">
            </x:Tree>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
