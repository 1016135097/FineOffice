<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmPolitical.aspx.cs" Inherits="Census_FrmPolitical" %>

<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmPolitical" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        Title="Panel" ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Form ID="searchForm" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server">
                <Rows>
                    <x:FormRow runat="server">
                        <Items>
                            <x:TwinTriggerBox runat="server"  ShowLabel="false" ID="ttbSearch"
                                Width="200" ShowTrigger1="false" OnTrigger1Click="ttbSearch_Trigger1Click" OnTrigger2Click="ttbSearch_Trigger2Click"
                                Trigger1Icon="Clear" Trigger2Icon="Search">
                            </x:TwinTriggerBox>
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
            <x:Panel ID="pnlPolitical" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
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
                    <x:Grid ID="politicalGrid" Title="政治面目" ShowBorder="false" ShowHeader="False" runat="server"
                        EnableCheckBoxSelect="True" DataKeyNames="ID,Political" EnableRowNumber="True"
                        OnRowCommand="politicalGrid_RowCommand">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="political" SortField="Political" DataField="Political"
                                HeaderText="政治面目" />
                            <x:WindowField TextAlign="Center" Width="60px" WindowID="frmModifyCensusType" Icon="Pencil"
                                ColumnID="btnModify" ToolTip="编辑" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmModifyPolitical.aspx?ID={0}"
                                Hideable="false" DataWindowTitleFormatString="编辑-{0}" DataWindowTitleField="CensusTypeName" />
                            <x:LinkButtonField TextAlign="Center" Width="60px" Icon="Delete" ColumnID="btnDelete"
                                ConfirmText="确认删除吗？" Hideable="false" CommandName="delete" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="frmNewPolitical" Title="新增" Popup="false" EnableMaximize="false" IsModal="true"
        Target="Parent" EnableResize="false" runat="server" Icon="Add" Width="420px"
        Height="120px" EnableConfirmOnClose="true" EnableIFrame="true" IFrameUrl="FrmNewPolitical.aspx">
    </x:Window>
    <x:Window ID="frmModifyCensusType" Title="编辑" Popup="false" EnableMaximize="false"
        IsModal="true" Target="Parent" EnableResize="false" runat="server" Icon="ApplicationEdit"
        Width="420px" Height="120px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]'
        runat="server" />
    </form>
</body>
</html>
