<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmCopyToPublic.aspx.cs" Inherits="HardDisk_FrmCopyToPublic" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="_FrmCopyToPublic" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" ShowBorder="false" Layout="Fit" BoxConfigAlign="Stretch"
        BoxConfigPosition="Start" BoxConfigPadding="0" ShowHeader="false">
        <Toolbars>
            <x:Toolbar ID="tsbMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" Icon="SystemClose" Text="关闭" runat="server" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnEnter" Icon="SystemSaveNew" Text="确定" OnClick="btnEnter_Click" runat="server" />
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
            <x:Tree runat="server" ID="tvwFolder" AutoScroll="true" EnableIcons="false" Expanded="true"
                Title="文件夹" ShowHeader="false" ShowBorder="false">
            </x:Tree>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hiddenFiles" runat="server" />
    </form>
</body>
</html>
