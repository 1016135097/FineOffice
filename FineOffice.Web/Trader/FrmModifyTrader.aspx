<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmModifyTrader.aspx.cs"
    Inherits="Trader_FrmModifyTrader" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmModifyTrader" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <x:Button ID="btnSave" Text="保存" runat="server" Icon="SystemSaveNew" OnClick="btnSave_Click"
                        ValidateForms="frmBase,frmEx" ValidateMessageBox="false" />
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlTrader" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true">
                <Items>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="基本信息" ID="grpBase" EnableCollapse="True"
                        EnableBackgroundColor="true">
                        <Items>
                            <x:Form ID="frmBase" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="5px"
                                EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtTraderNO" runat="server" Label="企业编码" Width="200px" Required="true" />
                                            <x:TextBox ID="txtTraderName" Label="企业名称" runat="server" Width="200px" Required="true" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtShortName" Label="简&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;称" runat="server"
                                                Width="200px" Required="true" AutoPostBack="true" OnTextChanged="Pinyin_TextChanged" />
                                            <x:TextBox ID="txtPinyinCode" Label="拼&nbsp;&nbsp;音&nbsp;码" runat="server" Width="200px"
                                                Required="true" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtIncorporator" Label="法人代表" runat="server" Width="200px" />
                                            <x:TextBox ID="txtNumberOfPeople" Label="企业人数" RegexPattern="NUMBER" runat="server"
                                                Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtTel" runat="server" Label="联系电话" Width="200px" />
                                            <x:TextBox ID="txtFax" runat="server" Label="传真号码" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtWebSite" runat="server" Label="网&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址"
                                                Width="200px" />
                                            <x:TextBox ID="txtEmail" runat="server" Label="电子邮箱" RegexPattern="EMAIL" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtPost" runat="server" Label="邮政编码" Width="200px" />
                                            <x:TextBox ID="txtAddress" runat="server" Label="联系地址" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtRemark" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" Width="200px"
                                                runat="server" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                        </Items>
                    </x:GroupPanel>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="扩展信息" ID="grpEx" EnableCollapse="True"
                        EnableBackgroundColor="true">
                        <Items>
                            <x:Form ID="frmEx" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="5px"
                                EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TriggerBox ID="txtArea" EnableEdit="false" Label="所在地区" EnablePostBack="false"
                                                TriggerIcon="Search" runat="server" Width="200px" Required="true" />
                                            <x:DropDownList runat="server" ID="ddlIndustry" Width="200px" Label="行业分类" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:DropDownList runat="server" ID="ddlTraderType" Width="200px" Label="企业性质" />
                                            <x:DropDownList runat="server" ID="ddlSource" Width="200px" Label="来源渠道" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:DropDownList runat="server" ID="ddlGrade" Width="200px" Label="企业等级" />
                                            <x:DatePicker ID="dtpCreateTime" Label="创建日期" Required="true" runat="server" Width="200px" />
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TriggerBox ID="txtHandler" Label="跟&nbsp;&nbsp;进&nbsp;人" EnableEdit="false" EnablePostBack="false"
                                                TriggerIcon="Search" runat="server" Width="200px" />
                                            <x:CheckBoxList ID="chkRule" runat="server">
                                                <x:CheckItem Value="Client" Text="客户" />
                                                <x:CheckItem Value="Supplier" Text="供应商" />
                                            </x:CheckBoxList>
                                        </Items>
                                    </x:FormRow>
                                </Rows>
                            </x:Form>
                        </Items>
                    </x:GroupPanel>
                    <x:GroupPanel runat="server" AutoHeight="true" Title="联系人" ID="grpLinkman" EnableCollapse="True"
                        EnableBackgroundColor="true">
                        <Items>
                            <x:Form ID="frmLinkman" ShowBorder="false" ShowHeader="false" AutoScroll="true" BodyPadding="5px"
                                EnableBackgroundColor="true" runat="server" EnableCollapse="True">
                                <Rows>
                                    <x:FormRow runat="server">
                                        <Items>
                                            <x:TextBox ID="txtLinkman" runat="server" Label="联&nbsp;&nbsp;系&nbsp;人" Width="200px" />
                                            <x:TextBox ID="txtMobile" runat="server" Label="移动电话" Width="200px" />
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
    <x:HiddenField ID="hiddenAreaID" runat="server" />
    <x:HiddenField ID="hiddenHandler" runat="server" />
    <x:HiddenField ID="hiddenID" runat="server" />
    <x:Window ID="wndSelectArea" Title="选择地区" Popup="false" EnableMaximize="true" IsModal="true"
        Target="Parent" EnableResize="true" runat="server" Icon="Find" Width="310px"
        Height="435px" EnableIFrame="true">
    </x:Window>
    <x:Window ID="wndHandler" Title="跟进人" Popup="false" EnableMaximize="true" Target="Parent"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    </form>
</body>
</html>
