<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmCensusMemberReport.aspx.cs"
    Inherits="Census_FrmCensusRegister" %>

<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmCensusMemberReport" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Panel ID="pnlSearch" runat="server" ShowHeader="false" EnableLargeHeader="false"
                ShowBorder="false" EnableBackgroundColor="true">
                <Items>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="条件过滤" ID="groupPanel" EnableCollapse="True"
                        Width="1000px">
                        <Items>
                            <x:Panel ID="pnlRow1" ShowHeader="false" CssClass="x-form-item" ShowBorder="false"
                                Layout="Column" runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                <Items>
                                    <x:Label ID="lblCensusType" Width="60px" runat="server" CssClass="inline" ShowLabel="false"
                                        Text="户&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：" />
                                    <x:DropDownList ID="ddlCensusType" runat="server" Width="113px" />
                                    <x:Label ID="lblRegisterNO" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="户&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：" />
                                    <x:TextBox ID="txtRegisterNO" runat="server" Width="118px" />
                                    <x:Label ID="lblHouseHolder" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="户主姓名：" />
                                    <x:TextBox ID="txtHouseHolder" runat="server" Width="118px" />
                                    <x:Label ID="lblName" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：" />
                                    <x:TextBox ID="txtName" runat="server" Width="118px" />
                                    <x:Label ID="lblSex" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：" />
                                    <x:DropDownList ID="ddlSex" runat="server" Width="113px">
                                        <x:ListItem Text="<全部>" Value="" Selected="true" />
                                        <x:ListItem Text="男" Value="1" />
                                        <x:ListItem Text="女" Value="0" />
                                    </x:DropDownList>
                                </Items>
                            </x:Panel>
                            <x:Panel ID="pnlRow2" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="x-form-item datecontainer"
                                runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                <Items>
                                    <x:Label ID="lblIDCard" runat="server" Width="60px" CssClass="inline" ShowLabel="false"
                                        Text="身份证号：" />
                                    <x:TextBox ID="txtIDCard" runat="server" Width="118px" />
                                    <x:Label ID="lblBrithday" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="出生日期：" />
                                    <x:DatePicker ID="dtpBrithdayBegin" Width="87px" runat="server" />
                                    <x:Label ID="lblBrithdaySplit" runat="server" ShowLabel="false" Text="到" CssClass="inline" />
                                    <x:DatePicker ID="dtpBrithdayEnd" Width="87px" runat="server" />
                                    <x:Label ID="lblIngoingDate" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="迁入日期：" />
                                    <x:DatePicker ID="dtpIngoingDateBegin" Width="87px" runat="server" />
                                    <x:Label ID="lblSplitIngoingDate" runat="server" ShowLabel="false" Text="到" CssClass="inline" />
                                    <x:DatePicker ID="dtpIngoingDateEnd" Width="87px" runat="server" />
                                </Items>
                            </x:Panel>
                            <x:Panel ID="pnlRow3" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="x-form-item datecontainer"
                                runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                <Items>
                                    <x:Label ID="lblAddress" runat="server" Width="60px" CssClass="inline" ShowLabel="false"
                                        Text="地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址：" />
                                    <x:TextBox ID="txtAddress" runat="server" Width="250px" />
                                    <x:Label ID="lblIsCanceled" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="状&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;态：" />
                                    <x:DropDownList ID="ddlIsCanceled" Label="" runat="server" Width="113px">
                                        <x:ListItem Text="<全部>" Value="" Selected="true" />
                                        <x:ListItem Text="已注销" Value="1" />
                                        <x:ListItem Text="未注销" Value="0" />
                                    </x:DropDownList>
                                    <x:Button ID="btnClear" Text="清空" CssClass="btnline" runat="server" OnClick="btnClear_Click" />
                                    <x:Button ID="btnFind" Icon="Find" Text="过虑" CssClass="btninline" runat="server"
                                        OnClick="btnFind_Click" />
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:GroupPanel>
                </Items>
            </x:Panel>
            <x:Panel ID="pnlMember" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbForm" runat="server">
                        <Items>
                            <x:Button ID="btnNewMember" Icon="Add" Text="新增" runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnModifyMember" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModifyMember_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDeleteMember" Icon="Delete" Text="删除" runat="server" OnClick="btnDeleteMember_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnExcelTemplate" Icon="PageWhiteExcel" EnableAjax="false" DisableControlBeforePostBack="false"
                                runat="server" Text="Excel模版" OnClick="btnTemplates_Click" />
                            <x:Button ID="btnLoadIn" runat="server" Text="导入Excel" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnLoadOut" EnableAjax="false" runat="server" Text="导出Excel" OnClick="btnLoadOut_Click"
                                DisableControlBeforePostBack="false" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="memberGird" Title="常住人口登记" PageSize="20" ShowBorder="false" AllowPaging="true"
                        AllowSorting="true" OnPageIndexChange="memberGird_PageIndexChange" ShowHeader="False"
                        IsDatabasePaging="true" EnableCheckBoxSelect="true" EnableMultiSelect="true"
                        runat="server" DataKeyNames="ID" SortColumn="RegisterNO" SortDirection="ASC"
                        OnSort="memberGird_Sort" EnableRowNumber="True">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="CensusTypeName" SortField="CensusTypeName"
                                DataField="CensusTypeName" HeaderText="户别" />
                            <x:BoundField Width="100px" ColumnID="RegisterNO" SortField="RegisterNO" DataField="RegisterNO"
                                HeaderText="户号" />
                            <x:BoundField Width="100px" ColumnID="HouseHolder" SortField="HouseHolder" DataField="HouseHolder"
                                HeaderText="户主" />
                            <x:BoundField Width="100px" ColumnID="Name" SortField="Name" DataField="Name" HeaderText="姓名" />
                            <x:BoundField Width="100px" ColumnID="Relation" SortField="Relation" DataField="Relation"
                                HeaderText="与户主关系" />
                            <x:BoundField Width="100px" ColumnID="OtherName" SortField="OtherName" DataField="OtherName"
                                HeaderText="曾用名" />
                            <x:BoundField Width="100px" ColumnID="Gender" SortField="Gender" DataField="Gender"
                                HeaderText="性别" />
                            <x:BoundField Width="100px" ColumnID="PlaceOfBirth" SortField="PlaceOfBirth" DataField="PlaceOfBirth"
                                HeaderText="出生地" />
                            <x:BoundField Width="100px" ColumnID="Nationalilty" SortField="Nationalilty" DataField="Nationalilty"
                                HeaderText="民族" />
                            <x:BoundField Width="100px" ColumnID="PlaceOfAncestral" SortField="PlaceOfAncestral"
                                DataField="PlaceOfAncestral" HeaderText="籍贯" />
                            <x:BoundField Width="100px" ColumnID="Brithday" SortField="Brithday" DataField="Brithday"
                                HeaderText="出生日期" DataFormatString="{0:yyyy-MM-dd}" />
                            <x:BoundField Width="100px" ColumnID="Age" SortField="Age" DataField="Age" HeaderText="年龄" />
                            <x:BoundField Width="100px" ColumnID="Address" SortField="Address" DataField="Address"
                                HeaderText="其他地址" />
                            <x:BoundField Width="100px" ColumnID="Religion" SortField="Religion" DataField="Religion"
                                HeaderText="宗教信养" />
                            <x:BoundField Width="100px" ColumnID="IDCard" SortField="IDCard" DataField="IDCard"
                                HeaderText="身份证号" />
                            <x:BoundField Width="100px" ColumnID="Height" SortField="Height" DataField="Height"
                                HeaderText="身高" />
                            <x:BoundField Width="100px" ColumnID="Education" SortField="Education" DataField="Education"
                                HeaderText="文化水平" />
                            <x:BoundField Width="100px" ColumnID="TypeOfBlood" SortField="TypeOfBlood" DataField="TypeOfBlood"
                                HeaderText="血型" />
                            <x:BoundField Width="100px" ColumnID="Marriage" SortField="Marriage" DataField="Marriage"
                                HeaderText="婚姻状况" />
                            <x:BoundField Width="100px" ColumnID="MilitaryService" SortField="MilitaryService"
                                DataField="MilitaryService" HeaderText="兵役状况" />
                            <x:BoundField Width="100px" ColumnID="Company" SortField="Company" DataField="Company"
                                HeaderText="服务处所" />
                            <x:BoundField Width="100px" ColumnID="IngoingDate" SortField="IngoingDate" DataField="IngoingDate"
                                HeaderText="迁入日期" DataFormatString="{0:yyyy-MM-dd}" />
                            <x:BoundField Width="100px" ColumnID="Political" SortField="Political" DataField="Political"
                                HeaderText="政治面目" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="frmNewCensusMember" Title="新增常住人口登记" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Top" EnableResize="true" runat="server" Icon="Add" Width="730px"
        Height="600px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="frmModifyCensusMember" Title="编辑常住人口信息" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Top" EnableResize="true" runat="server" Icon="Add" Width="730px"
        Height="600px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="frmExcelToMember" Title="导入Excel" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Add"
        Width="730px" Height="480px" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNewMember","btnModifyMember","btnDeleteMember","btnLoadIn","btnLoadOut"]'
        runat="server" />
    </form>
</body>
</html>
