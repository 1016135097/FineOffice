<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmNewPersonnel.aspx.cs"
    Inherits="HumanFrmNewPersonnel" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmNewPersonnel" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </x:Button>
                    <x:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" OnClick="btnSave_Click"
                        ValidateForms="frmPerson" ValidateMessageBox="false">
                    </x:Button>
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlPerson" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true">
                <Items>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="基本信息" ID="groupPanel" EnableCollapse="True"
                        EnableBackgroundColor="true">
                        <Items>
                            <x:Form ID="frmPerson" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="5px"
                                EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtPersonnelNO" runat="server" Label="职员编码" Width="200px" Required="true" />
                                            <x:TextBox ID="txtName" Label="职员姓名" runat="server" Width="200px" Required="true"
                                                AutoPostBack="true" OnTextChanged="Pinyin_TextChanged" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:DropDownList ID="ddlSex" Label="性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别" runat="server"
                                                Width="200px">
                                                <x:ListItem Text="男" Value="1" Selected="true" />
                                                <x:ListItem Text="女" Value="0" />
                                            </x:DropDownList>
                                            <x:TextBox ID="txtPinyin" Label="拼&nbsp;&nbsp;音&nbsp;码" runat="server" Width="200px"
                                                Required="true" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:DropDownList ID="ddlDepartment" Label="部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门"
                                                runat="server" Width="200px" />
                                            <x:DropDownList ID="ddlJob" Label="职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;位" runat="server"
                                                Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtMobile" runat="server" Label="移动电话" Width="200px" />
                                            <x:TextBox ID="txtEmail" runat="server" Label="电子邮箱" RegexPattern="EMAIL" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:DropDownList ID="ddlEducation" Label="学&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;历"
                                                runat="server" Width="200px" />
                                            <x:CheckBox ID="chkStop" runat="server" Checked="true" Text="" Label="是否在职" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtRemark" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" Width="535px"
                                                runat="server" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                        </Items>
                    </x:GroupPanel>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="扩展信息" ID="ExGroup" EnableCollapse="True"
                        EnableBackgroundColor="true">
                        <Items>
                            <x:Form ID="frmOther" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="5px"
                                EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtNativePlace" runat="server" Label="籍&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;贯"
                                                Width="200px" />
                                            <x:DatePicker ID="calDateOfBirth" Label="出生日期" runat="server" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtLinkman" runat="server" Label="联&nbsp;&nbsp;系&nbsp;人" Width="200px" />
                                            <x:TextBox ID="txtHomeTelephone" runat="server" Label="联系电话" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:DatePicker ID="calEntryDate" Label="入职日期" runat="server" Width="200px" />
                                            <x:DatePicker ID="calExitDate" Label="离职日期" runat="server" Width="200px" CompareControl="calEntryDate"
                                                CompareOperator="GreaterThan" CompareMessage="离职日期应该大于入职日期！" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtAddress" Label="联系地址" Width="535px" runat="server" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                        </Items>
                    </x:GroupPanel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
