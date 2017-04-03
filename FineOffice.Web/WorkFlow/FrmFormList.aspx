<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmFormList.aspx.cs" Inherits="WorkFlow_FrmFormList" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <script src="../js/common.js" type="text/javascript"></script>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmFormList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="regionPanel" runat="server" />
    <x:RegionPanel ID="regionPanel" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="pnlLeft" Split="true" EnableSplitTip="true" CollapseMode="Default"
                Width="200px" Margins="0 0 0 0" ShowHeader="true" Title="表单分类" EnableLargeHeader="false"
                Icon="Outline" EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                <Toolbars>
                    <x:Toolbar ID="toolbar" Position="Top" runat="server">
                        <Items>
                            <x:Button ID="btnExpandAll" Icon="Folder" Text="展开" OnClick="btnExpandAll_Click"
                                runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnCollapseAll" Icon="FolderUp" Text="收起" OnClick="btnCollapseAll_Click"
                                runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnRefresh" Icon="ArrowRefresh" Text="刷新" OnClick="btnRefresh_Click"
                                runat="server" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Tree runat="server" ID="tvwSort" EnableArrows="true" AutoScroll="true" EnableIcons="false"
                        OnNodeCommand="tvwSort_NodeCommand" Expanded="true" ShowHeader="false" ShowBorder="true">
                    </x:Tree>
                </Items>
            </x:Region>
            <x:Region ID="pnlRight" ShowHeader="false" Layout="Fit" Margins="0 0 0 0" Position="Center"
                runat="server">
                <Items>
                    <x:Panel ID="pnlFind" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                        Title="表单管理" EnableLargeHeader="false" ShowBorder="false" ShowHeader="true" Layout="VBox"
                        BoxConfigAlign="Stretch">
                        <Items>
                            <x:Form ID="frmFind" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                                ShowHeader="False" runat="server">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TwinTriggerBox runat="server" ID="ttbSearch" ShowLabel="false" Width="200" ShowTrigger1="false"
                                                OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                                                Trigger1Icon="Clear" Trigger2Icon="Search">
                                            </x:TwinTriggerBox>
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                            <x:Panel ID="pnlForm" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                                runat="server">
                                <Toolbars>
                                    <x:Toolbar ID="tsbMain" runat="server">
                                        <Items>
                                            <x:Button ID="btnNew" Icon="Add" Text="新增" runat="server" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnDesign" Icon="PageWord" Text="表单设计" runat="server" OnClick="btnDesign_Click" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnSelectAll" Icon="ArrowIn" Text="全选" runat="server" OnClick="btnSelectAll_Click" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnDelete" Icon="Delete" Text="删除" runat="server" OnClick="btnDelete_Click" />
                                        </Items>
                                    </x:Toolbar>
                                </Toolbars>
                                <Items>
                                    <x:Grid ID="formGrid" Title="表单管理" PageSize="20" ShowBorder="false" AllowPaging="true"
                                        IsDatabasePaging="true" AllowSorting="true" OnPageIndexChange="formGrid_PageIndexChange"
                                        ShowHeader="False" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,FormName"
                                        SortColumn="FormNO" SortDirection="ASC" OnSort="formGrid_Sort" EnableRowNumber="True"
                                        OnRowCommand="formGrid_RowCommand">
                                        <Columns>
                                            <x:BoundField Width="100px" ColumnID="FormNO" SortField="FormNO" DataField="FormNO"
                                                HeaderText="表单编码" />
                                            <x:BoundField Width="100px" ColumnID="FormName" SortField="FormName" DataField="FormName"
                                                HeaderText="表单名称" />
                                            <x:BoundField Width="100px" ColumnID="PinyinCode" SortField="PinyinCode" DataField="PinyinCode"
                                                HeaderText="拼音码" />
                                            <x:BoundField Width="100px" ColumnID="FormTypeName" SortField="FormTypeName" DataField="FormTypeName"
                                                HeaderText="表单类别" />
                                            <x:BoundField Width="100px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                                HeaderText="备注" />
                                            <x:CheckBoxField Width="60px" ColumnID="Stop" SortField="Stop" TextAlign="Center"
                                                RenderAsStaticField="true" DataField="Stop" HeaderText="是否可用" />
                                            <x:WindowField TextAlign="Center" WindowID="modifyFormWin" Width="60px" Icon="Pencil"
                                                ColumnID="btnModify" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmModifyForm.aspx?id={0}"
                                                Title="编辑表单" Hideable="false" />
                                            <x:LinkButtonField TextAlign="Center" Icon="Delete" Width="60px" ColumnID="btnDelete"
                                                ConfirmText="确认删除吗？" CommandName="delete" Hideable="false" />
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
    <x:Window ID="newFormWin" Title="新增" Popup="false" IFrameUrl="FrmNewForm.aspx" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Add"
        Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyFormWin" Title="编辑" Popup="false" EnableMaximize="true" IsModal="false"
        Target="Parent" EnableResize="true" runat="server" Icon="Pencil" Width="500px"
        Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete","btnDesign"]'
        runat="server" />
    </form>
</body>
</html>
