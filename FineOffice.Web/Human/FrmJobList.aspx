<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmJobList.aspx.cs" Inherits="Human_FrmJobList" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<%@ Register Src="../Common/WebPageAuthority.ascx" TagName="WebPageAuthority" TagPrefix="uc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="_FrmJobList" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        ShowBorder="false" ShowHeader="false" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Form ID="pnlFind" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
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
            <x:Panel ID="pnlGrid" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
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
                    <x:Grid ID="jobGrid" Title="职位信息" PageSize="20" ShowBorder="false" AllowPaging="true"
                        AllowSorting="true" OnPageIndexChange="jobGrid_PageIndexChange" ShowHeader="False"
                        IsDatabasePaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,JobNO"
                        SortColumn="JobNO" SortDirection="ASC" OnSort="jobGrid_Sort" EnableRowNumber="True"
                        OnRowCommand="jobGrid_RowCommand">
                        <Columns>
                            <x:BoundField Width="100px" ColumnID="JobNO" SortField="JobNO" DataField="JobNO"
                                HeaderText="职位编码" />
                            <x:BoundField Width="100px" ColumnID="Job" SortField="Job" DataField="Job" HeaderText="职位信息" />
                            <x:BoundField Width="100px" ColumnID="PinyinCode" SortField="PinyinCode" DataField="PinyinCode"
                                HeaderText="拼音码" />
                            <x:BoundField Width="100px" ColumnID="Remark" SortField="Remark" DataField="Remark"
                                HeaderText="备注" />
                            <x:CheckBoxField Width="60px" ColumnID="stop" SortField="Stop" TextAlign="Center"
                                RenderAsStaticField="true" DataField="Stop" HeaderText="是否可用" />
                            <x:WindowField ColumnID="btnModify" TextAlign="Center" Width="60px" WindowID="modifyJobWin"
                                Icon="Pencil" DataIFrameUrlFields="ID" DataIFrameUrlFormatString="FrmModifyJob.aspx?id={0}"
                                Hideable="false" DataWindowTitleField="Job" DataWindowTitleFormatString="编辑-{0}" />
                            <x:LinkButtonField ColumnID="btnDelete" TextAlign="Center" Width="60px" Icon="Delete"
                                ConfirmText="确认删除吗？" Hideable="false" CommandName="delete" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="newJobWin" Title="新增" Popup="false" IFrameUrl="FrmNewJob.aspx" EnableMaximize="true"
        IsModal="true" Target="Parent" EnableResize="true" runat="server" Icon="Add"
        Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <x:Window ID="modifyJobWin" Title="编辑" Popup="false" IFrameUrl="FrmModifyJob.aspx"
        EnableMaximize="true" IsModal="true" Target="Parent" EnableResize="true" runat="server"
        Icon="Pencil" Width="500px" Height="300px" EnableConfirmOnClose="true" EnableIFrame="true">
    </x:Window>
    <uc1:WebPageAuthority ID="pageAuthority" PageAuthority='["btnNew","btnModify","btnDelete"]'
        runat="server" />
    </form>
</body>
</html>
