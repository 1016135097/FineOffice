<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmNewForm.aspx.cs" Inherits="WorkFlow_FrmNewForm" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="..css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmNewForm" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </x:Button>
                    <x:Button ID="btnSave" Text="保存" runat="server" ValidateForms="frmForm" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click">
                    </x:Button>
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlForm" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:SimpleForm ID="frmForm" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <x:TextBox ID="txtFormNO" Label="表单编码" Required="true" runat="server" />
                            <x:TextBox ID="txtFormName" Label="表单名称" Required="true" runat="server" OnTextChanged="Pinyin_TextChanged"
                                AutoPostBack="true" />
                            <x:TextBox ID="txtPinyinCode" Label="拼&nbsp;&nbsp;音&nbsp;码" Required="true" runat="server" />
                            <x:DropDownList ID="ddlType" Label="表单类型" runat="server" Width="200px" />
                            <x:CheckBox ID="chkStop" runat="server" Checked="true" Text="" Label="是否可用">
                            </x:CheckBox>
                            <x:TextArea ID="txtRemark" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" runat="server" />
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
