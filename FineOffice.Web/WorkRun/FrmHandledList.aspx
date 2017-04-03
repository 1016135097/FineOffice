<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmHandledList.aspx.cs" Inherits="WorkRun_FrmHandledList" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="_FrmHandledList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="false" ShowBorder="false" ShowHeader="false" Layout="VBox"
        BoxConfigAlign="Stretch">
        <Items>
            <x:Panel ID="pnl_search" runat="server" ShowHeader="false" EnableLargeHeader="false"
                ShowBorder="false" EnableBackgroundColor="true">
                <Items>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="条件过滤" ID="groupPanel" Width="1000px"
                        EnableCollapse="True" AutoScroll="true">
                        <Items>
                            <x:Panel ID="pnlRow1" ShowHeader="false" CssClass="x-form-item" ShowBorder="false"
                                Layout="Column" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                                AutoScroll="true">
                                <Items>
                                    <x:Label ID="lblWorkNO" Width="60px" runat="server" CssClass="inline" ShowLabel="false"
                                        Text="工作编号：" />
                                    <x:TextBox ID="txtWorkNO" runat="server" Width="118px" />
                                    <x:Label ID="lblWorkName" Width="60px" runat="server" CssClass="inline" ShowLabel="false"
                                        Text="工作名称：" />
                                    <x:TextBox Width="118px" ID="txtWorkName" runat="server" />
                                    <x:Label ID="lblSort" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="流程类别：" />
                                    <x:DropDownList Width="113px" ID="ddlSort" runat="server" />
                                    <x:HiddenField ID="hiddenField" runat="server" />
                                    <x:Label ID="lblCreator" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="发&nbsp;&nbsp;起&nbsp;人：" />
                                    <x:TextBox ID="txtCreator" runat="server" Readonly="true" Width="118px" />
                                    <x:Button ID="btnChoose" Text="选择" runat="server" />
                                </Items>
                            </x:Panel>
                            <x:Panel ID="pnlRow2" ShowHeader="false" CssClass="x-form-item" ShowBorder="false"
                                Layout="Column" runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                <Items>
                                    <x:Label ID="lblCreateDate" runat="server" Width="60px" CssClass="inline" ShowLabel="false"
                                        Text="发起时间：" />
                                    <x:DatePicker ID="dtpBegin" Width="90px" runat="server" />
                                    <x:Label ID="lblSplit" runat="server" ShowLabel="false" Text="到" CssClass="inline" />
                                    <x:DatePicker ID="dtpEnd" Width="90px" runat="server" />
                                    <x:Button ID="btnClear" CssClass="btnline" Text="清空" runat="server" OnClick="btnClear_Click" />
                                    <x:Button ID="btnFind" CssClass="notline" Text="过滤" runat="server" Icon="Find" OnClick="btnFind_Click" />
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:GroupPanel>
                </Items>
            </x:Panel>
            <x:Panel ID="pnlData" ShowBorder="true" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <x:Button ID="btnRefresh" Icon="ArrowRefresh" Text="刷新" runat="server" OnClick="btnRefresh_Click" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="workGrid" Title="已办工作" DataKeyNames="ID,WorkName,ProcessName" PageSize="20"
                        IsDatabasePaging="true" ShowBorder="false" AllowPaging="true" AllowSorting="true"
                        OnPageIndexChange="workGrid_PageIndexChange" ShowHeader="False" EnableMultiSelect="false"
                        runat="server" EnableCheckBoxSelect="True" SortColumn="AcceptTime" SortDirection="ASC"
                        OnSort="workGrid_Sort" EnableRowNumber="True" OnRowCommand="workGrid_RowCommand">
                        <Columns>
                            <x:BoundField Width="150px" ColumnID="WorkNO" SortField="WorkNO" DataField="WorkNO"
                                HeaderText="工作编号" />
                            <x:BoundField Width="150px" ColumnID="WorkName" SortField="WorkName" DataField="WorkName"
                                HeaderText="工作标题" />
                            <x:BoundField Width="100px" ColumnID="FlowSortName" SortField="FlowSortName" DataField="FlowSortName"
                                HeaderText="流程分类" />
                            <x:BoundField Width="100px" ColumnID="HandleEvent" SortField="HandleEvent" DataField="HandleEvent"
                                HeaderText="操作" />
                            <x:BoundField Width="150px" ColumnID="ProcessName" SortField="ProcessName" DataField="ProcessName"
                                HeaderText="步骤" />
                            <x:BoundField Width="150px" ColumnID="AcceptTime" SortField="AcceptTime" DataField="AcceptTime"
                                DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="接收时间" />
                            <x:BoundField Width="100px" ColumnID="CreateName" SortField="CreateName" DataField="CreateName"
                                HeaderText="发起人" />
                            <x:BoundField Width="150px" ColumnID="WorkCreateTime" SortField="WorkCreateTime"
                                DataField="WorkCreateTime" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="发起时间" />
                            <x:LinkButtonField TextAlign="Center" Icon="EmailOpen" CommandName="handle" Width="60px"
                                ToolTip="工作详情" Hideable="false" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="frmPersonnel" Title="发起人" Popup="false" EnableMaximize="true" Target="Top"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
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
