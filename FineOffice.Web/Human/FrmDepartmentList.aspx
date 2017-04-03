<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmDepartmentList.aspx.cs"
    Inherits="Human_FrmDepartmentList" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmDepartmentList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Form ID="pnlFind" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
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
            <x:Panel ID="pnlDepartment" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <x:Button ID="btnNew" Icon="Add" Text="新增" runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnSelectAll" Icon="ArrowIn" Text="全选" runat="server" OnClick="btnSelectAll_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDelete" Icon="Delete" Text="删除" runat="server" OnClick="btnDelete_Click" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="departmentGrid" Title="部门信息" PageSize="20" ShowBorder="false" AllowPaging="true"
                        AllowSorting="true" OnPageIndexChange="departmentGrid_PageIndexChange" ShowHeader="False"
                        IsDatabasePaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,DepartmentNO"
                        SortColumn="DepartmentNO" SortDirection="ASC" OnSort="departmentGrid_Sort" EnableRowNumber="True"
                        OnRowCommand="departmentGrid_RowCommand">
                        <Columns>
                            <x:BoundField ColumnID="DepartmentNO" SortField="DepartmentNO" DataField="DepartmentNO"
                                HeaderText="部门编码" Width="100px" />
                            <x:BoundField ColumnID="DepartmentName" SortField="DepartmentName" DataField="DepartmentName"
                                HeaderText="部门名称" Width="100px" />
                            <x:BoundField ColumnID="PinyinCode" SortField="PinyinCode" DataField="PinyinCode"
                                HeaderText="拼音码" Width="100px" />
                            <x:BoundField ColumnID="Remark" SortField="Remark" DataField="Remark" HeaderText="备注"
                                Width="100px" />
                            <x:CheckBoxField ColumnID="Stop" SortField="Stop" TextAlign="Center" RenderAsStaticField="true"
                                DataField="Stop" HeaderText="是否可用" Width="60px" />
                            <x:WindowField ColumnID="btnModify" TextAlign="Center" WindowID="modifyDepartmentWin"
                                DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmModifyDepartment.aspx?id={0}"
                                DataWindowTitleField="DepartmentName" DataWindowTitleFormatString="编辑-{0}" Icon="Pencil"
                                Hideable="false" Width="60px" />
                            <x:LinkButtonField ColumnID="btnDelete" TextAlign="Center" Width="60px" Icon="Delete"
                                Hideable="false" ConfirmText="确认删除吗？" CommandName="delete" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="newDepartmentWin" Title="新增" Popup="false" IFrameUrl="FrmNewDepartment.aspx"
        EnableMaximize="true" IsModal="true" Target="Parent" EnableResize="true" runat="server"
        Icon="Add" Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyDepartmentWin" Title="编辑" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Pencil"
        Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]'
        runat="server" />
    </form>
</body>
</html>
