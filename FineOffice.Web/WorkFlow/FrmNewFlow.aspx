<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmNewFlow.aspx.cs" Inherits="WorkFlow_FrmNewForm" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="FrmNew" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </x:Button>
                    <x:Button ID="btnSave" Text="保存" runat="server" ValidateForms="frmFlow" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click">
                    </x:Button>
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlFlow" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:SimpleForm ID="frmFlow" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <x:TextBox ID="txtFormNO" Label="流程编码" Required="true" runat="server" />
                            <x:TextBox ID="txtFormName" Label="流程名称" Required="true" runat="server" OnTextChanged="Pinyin_TextChanged"
                                AutoPostBack="true" />
                            <x:TextBox ID="txtPinyinCode" Label="拼&nbsp;&nbsp;音&nbsp;码" Required="true" runat="server" />
                            <x:TextBox ID="txtVersion" Label="版&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;本" Required="true"
                                runat="server" />
                            <x:TextArea ID="txtFlowDesc" Label="流程描述" runat="server" Height="40px" />
                            <x:DropDownList ID="ddlSort" Label="流程分类" runat="server" />
                            <x:GroupPanel runat="server" AutoHeight="true" Title="流程选项" ID="grpOption" Width="544">
                                <Items>
                                    <x:Form runat="server" ShowBorder="False" EnableBackgroundColor="true" ShowHeader="False">
                                        <Rows>
                                            <x:FormRow runat="server">
                                                <Items>
                                                    <x:CheckBox ID="chkAllowRecall" runat="server" Checked="true" Label="允许召回" />
                                                    <x:CheckBox ID="chkAllowRevoke" runat="server" Checked="true" Label="允许召回" />
                                                </Items>
                                            </x:FormRow>
                                            <x:FormRow runat="server">
                                                <Items>
                                                    <x:CheckBox ID="chkAllowAttachment" runat="server" Checked="true" Label="允许附件" />
                                                    <x:CheckBox ID="chkIsFreedom" runat="server" Checked="true" Label="自由流程" />
                                                </Items>
                                            </x:FormRow>
                                            <x:FormRow runat="server">
                                                <Items>
                                                    <x:CheckBox ID="chkStop" runat="server" Checked="true" Label="是否可用" />
                                                </Items>
                                            </x:FormRow>
                                        </Rows>
                                    </x:Form>
                                </Items>
                            </x:GroupPanel>
                            <x:GroupPanel runat="server" AutoHeight="true" Title="经办权限" ID="grpUser" Width="544">
                                <Items>
                                    <x:Form ID="userForm" runat="server" ShowBorder="False" EnableBackgroundColor="true"
                                        ShowHeader="False">
                                        <Rows>
                                            <x:FormRow runat="server" ColumnWidths="75% 15%">
                                                <Items>
                                                    <x:TextArea ID="txtPersonnel" runat="server" Readonly="true" Label="职员权限" Height="40px" />
                                                    <x:Button ID="btnPersonnel" Text="选择" runat="server" Icon="Find" EnablePostBack="false" />
                                                </Items>
                                            </x:FormRow>
                                            <x:FormRow runat="server">
                                                <Items>
                                                    <x:HiddenField ID="hiddenPersonnel" runat="server" />
                                                    <x:HiddenField ID="hiddenDepartment" runat="server" />
                                                </Items>
                                            </x:FormRow>
                                            <x:FormRow runat="server" ColumnWidths="75% 15%">
                                                <Items>
                                                    <x:TextArea ID="txtDepartment" runat="server" Readonly="true" Label="部门权限" Height="40px" />
                                                    <x:Button ID="btnDepartment" Text="选择" runat="server" Icon="Find" EnablePostBack="false" />
                                                </Items>
                                            </x:FormRow>
                                        </Rows>
                                    </x:Form>
                                </Items>
                            </x:GroupPanel>
                            <x:TextArea ID="txtRemark" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" runat="server" />
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="departmentWin" Title="部门信息-选择" Popup="false" EnableMaximize="true"
        Target="Top" IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px"
        Height="420px" EnableIFrame="true">
    </x:Window>
    <x:Window ID="personnelWin" Title="职员信息-选择" Popup="false" EnableMaximize="true"
        Target="Top" IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px"
        Height="420px" EnableIFrame="true">
    </x:Window>
    </form>
</body>
</html>
