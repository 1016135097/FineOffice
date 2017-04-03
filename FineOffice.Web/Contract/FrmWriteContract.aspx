<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmWriteContract.aspx.cs"
    Inherits="Contract_FrmWriteContract" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="_FrmWriteContract" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" ShowBorder="False" ShowHeader="false" AutoScroll="true"
        EnableBackgroundColor="true" BodyPadding="5px">
        <Items>
            <x:Panel runat="server" ID="pnlContract" ShowHeader="true" EnableCollapse="true"
                EnableBackgroundColor="true" Height="160px" BodyPadding="1px" CssClass="rowpanel"
                Icon="BookOpen" Title="合同信息">
                <Items>
                    <x:Form ID="frmContract" ShowBorder="false" ShowHeader="false" AutoScroll="true"
                        BodyPadding="5px" EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                        <Rows>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:TextBox ID="txtContractNO" runat="server" Label="合同编号" Required="true" />
                                    <x:TextBox ID="txtContractName" runat="server" Label="合同名称" Required="true" />
                                    <x:DropDownList ID="ddlType" Label="合同类别" runat="server" Required="true" />
                                </Items>
                            </x:FormRow>
                        </Rows>
                        <Rows>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:TriggerBox ID="txtTrader" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                        Label="签定企业" runat="server" />
                                    <x:DatePicker runat="server" Required="true" Label="签定日期" ID="dtpSingnDate" />
                                    <x:DatePicker runat="server" Required="true" Label="有效期至" ID="dtpEndDate" />
                                </Items>
                            </x:FormRow>
                        </Rows>
                        <Rows>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:TextBox ID="txtLinkman" Label="联&nbsp;&nbsp;系&nbsp;人" runat="server" />
                                    <x:TextBox ID="txtMoblie" Label="联系电话" runat="server" />
                                    <x:HiddenField ID="hiddenOccupy" runat="server" />
                                </Items>
                            </x:FormRow>
                        </Rows>
                        <Rows>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:TriggerBox ID="txtHandler" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                        Label="签&nbsp;&nbsp;定&nbsp;人" runat="server" />
                                    <x:TextBox ID="txtLocation" runat="server" Label="存放位置" />
                                    <x:TextBox ID="txtRemark" runat="server" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" />
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
            <x:TabStrip ID="tbsContent" Height="160px" TabPosition="Top" EnableTabCloseMenu="false"
                EnableTitleBackgroundColor="true" ActiveTabIndex="0" runat="server" ShowBorder="true">
                <Tabs>
                    <x:Tab ID="tabContent" AutoHeight="true" Icon="User" Title="合同内容" EnableBackgroundColor="true"
                        BodyPadding="5px" Layout="Fit" runat="server">
                        <Items>
                            <x:TextArea ID="txtContent" ShowLabel="false" runat="server" />
                        </Items>
                    </x:Tab>
                </Tabs>
            </x:TabStrip>
            <x:TabStrip ID="tbsAttachment" BoxFlex="1" TabPosition="Top" EnableTabCloseMenu="false"
                EnableTitleBackgroundColor="true" ActiveTabIndex="0" runat="server" ShowBorder="false">
                <Tabs>
                    <x:Tab ID="tabAttachment" AutoHeight="true" Icon="FolderPage" Title="合同附件" EnableBackgroundColor="true"
                        Layout="Row" runat="server">
                        <Items>
                            <x:Panel ID="pnlAttachment" ShowBorder="true" ShowHeader="false" Layout="Fit" Height="200px"
                                Title="合同附件" EnableCollapse="True" runat="server">
                                <Toolbars>
                                    <x:Toolbar ID="toolAttachment" runat="server">
                                        <Items>
                                            <x:Button ID="btnUpload" Icon="ArrowUp" Text="上传附件" runat="server"  OnClick="btnUpload_Click"/>
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnModifyAttachment" Icon="ApplicationEdit" OnClick="btnModifyAttachment_Click"
                                                Text="编辑文件名" runat="server" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnDeleteAttachment" Icon="Delete" Text="删除" runat="server" OnClick="btnDeleteAttachment_Click" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnRefreshAttachment" Icon="ArrowRefresh" OnClick="btnRefreshAttachment_Click"
                                                Text="刷新" runat="server" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnTransfer" Icon="DiskDownload" Text="转存" runat="server" OnClick="btnTransfer_Click" />
                                            <x:ToolbarSeparator runat="server" />
                                            <x:Button ID="btnDownAttachment" Icon="DriveDisk" EnableAjax="false" Text="下载" OnClick="btnDownAttachment_Click"
                                                DisableControlBeforePostBack="false" runat="server" />
                                        </Items>
                                    </x:Toolbar>
                                </Toolbars>
                                <Items>
                                    <x:Grid ID="attachmentGrid" Title="附件" PageSize="10" ShowBorder="false" ShowHeader="False"
                                        AllowSorting="true" EnableMultiSelect="false" runat="server" OnRowCommand="attachmentGrid_RowCommand"
                                        AllowPaging="true" EnableCheckBoxSelect="True" DataKeyNames="ID,FileName" SortColumn="CreateTime"
                                        IsDatabasePaging="true" SortDirection="ASC" EnableRowNumber="True" OnSort="attachmentGrid_Sort"
                                        OnPageIndexChange="attachmentGrid_PageIndexChange">
                                        <Columns>
                                            <x:BoundField Width="200px" ColumnID="FileName" SortField="FileName" DataField="FileName"
                                                  HeaderText="文件名" />
                                            <x:BoundField Width="100px" ColumnID="size" SortField="Size" DataField="Size"  
                                                HeaderText="大小" />
                                            <x:BoundField Width="150px" ColumnID="XTypeName" SortField="XTypeName" DataField="XTypeName"
                                                  HeaderText="类型" />
                                            <x:BoundField Width="150px" ColumnID="PersonnelName" SortField="PersonnelName" DataField="PersonnelName"
                                                HeaderText="创建人" />
                                            <x:BoundField Width="150px" ColumnID="CreateTime" SortField="CreateTime" DataField="CreateTime"
                                                HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:LinkButtonField TextAlign="Center" Icon="Delete" ConfirmText="确认删除吗？" Width="50px"
                                                ToolTip="删除" CommandName="delete" Hideable="false" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:Tab>
                </Tabs>
            </x:TabStrip>
        </Items>
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server" Position="Top">
                <Items>
                    <x:Button ID="btnSave" Text="保存" runat="server" ValidateForms="frmContract" Icon="SystemSaveNew"
                        OnClick="btnSave_Click" ValidateMessageBox="false" />
                    <x:Button ID="btnReset" Text="重置" runat="server" Icon="ArrowUndo" OnClick="btnReset_Click" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                </Items>
            </x:Toolbar>
        </Toolbars>
    </x:Panel>
    <x:HiddenField ID="hiddenID" runat="server" />
    <x:HiddenField ID="hiddenWrite" runat="server" />
    <x:HiddenField ID="hiddenHandler" runat="server" />
    <x:HiddenField ID="hiddenTraderID" runat="server" />
    <x:HiddenField ID="hiddenTabID" runat="server" Text="_FrmWriteContract" />
    <x:Window ID="handlerWin" Title="签定人" Popup="false" EnableMaximize="true" Target="Parent"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    <x:Window ID="traderWin" Title="企业信息" Popup="false" EnableMaximize="true" Target="Parent"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    <x:Window ID="uploadAttachmentWin" Title="上传附件" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="FolderPage"
        Width="500px" Height="300px" EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyAttachmentWin" Title="编辑文件名" Popup="false" EnableMaximize="false"
        IsModal="true" Target="Parent" EnableResize="false" runat="server" Icon="ApplicationEdit"
        Width="420px" Height="120px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    </form>
    <script type="text/javascript">
        //刷新附件
        function refreshAttach() {
            __doPostBack('<%=this.btnRefreshAttachment.UniqueID%>', "");
        }
    </script>
</body>
</html>
