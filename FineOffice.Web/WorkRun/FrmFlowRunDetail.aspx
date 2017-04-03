<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmFlowRunDetail.aspx.cs"
    Inherits="WorkRun_FrmFlowRunDetail" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE html>
<html>
<head  runat="server">
    <title></title>
    <script src="../js/common.js" type="text/javascript"></script>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .highlight
        {
            background-color: #DDD;
        }
        .highlight .x-grid3-col
        {
            background-image: none;
        }
        .x-grid3-row-selected .highlight
        {
            background-color: #DDD;
        }
        .x-grid3-row-selected .highlight .x-grid3-col
        {
            background-image: none;
        }
    </style>
</head>
<body>
    <form id="_FrmFlowRunDetail" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:Panel ID="pnlMain" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Items>
            <x:Grid ID="transmitGrid" ShowHeader="False" ShowBorder="true" runat="server" DataKeyNames="ID"
                EnableMultiSelect="false" EnableRowNumber="false" AllowSorting="False" SortColumn="acceptTime">
                <Columns>
                    <x:TemplateField RenderAsRowExpander="true">
                        <ItemTemplate>
                            <div class="expander_no">
                                <p>
                                    <strong>办理意见：</strong><%# Eval("TransmitAdvice")%>
                                </p>
                            </div>
                        </ItemTemplate>
                    </x:TemplateField>
                    <x:BoundField Width="100px"   HeaderText="工作步聚" ColumnID="processName"
                        DataField="ProcessName" SortField="ProcessName" />
                    <x:BoundField Width="100px"   HeaderText="处理方式" ColumnID="handleEvent"
                        DataField="HandleEvent" SortField="HandleEvent" />
                    <x:BoundField Width="150px" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="接收时间"
                        ColumnID="acceptTime" DataField="AcceptTime" SortField="AcceptTime" />
                    <x:BoundField Width="150px" DataFormatString="{0:yyyy-MM-dd HH:mm}" HeaderText="处理时间"
                        ColumnID="handleTime" DataField="HandleTime" SortField="HandleTime" />
                    <x:BoundField Width="100px"   HeaderText="经办人员" ColumnID="acceptName"
                        SortField="AcceptName" DataField="AcceptName" />
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    <x:HiddenField ID="highlightRows" runat="server" />
    </form>
    <script type="text/javascript">
        var highlightRowsClientID = '<%= highlightRows.ClientID %>';
        var gridClientID = '<%= transmitGrid.ClientID %>';

        function highlightRows() {
            var highlightRows = X(highlightRowsClientID);
            var grid = X(gridClientID);

            grid.el.select('.x-grid3-row table.highlight').removeClass('highlight');

            Ext.each(highlightRows.getValue().split(','), function (item, index) {
                if (item !== '') {
                    var row = grid.getView().getRow(parseInt(item, 10));
                    Ext.get(row).first().addClass('highlight');
                }
            });
        }

        // 页面第一个加载完毕后执行的函数
        function onReady() {
            var grid = X(gridClientID);
            grid.addListener('viewready', function () {
                highlightRows();
            });
        }

        // 页面AJAX回发后执行的函数
        function onAjaxReady() {
            highlightRows();
        }
    </script>
</body>
</html>
