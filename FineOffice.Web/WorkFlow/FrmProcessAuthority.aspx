<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmProcessAuthority.aspx.cs"
    Inherits="WorkFlow_FrmProcessAuthority" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmProcessAuthority" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="tsMain" runat="server">
                <Items>
                    <x:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                    </x:Button>
                    <x:Button ID="btnSave" Text="保存" runat="server" ValidateForms="frmAuthority" ValidateMessageBox="false"
                        Icon="SystemSaveNew" OnClick="btnSave_Click">
                    </x:Button>
                    <x:ToolbarFill runat="server" />
                </Items>
            </x:Toolbar>
        </Toolbars>
        <Items>
            <x:Panel ID="pnlAuthority" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false"
                EnableBackgroundColor="true">
                <Items>
                    <x:Form ID="frmAuthority" ShowBorder="False" BodyPadding="5px" AnchorValue="100%" EnableBackgroundColor="true"
                        ShowHeader="False" runat="server">
                        <Rows>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:HiddenField ID="txtID" runat="server" />
                                </Items>
                            </x:FormRow>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:TextBox ID="txtProcessName" runat="server" Readonly="true" Label="当前步骤" Width="240" />
                                </Items>
                            </x:FormRow>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:CheckBoxList ID="chkOprate" Label="允许操作" runat="server" Width="240">
                                        <x:CheckItem Text="拒绝" Value="AllowRefuse" />
                                        <x:CheckItem Text="退回" Value="AllowGoBack" />
                                        <x:CheckItem Text="会签" Value="Feedback" />
                                    </x:CheckBoxList>
                                </Items>
                            </x:FormRow>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:NumberBox ID="txtTimeLimit" runat="server" EmptyText="小时(为0表示不限时)" Required="true"
                                        Width="240" Label="办理时限" />
                                </Items>
                            </x:FormRow>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:Label Text="小时(为0表示不限时)" ID="lblTimeLimit" runat="server" />
                                </Items>
                            </x:FormRow>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:NumberBox ID="txtRemind" runat="server" Required="true" Label="催办提前" Width="240" />
                                </Items>
                            </x:FormRow>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:Label Text="分钟(为0表示不催办)" ID="lblRemind" runat="server" />
                                </Items>
                            </x:FormRow>
                            <x:FormRow runat="server" ColumnWidths="83% 17%">
                                <Items>
                                    <x:TextArea ID="txtPersonnel" runat="server" Readonly="true" Height="65" Label="职员权限" />
                                    <x:Button ID="btnPersonnel" IconAlign="Left" Icon="Find" Text="选择" runat="server" />
                                </Items>
                            </x:FormRow>
                            <x:FormRow runat="server">
                                <Items>
                                    <x:HiddenField ID="hiddenDepartment" runat="server" />
                                    <x:HiddenField ID="hiddenPersonnel" runat="server" />
                                </Items>
                            </x:FormRow>
                            <x:FormRow runat="server" ColumnWidths="83% 17%">
                                <Items>
                                    <x:TextArea ID="txtDepartment" runat="server" Readonly="true" Height="65" Label="部门权限" />
                                    <x:Button ID="btnDepartment" Icon="Find" IconAlign="Left" Text="选择" runat="server" />
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="departmentWin" Title="部门信息-选择" Popup="false" EnableMaximize="true"
        Target="Top" IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px"
        Height="420px" EnableIFrame="true">
    </x:Window>
    <x:Window ID="personnelWin" Title="职员信息-选择" Popup="false" EnableMaximize="true" Target="Top"
        IsModal="true" EnableResize="true" runat="server" Icon="Find" Width="710px" Height="420px"
        EnableIFrame="true">
    </x:Window>
    </form>
</body>
</html>
