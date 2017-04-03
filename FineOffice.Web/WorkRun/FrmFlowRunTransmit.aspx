<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmFlowRunTransmit.aspx.cs"
    Inherits="WorkRun_FrmFlowRunTransmit" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="FrmNew" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlForm" runat="server" />
    <x:Panel ID="pnlForm" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Items>
            <x:Panel ID="pnlMain" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                <Items>
                    <x:Form ID="searchForm" runat="server" ShowBorder="False" EnableBackgroundColor="true"
                        ShowHeader="False">
                        <Rows>
                            <x:FormRow runat="server" ColumnWidths="300 80">
                                <Items>
                                    <x:TextBox ID="txtPersonnel" Required="true" runat="server" Readonly="true" Label="选择人员" />
                                    <x:Button ID="btnFind" Text="选择" runat="server" Icon="Find" />
                                </Items>
                            </x:FormRow>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:TextArea ID="txtTransmitAdvice" Label="委托原因" runat="server" Height="80" />
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
                <Toolbars>
                    <x:Toolbar ID="toolbar" runat="server" Position="Footer">
                        <Items>
                            <x:Button ID="btnSave" Text="确定" runat="server" Icon="SystemSaveNew" ValidateForms="searchForm"
                                ValidateMessageBox="false" OnClick="btnSave_Click" />
                            <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hiddenRunProcess" runat="server" />
    <x:HiddenField ID="hiddenPersonnel" runat="server" />
    <x:HiddenField ID="hiddenVersion" runat="server" />
    <x:Window ID="frmPersonnel" Title="选择人员" Popup="false" EnableMaximize="true" Target="Top"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    </form>
</body>
</html>
