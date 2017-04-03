<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmMyHardDisk.aspx.cs" Inherits="HardDisk_FrmMyHardDisk" %>

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
    <form id="_FrmMyHardDisk" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:RegionPanel ID="pnlMain" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="pnlLeft" Split="true" EnableSplitTip="true" CollapseMode="Default"
                Width="200px" Margins="0 0 0 0" ShowHeader="true" Title="文件夹" EnableLargeHeader="false"
                Icon="Outline" EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                <Toolbars>
                    <x:Toolbar ID="toolbar" Position="Top" runat="server">
                        <Items>
                            <x:Button ID="btnNewFolder" Icon="FolderAdd" Text="新建" runat="server" OnClick="btnNewFolder_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnModifyFolder" Icon="FolderEdit" Text="编辑" runat="server" OnClick="btnModifyFolder_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnExtends" EnablePostBack="false" Text="其他" runat="server">
                                <Menu runat="server">
                                    <x:MenuButton ID="btnDeleteFolder" Icon="FolderDelete" Text="删除" OnClick="btnDeleteFolder_Click"
                                        runat="server" />
                                    <x:MenuButton ID="btnMoveFolder" Icon="FolderGo" Text="移动文件夹" OnClick="btnMoveFolder_Click"
                                        runat="server" />
                                    <x:MenuSeparator runat="server" />
                                    <x:MenuButton ID="btnExpandAll" Icon="Folder" Text="展开" OnClick="btnExpandAll_Click"
                                        runat="server" />
                                    <x:MenuButton ID="btnCollapseAll" Icon="FolderUp" Text="收起" OnClick="btnCollapseAll_Click"
                                        runat="server" />
                                </Menu>
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Tree runat="server" ID="tvwFolder" EnableArrows="false" AutoScroll="true" EnableIcons="false"
                        Title="文件夹" OnNodeCommand="tvwFolder_NodeCommand" Expanded="true" ShowHeader="false"
                        ShowBorder="false">
                    </x:Tree>
                </Items>
            </x:Region>
            <x:Region ID="pnlRight" ShowHeader="true" Layout="Fit" Margins="0 0 0 0" Position="Center"
                Icon="Outline" Title="文件管理" runat="server">
                <Items>
                    <x:Panel ID="pnlLayout" runat="server" EnableBackgroundColor="true" BodyPadding="0px"
                        ShowHeader="false" EnableLargeHeader="false" ShowBorder="false" Layout="VBox"
                        BoxConfigAlign="Stretch">
                        <Items>
                            <x:Form ID="frmFind" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                                ShowHeader="False" runat="server">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:Panel ID="pnlFind" ShowHeader="false" CssClass="x-form-item" ShowBorder="false"
                                                Layout="Column" runat="server" EnableBackgroundColor="true">
                                                <Items>
                                                    <x:TwinTriggerBox runat="server" ID="ttbSearch" ShowLabel="false" Width="200" ShowTrigger1="false"
                                                        OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                                                        Trigger1Icon="Clear" Trigger2Icon="Search">
                                                    </x:TwinTriggerBox>
                                                    <x:Label ID="lblContainFolder" runat="server" Width="80px" CssClass="middleline"
                                                        ShowLabel="false" Text="包含子目录：" />
                                                    <x:CheckBox ID="chkContainFolder" Label="" runat="server" OnCheckedChanged="chkContainFolder_CheckedChanged"
                                                        AutoPostBack="true" />
                                                </Items>
                                            </x:Panel>
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                            <x:Panel ID="pnlFile" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                                runat="server">
                                <Toolbars>
                                    <x:Toolbar ID="tsbMain" runat="server">
                                        <Items>
                                            <x:Button ID="btnUpload" Icon="ArrowUp" OnClick="btnUpload_Click" Text="上传附件" runat="server" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnModifyFile" Icon="ApplicationEdit" OnClick="btnModifyFile_Click"
                                                Text="编辑文件名" runat="server" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnMoveFile" Icon="PageWhiteGo" OnClick="btnMoveFile_Click" Text="移动文件"
                                                runat="server" />
                                            <x:Button ID="btnCopy" EnablePostBack="false" Text="复制到" runat="server">
                                                <Menu runat="server">
                                                    <x:MenuButton ID="btnCopyToPerson" Icon="UserGo" Text="职员" OnClick="btnCopyToPerson_Click"
                                                        runat="server" />
                                                    <x:MenuButton ID="btnCopyToPublic" Icon="FolderGo" Text="共享硬盘" OnClick="btnCopyToPublic_Click"
                                                        runat="server" />
                                                </Menu>
                                            </x:Button>
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnDeleteFile" Icon="Delete" OnClick="btnDeleteFile_Click" Text="删除"
                                                runat="server" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnRefreshFile" Icon="ArrowRefresh" OnClick="btnRefreshFile_Click"
                                                Text="刷新" runat="server" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnDownFile" Icon="DriveDisk" EnableAjax="false" OnClick="btnDownFile_Click"
                                                Text="下载" DisableControlBeforePostBack="false" runat="server" />
                                        </Items>
                                    </x:Toolbar>
                                </Toolbars>
                                <Items>
                                    <x:Grid ID="fileGrid" Title="文件" PageSize="20" ShowBorder="false" ShowHeader="False"
                                        AllowSorting="true" EnableMultiSelect="True" runat="server" OnRowCommand="fileGrid_RowCommand"
                                        AllowPaging="true" EnableCheckBoxSelect="True" DataKeyNames="ID,FileName" SortColumn="CreateTime"
                                        IsDatabasePaging="true" SortDirection="ASC" EnableRowNumber="True" OnSort="fileGrid_Sort"
                                        OnPageIndexChange="fileGrid_PageIndexChange">
                                        <Columns>
                                            <x:BoundField Width="200px" ColumnID="FileName" SortField="FileName" DataField="FileName"
                                                HeaderText="文件名" />
                                            <x:BoundField Width="200px" ColumnID="FolderName" SortField="FolderName" DataField="FolderName"
                                                HeaderText="文件夹" />
                                            <x:BoundField Width="100px" ColumnID="size" SortField="Size" DataField="Size" HeaderText="大小" />
                                            <x:BoundField Width="150px" ColumnID="XTypeName" SortField="XTypeName" DataField="XTypeName"
                                                HeaderText="类型" />
                                            <x:BoundField Width="150px" ColumnID="SendName" SortField="SendName" DataField="SendName"
                                                HeaderText="发送人" />
                                            <x:BoundField Width="150px" ColumnID="SendTime" SortField="SendTime" DataField="SendTime"
                                                HeaderText="发送时间" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField Width="150px" ColumnID="PersonnelName" SortField="PersonnelName" DataField="PersonnelName"
                                                HeaderText="创建人" />
                                            <x:BoundField Width="150px" ColumnID="CreateTime" SortField="CreateTime" DataField="CreateTime"
                                                HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:LinkButtonField TextAlign="Center" Icon="Delete" ConfirmText="确认删除吗？" Width="50px"
                                                ToolTip="删除" CommandName="delete" Hideable="false" ConfirmTarget="Parent" />
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
    <x:Window ID="folderWin" Popup="false" EnableMaximize="false" IsModal="true" Target="Self"
        EnableResize="false" runat="server" Icon="Add" Width="420px" Height="120px" EnableConfirmOnClose="true"
        EnableIFrame="true">
    </x:Window>
    <x:Window ID="moveWin" Title="移动至" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Self" EnableResize="true" runat="server" Icon="FolderGo" Width="310px"
        Height="435px" EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyFileWin" Title="编辑文件名" Popup="false" EnableMaximize="false" IsModal="true"
        Target="Self" EnableResize="false" runat="server" Icon="ApplicationEdit" Width="420px"
        Height="120px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="copyPersonWin" Title="复制到职员" Popup="false" EnableMaximize="true" Target="Parent"
        IsModal="true" EnableResize="true" runat="server" Icon="UserGo" Width="710px"
        Height="420px" EnableIFrame="true">
    </x:Window>
    <x:Window ID="uploadFileWin" Title="上传文件" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Self" EnableResize="true" runat="server" Icon="FolderPage" Width="500px"
        Height="300px" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNewFolder","btnModifyFolder","btnDeleteFolder","btnMoveFolder","btnUpload","btnModifyFile","btnMoveFile","btnDeleteFile","btnDownFile","btnCopy"]'
        runat="server" />
    </form>
    <script type="text/javascript">
        //刷新附件
        function refreshAttach() {
            __doPostBack('<%=this.btnRefreshFile.UniqueID%>', "");
        }
    </script>
</body>
</html>
