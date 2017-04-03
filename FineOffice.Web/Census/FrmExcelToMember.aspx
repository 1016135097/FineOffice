<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmExcelToMember.aspx.cs"
    Inherits="Census_FrmExcelToMember" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmExcelToMember" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="VBox" ShowBorder="False" ShowHeader="false"
        BoxConfigAlign="Stretch" BodyPadding="0px" EnableBackgroundColor="true">
        <Items>
            <x:SimpleForm ID="simpleForm" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                Width="500px" AutoScroll="true" BodyPadding="10px" runat="server" EnableCollapse="True">
                <Items>
                    <x:FileUpload runat="server" ID="uploadFile" RegexMessage="非Excel文件" Label="选择Excel文件"
                        Required="true" Regex="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.xls|.XLS)$"
                        ShowRedStar="false" />
                </Items>
            </x:SimpleForm>
            <x:Panel ID="pnlMember" runat="server" Layout="Fit" ShowBorder="true" ShowHeader="false"
                BoxFlex="1" BodyPadding="0px" EnableBackgroundColor="true">
                <Items>
                    <x:Grid ID="gridMember" Title="常住人口登记" ShowBorder="False" ShowHeader="False" EnableCheckBoxSelect="true"
                        EnableMultiSelect="true" runat="server" EnableRowNumber="True">
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
                            <x:BoundField Width="100px" ColumnID="IsCanceled" SortField="IsCanceled" DataField="IsCanceled"
                                HeaderText="已注销" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
        <Toolbars>
            <x:Toolbar ID="toolbar" runat="server" Position="Footer">
                <Items>
                    <x:Button ID="btnLoad" Text="导入" runat="server" Icon="ReportGo" ValidateForms="simpleForm"
                        ValidateMessageBox="false" OnClick="btnLoad_Click" />
                    <x:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" ValidateMessageBox="false"
                        OnClick="btnSave_Click" />
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                </Items>
            </x:Toolbar>
        </Toolbars>
    </x:Panel>
    </form>
</body>
</html>
