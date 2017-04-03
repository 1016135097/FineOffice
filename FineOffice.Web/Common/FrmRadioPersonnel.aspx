<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmRadioPersonnel.aspx.cs"
    Inherits="Common_FrmRadioPersonnel" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmRadioPersonnel" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="false" Title="Panel" ShowBorder="false" ShowHeader="false"
        Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Panel ID="pnlFind" runat="server" ShowHeader="false" EnableLargeHeader="false"
                EnableBackgroundColor="true">
                <Items>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="条件过滤" ID="grpFind" EnableCollapse="True"
                        Width="700px">
                        <Items>
                            <x:Form ID="frmPerson" runat="server" ShowBorder="False" EnableBackgroundColor="true"
                                ShowHeader="False" LabelWidth="60">
                                <Rows>
                                    <x:FormRow runat="server" ColumnWidths="26% 26% 27% 10% 10%">
                                        <Items>
                                            <x:TextBox ID="txtPersonnelNO" runat="server" Label="编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码"
                                                Width="100px" />
                                            <x:TextBox ID="txtName" Label="职员姓名" runat="server" Width="100px" />
                                            <x:DropDownList ID="ddlDepartment" Label="部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门"
                                                runat="server" Width="100px" />
                                            <x:Button ID="btnFind" Text="过滤" runat="server" Icon="Find" OnClick="btnFind_Click" />
                                            <x:Button ID="btnEnter" Text="确定" runat="server" Icon="Tick" OnClick="btnEnter_Click" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                        </Items>
                    </x:GroupPanel>
                </Items>
            </x:Panel>
            <x:Panel ID="pnlPerson" EnableBackgroundColor="true" BoxFlex="1" runat="server" BodyPadding="0px"
                ShowBorder="true" ShowHeader="false" Layout="Fit">
                <Toolbars>
                    <x:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <x:Button ID="btnAdd" Icon="Add" Text="新增" runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDelelte" Icon="Delete" Text="删除" runat="server" OnClick="btnDelete_Click" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="personGrid" Title="职员信息" PageSize="20" AllowPaging="true" OnPageIndexChange="personGrid_PageIndexChange"
                        ShowHeader="False" AllowSorting="true" ShowBorder="false" runat="server" OnRowCommand="personGrid_RowCommand"
                        DataKeyNames="ID,Name" SortDirection="ASC" OnSort="personGrid_Sort" EnableRowNumber="True"
                        EnableMultiSelect="false" EnableCheckBoxSelect="True" SortColumn="PersonnelNO">
                        <Columns>
                            <x:BoundField Width="100px" HeaderText="编码" ColumnID="PersonnelNO" SortField="PersonnelNO"
                                DataField="PersonnelNO" />
                            <x:BoundField Width="100px" HeaderText="职员姓名" ColumnID="Name" SortField="Name" DataField="Name" />
                            <x:BoundField Width="100px" HeaderText="性别" ColumnID="Gender" DataField="Gender"
                                SortField="Gender" />
                            <x:BoundField Width="100px" HeaderText="拼音码" ColumnID="PinyinCode" SortField="PinyinCode"
                                DataField="PinyinCode" />
                            <x:BoundField Width="100px" HeaderText="部门" DataField="DepartmentName" ColumnID="DepartmentName"
                                SortField="DepartmentName" />
                            <x:BoundField Width="100px" HeaderText="职位" ColumnID="Job" SortField="Job" DataField="Job" />
                            <x:WindowField TextAlign="Center" Width="60px" WindowID="wndModifyPersonnel" Icon="Pencil"
                                ToolTip="编辑" DataIFrameUrlFormatString="../Human/FrmModifyPersonnel.aspx?ID={0}"
                                DataIFrameUrlFields="ID" DataWindowTitleFormatString="编辑-{0}" DataWindowTitleField="Name" />
                            <x:LinkButtonField TextAlign="Center" Width="60px" Icon="Delete" ToolTip="删除" ConfirmText="确认删除吗？"
                                CommandName="delete" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="newPersonWin" Title="新增" Popup="false" IFrameUrl="../Human/FrmNewPersonnel.aspx"
        EnableMaximize="true" IsModal="true" Target="Parent" EnableResize="true" runat="server"
        Icon="Add" Width="730px" Height="500px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyPersonWin" Title="编辑" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Pencil"
        Width="730px" Height="500px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    </form>
</body>
</html>
