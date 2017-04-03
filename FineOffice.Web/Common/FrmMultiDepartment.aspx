<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmMultiDepartment.aspx.cs"
    Inherits="FrmMultiDepartment" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
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
            <x:Form ID="frmFind" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server" Width="400px">
                <Rows>
                    <x:FormRow runat="server">
                        <Items>
                            <x:TwinTriggerBox runat="server" ShowLabel="false" ID="ttbSearch" Width="200px" ShowTrigger1="false"
                                OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                                Trigger1Icon="Clear" Trigger2Icon="Search">
                            </x:TwinTriggerBox>
                            <x:Button ID="btnEnter" Text="确定" runat="server" Icon="Tick" OnClick="btnEnter_Click" />
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
            <x:Panel ID="pnlLeft" runat="server" ShowBorder="false" BoxFlex="1" Layout="HBox"
                BoxConfigAlign="Stretch" BoxConfigPosition="Start" BoxConfigPadding="0" BoxConfigChildMargin="0 0 0 0"
                ShowHeader="false">
                <Items>
                    <x:Panel ID="pnlDepartment" EnableBackgroundColor="true" BoxFlex="1" runat="server"
                        BodyPadding="0px" ShowBorder="true" ShowHeader="false" Layout="Fit">
                        <Toolbars>
                            <x:Toolbar ID="tsbMain" runat="server">
                                <Items>
                                    <x:Button ID="btnNew" Icon="Add" Text="新增" runat="server" />
                                    <x:ToolbarSeparator runat="server" />
                                    <x:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" OnClick="btnModify_Click"
                                        runat="server" />
                                    <x:ToolbarSeparator runat="server" />
                                    <x:Button ID="btnSelectAll" Icon="ArrowIn" Text="全选" OnClick="btnSelectAll_Click"
                                        runat="server" />
                                    <x:ToolbarSeparator runat="server" />
                                    <x:Button ID="btnDelete" Icon="Delete" Text="删除" OnClick="btnDelete_Click" runat="server" />
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Items>
                            <x:Grid ID="departmentGrid" Title="部门信息" PageSize="20" ShowBorder="false" AllowPaging="true"
                                AllowSorting="true" OnPageIndexChange="departmentGrid_PageIndexChange" ShowHeader="False"
                                IsDatabasePaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,DepartmentName"
                                SortColumn="DepartmentNO" SortDirection="ASC" OnSort="departmentGrid_Sort" EnableRowNumber="True"
                                OnRowCommand="departmentGrid_RowCommand">
                                <Columns>
                                    <x:BoundField Width="100px" ColumnID="DepartmentNO" SortField="DepartmentNO" DataField="DepartmentNO"
                                        HeaderText="部门编码" />
                                    <x:BoundField Width="100px" ColumnID="DepartmentName" SortField="DepartmentName"
                                        DataField="DepartmentName" HeaderText="部门名称" />
                                    <x:BoundField Width="100px" ColumnID="PinyinCode" SortField="PinyinCode" DataField="PinyinCode"
                                        HeaderText="拼音码" />
                                    <x:BoundField Width="100px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                        HeaderText="备注" />
                                    <x:WindowField TextAlign="Center" Width="60px" DataIFrameUrlFormatString="../Human/FrmModifyDepartment.aspx?id={0}"
                                        WindowID="frmModifyDepartment" Icon="Pencil" Title="编辑" DataIFrameUrlFields="ID" />
                                    <x:LinkButtonField TextAlign="Center" Width="60px" Icon="Delete" ToolTip="删除" ConfirmText="确认删除吗？"
                                        CommandName="delete" />
                                </Columns>
                            </x:Grid>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="pnlMiddle" Width="50px" EnableBackgroundColor="true" runat="server"
                        Layout="VBox" BoxConfigAlign="Center" BoxConfigPosition="Center" BodyPadding="0px"
                        ShowBorder="true" ShowHeader="False">
                        <Items>
                            <x:Panel ID="row1" EnableBackgroundColor="true" runat="server" BodyPadding="0px"
                                Height="50px" ShowBorder="False" ShowHeader="False">
                                <Items>
                                    <x:Button ID="btnRight" Icon="ArrowRight" runat="server" OnClick="btnRight_Click" />
                                </Items>
                            </x:Panel>
                            <x:Panel ID="row2" EnableBackgroundColor="true" runat="server" BodyPadding="0px"
                                Height="50px" ShowBorder="False" ShowHeader="False">
                                <Items>
                                    <x:Button ID="btnLeft" Icon="ArrowLeft" runat="server" OnClick="btnLeft_Click" />
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="pnlRight" EnableBackgroundColor="true" Width="200px" runat="server"
                        BodyPadding="0px" BoxMargin="0" ShowBorder="true" ShowHeader="False" Layout="Fit">
                        <Items>
                            <x:Grid ID="rightGrid" Title="部门信息" ShowBorder="false" ShowHeader="False" runat="server"
                                EnableCheckBoxSelect="True" DataKeyNames="ID,DepartmentName" SortDirection="ASC"
                                EnableRowNumber="True">
                                <Columns>
                                    <x:BoundField Width="100px" ColumnID="DepartmentName" SortField="DepartmentName"
                                        DataField="DepartmentName" HeaderText="部门名称" />
                                </Columns>
                            </x:Grid>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="newDepartmentWin" Title="新增" Popup="false" IFrameUrl="../Human/FrmNewDepartment.aspx"
        EnableMaximize="true" IsModal="true" Target="Parent" EnableResize="true" runat="server"
        Icon="Add" Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyDepartmentWin" Title="编辑" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Pencil"
        Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    </form>
</body>
</html>
