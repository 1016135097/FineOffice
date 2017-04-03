<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmAreaList.aspx.cs" Inherits="Trader_FrmAreaList" %>

<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="_FrmAreaList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" ShowBorder="false" Layout="HBox" BoxConfigAlign="Stretch"
        BoxConfigPosition="Start" BoxConfigPadding="0" BoxConfigChildMargin="0 5 0 0"
        ShowHeader="false">
        <Items>
            <x:Panel ID="pnlArea" BoxFlex="1" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                ShowBorder="true" ShowHeader="true" Layout="Fit" Title="地区信息">
                <Toolbars>
                    <x:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <x:Button ID="btnNew" Icon="Add" Text="新增" runat="server" EnablePostBack="false" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDelete" Icon="Delete" Text="删除" runat="server" OnClick="btnDelelte_Click" />
                            <x:Button ID="btnExpandAll" Icon="Folder" Text="展开" OnClick="btnExpandAll_Click"
                                runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnCollapseAll" Icon="FolderUp" Text="收起" OnClick="btnCollapseAll_Click"
                                runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnRefresh" Icon="ArrowRefresh" Text="刷新" OnClick="btnRefresh_Click"
                                runat="server" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Tree runat="server" ID="tvwArea" EnableArrows="false" AutoScroll="true" EnableIcons="false"
                        Title="地区信息" OnNodeCommand="tvwArea_NodeCommand" Expanded="true" ShowHeader="false"
                        ShowBorder="false">
                    </x:Tree>
                </Items>
            </x:Panel>
            <x:SimpleForm ID="frmArea" runat="server" Width="350px" LabelAlign="Left" LabelWidth="60px"
                ShowBorder="true" Title="详细信息" BodyPadding="5px 10px" BoxMargin="0">
                <Items>
                    <x:Label runat="server" ID="lblArea" Label="地区信息" />
                    <x:Label runat="server" ID="lblOrdering" Label="排&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;序" />
                    <x:Label runat="server" ID="lblAreaNumber" Label="地区数量" />
                    <x:Label runat="server" ID="lblTraderNumber" Label="企业数量" />
                    <x:Label runat="server" ID="lblRemark" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" />
                </Items>
            </x:SimpleForm>
        </Items>
    </x:Panel>
    <x:Window ID="newAreaWin" Title="新增" Popup="false" IFrameUrl="FrmNewArea.aspx" EnableMaximize="true"
        IsModal="true" Target="Top" EnableResize="true" runat="server" Icon="Add" Width="500px"
        Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyAreaWin" Title="编程" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Top" EnableResize="true" runat="server" Icon="Pencil" Width="500px" Height="300px"
        EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]'
        runat="server" />
    </form>
</body>
</html>
