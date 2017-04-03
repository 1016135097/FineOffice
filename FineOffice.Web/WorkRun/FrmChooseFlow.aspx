<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmChooseFlow.aspx.cs" Inherits="WorkRun_FrmChooseFlow" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="_FrmChooseFlow" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:RegionPanel ID="pnlMain" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="pnlLeft" Split="true" EnableSplitTip="true" CollapseMode="Default"
                Width="200px" Margins="0 0 0 0" ShowHeader="true" Title="流程分类" EnableLargeHeader="false"
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
                    <x:Panel ID="pnlFlow" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                        EnableLargeHeader="false" Title="流程列表" ShowBorder="false" ShowHeader="True" Layout="VBox"
                        BoxConfigAlign="Stretch">
                        <Items>
                            <x:Panel ID="pnlSearch" runat="server" ShowHeader="false" EnableLargeHeader="false"
                                ShowBorder="false" EnableBackgroundColor="true">
                                <Items>
                                    <x:GroupPanel runat="server" AutoHeight="true" Title="条件过滤" ID="groupPanel" EnableCollapse="True"
                                        Width="1000px">
                                        <Items>
                                            <x:Panel ID="pnlRow1" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="x-form-item datecontainer"
                                                runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                                <Items>
                                                    <x:Label ID="lblFlowName" runat="server" Width="60px" CssClass="inline" ShowLabel="false"
                                                        Text="流程名称：" />
                                                    <x:TextBox ID="txtFlowName" Width="118px" runat="server" />
                                                    <x:Label ID="lblFlowDesc" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                                        Text="流程描述：" />
                                                    <x:TextBox ID="txtFlowDesc" runat="server" Width="118px" />
                                                    <x:Button ID="btnFind" Text="过滤" CssClass="btnline" runat="server" Icon="Find" OnClick="btnFind_Click" />
                                                </Items>
                                            </x:Panel>
                                        </Items>
                                    </x:GroupPanel>
                                </Items>
                            </x:Panel>
                            <x:Panel ID="pnlData" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                                runat="server">
                                <Toolbars>
                                    <x:Toolbar ID="tsbMain" runat="server">
                                        <Items>
                                            <x:Button ID="btnRefreshFlow" Icon="ArrowRefresh" Text="刷新" runat="server" OnClick="btnRefreshFlow_Click" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnFlowProcess" Icon="ArrowSwitch" Text="查看流程" runat="server" OnClick="btnFlowProcess_Click" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnTask" Icon="PageWhiteAdd" Text="新建工作" runat="server" OnClick="btnTask_Click" />
                                        </Items>
                                    </x:Toolbar>
                                </Toolbars>
                                <Items>
                                    <x:Grid ID="flowGrid" Title="工作流程" PageSize="20" ShowBorder="false" AllowPaging="true"
                                        AllowSorting="true" OnPageIndexChange="flowGrid_PageIndexChange" ShowHeader="False"
                                        IsDatabasePaging="true" EnableMultiSelect="false" runat="server" EnableCheckBoxSelect="True"
                                        DataKeyNames="ID,FlowNO,FlowName" SortColumn="FlowNO" SortDirection="ASC" OnSort="flowGrid_Sort"
                                        EnableRowNumber="True">
                                        <Columns>
                                            <x:BoundField Width="100px" ColumnID="FlowNO" SortField="FlowNO" DataField="FlowNO"
                                                HeaderText="流程编码" />
                                            <x:BoundField Width="100px" ColumnID="FlowName" SortField="FlowName" DataField="FlowName"
                                                HeaderText="流程名称" />
                                            <x:BoundField Width="100px" ColumnID="PinyinCode" SortField="PinyinCode" DataField="PinyinCode"
                                                HeaderText="拼音码" />
                                            <x:BoundField Width="100px" ColumnID="Version" SortField="Version" DataField="Version"
                                                HeaderText="版本" />
                                            <x:BoundField Width="100px" ColumnID="FlowDesc" SortField="FlowDesc" DataField="FlowDesc"
                                                HeaderText="流程描述" />
                                            <x:BoundField Width="100px" ColumnID="FlowSortName" SortField="FlowSortName" DataField="FlowSortName"
                                                HeaderText="流程分类" />
                                            <x:BoundField Width="100px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                                HeaderText="备注" />
                                            <x:BoundField Width="100px" ColumnID="CreateDate" SortField="CreateDate" DataField="CreateDate"
                                                DataFormatString="{0:yyyy-MM-dd}" HeaderText="创建日期" />
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
    <x:Window ID="newWorkWin" Title="新建工作" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="Add" Width="500px" Height="300px"
        EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnTask"]' runat="server" />
    </form>
</body>
</html>
