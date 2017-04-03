<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmTraderList.aspx.cs" Inherits="Trader_FrmTraderList" %>

<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="_FrmTraderList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Panel ID="pnlFind" runat="server" ShowHeader="false" EnableLargeHeader="false"
                ShowBorder="false" EnableBackgroundColor="true">
                <Items>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="条件过滤" ID="grpCondition" EnableCollapse="True"
                        Width="1000px">
                        <Items>
                            <x:Panel ID="row1" ShowHeader="false" CssClass="x-form-item" ShowBorder="false" Layout="Column"
                                runat="server" EnableBackgroundColor="true">
                                <Items>
                                    <x:Label ID="lblArea" Width="60px" runat="server" CssClass="inline" ShowLabel="false"
                                        Text="所在地区：" />
                                    <x:TriggerBox ID="txtArea" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                        runat="server" Width="112px" />
                                    <x:Label ID="lblIndustry" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="行业分类：" />
                                    <x:DropDownList ID="ddlIndustry" runat="server" Width="112px" />
                                    <x:Label ID="lblTraderType" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="企业性质：" />
                                    <x:DropDownList ID="ddlTraderType" runat="server" Width="112px" />
                                    <x:Label ID="lblSource" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="来源渠道：" />
                                    <x:DropDownList ID="ddlSource" runat="server" Width="112px" />
                                    <x:Label ID="lblGrade" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="企业等级：" />
                                    <x:DropDownList ID="ddlGrade" runat="server" Width="112px" />
                                </Items>
                            </x:Panel>
                            <x:Panel ID="row2" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="x-form-item datecontainer"
                                runat="server" EnableBackgroundColor="true">
                                <Items>
                                    <x:Label ID="lblTraderNO" runat="server" Width="60px" CssClass="inline" ShowLabel="false"
                                        Text="编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：" />
                                    <x:TextBox ID="txtTraderNO" runat="server" Width="118px" />
                                    <x:Label ID="lblTraderName" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="企业名称：" />
                                    <x:TextBox ID="txtTraderName" runat="server" Width="118px" />
                                    <x:Label ID="lblCreateTime" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="创建日期：" />
                                    <x:DatePicker ID="dtpBeginDate" Width="85px" runat="server" />
                                    <x:Label ID="lblSplit" runat="server" ShowLabel="false" Text="到" CssClass="inline" />
                                    <x:DatePicker ID="dtpEndDate" Width="85px" runat="server" />
                                    <x:Label ID="lblHandler" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="跟&nbsp;&nbsp;进&nbsp;人：" />
                                    <x:TriggerBox ID="txtHandler" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                        runat="server" Width="108px" />
                                    <x:DropDownList ID="ddlRule" runat="server" Width="80px">
                                        <x:ListItem Text="<全部>" Value="" />
                                        <x:ListItem Text="客户&供应商" Value="All" />
                                        <x:ListItem Text="客户" Value="Client" />
                                        <x:ListItem Text="供应商" Value="Supplier" />
                                    </x:DropDownList>
                                    <x:Button ID="btnClear" Text="清空" CssClass="btnline" runat="server" OnClick="btnClear_Click" />
                                    <x:Button ID="btnFind" Text="过虑" CssClass="btninline" runat="server" OnClick="btnFind_Click" />
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:GroupPanel>
                </Items>
            </x:Panel>
            <x:Panel ID="pnlTraderList" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbForm" runat="server">
                        <Items>
                            <x:Button ID="btnNew" Icon="Add" Text="新增" runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDelete" Icon="Delete" Text="删除" runat="server" OnClick="btnDelete_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnRefresh" Icon="ArrowRefresh" Text="刷新" runat="server" OnClick="btnRefresh_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnLoadOut" EnableAjax="false" Icon="PageWhiteExcel" OnClick="btnLoadOut_Click"
                                runat="server" Text="导出Excel" DisableControlBeforePostBack="false" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="traderGrid" Title="企业信息" PageSize="20" ShowBorder="false" AllowPaging="true"
                        AllowSorting="true" OnPageIndexChange="traderGrid_PageIndexChange" ShowHeader="False"
                        EnableCheckBoxSelect="true" EnableMultiSelect="true" runat="server" DataKeyNames="ID,TraderName"
                        SortColumn="CreateTime" SortDirection="ASC" OnSort="traderGrid_Sort" EnableRowNumber="True">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="TraderNO" SortField="TraderNO" DataField="TraderNO"
                                HeaderText="编码" Hideable="false" />
                            <x:BoundField Width="100px" ColumnID="TraderName" SortField="TraderName" DataField="TraderName"
                                HeaderText="企业名称" />
                            <x:BoundField Width="100px" ColumnID="ShortName" SortField="ShortName" DataField="ShortName"
                                HeaderText="简称" />
                            <x:BoundField Width="100px" ColumnID="HandlerName" SortField="HandlerName" DataField="HandlerName"
                                HeaderText="跟进人" />
                            <x:BoundField Width="100px" ColumnID="Area" SortField="Area" DataField="Area" HeaderText="所在地区" />
                            <x:BoundField Width="100px" ColumnID="Industry" SortField="Industry" DataField="Industry"
                                HeaderText="行业分类" />
                            <x:BoundField Width="100px" ColumnID="TraderType" SortField="TraderType" DataField="TraderType"
                                HeaderText="企业性质" />
                            <x:BoundField Width="100px" ColumnID="Source" SortField="Source" DataField="Source"
                                HeaderText="来源渠道" />
                            <x:BoundField Width="100px" ColumnID="Grade" SortField="Grade" DataField="Grade"
                                HeaderText="企业等级" />
                            <x:BoundField Width="100px" ColumnID="Linkman" SortField="Linkman" DataField="Linkman"
                                HeaderText="联系人" />
                            <x:BoundField Width="100px" ColumnID="Mobile" SortField="Mobile" DataField="Mobile"
                                HeaderText="移动电话" />
                            <x:CheckBoxField Width="100px" ColumnID="IsClient" SortField="IsClient" TextAlign="Center"
                                RenderAsStaticField="true" DataField="IsClient" HeaderText="是/否客户" />
                            <x:CheckBoxField Width="100px" ColumnID="IsSupplier" SortField="IsSupplier" TextAlign="Center"
                                RenderAsStaticField="true" DataField="IsSupplier" HeaderText="是/否供应商" />
                            <x:BoundField Width="100px" ColumnID="CreateTime" SortField="CreateTime" DataField="CreateTime"
                                HeaderText="创建日期" DataFormatString="{0:yyyy-MM-dd}" />
                            <x:BoundField Width="100px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                HeaderText="备注" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hiddenAreaID" runat="server" />
    <x:HiddenField ID="hiddenHandler" runat="server" />
    <x:Window ID="selectAreaWin" Title="选择地区" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="Find" Width="310px"
        Height="435px" EnableIFrame="true">
    </x:Window>
    <x:Window ID="handlerWin" Title="跟进人" Popup="false" EnableMaximize="true" Target="Parent"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    <x:Window ID="newTraderWin" Title="新增" Popup="false" IFrameUrl="FrmNewTrader.aspx"
        EnableMaximize="true" IsModal="true" Target="Parent" EnableResize="true" runat="server"
        Icon="Add" Width="730px" Height="550px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyTraderWin" Title="编辑" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="Add" Width="730px" Height="550px"
        EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]'
        runat="server" />
    </form>
</body>
</html>
