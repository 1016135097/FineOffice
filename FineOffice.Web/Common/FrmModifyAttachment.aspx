<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmModifyAttachment.aspx.cs"
    Inherits="Common_FrmModifyAttachment" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmModifyAttachment" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="False">
        <Items>
            <x:Panel ID="pnlAttachment" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:SimpleForm ID="frmAttachment" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="False"
                        AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                        <Items>
                            <x:HiddenField ID="hiddenID" runat="server" />
                            <x:TextBox ID="txtFileName" ShowLabel="false" Required="true" runat="server" />
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server" Position="Footer">
                <Items>
                    <x:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" ValidateForms="frmAttachment"
                        ValidateMessageBox="false" OnClick="btnSave_Click" />
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                </Items>
            </x:Toolbar>
        </Toolbars>
    </x:Panel>   
    </form>
</body>
</html>
