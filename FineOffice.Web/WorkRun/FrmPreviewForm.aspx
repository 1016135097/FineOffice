<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmPreviewForm.aspx.cs" Inherits="WorkRun_FrmPreviewForm" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin: 0px;">
    <form id="FrmDesign" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlForm" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        EnableBackgroundColor="true">
    </x:Panel>
    <object id="FineWebOffice" height="870" width='100%' style='left: 0px; top: 0px'
        classid='clsid:E77E049B-23FC-4DB8-B756-60529A35FAD5' codebase="../WorkFlow/WebOffice/weboffice_v6.0.5.0.cab">
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
            office.ShowToolBar=false;
            office.SetToolBarButton2("Menu Bar",1,8);
            office.HideMenuArea("hideall","","","");
            office.ProtectDoc(1,1, "");
            office.HideMenuArea("","","","");

            office.OptionFlag |= 0x0400;
            office.LoadOriginalFile('<%=GetServerUri() %>WorkRun/GetWorkForm.ashx?ID=<%=model.ID %>', '<%=model.XType %>');
            <%if(this.CookiePersonnel!=null){ %>
            office.SetCurrUserName('<%=this.CookiePersonnel.Name %>');
            <%} %>           
        }
    </script>
</body>
</html>
