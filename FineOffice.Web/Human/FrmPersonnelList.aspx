<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmPersonnelList.aspx.cs"
    Inherits="Human_FrmPersonnelList" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmPersonnelList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Panel ID="pnlFind" runat="server" ShowHeader="false" EnableLargeHeader="false"
                ShowBorder="false" EnableBackgroundColor="true">
                <Items>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="条件过滤" ID="groupPanel" EnableCollapse="True"
                        Width="1000px">
                        <Items>
                            <x:Panel ID="pnlRow1" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="x-form-item datecontainer"
                                runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                <Items>
                                    <x:Label ID="lblPersonnelNO" runat="server" Width="60px" CssClass="inline" ShowLabel="false"
                                        Text="编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：" />
                                    <x:TextBox ID="txtPersonnelNO" Width="118px" runat="server" />
                                    <x:Label ID="lblName" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="职员姓名：" />
                                    <x:TextBox ID="txtName" runat="server" Width="118px" />
                                    <x:Label ID="lblDepartment" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门：" />
                                    <x:DropDownList ID="ddlDepartment" runat="server" Width="113px" />
                                    <x:Button ID="btnFind" Text="过滤" runat="server" CssClass="btnline" OnClick="btnFind_Click" />
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:GroupPanel>
                </Items>
            </x:Panel>
            <x:Panel ID="pnlPerson" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
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
                    <x:Grid ID="personnelGrid" Title="职员信息" PageSize="20" ShowBorder="false" AllowPaging="true"
                        AllowSorting="true" OnPageIndexChange="personnelGrid_PageIndexChange" ShowHeader="False"
                        IsDatabasePaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,PersonnelNO"
                        SortColumn="PersonnelNO" SortDirection="ASC" OnSort="personnelGrid_Sort" EnableRowNumber="True"
                        OnRowCommand="personnelGrid_RowCommand">
                        <Columns>
                            <x:TemplateField RenderAsRowExpander="true">
                                <ItemTemplate>
                                    <div class="expander">
                                        <p>
                                            <strong>籍贯：</strong><%# Eval("NativePlace")%>
                                            <strong class="padding">出生日期：</strong><%# Eval("DateOfBirth","{0:yyyy-MM-dd}")%></p>
                                        <p>
                                            <strong>家庭地址：</strong><%# Eval("Address")%><strong class="padding">联系人：</strong><%# Eval("Linkman")%>
                                            <strong class="padding">电话：</strong><%# Eval("HomeTelephone")%></p>
                                        <p>
                                            <strong>入职日期：</strong><%# Eval("EntryDate", "{0:yyyy-MM-dd}")%></p>
                                        <p>
                                            <strong>离职日期：</strong><%# Eval("ExitDate", "{0:yyyy-MM-dd}")%></p>
                                    </div>
                                </ItemTemplate>
                            </x:TemplateField>
                            <x:BoundField Width="100px" HeaderText="编码" ColumnID="PersonnelNO" SortField="PersonnelNO"
                                DataField="PersonnelNO" />
                            <x:BoundField Width="100px" HeaderText="职员姓名" ColumnID="Name" SortField="Name" DataField="Name" />
                            <x:BoundField Width="100px" HeaderText="性别" ColumnID="Gender" SortField="Gender"
                                DataField="Gender" />
                            <x:BoundField Width="100px" HeaderText="拼音码" ColumnID="PinyinCode" SortField="PinyinCode"
                                DataField="PinyinCode" />
                            <x:BoundField Width="100px" HeaderText="部门" DataField="DepartmentName" ColumnID="DepartmentName"
                                SortField="DepartmentName" />
                            <x:BoundField Width="100px" HeaderText="职位" ColumnID="job" SortField="Job" DataField="Job" />
                            <x:BoundField Width="100px" HeaderText="移动电话" ColumnID="Mobile" SortField="Mobile"
                                DataField="Mobile" />
                            <x:BoundField Width="100px" HeaderText="电子邮箱" ColumnID="Email" SortField="Email"
                                DataField="Email" />
                            <x:BoundField Width="100px" HeaderText="学历" ColumnID="Education" SortField="Education"
                                DataField="Education" />
                            <x:BoundField Width="100px" HeaderText="备注" ColumnID="Remark" SortField="Remark"
                                DataField="Remark" />
                            <x:CheckBoxField Width="60px" ColumnID="stop" SortField="Stop" TextAlign="Center"
                                RenderAsStaticField="true" DataField="Stop" HeaderText="是否可用" />
                            <x:WindowField TextAlign="Center" ColumnID="btnModify" Width="60px" WindowID="modifyPersonnelWin"
                                Icon="Pencil" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmModifyPersonnel.aspx?id={0}"
                                DataWindowTitleFormatString="编辑-{0}" DataWindowTitleField="Name" Hideable="false" />
                            <x:LinkButtonField ColumnID="btnDelete" TextAlign="Center" Width="60px" Icon="Delete"
                                ConfirmText="确认删除吗？" CommandName="delete" Hideable="false" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="newPersonnelWin" Title="新增" Popup="false" IFrameUrl="FrmNewPersonnel.aspx"
        EnableMaximize="true" IsModal="true" Target="Parent" EnableResize="true" runat="server"
        Icon="Add" Width="730px" Height="500px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyPersonnelWin" Title="编辑" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Pencil"
        Width="730px" Height="500px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]'
        runat="server" />
    </form>
</body>
</html>
