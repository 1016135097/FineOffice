<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmUserList.aspx.cs" Inherits="System_FrmUserList" %>

<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmUserList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Form ID="frmFind" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <x:FormRow runat="server">
                        <Items>
                            <x:TwinTriggerBox runat="server" ShowLabel="false" ID="ttbSearch" Width="200" ShowTrigger1="false"
                                OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                                Trigger1Icon="Clear" Trigger2Icon="Search">
                            </x:TwinTriggerBox>
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
            <x:Panel ID="pnlUserGrid" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <x:Button ID="btnAdd" Icon="Add" Text="新增" runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnAwardRole" Icon="Feed" Text="授权" runat="server" OnClick="btnAwardRole_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDelete" Icon="Delete" Text="删除" runat="server" OnClick="btnDelete_Click" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="userGrid" Title="用户" PageSize="20" ShowBorder="false" OnPageIndexChange="userGrid_PageIndexChange"
                        ShowHeader="False" AllowPaging="true" EnableMultiSelect="false" OnRowCommand="userGrid_RowCommand"
                        SortColumn="CreateDate" EnableCheckBoxSelect="True" SortDirection="ASC" EnableRowNumber="True"
                        DataKeyNames="ID,UserName,IsModify" runat="server">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="UserName" SortField="UserName" DataField="UserName"
                                HeaderText="用户名称" />
                            <x:BoundField Width="150px" ColumnID="CreateDate" SortField="CreateDate" DataField="CreateDate"
                                DataFormatString="{0:yyyy-MM-dd}" HeaderText="创建日期" />
                            <x:BoundField Width="100px" ColumnID="PersonnelName" SortField="PersonnelName" DataField="PersonnelName"
                                HeaderText="使用人" />
                            <x:BoundField Width="100px" ColumnID="DepartmentName" SortField="DepartmentName"
                                DataField="DepartmentName" HeaderText="部门" />
                            <x:BoundField Width="100px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                HeaderText="备注" />
                            <x:CheckBoxField Width="60px" ColumnID="Stop" SortField="Stop" TextAlign="Center"
                                RenderAsStaticField="true" DataField="Stop" HeaderText="是否可用" />
                            <x:WindowField TextAlign="Center" Width="60px" WindowID="modifyUserWin" Icon="Pencil"
                                ColumnID="btnModify" ToolTip="编辑" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmModifyUser.aspx?id={0}"
                                Hideable="false" DataWindowTitleField="UserName" DataWindowTitleFormatString="编辑-{0}" />
                            <x:LinkButtonField TextAlign="Center" Width="60px" Icon="Delete" ColumnID="btnDelete"
                                ConfirmText="确认删除吗？" Hideable="false" CommandName="delete" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="newUserWin" Title="新增" Popup="false" EnableMaximize="false" IsModal="true"
        Target="Parent" EnableResize="false" runat="server" Icon="Add" Width="500px"
        Height="300px" EnableConfirmOnClose="true" EnableIFrame="true" IFrameUrl="FrmNewUser.aspx">
    </x:Window>
    <x:Window ID="modifyUserWin" Title="编辑" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="Pencil" Width="500px"
        Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="awardRoleWin" Title="授权" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="Pencil" Width="500px"
        Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete","btnAwardRole"]'
        runat="server" />
    </form>
</body>
</html>
