<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmExpireContract.aspx.cs"
    Inherits="Contract_FrmExpireContract" %>

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
    <form id="_FrmExpireContract" runat="server">
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
                                    <x:Label ID="lblContractNO" Width="60px" runat="server" CssClass="inline" ShowLabel="false"
                                        Text="合同编号：" />
                                    <x:TextBox ID="txtContractNO" runat="server" Width="118px" />
                                    <x:Label ID="lblContractName" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="合同名称：" />
                                    <x:TextBox ID="txtContractName" runat="server" Width="118px" />
                                    <x:Label ID="lblType" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="合同类别：" />
                                    <x:DropDownList ID="ddlType" runat="server" Width="112px" />
                                    <x:Label ID="lblTrader" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="签定企业：" />
                                    <x:TriggerBox ID="txtTrader" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                        runat="server" Width="112px" />
                                    <x:Label ID="lblHandler" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="签定人：" />
                                    <x:TriggerBox ID="txtHandler" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                        runat="server" Width="112px" />
                                </Items>
                            </x:Panel>
                            <x:Panel ID="row2" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="x-form-item datecontainer"
                                runat="server" EnableBackgroundColor="true">
                                <Items>
                                    <x:Label ID="lblSingnDate" runat="server" Width="60px" CssClass="inline" ShowLabel="false"
                                        Text="签定日期：" />
                                    <x:DatePicker ID="dtpBeginDate" Width="85px" runat="server" />
                                    <x:Label ID="lblSplit" runat="server" ShowLabel="false" Text="到" CssClass="inline" />
                                    <x:DatePicker ID="dtpEndDate" Width="85px" runat="server" />
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
                            <x:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDelelte" Icon="Delete" Text="删除" runat="server" OnClick="btnDelete_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnRefresh" Icon="ArrowRefresh" Text="刷新" runat="server" OnClick="btnRefresh_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:TextBox ID="txtExpire" Width="50" runat="server" RegexPattern="NUMBER" />
                            <x:Button ID="btnExpire" Text="设置天数" runat="server" OnClick="btnExpire_Click" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="contractGrid" Title="合同信息" PageSize="20" ShowBorder="false" AllowPaging="true"
                        AllowSorting="true" OnPageIndexChange="contractGrid_PageIndexChange" ShowHeader="False"
                        EnableCheckBoxSelect="true" EnableMultiSelect="true" runat="server" DataKeyNames="ID,ContractName"
                        SortColumn="SingnDate" SortDirection="ASC" OnSort="contractGrid_Sort" EnableRowNumber="True">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="ContractNO" SortField="ContractNO" DataField="ContractNO"
                                HeaderText="合同编号" Hideable="false" />
                            <x:BoundField Width="100px" ColumnID="ContractName" SortField="ContractName" DataField="ContractName"
                                HeaderText="合同名称" />
                            <x:BoundField Width="100px" ColumnID="TypeName" SortField="TypeName" DataField="TypeName"
                                HeaderText="合同类别" />
                            <x:BoundField Width="100px" ColumnID="TraderName" SortField="TraderName" DataField="TraderName"
                                HeaderText="签定企业" />
                            <x:BoundField Width="100px" ColumnID="HandlerName" SortField="HandlerName" DataField="HandlerName"
                                HeaderText="签定人" />
                            <x:BoundField Width="100px" DataFormatString="{0:yyyy-MM-dd}" ColumnID="SingnDate"
                                SortField="SingnDate" DataField="SingnDate" HeaderText="签定日期" />
                            <x:BoundField Width="100px" DataFormatString="{0:yyyy-MM-dd}" ColumnID="EndDate"
                                SortField="EndDate" DataField="EndDate" HeaderText="有效期至" />
                            <x:BoundField Width="100px" ColumnID="Location" SortField="Location" DataField="Location"
                                HeaderText="存放位置" />
                            <x:BoundField Width="100px" ColumnID="Expire" SortField="Expire" DataField="Expire"
                                HeaderText="到期剩余天数" />
                            <x:BoundField Width="100px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                HeaderText="备注" />
                            <x:LinkButtonField TextAlign="Center" Icon="Delete" ConfirmText="确认删除吗？" Width="50px"
                                ToolTip="删除" CommandName="delete" Hideable="false" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hiddenHandler" runat="server" />
    <x:HiddenField ID="hiddenTraderID" runat="server" />
    <x:Window ID="handlerWin" Title="签订人" Popup="false" EnableMaximize="true" Target="Parent"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyContractWin" Title="编辑" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="Add" Width="730px" Height="550px"
        EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="traderWin" Title="企业信息" Popup="false" EnableMaximize="true" Target="Parent"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnModify","btnDelete"]'
        runat="server" />
    </form>
</body>
</html>
