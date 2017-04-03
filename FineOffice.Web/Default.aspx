<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>村委办公系统-支点软件</title>
    <link href="themes/index.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
</head>
<body id="login">
    <div id="page">
        <h1>
            FineOffice 简单、易用，让您更专注于您的工作</h1>
        <div id="login_form">
            <form id="frmLogin" runat="server">
            <x:PageManager ID="pageManager" runat="server" />
            <x:Window ID="window" runat="server" Title="Sign in" IsModal="false" EnableClose="false"
                IconUrl="images/16/8.png" Width="410px">
                <Items>
                    <x:SimpleForm ID="loginForm" runat="server" ShowBorder="false" BodyPadding="10px"
                        LabelWidth="50px" EnableBackgroundColor="true" ShowHeader="false">
                        <Items>
                            <x:TextBox ID="txtUserName" Label="用户名" Required="true" runat="server" />
                            <x:TextBox ID="txtPassword" Label="密&nbsp;&nbsp;&nbsp;码" TextMode="Password" Required="true"
                                runat="server" />
                            <x:TextBox ID="txtCaptcha" Label="验证码" Required="true" runat="server" />
                            <x:Panel CssStyle="padding-left:65px;" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                runat="server">
                                <Items>
                                    <x:Image ID="imgCaptcha" CssStyle="float:left;width:70px;" runat="server" ShowEmptyLabel="true">
                                    </x:Image>
                                    <x:LinkButton CssStyle="float:left;padding-top:8px;margin-left:5px;" ID="btnRefresh"
                                        Text="看不清？" runat="server" OnClick="btnRefresh_Click">
                                    </x:LinkButton>
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:SimpleForm>
                </Items>
                <Toolbars>
                    <x:Toolbar ID="toolbar" runat="server" Position="Footer">
                        <Items>
                            <x:Button ID="btnLogin" Text="登录" Type="Submit" ValidateForms="loginForm" ValidateTarget="Top"
                                ValidateMessageBox="false" OnClick="btnLogin_Click" runat="server">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
            </x:Window>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="zu-index-link-apply-x2 r5px">
                <a href="javascript:void(0)" class="zu-index-link-apply r5px"><span class="r5px zu-index-link-apply-x1">
                    <x:Label ID="lblValrUser" EncodeText="false" CssStyle="color:red;font-weight:bold;"
                        Text="" runat="server">
                    </x:Label>
                </span></a>
            </div>
            </form>
        </div>
        <div id="footer">
            <p>
                &copy; 2010-2013 版权 &middot; <a href="http://www.boolxun.com/" target="_blank">支点软件-FineOffice1.0</a>
                <br />
            </p>
        </div>
    </div>
</body>
</html>
