<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmAttachmentTransfer.aspx.cs"
    Inherits="WorkRun_FrmAttachmentTransfer" %>

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
    <form id="_FrmAttachmentTransfer" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="false" Title="工作附件" ShowBorder="false" ShowHeader="false"
        Layout="VBox" BoxConfigAlign="Stretch">
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
                                    <x:Label ID="lblWorkName" Width="60px" runat="server" CssClass="inline" ShowLabel="false"
                                        Text="工作编号：" />
                                    <x:TextBox Width="118px" ID="txtWorkName" runat="server" />
                                    <x:Label ID="lblSort" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="流程类别：" />
                                    <x:DropDownList Width="115px" ID="ddlSort" runat="server" />
                                    <x:Label ID="lblCreator" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="发起人：" />
                                    <x:HiddenField ID="hiddenField" runat="server" />
                                    <x:TextBox ID="txtCreator" Width="118px" runat="server" Label="发起人" Readonly="true" />
                                    <x:Button ID="btnChoose" Text="选择" runat="server" />
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
            <x:Panel ID="pnlAttachment" ShowBorder="true" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <x:Button ID="btnTransfer" Icon="DiskDownload" Text="转存" runat="server" OnClick="btnTransfer_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDownAttachment" Icon="DriveDisk" EnableAjax="false" Text="下载" DisableControlBeforePostBack="false"
                                runat="server" OnClick="btnDownAttachment_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnRefresh" Icon="ArrowRefresh" Text="刷新" runat="server" OnClick="btnRefresh_Click" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="attachmentGrid" Title="附件" DataKeyNames="ID,WorkName,ProcessName" PageSize="20"
                        IsDatabasePaging="true" OnRowCommand="attachmentGrid_RowCommand" ShowBorder="false"
                        AllowPaging="true" AllowSorting="true" OnPageIndexChange="attachmentGrid_PageIndexChange"
                        ShowHeader="False" EnableMultiSelect="false" runat="server" EnableCheckBoxSelect="True"
                        SortColumn="CreateTime" SortDirection="ASC" OnSort="attachmentGrid_Sort" EnableRowNumber="True">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="FileName" SortField="FileName" DataField="FileName"
                                HeaderText="表单标题" />
                            <x:BoundField Width="100px" ColumnID="ProcessName" SortField="ProcessName" DataField="ProcessName"
                                HeaderText="创建步骤" />
                            <x:BoundField Width="100px" ColumnID="PersonnelName" SortField="PersonnelName" DataField="PersonnelName"
                                HeaderText="创建人" />
                            <x:BoundField Width="100px" ColumnID="CreateTime" SortField="CreateTime" DataField="CreateTime"
                                HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd}" />
                            <x:BoundField Width="150px" ColumnID="WorkNO" SortField="WorkNO" DataField="WorkNO"
                                HeaderText="工作编号" />
                            <x:BoundField Width="150px" ColumnID="WorkName" SortField="WorkName" DataField="WorkName"
                                HeaderText="工作标题" />
                            <x:BoundField Width="100px" ColumnID="CreateName" SortField="CreateName" DataField="CreateName"
                                HeaderText="发起人" />
                            <x:BoundField Width="150px" ColumnID="WorkCreateTime" SortField="WorkCreateTime"
                                DataField="WorkCreateTime" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="发起时间" />
                            <x:BoundField Width="100px" ColumnID="FlowSortName" SortField="FlowSortName" DataField="FlowSortName"
                                HeaderText="流程分类" />
                            <x:LinkButtonField TextAlign="Center" Icon="Delete" ConfirmText="确认删除吗？" Width="50px"
                                ColumnID="btnDelete" CommandName="delete" Hideable="false" />
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
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnTransfer","btnDownAttachment","btnDelete"]'
        runat="server" />
</body>
</html>
