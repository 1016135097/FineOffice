<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmLetterList.aspx.cs" Inherits="Letter_FrmLetterList" %>

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
    <form id="_FrmLetterList" runat="server">
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
                            <x:Panel ID="pnlRow1" ShowHeader="false" CssClass="x-form-item" ShowBorder="false"
                                Layout="Column" runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                <Items>
                                    <x:Label ID="lblChanne" Width="60px" runat="server" CssClass="inline" ShowLabel="false"
                                        Text="信访渠道：" />
                                    <x:DropDownList ID="ddlChannel" runat="server" Width="113px" />
                                    <x:Label ID="lblLetterType" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="问题分类：" />
                                    <x:DropDownList ID="ddlLetterType" runat="server" Width="113px" />
                                    <x:Label ID="lblLetterNO" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="信访编号：" />
                                    <x:TextBox ID="txtLetterNO" runat="server" Width="118px" />
                                    <x:Label ID="lblTitle" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题：" />
                                    <x:TextBox ID="txtTitle" runat="server" Width="118px" />
                                    <x:Label ID="lblVisitor" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="信&nbsp;&nbsp;访&nbsp;人：" />
                                    <x:TextBox ID="txtVisitor" runat="server" Width="118px" />
                                </Items>
                            </x:Panel>
                            <x:Panel ID="pnlRow2" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="x-form-item datecontainer"
                                runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                <Items>
                                    <x:Label ID="lblSex" runat="server" Width="60px" CssClass="inline" ShowLabel="false"
                                        Text="性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：" />
                                    <x:DropDownList ID="ddlSex" runat="server" Width="109px">
                                        <x:ListItem Text="<全部>" Value="" Selected="true" />
                                        <x:ListItem Text="男" Value="1" />
                                        <x:ListItem Text="女" Value="0" />
                                    </x:DropDownList>
                                    <x:Label ID="lblIDCard" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="身份证号：" />
                                    <x:TextBox ID="txtIDCard" runat="server" Width="118px" />
                                    <x:Label ID="lblAddress" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址：" />
                                    <x:TextBox ID="txtAddress" runat="server" Width="118px" />
                                    <x:Label ID="lblVisitDate" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="信访日期：" />
                                    <x:DatePicker ID="dtpBeginDate" Width="90px" runat="server" />
                                    <x:Label ID="lblSplit" runat="server" ShowLabel="false" Text="到" CssClass="inline" />
                                    <x:DatePicker ID="dtpEndDate" Width="90px" runat="server" />
                                </Items>
                            </x:Panel>
                            <x:Panel ID="pnlRow3" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="x-form-item datecontainer"
                                runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                <Items>
                                    <x:Label ID="lblHandler" runat="server" Width="60px" CssClass="inline" ShowLabel="false"
                                        Text="处&nbsp;&nbsp;理&nbsp;人：" />
                                    <x:TextBox ID="txtHandler" Width="118px" runat="server" Readonly="true" />
                                    <x:Button ID="btnHandler" Text="选择" runat="server" />
                                    <x:Label ID="lblRecorder" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="登&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;记：" />
                                    <x:TextBox ID="txtRecorder" Width="118px" runat="server" Readonly="true" />
                                    <x:Button ID="btnRecorder" Text="选择" runat="server" />
                                    <x:Button ID="btnClear" Text="清空" CssClass="btnline" runat="server" OnClick="btnClear_Click" />
                                    <x:Button ID="btnFind" Text="过虑" CssClass="btninline" Icon="Find" runat="server"
                                        OnClick="btnFind_Click" />
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:GroupPanel>
                </Items>
            </x:Panel>
            <x:Panel ID="pnlLetter" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbForm" runat="server">
                        <Items>
                            <x:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnFollow" Icon="BookAdd" Text="跟进情况" runat="server" OnClick="btnFollow_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDelete" Icon="Delete" Text="删除" runat="server" OnClick="btnDelete_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnRefresh" Icon="ArrowRefresh" Text="刷新" OnClick="btnRefresh_Click"
                                runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnLoadOut" EnableAjax="false" Icon="PageWhiteExcel" runat="server"
                                Text="导出Excel" OnClick="btnLoadOut_Click" DisableControlBeforePostBack="false" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="letterGrid" Title="信访记录" PageSize="20" ShowBorder="false" AllowPaging="true"
                        AllowSorting="true" OnPageIndexChange="letterGrid_PageIndexChange" ShowHeader="False"
                        EnableCheckBoxSelect="true" EnableMultiSelect="true" runat="server" DataKeyNames="ID,Title"
                        SortColumn="VisitTime" SortDirection="ASC" OnSort="letterGrid_Sort" EnableRowNumber="True">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="LetterNO" SortField="LetterNO" DataField="LetterNO"
                                Hideable="false" HeaderText="信访编号" />
                            <x:BoundField Width="100px" ColumnID="Title" SortField="Title" DataField="Title"
                                HeaderText="标题" />
                            <x:BoundField Width="100px" ColumnID="Channel" SortField="Channel" DataField="Channel"
                                HeaderText="信访渠道" />
                            <x:BoundField Width="100px" ColumnID="LetterType" SortField="LetterType" DataField="LetterType"
                                HeaderText="问题分类" />
                            <x:BoundField Width="100px" ColumnID="NumberOfpeople" SortField="NumberOfpeople"
                                DataField="NumberOfpeople" HeaderText="信访人数" />
                            <x:BoundField Width="100px" ColumnID="Area" SortField="Area" DataField="Area" HeaderText="发生地点" />
                            <x:BoundField Width="180px" ColumnID="VisitTime" SortField="VisitTime" DataField="VisitTime"
                                HeaderText="信访时间" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                            <x:BoundField Width="100px" ColumnID="Visitor" SortField="Visitor" DataField="Visitor"
                                HeaderText="信访人" />
                            <x:BoundField Width="100px" ColumnID="Age" SortField="Age" DataField="Age" HeaderText="年龄" />
                            <x:BoundField Width="100px" ColumnID="Gender" SortField="Gender" DataField="Gender"
                                HeaderText="性别" />
                            <x:BoundField Width="100px" ColumnID="Mobile" SortField="Mobile" DataField="Mobile"
                                HeaderText="移动电话" />
                            <x:BoundField Width="100px" ColumnID="IDCard" SortField="IDCard" DataField="IDCard"
                                HeaderText="身份证号" />
                            <x:BoundField Width="100px" ColumnID="Address" SortField="Address" DataField="Address"
                                HeaderText="联系地址" />
                            <x:BoundField Width="100px" ColumnID="ReceiverName" SortField="ReceiverName" DataField="ReceiverName"
                                HeaderText="信访对象" />
                            <x:BoundField Width="100px" ColumnID="HandlerName" SortField="HandlerName" DataField="HandlerName"
                                HeaderText="处理人" />
                            <x:BoundField Width="100px" ColumnID="RecorderName" SortField="RecorderName" DataField="RecorderName"
                                HeaderText="登记人" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:HiddenField ID="hiddenHandler" runat="server" />
    <x:HiddenField ID="hiddenRecorder" runat="server" />
    <x:Window ID="wndHandler" Title="处理人" Popup="false" EnableMaximize="true" Target="Top"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    <x:Window ID="wndRecorder" Title="登记人" Popup="false" EnableMaximize="true" Target="Top"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnFollow","btnModify","btnDelete"]'
        runat="server" />
    </form>
</body>
</html>
