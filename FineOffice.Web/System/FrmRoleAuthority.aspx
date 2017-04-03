<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmRoleAuthority.aspx.cs"
    Inherits="System_FrmRoleAuthority" %>

<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="_FrmRoleAuthority" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:RegionPanel ID="pnlMain" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="pnlLeft" Split="true" EnableSplitTip="true" CollapseMode="Default"
                Width="200px" Margins="0 0 0 0" ShowHeader="true" Title="系统角色" EnableLargeHeader="false"
                Icon="Outline" EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                <Items>
                    <x:Grid ID="roleGrid" ShowBorder="false" ShowHeader="False" EnableMultiSelect="false"
                        OnRowSelect="roleGrid_RowSelect" EnableCheckBoxSelect="true" EnableRowSelect="true"
                        Title="系统角色" EnableRowClick="true" runat="server" DataKeyNames="ID,RoleName"
                        SortColumn="Ordering" IsDatabasePaging="true" SortDirection="ASC" EnableRowNumber="True">
                        <Columns>
                            <x:BoundField Width="150px" Sortable="false" Hideable="false" ColumnID="RoleName"
                                SortField="RoleName" DataField="RoleName" HeaderText="角色名称" />
                            <x:BoundField Width="60px" Sortable="false" Hideable="false" ColumnID="Ordering"
                                SortField="Ordering" DataField="Ordering" HeaderText="排序" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Region>
            <x:Region ID="pnlRight" ShowHeader="true" Layout="Fit" Margins="0 0 0 0" Position="Center"
                Icon="Outline" Title="权限设置" runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <x:Button ID="btnSelectAll" Icon="ArrowIn" Text="全选" runat="server" OnClick="btnSelectAll_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnInverse" Icon="ArrowOut" Text="反选" runat="server" OnClick="btnInverse_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnAward" Icon="SystemSaveNew" Text="授权" runat="server" OnClick="btnAwardRole_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnRefresh" Icon="ArrowRefresh" OnClick="btnRefresh_Click" Text="刷新"
                                runat="server" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:RegionPanel ID="pnlLayout" ShowBorder="false" runat="server">
                        <Regions>
                            <x:Region ID="pnlMenu" Split="true" EnableSplitTip="true" CollapseMode="Default"
                                Width="200px" Margins="0 0 0 0" ShowHeader="false" EnableLargeHeader="false"
                                Icon="Outline" EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                                <Toolbars>
                                    <x:Toolbar ID="toolbar" Position="Top" runat="server">
                                        <Items>
                                            <x:Button ID="btnExpandAll" Icon="FolderAdd" Text="展开" runat="server" OnClick="btnExpandAll_Click" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnCollapseAll" Icon="FolderEdit" Text="收起" runat="server" OnClick="btnCollapseAll_Click" />
                                        </Items>
                                    </x:Toolbar>
                                </Toolbars>
                                <Items>
                                    <x:Tree runat="server" ID="tvwMenu" EnableArrows="false" OnNodeCheck="twvMenu_NodeCheck"
                                        AutoScroll="true" EnableIcons="false" Title="菜单" OnNodeCommand="tvwMenu_NodeCommand"
                                        Expanded="true" ShowHeader="false" ShowBorder="false">
                                    </x:Tree>
                                </Items>
                            </x:Region>
                            <x:Region ID="pnlAuthority" Layout="Fit" Margins="0 0 0 0" Position="Center" ShowHeader="false"
                                Title="页面权限" runat="server">
                                <Items>
                                    <x:Panel ID="pnlFile" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                                        runat="server">
                                        <Items>
                                            <x:Grid ID="authorityGrid" Title="页面权限" ShowBorder="false" ShowHeader="False" EnableMultiSelect="True"
                                                runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,MenuID,ControlID"
                                                SortColumn="Text" SortDirection="ASC" EnableRowNumber="True">
                                                <Columns>
                                                    <x:BoundField Width="150px" ColumnID="Text" SortField="Text" DataField="Text" HeaderText="系统菜单" />
                                                    <x:BoundField Width="150px" ColumnID="AuthorityName" SortField="AuthorityName" DataField="AuthorityName"
                                                        HeaderText="权限名称" />
                                                    <x:BoundField Width="150px" ColumnID="ControlID" SortField="ControlID" DataField="ControlID"
                                                        HeaderText="控件ID" />
                                                    <x:BoundField Width="60px" ColumnID="Ordering" SortField="Ordering" DataField="Ordering"
                                                        HeaderText="排序" />
                                                    <x:BoundField Width="150px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                                        HeaderText="备注" />
                                                </Columns>
                                            </x:Grid>
                                        </Items>
                                    </x:Panel>
                                </Items>
                            </x:Region>
                        </Regions>
                    </x:RegionPanel>
                </Items>
            </x:Region>
        </Regions>
    </x:RegionPanel>
    <x:HiddenField ID="hiddenSelectedNodes" runat="server" />
    <x:HiddenField ID="hiddenSelectedIDs" runat="server" />
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnAward"]'
        runat="server" />
    </form>
</body>
</html>
