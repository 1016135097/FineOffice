﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmModifyPolitical.aspx.cs"
    Inherits="Census_FrmModifyPolitical" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmModifyPolitical" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="False">
        <Items>
            <x:SimpleForm ID="simpleForm" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="False"
                AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                <Items>
                    <x:HiddenField ID="hiddenID" runat="server" />
                    <x:TextBox ID="txtPolitical" ShowLabel="false" Required="true" runat="server" />
                </Items>
            </x:SimpleForm>
        </Items>
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server" Position="Footer">
                <Items>
                    <x:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" ValidateForms="simpleForm"
                        ValidateMessageBox="false" OnClick="btnSave_Click" />
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                </Items>
            </x:Toolbar>
        </Toolbars>
    </x:Panel>
    </form>
</body>
</html>
