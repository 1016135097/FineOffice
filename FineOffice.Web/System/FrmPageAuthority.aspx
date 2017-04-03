<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmPageAuthority.aspx.cs"
    Inherits="System_FrmPageAuthority" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="_FrmPageAuthority" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:RegionPanel ID="pnlMain" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="pnlLeft" Split="true" EnableSplitTip="true" CollapseMode="Default"
                Width="200px" Margins="0 0 0 0" ShowHeader="true" Title="系统菜单" EnableLargeHeader="false"
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
                    <x:Tree runat="server" ID="tvwMenu" EnableArrows="false" AutoScroll="true" EnableIcons="false"
                        Title="菜单" OnNodeCommand="tvwMenu_NodeCommand" Expanded="true" ShowHeader="false"
                        ShowBorder="false">
                    </x:Tree>
                </Items>
            </x:Region>
            <x:Region ID="pnlRight" ShowHeader="true" Layout="Fit" Margins="0 0 0 0" Position="Center"
                Icon="Outline" Title="页面权限" runat="server">
                <Items>
                    <x:Panel ID="pnlLayout" runat="server" EnableBackgroundColor="true" BodyPadding="0px"
                        ShowHeader="false" EnableLargeHeader="false" ShowBorder="false" Layout="VBox"
                        BoxConfigAlign="Stretch">
                        <Items>
                            <x:Panel ID="pnlAuthority" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                                runat="server">
                                <Toolbars>
                                    <x:Toolbar ID="tsbMain" runat="server">
                                        <Items>
                                            <x:Button ID="btnNew" Icon="Add" Text="新增" runat="server" OnClick="btnNew_Click" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnModify" Icon="ApplicationEdit" OnClick="btnModify_Click" Text="编辑"
                                                runat="server" />
                                            <x:Button ID="btnDelete" Icon="Delete" OnClick="btnDelete_Click" Text="删除" runat="server" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnRefresh" Icon="ArrowRefresh" OnClick="btnRefresh_Click" Text="刷新"
                                                runat="server" />
                                        </Items>
                                    </x:Toolbar>
                                </Toolbars>
                                <Items>
                                    <x:Grid ID="authorityGrid" Title="页面权限" ShowBorder="false" ShowHeader="False" EnableMultiSelect="True"
                                        runat="server" OnRowCommand="authorityGrid_RowCommand" SortColumn="Text" SortDirection="ASC"
                                        DataKeyNames="ID,AuthorityName" IsDatabasePaging="true" EnableCheckBoxSelect="True"
                                        EnableRowNumber="True">
                                        <Columns>
                                            <x:BoundField Width="200px" ColumnID="Text" SortField="Text" DataField="Text" HeaderText="系统菜单" />
                                            <x:BoundField Width="200px" ColumnID="AuthorityName" SortField="AuthorityName" DataField="AuthorityName"
                                                HeaderText="权限名称" />
                                            <x:BoundField Width="200px" ColumnID="ControlID" SortField="ControlID" DataField="ControlID"
                                                HeaderText="控件ID" />
                                            <x:BoundField Width="150px" ColumnID="Ordering" SortField="Ordering" DataField="Ordering"
                                                HeaderText="排序" />
                                            <x:BoundField Width="150px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                                HeaderText="备注" />
                                            <x:WindowField TextAlign="Center" Width="60px" WindowID="authorityWin" Icon="Pencil"
                                                ToolTip="编辑" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmModifyPageAuthority.aspx?id={0}"
                                                Hideable="false" DataWindowTitleFormatString="编辑-{0}" DataWindowTitleField="Text" />
                                            <x:LinkButtonField TextAlign="Center" Icon="Delete" ConfirmText="确认删除吗？" ToolTip="删除"
                                                Width="50px" CommandName="delete" Hideable="false" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Region>
        </Regions>
    </x:RegionPanel>
    <x:Window ID="authorityWin" runat="server" Popup="false" IsModal="true" Target="Self"
        EnableMaximize="true" EnableResize="true" EnableIFrame="true" Icon="Add" Width="500px"
        Height="300px">
    </x:Window>
    </form>
</body>
</html>
