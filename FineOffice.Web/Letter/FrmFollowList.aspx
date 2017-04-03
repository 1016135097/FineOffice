<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmFollowList.aspx.cs" Inherits="Letter_FrmFollowList" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="_FrmFollowList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:RegionPanel ID="pnlMain" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="pnlFollow" ShowHeader="true" Layout="VBox" Margins="0 0 0 0" Position="Center"
                Title="跟进情况" EnableBackgroundColor="true" ShowBorder="false" runat="server" Icon="BookAdd">
                <Items>
                    <x:Panel ID="pnlFind" runat="server" ShowHeader="false" EnableLargeHeader="false"
                        ShowBorder="false" EnableBackgroundColor="true">
                        <Items>
                            <x:Panel ID="pnlRow1" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="x-form-item datecontainer"
                                runat="server" EnableBackgroundColor="true" BodyPadding="5px">
                                <Items>
                                    <x:Label ID="lblLinkman" runat="server" Width="60px" CssClass="inline" ShowLabel="false"
                                        Text="联&nbsp;&nbsp;系&nbsp;人：" />
                                    <x:TextBox ID="txtLinkman" runat="server" Width="118px" />
                                    <x:Label ID="lblMoblie" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="联系方式：" />
                                    <x:TextBox ID="txtMoblie" runat="server" Width="118px" />
                                    <x:Label ID="lblHandleDate" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="信访日期：" />
                                    <x:DatePicker ID="dtpBeginDate" Width="90px" runat="server" />
                                    <x:Label ID="lblSplit" runat="server" ShowLabel="false" Text="到" CssClass="inline" />
                                    <x:DatePicker ID="dtpEndDate" Width="90px" runat="server" />
                                    <x:Label ID="lblHandler" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="处&nbsp;&nbsp;理&nbsp;人：" />
                                    <x:TextBox ID="txtHandler" Width="118px" runat="server" Readonly="true" />
                                    <x:Button ID="btnHandler" Text="选择" runat="server" />
                                    <x:Button ID="btnClear" Text="清空" CssClass="btnline" runat="server" OnClick="btnClear_Click" />
                                    <x:Button ID="btnFind" Text="过虑" CssClass="btninline" Icon="Find" runat="server"
                                        OnClick="btnFind_Click" />
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="pnlGrid" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                        runat="server">
                        <Toolbars>
                            <x:Toolbar ID="tsbMain" runat="server">
                                <Items>
                                    <x:Button ID="btnNewFollow" Icon="Add" Text="新增" runat="server" />
                                    <x:ToolbarSeparator runat="server" />
                                    <x:Button ID="btnModifyFollow" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModifyFollow_Click" />
                                    <x:ToolbarSeparator runat="server" />
                                    <x:Button ID="btnDelelteFollow" Icon="Delete" Text="删除" runat="server" OnClick="btnDeleteFollow_Click" />
                                    <x:ToolbarSeparator runat="server" />
                                    <x:Button ID="btnRefreshFollow" Icon="ArrowRefresh" Text="刷新" OnClick="btnRefreshFollow_Click"
                                        runat="server" />
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Items>
                            <x:Grid ID="grdFollow" PageSize="20" ShowBorder="false" AllowPaging="true" AllowSorting="true"
                                EnableCheckBoxSelect="true" EnableMultiSelect="false" EnableRowSelect="true"
                                ShowHeader="False" OnRowSelect="grdFollow_RowSelect" OnPageIndexChange="grdFollow_PageIndexChange"
                                OnSort="grdFollow_Sort" runat="server" DataKeyNames="ID" SortColumn="HandleTime"
                                SortDirection="ASC" EnableRowNumber="True">
                                <Columns>
                                    <x:BoundField Width="100px" ColumnID="Linkman" SortField="Linkman" DataField="Linkman"
                                        HeaderText="联系人" />
                                    <x:BoundField Width="100px" ColumnID="Mobile" SortField="Mobile" DataField="Mobile"
                                        HeaderText="联系方式" />
                                    <x:BoundField Width="200px" ColumnID="Matter" SortField="Matter" DataField="Matter"
                                        HeaderText="跟进内容" />
                                    <x:BoundField Width="200px" ColumnID="Result" SortField="Result" DataField="Result"
                                        HeaderText="跟进结果" />
                                    <x:BoundField Width="180px" ColumnID="HandleTime" SortField="HandleTime" DataField="HandleTime"
                                        DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="处理时间" />
                                    <x:BoundField Width="100px" ColumnID="HandlerName" SortField="HandlerName" DataField="HandlerName"
                                        HeaderText="处理人" />
                                </Columns>
                            </x:Grid>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Region>
            <x:Region ID="pnlAttachment" Split="true" EnableSplitTip="true" CollapseMode="Default"
                EnableBackgroundColor="true" Height="280" Margins="0 0 0 0" ShowHeader="true"
                Title="附件" EnableLargeHeader="false" Icon="FolderPage" EnableCollapse="true"
                Position="Bottom" Layout="Fit" runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbForm" runat="server">
                        <Items>
                            <x:Button ID="btnUpload" Icon="ArrowUp" Text="上传附件" runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnModifyFileName" Icon="ApplicationEdit" Text="编辑文件名" OnClick="btnModifyFileName_Click"
                                runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDeleteAttach" Icon="Delete" Text="删除" runat="server" OnClick="btnDeleteAttach_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnRefreshAttach" Icon="ArrowRefresh" Text="刷新" OnClick="btnRefreshAttach_Click"
                                runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnTransfer" Icon="DiskDownload" Text="转存" runat="server" OnClick="btnTransferAttach_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDownAttachment" Icon="DriveDisk" EnableAjax="false" Text="下载" OnClick="btnDownAttach_Click"
                                DisableControlBeforePostBack="false" runat="server" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="grdAttachment" Title="公共附件" PageSize="10" ShowBorder="false" AllowPaging="true"
                        AllowSorting="true" OnPageIndexChange="grdAttachment_PageIndexChange" ShowHeader="False"
                        EnableMultiSelect="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,FileName"
                        SortColumn="CreateTime" IsDatabasePaging="true" SortDirection="ASC" OnSort="grdAttachment_Sort"
                        EnableRowNumber="True" OnRowCommand="grdAttachment_RowCommand">
                        <Columns>
                            <x:BoundField Width="200px" ColumnID="FileName" SortField="FileName" DataField="FileName"
                                HeaderText="文件名" />
                            <x:BoundField Width="100px" ColumnID="size" SortField="Size" DataField="Size" HeaderText="大小" />
                            <x:BoundField Width="150px" ColumnID="PersonnelName" SortField="PersonnelName" DataField="PersonnelName"
                                HeaderText="创建人" />
                            <x:BoundField Width="150px" ColumnID="CreateTime" SortField="CreateTime" DataField="CreateTime"
                                HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd}" />
                            <x:LinkButtonField TextAlign="Center" Icon="Delete" ConfirmText="确认删除吗？" Width="50px"
                                ToolTip="删除" CommandName="delete" Hideable="false" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Region>
        </Regions>
    </x:RegionPanel>
    <x:HiddenField ID="hiddenHandler" runat="server" />
    <x:Window ID="wndHandler" Title="处理人" Popup="false" EnableMaximize="true" Target="Top"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    <x:Window ID="wndNewFollow" Title="新增" Popup="false" EnableMaximize="true" Target="Top"
        IsModal="true" EnableResize="true" runat="server" Icon="BookAdd" Width="550px"
        Height="400px" EnableIFrame="true">
    </x:Window>
    <x:Window ID="wndModifyFollow" Title="编辑" Popup="false" EnableMaximize="true" Target="Top"
        IsModal="true" EnableResize="true" runat="server" Icon="BookAdd" Width="550px"
        Height="400px" EnableIFrame="true">
    </x:Window>
    <x:Window ID="wndAttachment" Title="上传附件" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="FolderPage" Width="500px"
        Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="wndModifyAttachName" Title="编辑文件名" Popup="false" EnableMaximize="false"
        IsModal="true" Target="Parent" EnableResize="false" runat="server" Icon="ApplicationEdit"
        Width="420px" Height="120px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:HiddenField ID="hiddenLetterID" runat="server" />
    <x:HiddenField ID="hiddenTabID" runat="server" />
    </form>
    <script type="text/javascript">
        //刷新附件
        function refreshAttach() {
            __doPostBack('<%=this.btnRefreshAttach.UniqueID%>', "");
        }
    </script>
</body>
</html>
