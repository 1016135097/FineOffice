<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmWriteLetter.aspx.cs" Inherits="Letter_FrmWriteLetter" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <script src="../js/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="_FrmWriteLetter" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" ShowBorder="False" ShowHeader="false" EnableBackgroundColor="true"
        AutoScroll="true" BodyPadding="5px">
        <Items>
            <x:Panel runat="server" ID="pnlContract" ShowHeader="true" EnableCollapse="true"
                EnableBackgroundColor="true" Height="135px" BodyPadding="1px" CssClass="rowpanel"
                Icon="User" Title="信访人信息">
                <Items>
                    <x:Form ID="frmVisitor" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="5px"
                        EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                        <Rows>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:TextBox ID="txtVisitor" runat="server" Label="姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名"
                                        Required="true" />
                                    <x:DropDownList ID="ddlSex" Label="性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别" runat="server">
                                        <x:ListItem Text="男" Value="1" Selected="true" />
                                        <x:ListItem Text="女" Value="0" />
                                    </x:DropDownList>
                                    <x:TextBox ID="txtAge" runat="server" Label="年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;龄"
                                        RegexPattern="NUMBER" />
                                </Items>
                            </x:FormRow>
                        </Rows>
                        <Rows>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:TextBox ID="txtMobile" runat="server" Label="移动电话" />
                                    <x:TextBox ID="txtEmail" runat="server" Label="电子邮箱" RegexPattern="EMAIL" />
                                    <x:TextBox ID="txtOccupation" Label="职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业" runat="server" />
                                </Items>
                            </x:FormRow>
                        </Rows>
                        <Rows>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:TextBox ID="txtTel" Label="固定电话" runat="server" />
                                    <x:TextBox ID="txtIDCard" RegexPattern="IDENTITY_CARD" Label="身份证号" runat="server" />
                                    <x:TextBox ID="txtAddress" Label="联系地址" runat="server" />
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
            <x:TabStrip ID="tsbMatter" Height="165px" TabPosition="Top" EnableTabCloseMenu="false"
                EnableTitleBackgroundColor="true" ActiveTabIndex="0" runat="server" ShowBorder="true">
                <Tabs>
                    <x:Tab ID="tabMatter" AutoHeight="true" Icon="BookAdd" Title="信访内容" EnableBackgroundColor="true"
                        BodyPadding="5px" Layout="Fit" runat="server">
                        <Items>
                            <x:Form ID="frmMatter" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="5px"
                                EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtLetterNO" Required="true" runat="server" Label="信访编号" />
                                            <x:TextBox ID="txtTitle" Required="true" runat="server" Label="标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题" />
                                            <x:TextBox ID="txtNumberOfpeople" Label="信访人数" runat="server" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtArea" Label="发生地点" runat="server" />
                                            <x:DropDownList ID="ddlReceiveDepartment" Label="部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门"
                                                runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlReceiveDepartment_SelectedIndexChanged" />
                                            <x:DropDownList ID="ddlReceiver" Label="信访对象" runat="server" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:DropDownList ID="ddlChannel" Label="信访渠道" runat="server" />
                                            <x:DropDownList ID="ddlType" Label="事件分类" runat="server" />
                                            <x:HiddenField ID="hiddenOccupy1" runat="server" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server" ColumnWidths="310 100">
                                        <Items>
                                            <x:DatePicker runat="server" Required="true" Label="信访时间" ID="dtpDate" Width="195px" />
                                            <x:TimePicker ID="dtpTime" Increment="5" ShowLabel="false" Required="true" runat="server"
                                                Width="80px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                        </Items>
                    </x:Tab>
                </Tabs>
            </x:TabStrip>
            <x:TabStrip ID="tsbTransmitAdvice" Height="160px" TabPosition="Top" EnableTabCloseMenu="false"
                EnableTitleBackgroundColor="true" ActiveTabIndex="0" runat="server" ShowBorder="false">
                <Tabs>
                    <x:Tab ID="tabTransmitAdvice" AutoHeight="true" Icon="BookAdd" Title="信访内容" EnableBackgroundColor="true"
                        BodyPadding="5px" Layout="Fit" runat="server">
                        <Items>
                            <x:TextArea ID="txtTransmitAdvice" Required="true" ShowLabel="false" runat="server"
                                Width="650" Height="60">
                            </x:TextArea>
                        </Items>
                    </x:Tab>
                </Tabs>
            </x:TabStrip>
            <x:TabStrip ID="tbsHandler" Height="100px" TabPosition="Top" EnableTabCloseMenu="false"
                EnableTitleBackgroundColor="true" ActiveTabIndex="0" runat="server" ShowBorder="false">
                <Tabs>
                    <x:Tab ID="tabHandler" AutoHeight="true" Icon="BookAdd" Title="信访处理" EnableBackgroundColor="true"
                        BodyPadding="5px" Layout="Fit" runat="server">
                        <Items>
                            <x:Form ID="frmHandle" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="5px"
                                EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:DropDownList ID="ddlHandleDepartment" Label="部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门"
                                                runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHandleDepartment_SelectedIndexChanged" />
                                            <x:DropDownList ID="ddlHandler" Label="处&nbsp;&nbsp;理&nbsp;人" runat="server" />
                                            <x:TextBox ID="txtRemark" runat="server" Readonly="true" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtRecorder" runat="server" Readonly="true" Label="登&nbsp;&nbsp;记&nbsp;人" />
                                            <x:TextBox ID="txtRecordTime" runat="server" Readonly="true" Label="时&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;间" />
                                            <x:HiddenField ID="hiddenOccupy" runat="server" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                        </Items>
                    </x:Tab>
                </Tabs>
            </x:TabStrip>
        </Items>
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server" Position="Top">
                <Items>
                    <x:Button ID="btnSave" Text="保存" runat="server" ValidateForms="frmVisitor,frmMatter"
                        Icon="SystemSaveNew" OnClick="btnSave_Click" ValidateMessageBox="false" />
                    <x:Button ID="btnReset" Text="重置" runat="server" Icon="ArrowUndo" OnClick="btnReset_Click" />
                    <x:ToolbarSeparator runat="server" />
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                </Items>
            </x:Toolbar>
        </Toolbars>
    </x:Panel>
    <x:HiddenField ID="hiddenID" runat="server" />
    <x:HiddenField ID="hiddenWrite" runat="server" />
    <x:HiddenField ID="hiddenTabID" runat="server" Text="_FrmWriteLetter" />
    </form>
</body>
</html>
