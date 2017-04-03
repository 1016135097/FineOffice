<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmModifyCensusMember.aspx.cs"
    Inherits="Census_FrmModifyCensusMember" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmModifyCensusMember" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsbMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </x:Button>
                    <x:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" OnClick="btnSave_Click"
                        ValidateForms="BaseForm" ValidateMessageBox="false">
                    </x:Button>
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlPerson" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true">
                <Items>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="基本信息" ID="groupPanel" EnableCollapse="True"
                        EnableBackgroundColor="true">
                        <Items>
                            <x:Form ID="pnlBase" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="5px"
                                EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtRegisterNO" runat="server" Label="户&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号"
                                                Width="200px" Required="true" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtName" runat="server" Label="姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名"
                                                Width="200px" Required="true" />
                                            <x:DropDownList ID="ddlRelation" Label="户主关系" runat="server" Width="200px" Required="true" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtOtherName" runat="server" Label="曾&nbsp;&nbsp;用&nbsp;名" Width="200px"
                                                Required="true" />
                                            <x:DropDownList ID="ddlSex" Label="性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别" runat="server"
                                                Width="200px">
                                                <x:ListItem Text="男" Value="1" Selected="true" />
                                                <x:ListItem Text="女" Value="0" />
                                            </x:DropDownList>
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtPlaceOfBirth" runat="server" Label="出&nbsp;&nbsp;生&nbsp;地" Width="200px" />
                                            <x:TextBox ID="txtNationalilty" runat="server" Label="民&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;族"
                                                Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtPlaceOfAncestral" runat="server" Label="籍&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;贯"
                                                Width="200px" />
                                            <x:DatePicker ID="dtpBrithday" runat="server" Label="出生日期" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtAddress" Label="其他地址" runat="server" Width="200px" />
                                            <x:TextBox ID="txtReligion" Label="宗教信养" runat="server" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtIDCard" Label="身份证号" runat="server" Width="200px" />
                                            <x:TextBox ID="txtHeight" Label="身&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;高" runat="server"
                                                Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtTypeOfBlood" Label="血&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;型" runat="server"
                                                Width="200px" />
                                            <x:DropDownList ID="ddlEducation" Label="文化程度" runat="server" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtMarriage" Label="婚姻状况" runat="server" Width="200px" />
                                            <x:TextBox ID="txtMilitaryService" Label="兵役状况" runat="server" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtCompany" Label="服务处所" runat="server" Width="200px" />
                                            <x:TextBox ID="txtOccupation" Label="职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业" runat="server"
                                                Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:DropDownList ID="ddlPolitical" Label="政治面目" runat="server" Width="200px" />
                                            <x:TextBox ID="txtTel" Label="电话号码" runat="server" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                        </Items>
                    </x:GroupPanel>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="迁徙信息" ID="ExGroup" EnableCollapse="True"
                        EnableBackgroundColor="true">
                        <Items>
                            <x:Form ID="pnlMove" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="5px"
                                EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:DatePicker ID="dtpIngoingDate" Label="迁入日期" runat="server" Width="200px" />
                                            <x:TextBox ID="txtPreviousAddress" runat="server" Label="原&nbsp;&nbsp;住&nbsp;地" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtIngoingReason" runat="server" Label="迁入原因" Width="535px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:DatePicker ID="dtpMoveOutDate" Label="迁出日期" runat="server" Width="200px" />
                                            <x:TextBox ID="txtMoveToAddress" Label="迁&nbsp;&nbsp;出&nbsp;到" runat="server" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:CheckBox ID="chkIsCanceled" runat="server" Label="是否注销" />
                                            <x:DatePicker ID="dtpCancelDate" Label="注销日期" runat="server" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtCancelReason" runat="server" Label="注销原因" Width="535px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                        </Items>
                    </x:GroupPanel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
     <x:HiddenField ID="hiddenID" runat="server" /> 
    </form>
</body>
</html>
