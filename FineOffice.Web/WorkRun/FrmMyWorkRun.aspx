<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmMyWorkRun.aspx.cs" Inherits="WorkRun_FrmMyWorkRun" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="frmRunProcess" runat="server">
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
                                    <x:TextBox ID="txtWorkNO" runat="server" Width="118px" />
                                    <x:Label ID="lblWorkName" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="工作名称：" />
                                    <x:TextBox ID="txtWorkName" runat="server" Width="118px" />
                                    <x:Label ID="lblSort" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="流程类别：" />
                                    <x:DropDownList ID="ddlSort" runat="server" Width="113px" />
                                    <x:Label ID="lblCreateTime" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="发起日期：" />
                                    <x:DatePicker ID="dtpBegin" Width="90px" runat="server" />
                                    <x:Label ID="lblSplit" runat="server" ShowLabel="false" Text="到" CssClass="inline" />
                                    <x:DatePicker ID="dtpEnd" Width="90px" runat="server" />
                                    <x:Button ID="btnClear" Text="清空" CssClass="btnline" runat="server" OnClick="btnClear_Click" />
                                    <x:Button ID="btnFind" Icon="Find" Text="过虑" CssClass="btninline" runat="server"
                                        OnClick="btnFind_Click" />
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
                    <x:Grid ID="flowGrid" Title="我的工作" PageSize="20" ShowBorder="false" AllowPaging="true"
                        AllowSorting="true" OnPageIndexChange="flowGrid_PageIndexChange" ShowHeader="False"
                        IsDatabasePaging="true" EnableMultiSelect="false" runat="server" EnableCheckBoxSelect="True"
                        DataKeyNames="ID,FlowID,WorkName" SortColumn="CreateTime" SortDirection="DESC"
                        OnSort="flowGrid_Sort" EnableRowNumber="True">
                        <Columns>
                            <x:BoundField Width="150px" ColumnID="WorkNO" SortField="WorkNO" DataField="WorkNO"
                                HeaderText="工作编号" />
                            <x:BoundField Width="150px" ColumnID="WorkName" SortField="WorkName" DataField="WorkName"
                                HeaderText="工作标题" />
                            <x:BoundField Width="150px" ColumnID="CreateTime" SortField="CreateTime" DataField="CreateTime"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="创建时间" />
                            <x:BoundField Width="150px" ColumnID="ProcessName" SortField="ProcessName" DataField="ProcessName"
                                HeaderText="当前步骤" />
                            <x:BoundField Width="150px" ColumnID="FlowName" SortField="FlowName" DataField="FlowName"
                                HeaderText="流程名称" />
                            <x:BoundField Width="100px" ColumnID="FlowSortName" SortField="FlowSortName" DataField="FlowSortName"
                                HeaderText="流程分类" />
                            <x:CheckBoxField Width="60px" ColumnID="IsEnd" SortField="IsEnd" TextAlign="Center"
                                RenderAsStaticField="true" DataField="IsEnd" HeaderText="是否完成" />
                            <x:WindowField TextAlign="Center" Width="60px" WindowID="frmFlowRunDetail" Icon="EmailOpen"
                                ToolTip="流程事件" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmFlowRunEvent.aspx?RunID={0}"
                                Hideable="false" Title="流程事件" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="frmFlowRunDetail" Title="流程事件" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="EmailOpen"
        Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    </form>
    <script type="text/javascript">
        //调用服务端
        function refreshData() {
            __doPostBack('<%=this.btnRefresh.UniqueID%>', '');
        }
    </script>
</body>
</html>
