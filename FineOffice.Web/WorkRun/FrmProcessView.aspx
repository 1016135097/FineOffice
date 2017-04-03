<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmProcessView.aspx.cs" Inherits="WorkRun_FrmProcessView" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="_FrmProcessView" runat="server">
    <x:PageManager ID="pageManager" runat="server" AutoSizePanelID="pnlMain" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
        AutoScroll="true" ShowHeader="false" Layout="Fit">
        <Items>
            <x:Panel ID="pnlContent" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
                AutoScroll="true" ShowHeader="false" Layout="Row">
                <Items>
                    <x:ContentPanel runat="server" ID="pnlFlowRun" ShowHeader="true" EnableCollapse="true"
                        BodyPadding="1px" CssClass="rowpanel" Icon="BookOpen" Title="工作信息">
                        <div class="body">
                            <table width="100%" cellspacing="1" cellpadding="0" class="table">
                                <tbody>
                                    <tr>
                                        <td valign="middle" class="lable">
                                            工作编号：
                                        </td>
                                        <td valign="middle" class="field">
                                            <x:HiddenField ID="hiddenWork" runat="server" />
                                            <x:HiddenField ID="hiddenVersion" runat="server" />
                                            <x:HiddenField ID="hiddenRunProcess" runat="server" />
                                            <x:Label ID="lblWorkNO" runat="server" CssClass="mright" ShowLabel="false" />
                                        </td>
                                        <td valign="middle" class="lable">
                                            工作名称：
                                        </td>
                                        <td valign="middle" class="field">
                                            <x:Label ID="lblWorkName" runat="server" CssClass="mright" ShowLabel="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="middle" class="lable">
                                            创&nbsp;&nbsp;建&nbsp;&nbsp;人：
                                        </td>
                                        <td class="field" valign="middle">
                                            <x:Label ID="lblCreator" runat="server" CssClass="mright" ShowLabel="false" />
                                        </td>
                                        <td valign="middle" class="lable">
                                            创建时间：
                                        </td>
                                        <td class="field" valign="middle">
                                            <x:Label ID="lblCreateTime" runat="server" CssClass="mright" ShowLabel="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="middle" class="lable">
                                            备注信息：
                                        </td>
                                        <td class="field" valign="middle" colspan="3">
                                            <x:Label ID="lblRemrk" runat="server" CssClass="mright" ShowLabel="false" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </x:ContentPanel>
                    <x:TabStrip ID="tabStrip" Height="360px" ShowBorder="true" TabPosition="Top" EnableTabCloseMenu="false"
                        CssClass="rowbuttom" EnableTitleBackgroundColor="true" ActiveTabIndex="0" runat="server">
                        <Tabs>
                            <x:Tab ID="tabForm" Title="工作表单" EnableBackgroundColor="true" BodyPadding="0px" Layout="Fit"
                                Icon="PageWhiteWord" runat="server">
                                <Items>
                                    <x:Panel ID="pnlForm" ShowBorder="false" ShowHeader="false" BoxFlex="1" Layout="Fit"
                                        Title="工作表单" runat="server">
                                        <Toolbars>
                                            <x:Toolbar ID="toolForm" runat="server">
                                                <Items>
                                                    <x:Button ID="btnPreview" Icon="FolderMagnify" Text="预览" runat="server" OnClick="btnPreview_Click" />
                                                    <x:ToolbarSeparator runat="server" />
                                                    <x:Button ID="btnDownForm" Icon="DriveDisk" EnableAjax="false" Text="下载" DisableControlBeforePostBack="false"
                                                        runat="server" OnClick="btnDownForm_Click" />
                                                    <x:ToolbarSeparator runat="server" />
                                                    <x:Button ID="btnRefreshForm" Icon="ArrowRefresh" Text="刷新" runat="server" OnClick="btnRefreshForm_Click" />
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Items>
                                            <x:Grid ID="formGrid" Title="表单" PageSize="10" ShowBorder="false" AllowPaging="true"
                                                AllowSorting="true" OnPageIndexChange="formGrid_PageIndexChange" ShowHeader="False"
                                                EnableMultiSelect="false" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,Title"
                                                SortColumn="CreateTime" IsDatabasePaging="true" SortDirection="ASC" OnSort="formGrid_Sort"
                                                EnableRowNumber="True">
                                                <Columns>
                                                    <x:BoundField Width="100px" ColumnID="Title" SortField="Title" DataField="Title"
                                                        HeaderText="表单标题" />
                                                    <x:BoundField Width="100px" ColumnID="FormName" SortField="FormName" DataField="FormName"
                                                        HeaderText="表单名称" />
                                                    <x:BoundField Width="100px" ColumnID="ProcessName" SortField="ProcessName" DataField="ProcessName"
                                                        HeaderText="创建步骤" />
                                                    <x:BoundField Width="100px" ColumnID="PersonnelName" SortField="PersonnelName" DataField="PersonnelName"
                                                        HeaderText="创建人" />
                                                    <x:BoundField Width="100px" ColumnID="CreateTime" SortField="CreateTime" DataField="CreateTime"
                                                        HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd}" />
                                                    <x:BoundField Width="100px" ColumnID="UpdateTime" SortField="UpdateTime" DataField="UpdateTime"
                                                        HeaderText="编辑时间" DataFormatString="{0:yyyy-MM-dd}" />
                                                </Columns>
                                            </x:Grid>
                                        </Items>
                                    </x:Panel>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="tabAttachment" Title="公共附件" BodyPadding="0px" Layout="Fit" EnableBackgroundColor="true"
                                Icon="FolderPage" runat="server">
                                <Items>
                                    <x:Panel ID="pnlAttachment" ShowBorder="false" ShowHeader="false" BoxFlex="1" Layout="Fit"
                                        Title="公共附件" EnableCollapse="True" runat="server">
                                        <Toolbars>
                                            <x:Toolbar ID="toolAttachment" runat="server">
                                                <Items>
                                                    <x:Button ID="btnDownAttachment" Icon="DriveDisk" EnableAjax="false" Text="下载" DisableControlBeforePostBack="false"
                                                        runat="server" OnClick="btnDownAttachment_Click" />
                                                    <x:ToolbarSeparator runat="server" />
                                                    <x:Button ID="btnRefreshAtt" Icon="ArrowRefresh" Text="刷新" OnClick="btnRefreshAtt_Click"
                                                        runat="server" />
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Items>
                                            <x:Grid ID="attachmentGrid" Title="公共附件" PageSize="10" ShowBorder="false" AllowPaging="true"
                                                AllowSorting="true" OnPageIndexChange="attachmentGrid_PageIndexChange" ShowHeader="False"
                                                EnableMultiSelect="false" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,FileName"
                                                SortColumn="CreateTime" IsDatabasePaging="true" SortDirection="ASC" OnSort="attachmentGrid_Sort"
                                                EnableRowNumber="True">
                                                <Columns>
                                                    <x:BoundField Width="200px" ColumnID="FileName" SortField="FileName" DataField="FileName"
                                                        HeaderText="文件名" />
                                                    <x:BoundField Width="100px" ColumnID="Size" SortField="Size" DataField="Size" HeaderText="大小" />
                                                    <x:BoundField Width="150px" ColumnID="XTypeName" SortField="XTypeName" DataField="XTypeName"
                                                        HeaderText="类型" />
                                                    <x:BoundField Width="150px" ColumnID="ProcessName" SortField="ProcessName" DataField="ProcessName"
                                                        HeaderText="创建步骤" />
                                                    <x:BoundField Width="150px" ColumnID="PersonnelName" SortField="PersonnelName" DataField="PersonnelName"
                                                        HeaderText="创建人" />
                                                    <x:BoundField Width="150px" ColumnID="CreateTime" SortField="CreateTime" DataField="CreateTime"
                                                        HeaderText="创建时间" DataFormatString="{0:yyyy-MM-dd}" />
                                                </Columns>
                                            </x:Grid>
                                        </Items>
                                    </x:Panel>
                                </Items>
                            </x:Tab>
                        </Tabs>
                    </x:TabStrip>
                    <x:Panel ID="pnlOperator" runat="server" BodyPadding="2px" EnableBackgroundColor="true"
                        Icon="BookmarkEdit" Layout="Fit" ShowBorder="true" ShowHeader="true" Title="办理意见"
                        CssClass="rowbuttom">
                        <Items>
                            <x:TextArea ID="txtTransmitAdvice" runat="server" Height="150">
                            </x:TextArea>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
        <Toolbars>
            <x:Toolbar runat="server" Position="Top">
                <Items>
                    <x:Button ID="btnRunDetail" Icon="ApplicationViewList" Text="流程步聚" runat="server"
                        OnClick="btnRunDetail_Click" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnRunEvent" Icon="EmailOpen" Text="流程事件" runat="server" OnClick="btnRunEvent_Click" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnClose" Icon="SystemClose" Text="关闭" runat="server" EnablePostBack="false"
                        OnClientClick="closeWindow();" />
                </Items>
            </x:Toolbar>
        </Toolbars>
    </x:Panel>
    <x:Window ID="frmFlowRunDetail" Title="流程步聚" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="ApplicationViewList"
        Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="frmFlowRunEvent" Title="流程事件" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="EmailOpen" Width="500px"
        Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:HiddenField ID="hiddenTabID" runat="server" />
    </form>
    <script type="text/javascript">
        //关闭当前选项卡，并刷新待办事项
        function closeWindow() {
            Ext.Msg.confirm('确认对话框', '确定要关闭吗？',
            function (btn) {
                if (btn == 'yes') {
                    parent.closeRefreshRunProcess();
                }
            }, this);
        }
    </script>
</body>
</html>
