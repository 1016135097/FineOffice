<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <%--<meta http-equiv="X-UA-Compatible" content="IE=7" />--%>
    <title>村委办公系统-支点软件</title>
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <script src="js/default.js" type="text/javascript"></script>
</head>
<body>
    <form id="mainForm" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server"></x:PageManager>
    <x:RegionPanel ID="pnlMain" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="pnlTop" Margins="0 0 0 0" ShowBorder="false" Height="50px" ShowHeader="false"
                Position="Top" Layout="Fit" runat="server">
                <Items>
                    <x:ContentPanel CssClass="jumbotron" ShowHeader="false" ID="ContentPanel1" runat="server">
                        <div class="title">
                            <a href="#" title="" class="logo">
                                <img src="./images/logo.png" alt="支点软件" /></a>
                        </div>
                    </x:ContentPanel>
                </Items>
            </x:Region>
            <x:Region ID="pnlMenu" EnableSplitTip="true" CollapseMode="Mini" Margins="0 0 0 0"
                Width="200px" ShowHeader="true" Title="功能菜单" EnableLargeHeader="false" Split="true"
                Icon="Outline" EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                <Toolbars>
                    <x:Toolbar ID="toolbar" Position="Top" runat="server">
                        <Items>
                            <x:Button ID="btnExpandAll" Icon="Folder" Text="展开" EnablePostBack="false" runat="server" />
                            <x:ToolbarSeparator ID="tss1" runat="server" />
                            <x:Button ID="btnCollapseAll" Icon="FolderUp" Text="收起" EnablePostBack="false" runat="server" />
                            <x:ToolbarFill ID="toolbarFill" runat="server" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
            </x:Region>
            <x:Region ID="pnlRight" ShowHeader="false" Layout="Fit" Margins="0 0 0 0" Position="Center"
                runat="server">
                <Items>
                    <x:TabStrip ID="tbsRight" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                        <Tabs>
                            <x:Tab Title="首页" Layout="Fit" Icon="House" runat="server">
                                <Items>
                                    <x:ContentPanel ShowBorder="true" BodyPadding="5px" ShowHeader="false" AutoScroll="true"
                                        CssClass="intro" runat="server">
                                    </x:ContentPanel>
                                </Items>
                            </x:Tab>
                        </Tabs>
                    </x:TabStrip>
                </Items>
            </x:Region>
        </Regions>
        <Toolbars>
            <x:Toolbar ID="buttomToolbar" runat="server" Position="Bottom">
                <Items>
                    <x:Button ID="btnExit" Icon="ComputerStop" Text="安全退出" EnablePostBack="false" runat="server" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnUser" Icon="User" EnablePostBack="false" runat="server" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnRefreshTab" Icon="ArrowRefresh" Text="刷新当前页" EnablePostBack="false"
                        runat="server" />
                    <x:ToolbarFill runat="server" />
                    <x:Label runat="server" ID="lblFineOffice" Text="技术支持：" />
                    <x:LinkButton runat="server" ID="FineOffice" Text="中山支点软件有限公司" EnablePostBack="false" />
                    <x:ToolbarSeparator runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
    </x:RegionPanel>
    </form>
</body>
</html>
