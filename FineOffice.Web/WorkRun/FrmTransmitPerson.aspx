<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmTransmitPerson.aspx.cs"
    Inherits="WorkRun_FrmTransmitPerson" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="FrmList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="false" Title="Panel" ShowBorder="false" ShowHeader="false"
        Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Panel ID="pnlSearch" runat="server" ShowHeader="false" EnableLargeHeader="false"
                EnableBackgroundColor="true">
                <Items>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="条件过滤" ID="groupPanel" EnableCollapse="True"
                        Width="650px">
                        <Items>
                            <x:Form ID="searchForm" runat="server" ShowBorder="False" EnableBackgroundColor="true"
                                ShowHeader="False" LabelWidth="60">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtPersonnelNO" runat="server" Label="编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码"
                                                Width="200px" />
                                            <x:TextBox ID="txtName" Label="职员姓名" runat="server" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server" ColumnWidths="50% 10% 15%">
                                        <Items>
                                            <x:DropDownList ID="ddlDepartment" Label="部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门"
                                                runat="server" Width="200px" />
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
            <x:Panel ID="pnlPerson" runat="server" ShowBorder="false" BoxFlex="1" Layout="Fit"
                BoxConfigAlign="Stretch" BoxConfigPosition="Start" BoxConfigPadding="0" BoxConfigChildMargin="0 0 0 0"
                ShowHeader="false">
                <Items>
                    <x:Grid ID="CommonGrid" Title="职员信息" PageSize="20" AllowPaging="true" OnPageIndexChange="Grid_PageIndexChange"
                        ShowHeader="False" AllowSorting="true" ShowBorder="false" runat="server" EnableMultiSelect="False"
                        DataKeyNames="ID,Name" SortDirection="ASC" OnSort="Grid_Sort" EnableRowNumber="True"
                        EnableCheckBoxSelect="True" SortColumn="personnelNO">
                        <Columns>
                            <x:BoundField Width="100px"   HeaderText="编码" ColumnID="personnelNO"
                                SortField="PersonnelNO" DataField="PersonnelNO" />
                            <x:BoundField Width="100px"   HeaderText="职员姓名" ColumnID="name"
                                SortField="Name" DataField="Name" />
                            <x:BoundField Width="100px"   HeaderText="性别" ColumnID="sexName"
                                SortField="Gender" DataField="Gender" />
                            <x:BoundField Width="100px"   HeaderText="拼音码" ColumnID="pinyinCode"
                                SortField="PinyinCode" DataField="PinyinCode" />
                            <x:BoundField Width="100px"   HeaderText="部门" DataField="DepartmentName"
                                ColumnID="departmentName" SortField="DepartmentName" />
                            <x:BoundField Width="100px"   HeaderText="职位" ColumnID="job"
                                SortField="Job" DataField="Job" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hiddenPerson" runat="server">
    </x:HiddenField>
    <x:HiddenField ID="hiddenDepartment" runat="server">
    </x:HiddenField>
    <x:Window ID="frmNewPersonnel" Title="新增职员" Popup="false" IFrameUrl="../Base/HR/FrmNewPersonnel.aspx"
        EnableMaximize="true" IsModal="true" Target="Parent" EnableResize="true" runat="server"
        Icon="Add" Width="730px" Height="500px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="frmModifyPersonnel" Title="编辑职员" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Pencil"
        Width="730px" Height="500px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    </form>
</body>
</html>
