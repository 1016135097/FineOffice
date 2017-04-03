<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmDesignForm.aspx.cs" Inherits="WorkFlow_FrmDesignForm" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin: 0px;">
    <form id="FrmDesign" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlForm" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" OnClientClick="Exit();"
                        runat="server" Icon="SystemClose" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnSave" Text="保存" runat="server" ValidateForms="simpleForm" ValidateMessageBox="false"
                        OnClientClick="SaveDoc();" Icon="SystemSave" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnSaveExit" Text="保存退出" runat="server" ValidateForms="simpleForm"
                        ValidateMessageBox="false" OnClientClick="SaveExit();" Icon="SystemSaveClose" />
                    <x:ToolbarFill ID="ToolbarFill1" runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
    </x:Panel>
    <object id="FineWebOffice" height="870" width='100%' style='left: 0px; top: 0px'
        classid='clsid:E77E049B-23FC-4DB8-B756-60529A35FAD5' codebase="WebOffice/weboffice_v6.0.5.0.cab">
        <param name='_ExtentX' value='6350' />
        <param name='_ExtentY' value='6350' />
    </object>
    </form>
    <script type="text/javascript">
        Ext.onReady(function () {
            Ext.useShims = true
            Office_NotifyCtrlReady();
        })
        function Office_NotifyCtrlReady() {           
            var office = document.all.FineWebOffice;
            office.OptionFlag |= 0x0400;
            office.LoadOriginalFile('<%=GetServerUri() %>WorkFlow/GetFlowForm.ashx?ID=<%=model.ID%>', '<%= model.XType%>');
            <%if(this.CookiePersonnel!=null){ %>
            office.SetCurrUserName('<%=this.CookiePersonnel.Name %>');
            <%} %>
        }

        function SetTrackRevisions(state) {
            document.all.FineWebOffice.SetTrackRevisions(state);
        }

        //关闭当前选项
        function Exit() {
            var office = document.all.FineWebOffice;
            office.style.display="none";
            parent.closeCurrentTab();      
        }

        function SaveDoc() {
            var office = document.all.FineWebOffice;
            office.HttpInit();
            office.SetTrackRevisions(0);
            office.ShowRevisions(0);
            office.HttpAddPostString("ID", '<%=Request["ID"] %>');
            office.HttpAddPostCurrFile("DocContent", "");
            var vtRet = office.HttpPost("<%=GetServerUri() %>WorkFlow/SaveFlowForm.ashx");           
        }

        function SaveExit() {
            var office = document.all.FineWebOffice;
            office.HttpInit();
            office.SetTrackRevisions(0);
            office.ShowRevisions(0);
            office.HttpAddPostString("ID", '<%=Request["ID"] %>');
            office.HttpAddPostCurrFile("DocContent", "");
            var vtRet = office.HttpPost("<%=GetServerUri() %>WorkFlow/SaveFlowForm.ashx");
            parent.closeCurrentTab();
        }             
    </script>
</body>
</html>
