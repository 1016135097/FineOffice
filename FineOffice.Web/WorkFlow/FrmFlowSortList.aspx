<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmFlowSortList.aspx.cs"
    Inherits="WorkFlow_FrmFlowSortList" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmFlowSortList" runat="server">
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
            <x:Panel ID="pnlFlowSort" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
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
                    <x:Grid ID="flowSortGrid" Title="流程分类" PageSize="20" ShowBorder="false" AllowPaging="true"
                        AllowSorting="true" OnPageIndexChange="flowSortGrid_PageIndexChange" ShowHeader="False"
                        IsDatabasePaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,SortNO"
                        SortColumn="SortNO" SortDirection="ASC" OnSort="flowSortGrid_Sort" EnableRowNumber="True"
                        OnRowCommand="flowSortGrid_RowCommand">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="SortNO" SortField="SortNO" DataField="SortNO"
                                HeaderText="分类编码" />
                            <x:BoundField Width="100px" ColumnID="FlowSortName" SortField="FlowSortName" DataField="FlowSortName"
                                HeaderText="分类名称" />
                            <x:BoundField Width="100px" ColumnID="PinyinCode" SortField="PinyinCode" DataField="PinyinCode"
                                HeaderText="拼音码" />
                            <x:BoundField Width="100px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                HeaderText="备注" />
                            <x:CheckBoxField Width="60px" ColumnID="Stop" SortField="Stop" TextAlign="Center"
                                RenderAsStaticField="true" DataField="Stop" HeaderText="是否可用" />
                            <x:WindowField ColumnID="btnModify" TextAlign="Center" Width="60px" WindowID="modifyFlowSortWin"
                                Icon="Pencil" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmModifyFlowSort.aspx?id={0}"
                                Title="编辑类别" Hideable="false" />
                            <x:LinkButtonField ColumnID="btnDelete" TextAlign="Center" Width="60px" Icon="Delete"
                                ConfirmText="确认删除吗？" CommandName="delete" Hideable="false" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="newFlowSortWin" Title="新增" Popup="false" IFrameUrl="FrmNewFlowSort.aspx"
        EnableMaximize="true" IsModal="true" Target="Parent" EnableResize="true" runat="server"
        Icon="Add" Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyFlowSortWin" Title="编辑类别" Popup="false" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Pencil"
        Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]'
        runat="server" />
    </form>
</body>
</html>
