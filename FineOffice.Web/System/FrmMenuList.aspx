<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmMenuList.aspx.cs" Inherits="System_FrmMenuList" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmMenuList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        Icon="Outline" ShowBorder="false" ShowHeader="true" Layout="VBox" BoxConfigAlign="Stretch"
        Title="系统菜单">
        <Items>
            <x:Panel ID="pnlMenu" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <x:Button ID="btnNew" Icon="Add" Text="新增" runat="server" OnClick="btnNew_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnRefresh" Icon="ArrowRefresh" OnClick="btnRefresh_Click" Text="刷新"
                                runat="server" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="menuGrid" Title="系统菜单" ShowBorder="false" AllowPaging="false" AllowSorting="false"
                        ShowHeader="False" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,Text"
                        SortColumn="personnelNO" EnableRowNumber="True" OnRowCommand="menuGrid_RowCommand">
                        <Columns>
                            <x:BoundField Width="190px" ColumnID="Text" DataField="Text" DataSimulateTreeLevelField="TreeLevel"
                                Hideable="false" Sortable="false" HeaderText="菜单标题" />
                            <x:BoundField Width="150px" ColumnID="AuthorityValue" DataField="AuthorityValue"
                                Sortable="false" HeaderText="选项卡ID" />
                            <x:BoundField Width="200px" ColumnID="NavigateUrl" DataField="NavigateUrl" Sortable="false"
                                HeaderText="菜单地址" />
                            <x:ImageField Width="60px" ColumnID="Icon" DataImageUrlField="Icon" DataImageUrlFormatString="~/Icon/{0}.png"
                                Sortable="false" TextAlign="Center" HeaderText="图标" />
                            <x:BoundField Width="60px" ColumnID="Ordering" DataField="Ordering" Sortable="false"
                                HeaderText="排序" />
                            <x:BoundField Width="150px" ColumnID="Remark" DataField="Remark" Sortable="false"
                                HeaderText="备注" />
                            <x:WindowField TextAlign="Center" Width="60px" WindowID="menuWin" Icon="Pencil" ToolTip="编辑"
                                DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmModifyMenu.aspx?id={0}"
                                Hideable="false" DataWindowTitleFormatString="编辑-{0}" DataWindowTitleField="Text" />
                            <x:LinkButtonField TextAlign="Center" Width="60px" Icon="Delete" ToolTip="删除" ConfirmText="确认删除吗？"
                                Hideable="false" CommandName="delete" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="menuWin" runat="server" Popup="false" IsModal="true" Target="Self"
        EnableMaximize="true" EnableResize="true" EnableIFrame="true" Icon="Add" Width="500px"
        Height="420px">
    </x:Window>
    </form>
</body>
</html>
