<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmNewCensusRegister.aspx.cs"
    Inherits="Census_FrmNewCensusRegister" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmNewCensusRegister" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </x:Button>
                    <x:Button ID="btnSave" Text="保存" runat="server" ValidateForms="simpleForm" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click">
                    </x:Button>
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlForm" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:SimpleForm ID="simpleForm" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <x:DropDownList ID="ddlCensusType" Label="户&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别"
                                runat="server" />
                            <x:TextBox ID="txtRegisterNO" Label="户&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号" Required="true"
                                runat="server" />
                            <x:TextBox ID="txtHouseHolder" Label="户主姓名" Required="true" runat="server" />
                            <x:TextBox ID="txtHabitation" Label="住&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址" Required="true"
                                runat="server" />
                            <x:TextBox ID="txtIssuingAuthority" Label="登记机关" runat="server" Required="true" />
                            <x:DatePicker ID="dtpIssuingDate" Label="登记日期" runat="server" Required="true" />
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>   
    </form>
</body>
</html>
