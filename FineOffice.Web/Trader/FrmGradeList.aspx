<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmGradeList.aspx.cs" Inherits="Trader_FrmGradeList" %>

<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmGradeList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Form ID="frmFind" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <x:FormRow runat="server">
                        <Items>
                            <x:TwinTriggerBox runat="server" ShowLabel="false" ID="ttbSearch" Width="200" ShowTrigger1="false"
                                OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                                Trigger1Icon="Clear" Trigger2Icon="Search">
                            </x:TwinTriggerBox>
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
            <x:Panel ID="pnlGradeList" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="tsbMain" runat="server">
                        <Items>
                            <x:Button ID="btnNew" Icon="Add" Text="新增" runat="server" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnModify" Icon="ApplicationEdit" Text="编辑" runat="server" OnClick="btnModify_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnSelectAll" Icon="ArrowIn" Text="全选" runat="server" OnClick="btnSelectAll_Click" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnDelete" Icon="Delete" Text="删除" runat="server" OnClick="btnDelete_Click" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="gradeGrid" Title="等级信息" ShowBorder="false" ShowHeader="False" runat="server"
                        EnableCheckBoxSelect="True" DataKeyNames="ID,Grade" EnableRowNumber="True" OnRowCommand="gradeGrid_RowCommand">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="Grade" SortField="Grade" DataField="Grade"
                                HeaderText="企业等级" />
                            <x:BoundField Width="100px" ColumnID="Ordering" SortField="Ordering" DataField="Ordering"
                                HeaderText="排序" />
                            <x:BoundField Width="200px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                HeaderText="备注" />
                            <x:WindowField TextAlign="Center" Width="60px" WindowID="modifyGradeWin" Icon="Pencil"
                                ToolTip="编辑" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmModifyGrade.aspx?ID={0}"
                                Hideable="false" DataWindowTitleFormatString="编辑-{0}" DataWindowTitleField="Grade" />
                            <x:LinkButtonField TextAlign="Center" Width="60px" Icon="Delete" ToolTip="删除" ConfirmText="确认删除吗？"
                                Hideable="false" CommandName="delete" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="newGradeWin" Title="新增" Popup="false" EnableMaximize="false" IsModal="true"
        Target="Parent" EnableResize="false" runat="server" Icon="Add" Width="500px"
        Height="300px" EnableConfirmOnClose="true" EnableIFrame="true" IFrameUrl="FrmNewGrade.aspx">
    </x:Window>
    <x:Window ID="modifyGradeWin" Title="编辑" Popup="false" EnableMaximize="false" IsModal="true"
        Target="Parent" EnableResize="false" runat="server" Icon="ApplicationEdit" Width="500px"
        Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]'
        runat="server" />
    </form>
</body>
</html>
