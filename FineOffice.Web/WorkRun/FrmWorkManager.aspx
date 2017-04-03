<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmWorkManager.aspx.cs" Inherits="WorkRun_FrmWorkManager" %>

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
    <form id="_FrmWorkManager" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="false" ShowBorder="false" ShowHeader="false" Layout="VBox"
        BoxConfigAlign="Stretch">
        <Items>
            <x:Panel ID="pnl_search" runat="server" ShowHeader="false" EnableLargeHeader="false"
                ShowBorder="false" EnableBackgroundColor="true">
                <Items>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="条件过滤" ID="groupPanel" Width="1000px"
                        EnableCollapse="True">
                        <Items>
                            <x:Panel ID="pnlRow1" ShowHeader="false" CssClass="x-form-item" ShowBorder="false"
                                Layout="Column" runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                <Items>
                                    <x:Label ID="lblWorkNO" Width="60px" runat="server" CssClass="inline" ShowLabel="false"
                                        Text="工作编号：" />
                                    <x:TextBox Width="118px" ID="txtWorkNO" runat="server" />
                                    <x:Label ID="lblWorkName" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="工作编号：" />
                                    <x:TextBox Width="118px" ID="txtWorkName" runat="server" />
                                    <x:Label ID="lblSort" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="流程类别：" />
                                    <x:DropDownList Width="113px" ID="ddlSort" runat="server" />
                                    <x:Label ID="lblCreateDate" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="发起时间：" />
                                    <x:DatePicker ID="dtpBegin" Width="90px" runat="server" />
                                    <x:Label ID="lblSplit" runat="server" ShowLabel="false" Text="到" CssClass="inline" />
                                    <x:DatePicker ID="dtpEnd" Width="90px" runat="server" />
                                    <x:Button ID="btnClear" Text="清空" runat="server" CssClass="btnline" OnClick="btnClear_Click" />
                                    <x:Button ID="btnFind" Text="过滤" runat="server" Icon="Find" OnClick="btnFind_Click" />
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:GroupPanel>
                </Items>
            </x:Panel>
            <x:Panel ID="pnlWorkRun" ShowBorder="true" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <x:Button ID="btnRefresh" Icon="ArrowRefresh" Text="刷新" OnClick="btnRefresh_Click"
                                runat="server" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="workGrid" Title="工作管理" PageSize="20" ShowBorder="false" AllowPaging="true"
                        IsDatabasePaging="true" AllowSorting="true" OnPageIndexChange="workGrid_PageIndexChange"
                        EnableCheckBoxSelect="True" OnRowCommand="workGrid_RowCommand" EnableMultiSelect="false"
                        runat="server" ShowHeader="False" DataKeyNames="ID,FlowID,WorkName" SortColumn="CreateTime"
                        SortDirection="DESC" OnSort="workGrid_Sort" EnableRowNumber="True">
                        <Columns>
                            <x:BoundField Width="150px" ColumnID="WorkNO" SortField="WorkNO" DataField="WorkNO"
                                HeaderText="工作编号" />
                            <x:BoundField Width="150px" ColumnID="WorkName" SortField="WorkName" DataField="WorkName"
                                HeaderText="工作标题" />
                            <x:BoundField Width="150px" ColumnID="CreateTime" SortField="CreateTime" DataField="CreateTime"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="创建时间" />
                            <x:BoundField Width="150px" ColumnID="ProcessName" SortField="ProcessName" DataField="ProcessName"
                                HeaderText="当前步骤" />
                            <x:BoundField Width="100px" ColumnID="FlowName" SortField="FlowName" DataField="FlowName"
                                HeaderText="流程名称" />
                            <x:BoundField Width="100px" ColumnID="FlowSortName" SortField="FlowSortName" DataField="FlowSortName"
                                HeaderText="流程分类" />
                            <x:CheckBoxField Width="60px" ColumnID="IsEnd" TextAlign="Center" RenderAsStaticField="true"
                                HeaderText="是否完成" DataField="IsEnd" SortField="IsEnd" />
                            <x:WindowField TextAlign="Center" Width="60px" WindowID="flowRunDetailWin" Icon="EmailOpen"
                                ToolTip="流程事件" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmFlowRunEvent.aspx?RunID={0}"
                                Hideable="false" Title="流程事件" />
                            <x:LinkButtonField ColumnID="btnDelete" TextAlign="Center" Width="60px" Icon="Delete"
                                ConfirmText="将删除该工作的所有数据</br>确认删除吗？" CommandName="delete" Hideable="false" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="flowRunDetailWin" Title="流程事件" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="EmailOpen"
        Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnDelete"]' runat="server" />
    </form>
</body>
</html>
