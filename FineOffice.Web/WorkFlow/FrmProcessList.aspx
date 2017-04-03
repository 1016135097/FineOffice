<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmProcessList.aspx.cs" Inherits="WorkFlow_FrmProcessList" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmProcessList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:RegionPanel ID="pnlMain" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="pnlFind" ShowHeader="true" Layout="VBox" Margins="0 0 0 0" Position="Center"
                Title="流程节点" EnableBackgroundColor="true" ShowBorder="false" runat="server" IconUrl="../icon/task.gif">
                <Items>
                    <x:Form ID="frmFind" ShowBorder="False" BodyPadding="5px" ShowHeader="False" runat="server"
                        EnableBackgroundColor="true">
                        <Rows>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:TwinTriggerBox runat="server" ShowLabel="false" ID="ttbSearch" Width="200" ShowTrigger1="false"
                                        Trigger1Icon="Clear" Trigger2Icon="Search">
                                    </x:TwinTriggerBox>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                    <x:Panel ID="pnlProcess" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                        runat="server">
                        <Toolbars>
                            <x:Toolbar ID="tsbMain" runat="server">
                                <Items>
                                    <x:Button ID="btnRefresh" Icon="ArrowRefresh" Text="刷新" OnClick="btnRefresh_Click"
                                        runat="server" />
                                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                                    <x:Button ID="btnAuthority" Icon="User" Text="经办权限" runat="server" OnClick="btnAuthority_Click" />
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Items>
                            <x:Grid ID="processGrid" Title="流程步聚" PageSize="20" ShowBorder="false" AllowPaging="true"
                                AllowSorting="true" OnPageIndexChange="processGrid_PageIndexChange" ShowHeader="False"
                                EnableCheckBoxSelect="true" EnableMultiSelect="false" EnableRowSelect="true"
                                IsDatabasePaging="true" runat="server" DataKeyNames="ID,ProcessName,IsEnd" SortColumn="ProcessName"
                                OnRowSelect="processGrid_RowSelect" SortDirection="ASC" OnSort="processGrid_Sort"
                                EnableRowNumber="True">
                                <Columns>
                                    <x:BoundField Width="200px" ColumnID="ProcessName" SortField="ProcessName" DataField="ProcessName"
                                        HeaderText="步骤名称" />
                                    <x:BoundField Width="200px" ColumnID="FlowName" SortField="FlowName" DataField="FlowName"
                                        HeaderText="流程名称" />
                                    <x:CheckBoxField Width="80px" ColumnID="IsStart" SortField="IsStart" TextAlign="Center"
                                        RenderAsStaticField="true" DataField="IsStart" HeaderText="开始步骤" />
                                    <x:CheckBoxField Width="80px" ColumnID="IsEnd" SortField="IsEnd" TextAlign="Center"
                                        RenderAsStaticField="true" DataField="IsEnd" HeaderText="结束步聚" />
                                    <x:BoundField Width="200px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                        HeaderText="备注" />
                                </Columns>
                            </x:Grid>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Region>
            <x:Region ID="pnlForm" Split="true" EnableSplitTip="true" CollapseMode="Default"
                EnableBackgroundColor="true" Height="280" Margins="0 0 0 0" ShowHeader="true"
                Title="流程表单" EnableLargeHeader="false" Icon="Table" EnableCollapse="true" Position="Bottom"
                Layout="Fit" runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbForm" runat="server">
                        <Items>
                            <x:Button ID="btnAdd" Icon="Add" Text="新增" runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDelelte" Icon="Delete" Text="删除" runat="server" OnClick="btnDelete_Click" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="formGrid" Title="流程表单" PageSize="20" ShowBorder="false" AllowPaging="true"
                        AllowSorting="true" OnPageIndexChange="formGrid_PageIndexChange" ShowHeader="False"
                        IsDatabasePaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,FormNO"
                        SortColumn="FormNO" SortDirection="ASC" OnSort="formGrid_Sort" EnableRowNumber="True">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="FormNO" SortField="FormNO" DataField="FormNO"
                                HeaderText="表单编码" />
                            <x:BoundField Width="100px" ColumnID="FormName" SortField="FormName" DataField="FormName"
                                HeaderText="表单名称" />
                            <x:BoundField Width="100px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                HeaderText="备注" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Region>
        </Regions>
    </x:RegionPanel>
    <x:Window ID="formListWin" Title="流程表单-选择" Popup="false" EnableMaximize="true" Target="Top"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    <x:Window ID="processAuthorityWin" Title="经办权限" Popup="false" EnableMaximize="true"
        IsModal="false" Target="Parent" EnableResize="true" runat="server" Icon="User"
        Width="475px" Height="420px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:HiddenField ID="hiddenForm" runat="server" />
    <x:HiddenField ID="hiddenProcess" runat="server" />
    </form>
</body>
</html>
