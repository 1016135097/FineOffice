<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmCensusRegister.aspx.cs"
    Inherits="Census_FrmCensusRegister" %>

<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmCensusRegister" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="regionPanel" runat="server" />
    <x:RegionPanel ID="regionPanel" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="pnlRegister" ShowHeader="true" Icon="Table" Title="居民户口簿" Layout="VBox"
                ShowBorder="false" EnableBackgroundColor="true" Margins="0 0 0 0" Position="Center"
                runat="server">
                <Items>
                    <x:SimpleForm ID="pnlFind" Width="1000px" BodyPadding="5px" LabelAlign="Right" ShowBorder="false"
                        EnableBackgroundColor="true" ShowHeader="false" runat="server">
                        <Items>
                            <x:Panel ID="pnlRow1" ShowHeader="false" CssClass="x-form-item" ShowBorder="false"
                                Layout="Column" runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                <Items>
                                    <x:Label ID="lblCensusType" Width="60px" runat="server" CssClass="inline" ShowLabel="false"
                                        Text="户&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：" />
                                    <x:DropDownList ID="ddlCensusType" runat="server" Width="113px" />
                                    <x:Label ID="pnlRegisterNO" Width="60px" runat="server" CssClass="middleline" ShowLabel="false"
                                        Text="户&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：" />
                                    <x:TextBox ID="txtRegisterNO" runat="server" Width="118px" />
                                    <x:Label ID="lblHouseHolder" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="户主姓名：" />
                                    <x:TextBox ID="txtHouseHolder" runat="server" Width="118px" />
                                    <x:Label ID="lblHabitation" runat="server" Width="60px" CssClass="middleline" ShowLabel="false"
                                        Text="住&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址：" />
                                    <x:TextBox ID="txtHabitation" runat="server" Width="118px" />
                                    <x:Label ID="lblIssuingAuthority" runat="server" Width="60px" CssClass="middleline"
                                        ShowLabel="false" Text="登记机关：" />
                                    <x:TextBox ID="txtIssuingAuthority" runat="server" Width="118px" />
                                </Items>
                            </x:Panel>
                            <x:Panel ID="pnlRow3" ShowHeader="false" ShowBorder="false" Layout="Column" CssClass="x-form-item datecontainer"
                                runat="server" EnableBackgroundColor="true" BodyPadding="3px">
                                <Items>
                                    <x:Label ID="lblIssuingDate" runat="server" Width="60px" CssClass="inline" ShowLabel="false"
                                        Text="登记日期：" />
                                    <x:DatePicker ID="dtpBegin" Width="89px" runat="server" />
                                    <x:Label ID="lblSplit" runat="server" ShowLabel="false" Text="到" CssClass="inline" />
                                    <x:DatePicker ID="dtpEnd" Width="89px" runat="server" />
                                    <x:Button ID="btnClear" Text="清空" CssClass="mright" runat="server" OnClick="btnClear_Click" />
                                    <x:Button ID="btnFind" Text="过虑" Icon="Find" CssClass="mright" runat="server" OnClick="btnFind_Click" />
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:SimpleForm>
                    <x:Panel ID="pnlRegisterGrid" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                        runat="server">
                        <Toolbars>
                            <x:Toolbar ID="tsbMain" runat="server">
                                <Items>
                                    <x:Button ID="btnNewRegister" Icon="Add" Text="新增" runat="server" />
                                    <x:ToolbarSeparator runat="server" />
                                    <x:Button ID="btnModifyRegister" Icon="ApplicationEdit" Text="编辑" runat="server"
                                        OnClick="btnModifyRegister_Click" />
                                    <x:ToolbarSeparator runat="server" />
                                    <x:Button ID="btnDeleteRegister" Icon="Delete" Text="删除" OnClick="btnDeleteRegister_Click"
                                        runat="server" />
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Items>
                            <x:Grid ID="registerGrid" Title="居民户口薄" PageSize="20" ShowBorder="false" AllowPaging="true"
                                AllowSorting="true" OnPageIndexChange="registerGrid_PageIndexChange" ShowHeader="False"
                                IsDatabasePaging="true" OnRowSelect="registerGrid_RowSelect" EnableCheckBoxSelect="true"
                                EnableMultiSelect="true" EnableRowSelect="true" runat="server" DataKeyNames="ID,RegisterNO"
                                SortColumn="IssuingDate" SortDirection="ASC" OnSort="registerGrid_Sort" EnableRowNumber="True">
                                <Columns>
                                    <x:BoundField Width="100px" HeaderText="户别" ColumnID="CensusTypeName" DataField="CensusTypeName"
                                        SortField="CensusTypeName" />
                                    <x:BoundField Width="100px" HeaderText="户号" ColumnID="RegisterNO" DataField="RegisterNO"
                                        SortField="RegisterNO" />
                                    <x:BoundField Width="100px" HeaderText="户主姓名" ColumnID="HouseHolder" DataField="HouseHolder"
                                        SortField="HouseHolder" />
                                    <x:BoundField Width="200px" HeaderText="住址" ColumnID="Habitation" DataField="Habitation"
                                        SortField="Habitation" />
                                    <x:BoundField Width="100px" HeaderText="登记机关" ColumnID="IssuingAuthority" DataField="IssuingAuthority"
                                        SortField="IssuingAuthority" />
                                    <x:BoundField Width="100px" ColumnID="IssuingDate" HeaderText="登记日期" SortField="IssuingDate"
                                        DataField="IssuingDate" DataFormatString="{0:yyyy-MM-dd}" />
                                </Columns>
                            </x:Grid>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Region>
            <x:Region ID="pnlMember" Split="true" EnableSplitTip="true" CollapseMode="Default"
                EnableBackgroundColor="true" Height="280" Margins="0 0 0 0" ShowHeader="true"
                Title="常住人口登记" EnableLargeHeader="false" Icon="Table" EnableCollapse="true" Position="Bottom"
                Layout="Fit" runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbForm" runat="server">
                        <Items>
                            <x:Button ID="btnNewMember" Icon="Add" Text="新增" runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnModifyMember" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModifyMember_Click" />
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                            <x:Button ID="btnDeleteMember" Icon="Delete" Text="删除" runat="server" OnClick="btnDeleteMember_Click" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="memberGrid" Title="常住人口登记" ShowBorder="false" ShowHeader="False" runat="server"
                        EnableCheckBoxSelect="True" DataKeyNames="ID" EnableRowNumber="True">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="RegisterNO" SortField="RegisterNO" DataField="RegisterNO"
                                HeaderText="户号" />
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
                                DataFormatString="{0:yyyy-MM-dd}" HeaderText="出生日期" />
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
                                HeaderText="身高" />
                            <x:BoundField Width="100px" ColumnID="TypeOfBlood" SortField="TypeOfBlood" DataField="TypeOfBlood"
                                HeaderText="血型" />
                            <x:BoundField Width="100px" ColumnID="Marriage" SortField="Marriage" DataField="Marriage"
                                HeaderText="婚姻状况" />
                            <x:BoundField Width="100px" ColumnID="MilitaryService" SortField="MilitaryService"
                                DataField="MilitaryService" HeaderText="兵役状况" />
                            <x:BoundField Width="100px" ColumnID="Company" SortField="Company" DataField="Company"
                                HeaderText="服务处所" />
                            <x:BoundField Width="100px" ColumnID="Political" SortField="Political" DataField="Political"
                                HeaderText="政治面目" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Region>
        </Regions>
    </x:RegionPanel>
    <x:Window ID="frmNewCensusRegister" Title="新增" Popup="false" runat="server" IsModal="true"
        EnableMaximize="true" Target="Top" EnableResize="true" IFrameUrl="FrmNewCensusRegister.aspx"
        Icon="Add" Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="frmModifyCensusRegister" Title="编辑" Popup="false" EnableMaximize="true"
        Target="Top" EnableResize="true" runat="server" IsModal="true" Icon="Add" Width="500px"
        Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="frmNewCensusMember" Title="新增常住人口登记" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Top" EnableResize="true" runat="server" Icon="Add" Width="730px"
        Height="600px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="frmModifyCensusMember" Title="编辑常住人口信息" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Top" EnableResize="true" runat="server" Icon="Add" Width="730px"
        Height="600px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNewRegister","btnModifyRegister","btnDeleteRegister","btnNewMember","btnModifyMember","btnDeleteMember"]'
        runat="server" />
    </form>
</body>
</html>
