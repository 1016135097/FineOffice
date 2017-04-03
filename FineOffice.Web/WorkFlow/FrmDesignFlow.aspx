<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmDesignFlow.aspx.cs" Inherits="WorkFlow_FrmDesignFlow"
    ValidateRequest="false" %>

<%@ Register Assembly="FineUI" Namespace="FineUI" TagPrefix="x" %>
<!DOCTYPE HTML system "about:legacy-compat">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title></title>
    <style type="text/css">
        v\:*
        {
            behavior: url(#default#VML);
            display: inline-block;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="FlowDesigner/design.css" />
</head>
<body oncontextmenu="return noContextMenu();">
    <form id="_FrmDesignFlow" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:RegionPanel ID="pnlMain" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="regionTool" Split="true" EnableSplitTip="true" CollapseMode="Default"
                Width="180" MaxSize="180" MinSize="180" Margins="0 0 0 0" ShowHeader="true" Title="工具栏"
                EnableLargeHeader="false" Icon="Outline" EnableCollapse="true" Layout="Fit" Position="Left"
                runat="server">
                <Items>
                    <x:ContentPanel ID="pnlTool" Title="" ShowBorder="false" EnableBackgroundColor="true"
                        EnableCollapse="false" ShowHeader="false" runat="server">
                        <div id="tool">
                            <div mark="select" class="btn btn_down">
                                <span class="icon_select">选择</span></div>
                            <div class="btn_split">
                            </div>
                            <div mark="start" class="btn btn_up">
                                <span class="icon_start">开始</span></div>
                            <div mark="end" class="btn btn_up">
                                <span class="icon_stop">结束</span></div>
                            <div mark="transition" class="btn btn_up">
                                <span class="icon_transtion">流转</span></div>
                            <div class="btn_split">
                            </div>
                            <div mark="task" class="btn btn_up">
                                <span class="icon_task">任务</span></div>
                        </div>
                    </x:ContentPanel>
                </Items>
            </x:Region>
            <x:Region ID="regionDesinger" ShowHeader="false" Layout="Fit" Margins="0 0 0 0" Position="Center"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="toolbar" Position="Top" runat="server">
                        <Items>
                            <x:Button ID="btnGrid" IconUrl="FlowDesigner/images/icon/grid.gif" Text="栅格" runat="server"
                                OnClientClick="setGrid();" EnablePostBack="false" />
                            <x:ToolbarSeparator runat="server" />
                            <x:Button ID="btnSave" Icon="SystemSave" Text="保存" runat="server" OnClientClick="showXml();"
                                OnClick="btnSave_Click" />
                        </Items>
                    </x:Toolbar>
                </Toolbars>
            </x:Region>
            <x:Region ID="regionAttribute" Split="true" EnableSplitTip="true" CollapseMode="Default"
                EnableBackgroundColor="true" Width="325" Margins="0 0 0 0" ShowHeader="true"
                EnableLargeHeader="false" Icon="Table" EnableCollapse="true" Position="Right"
                Layout="Fit" runat="server">
                <Items>
                    <x:SimpleForm ID="baseForm" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                        LabelWidth="75" AutoScroll="true" runat="server" EnableCollapse="True" BodyPadding="5">
                        <Items>
                            <x:HiddenField ID="txtID" runat="server" />
                            <x:HiddenField ID="txtXML" runat="server" />
                            <x:TextBox ID="txtGUID" Label="步&nbsp;聚&nbsp;&nbsp;ID" runat="server" Readonly="true" />
                            <x:TextBox ID="txtProcessName" Label="步聚名称" runat="server" />
                            <x:TextArea ID="txtRemark" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" runat="server" />
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Region>
        </Regions>
    </x:RegionPanel>
    <div id="center">
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    Ext.namespace("DesignConfig");
    var DesignConfig = {
        init: function () {
            currentBtn = "select";
            currentParam = "base";

            lineFlag = false;
            dragable = true;
            eventsrc = null; //eventsrc是当前触发事件的节点对象
            presrc = null; //前一个选中的对象
            xmlNode = null; //当前选中的XML节点
            x = 0, y = 0;
            temp1 = 0;
            temp2 = 0;

            //连线的源和目标
            srcRect = null;
            desRect = null;

            x0 = 0, x1 = 0, y0 = 0, y1 = 0;   //连线的头尾坐标
            fontX = 0, fontY = 0;    //文字的坐标

            xml = null; //xml对象
            //各个节点所拥有的属性
            nodeParams = {
                base: ["base"], //文本节点
                mail: ["base", "mailto"], //mail节点
                process: ["base", "swimlane", "sql", "notice", "mailto"], //流程定义
                main: ["base", "sql", "notice", "mailto"], //start、end节点
                task: ["base", "sql", "notice", "mailto", "change", "delegate", "form", "method"], //任务节点
                transition: ["base", "sql", "notice", "mailto", "autoDelegate", "case"]//transition
            }

            //虚线
            dashLine = null;
            var keyPanel = new Ext.Panel({
                id: 'pnlCenter',
                border: false,
                header: false,
                layout: 'fit',
                autoScroll: true,
                contentEl: 'center'
            });

            Ext.getCmp('<%=this.regionDesinger.ClientID %>').add(keyPanel).doLayout();

            //初始流程属性
            initProcess();
            //为工具栏按钮注册事件
            Ext.get(Ext.DomQuery.select(".btn")).on("click", function () {
                if (!Ext.fly(this).hasClass("btn_down")) {
                    currentBtn = this.mark;
                    Ext.get(Ext.DomQuery.select(".btn_down")).removeClass("btn_down");
                    Ext.fly(this).addClass("btn_down");
                    setParams();
                }
            });

            //为流程区添加右键菜单
            var target = null;
            var contextmenu = new Ext.menu.Menu({
                items: [{
                    text: '删除',
                    iconCls: 'delete',
                    handler: function () {
                        if (presrc == target)
                            initProcess();
                        //删除与之相关的连线
                        if (target.tagName.toLowerCase() == "roundrect") {
                            var sources = Ext.DomQuery.select("line[source=" + target.id + "]");
                            var projects = Ext.DomQuery.select("line[project=" + target.id + "]");
                            //删除与之对应的文本节点
                            var lines = sources.concat(projects);
                            for (var i = 0; i < lines.length; i++) {
                                deleteXmlNode(lines[i]);
                                Ext.get(Ext.DomQuery.select("span[target=" + lines[i].id + "]")).remove();
                            }
                            Ext.get(lines).remove();
                        }
                        //删除与之相关的文本节点
                        var lineText;
                        if (target.tagName.toLowerCase() == "line") {
                            lineText = Ext.get(Ext.DomQuery.select("span[target=" + target.id + "]"))
                        }
                        if (target.tagName.toLowerCase() == "span") {
                            var lineObject = Ext.getDom(target.target)
                            deleteXmlNode(lineObject);
                            Ext.fly(lineObject).remove();
                            if (lineText != null) lineText.remove();

                        } else {
                            deleteXmlNode(target);
                            Ext.fly(target).remove();
                            if (lineText != null) lineText.remove();
                        }
                    }
                }]
            });

            Ext.getBody().on('mousedown', function (e) {
                //判断是否是右键
                if (e.button != "2")
                    return false;
                target = e.target;
                if (!Ext.get(target).findParent("div[id=center]", Ext.getBody()))
                    return false;
                if (e.target.tagName.toLowerCase() == 'textbox')
                    target = event.srcElement.parentElement;
                if (e.target.tagName.toLowerCase() == 'b')
                    target = event.srcElement.parentElement.parentElement;
                var tagName = target.tagName.toLowerCase();
                if (tagName != "line" && tagName != "roundrect" && tagName != "span")
                    return false;
                contextmenu.showAt(e.getXY());
            })
            document.onmousedown = downAction;  //开始移动               
            document.onmouseup = upAction;  //结束移动                
        }
    };

    function setGrid() {
        if (Ext.fly(Ext.getDom("center").parentNode).hasClass("designer"))
            Ext.fly(Ext.getDom("center").parentNode).removeClass("designer");
        else
            Ext.fly(Ext.getDom("center").parentNode).addClass("designer");
    }

    function initGrid() {
        if (!Ext.fly(Ext.getDom("center").parentNode).hasClass("designer"))
            Ext.fly(Ext.getDom("center").parentNode).addClass("designer");
    }

    //查看xml
    function showXml() {
        var str = xml.xml.replace(/></g, '>\n\r<');
        str = str.replace(/xmlns=\"\"/g, '');
        Ext.getCmp('<%=this.txtXML.ClientID %>').setValue(str);
    }

    //根据点击的按钮设置参数
    function setParams() {
        switch (currentBtn) {
            case "select":
                dragable = true;
                break
            case "grid":
                break
            case "transition":
                lineFlag = true;
                break
            default:
        }
    }

    //左键释放时方法
    function upAction() {
        if (!Ext.get(eventsrc).findParent("div[id=center]", Ext.getBody()))
            return false;
        switch (currentBtn) {
            case "select":
                dragable = false;
                break
            case "transition":
                drawLine();
                break
            default:
        }
    }

    //左键按下时方法
    function downAction() {
        //判断是否是左键被按下
        if (event.button != 1)
            return;
        switch (currentBtn) {
            case "select":
                drags(); //拖动                    
                showParams(); //显示属性
                break
            case "transition":
                createLine();
                break
            default:
                createNode();
        }
    }

    //查看选择节点的属性
    function showParams() {
        if (presrc == null && eventsrc.tagName.toLowerCase() == "div"
         && eventsrc.firstChild.id == "center" || eventsrc.id == "center") {
            initProcess(); //如果前次选中为null的话，显示流程定义属性
            return false;
        }
        if (!Ext.get(eventsrc).findParent("div[id=center]", Ext.getBody()))
            return false;
        switch (eventsrc.flowtype) {
            case "start":
                showNodeParams(nodeParams.base, "开始节点", "task");
                break
            case "end":
                showNodeParams(nodeParams.base, "结束节点", "task");
                break
            case "transition":
                showNodeParams(nodeParams.base, "流转节点", "transition");
                break
            case "task":
                showNodeParams(nodeParams.base, "任务节点", "task");
                break
            default:
                eventsrc = Ext.getDom(eventsrc.target); //文本节点转换成对应的连线
                showNodeParams(nodeParams.base, "流转节点", "transition");
                break
        }
        XmlSetParams(eventsrc); //设置显示属性
    }

    //根据节点获取对应的XML节点，并对相应的属性页面赋值
    function XmlSetParams(node) {
        xmlNode = findXmlNode(node);
        if (xmlNode == null)
            return false;
        if (xmlNode.tagName == "process") {
            Ext.getCmp('<%=this.txtGUID.ClientID%>').setValue("");
            Ext.getCmp('<%=this.txtProcessName.ClientID%>').setValue("");
            Ext.getCmp('<%=this.txtRemark.ClientID%>').setValue("");
            Ext.getCmp('<%=this.regionAttribute.ClientID %>').setTitle("");
            Ext.getCmp('<%=this.regionAttribute.ClientID %>').setIconClass("");
            return;
        }
        switch (currentParam) {
            case "base":
                if (node != null) {
                    Ext.getCmp('<%=this.txtGUID.ClientID%>').setValue(xmlNode.getAttribute("id"));
                    Ext.getCmp('<%=this.txtProcessName.ClientID%>').setValue(xmlNode.getAttribute("name"));
                    Ext.getCmp('<%=this.txtRemark.ClientID%>').setValue(xmlNode.getAttribute("Remark"));
                }
                break
        }
    }

    //显示各节点对应的属性
    function showNodeParams(params, title, icon) {
        Ext.getCmp('<%=this.regionAttribute.ClientID %>').setTitle(title);
        Ext.getCmp('<%=this.regionAttribute.ClientID %>').setIconClass(icon);
    }

    function drags() {
        if (event.button != 1)
            return;
        selectNode();
        if (eventsrc.tagName.toLowerCase() == 'roundrect') {
            dragable = true;
            temp1 = eventsrc.style.pixelLeft;
            temp2 = eventsrc.style.pixelTop;
            x = event.x;
            y = event.y;
            document.onmousemove = move;
        }
    }

    function move() {
        if (event.button == 1 && dragable) {
            var newleft = temp1 + event.x - x;
            var newtop = temp2 + event.y - y;
            //重新设置节点的坐标
            modifyXmlNodeAttr(eventsrc, "g", newleft + "," + newtop + "," + eventsrc.style.pixelWidth + "," + eventsrc.style.pixelHeight);
            eventsrc.style.pixelLeft = newleft;
            eventsrc.style.pixelTop = newtop;
            //重画与节点相关的线和文字节点
            reDrawLine();
            return false;
        }
    }

    function reDrawLine() {
        var lines = Ext.DomQuery.select("line[project=" + eventsrc.id + "]").concat(Ext.DomQuery.select("line[source=" + eventsrc.id + "]"));
        for (var i = 0; i < lines.length; i++) {
            if (eventsrc.id == lines[i].source) {
                //将源与目的赋值为线的源与目的
                srcRect = document.getElementById(lines[i].source);
                desRect = document.getElementById(lines[i].project);
                direction();
                lines[i].to = x1 + "," + y1;
                lines[i].from = x0 + "," + y0;
                //重新设置文本位置
                fontLocation();
                var font = Ext.DomQuery.select("span[target=" + lines[i].id + "]")[0];
                if (font != null) {
                    modifyXmlNodeAttr(lines[i], "g", fontX + "," + fontY);
                    font.style.pixelLeft = fontX;
                    font.style.pixelTop = fontY;
                }
            }
            if (eventsrc.id == lines[i].project) {
                //将源与目的赋值为线的源与目的
                srcRect = document.getElementById(lines[i].source);
                desRect = document.getElementById(lines[i].project);
                var locations = direction();
                lines[i].to = x1 + "," + y1;
                lines[i].from = x0 + "," + y0;
                //重新设置文本位置
                fontLocation();
                var font = Ext.DomQuery.select("span[target=" + lines[i].id + "]")[0];
                if (font != null) {
                    //在编辑坐标前先编辑XML中的坐标，否则改完后找不到相应的节点
                    modifyXmlNodeAttr(lines[i], "g", fontX + "," + fontY);
                    font.style.pixelLeft = fontX;
                    font.style.pixelTop = fontY;
                }
            }
        }
    }

    //判断是否创建节点
    function nodeOrNot() {
        //点击事件事是否发生在工作区
        //防止右键菜单弹出时点击阴影出错
        if (event.srcElement == null || event.srcElement.firstChild == null) return false;
        if (event.srcElement.firstChild.id != "center" && event.srcElement.id != "center")
            return false;
        //如果是start节点判断是否已经存在
        var nodes = findXmlNodesByName("start");
        if (currentBtn == "start" && nodes.length > 0) {
            return false;
        }
        return true;
    }

    function createLine() {
        selectNode();
        if (eventsrc.tagName == 'roundrect' && eventsrc.flowtype != "end") {
            srcRect = eventsrc;
            //将虚线显示，并将虚线的起点和终点设为点击事件对象的中心
            var dx = srcRect.style.pixelLeft + srcRect.style.pixelWidth / 2;
            var dy = srcRect.style.pixelTop + srcRect.style.pixelHeight / 2;
            dashLine.from = dx + "," + dy;
            dashLine.to = dx + "," + dy;
            dashLine.style.pixelLeft = dx + 'px';
            dashLine.style.pixelTop = dy + 'px';
            dashLine.style.display = "block";
            document.onmousemove = lineMove;
        } else {
            srcRect = null;
        }
    }

    function lineMove() {
        //移动时的虚线随鼠标移动

        if (lineFlag) {
            //判断是否有滚动条，有的话加上滚动条的滚动长度
            dashLine.to = (event.x + Ext.getDom("center").parentNode.scrollLeft) + "," + (event.y + Ext.getDom("center").parentNode.scrollTop);
            return false;
        }
    }

    //选择节点
    function selectNode() {
        eventsrc = event.srcElement;
        if (event.srcElement.tagName.toLowerCase() == 'textbox')//如果事件对象是textbox，将事件对象变为它的父对象
            eventsrc = event.srcElement.parentElement;

        if (event.srcElement.tagName.toLowerCase() == 'b') //如果事件对象是b，将事件对象变为它的父对象的父对象
            eventsrc = event.srcElement.parentElement.parentElement;

        if (currentBtn == "select" && !!Ext.get(eventsrc).findParent("div[id=center]", Ext.getBody())) //如果是选择并且在center区域，执行下面的选中
        {
            //如果前次选择与当前选中一致，不执行以下语句
            if (presrc == eventsrc)
                return false;
            if (presrc != null) {
                if (presrc.tagName.toLowerCase() == "span") {
                    presrc.style.border = "0";
                } else {
                    presrc.strokeColor = "#27548d";
                    presrc.strokeWeight = "1pt";
                    presrc.style.zIndex = 1;
                }
            }
            switch (eventsrc.tagName.toLowerCase()) {
                case "roundrect":
                    eventsrc.strokeColor = "#ff0000";
                    eventsrc.strokeWeight = "2pt";
                    eventsrc.style.zIndex = 2;
                    break
                case "line":
                    eventsrc.strokeColor = "#ff0000";
                    eventsrc.strokeWeight = "2pt";
                    break
                case "span":
                    eventsrc.style.border = "2px solid #ff0000";
                    break
            }
            //将当前节点赋值给presrc
            presrc = eventsrc;
        } else if (currentBtn == "select") {
            if (presrc != null && eventsrc.tagName.toLowerCase() == "div" &&
            eventsrc.firstChild.id == "center" || eventsrc.id == "center") {

                if (presrc.tagName.toLowerCase() == "span") {
                    presrc.style.border = "0";
                } else {
                    presrc.strokeColor = "#27548d";
                    presrc.strokeWeight = "1pt";
                    presrc.style.zIndex = 1;
                }
                presrc = null;
            }
        }
    }

    function drawLine() {
        if (srcRect == null)
            return;
        selectNode();
        if (eventsrc.tagName == 'roundrect' && srcRect != eventsrc) {
            desRect = eventsrc;
            //创建线
            //判断是否画线
            if (drawOrNot()) {
                var line = document.createElement("v:line");
                direction();
                line.from = x0 + "," + y0;
                line.to = x1 + "," + y1;
                line.style.pixelLeft = x0 + 'px';
                line.style.pixelTop = y0 + 'px';
                line.style.position = "absolute";
                line.style.display = "block";
                line.id = newGuid();
                line.flowtype = "transition";
                line.strokeWeight = "1pt";
                line.style.cursor = "pointer";
                line.strokeColor = "#27548d";
                line.source = srcRect.id;
                line.project = desRect.id;
                //创建箭头
                line.innerHTML = "<v:stroke endarrow='Classic' />";
                document.getElementById("center").appendChild(line);
                //在连线上生成文字
                var font = createFont(line);
                line.title = font.innerHTML;
                line.TextNode = font.id;
                addXmlNode(line, srcRect);
            }
        }
        document.onmousemove = null;
        dashLine.style.display = "none";
    }

    //在横线上生成文字
    function createFont(line) {
        var textNode = document.createElement("span");
        fontLocation();
        textNode.style.pixelLeft = fontX;
        textNode.style.pixelTop = fontY;
        textNode.innerHTML = "to " + desRect.title;
        Ext.fly(textNode).addClass("font_node");
        textNode.target = line.id;
        textNode.id = newGuid();
        document.getElementById("center").appendChild(textNode);
        return textNode;
    }

    //判断文字的位置
    function fontLocation() {
        fontX = Math.round(x0 + (x1 - x0) / 2 - 30);
        fontY = Math.round(y0 + (y1 - y0) / 2 - 25);
    }

    //箭头方向
    function direction() {
        if (srcRect.style.pixelLeft > desRect.style.pixelLeft) {
            if ((srcRect.style.pixelLeft - desRect.style.pixelLeft) <= desRect.style.pixelWidth) {
                x0 = srcRect.style.pixelLeft + srcRect.style.pixelWidth / 2;
                x1 = desRect.style.pixelLeft + desRect.style.pixelWidth / 2;
                if (srcRect.style.pixelTop > desRect.style.pixelTop) {
                    y0 = srcRect.style.pixelTop;
                    y1 = desRect.style.pixelTop + desRect.style.pixelHeight;
                } else {
                    y0 = srcRect.style.pixelTop + srcRect.style.pixelHeight;
                    y1 = desRect.style.pixelTop;
                }
            } else {
                x0 = srcRect.style.pixelLeft;
                x1 = desRect.style.pixelLeft + desRect.style.pixelWidth;
                y0 = srcRect.style.pixelTop + srcRect.style.pixelHeight / 2;
                y1 = desRect.style.pixelTop + desRect.style.pixelHeight / 2;
            }
        } else {
            if ((desRect.style.pixelLeft - srcRect.style.pixelLeft) <= desRect.style.pixelWidth) {
                x0 = srcRect.style.pixelLeft + srcRect.style.pixelWidth / 2;
                x1 = desRect.style.pixelLeft + desRect.style.pixelWidth / 2;
                if (srcRect.style.pixelTop > desRect.style.pixelTop) {
                    y0 = srcRect.style.pixelTop;
                    y1 = desRect.style.pixelTop + desRect.style.pixelHeight;
                } else {
                    y0 = srcRect.style.pixelTop + srcRect.style.pixelHeight;
                    y1 = desRect.style.pixelTop;
                }
            } else {
                x0 = srcRect.style.pixelLeft + srcRect.style.pixelWidth;
                x1 = desRect.style.pixelLeft;
                y0 = srcRect.style.pixelTop + srcRect.style.pixelHeight / 2;
                y1 = desRect.style.pixelTop + desRect.style.pixelHeight / 2;
            }
        }
    }

    //判断是否画线
    function drawOrNot() {
        //目的地址不能是start
        if (desRect.flowtype == "start")
            return false;
        //是否已存在
        var lines = document.getElementsByTagName('line');
        for (var i = 0; i < lines.length; i++) {
            //if (srcRect.id == "start" && lines[i].source == "start")
            //    return false;
            if (srcRect.id == lines[i].source && desRect.id == lines[i].project)
                return false;
        }
        return true;
    }

    //创建节点
    function createNode() {
        if (!nodeOrNot())
            return false;
        var node = document.createElement("v:roundrect");
        node.inset = '2pt,2pt,2pt,2pt';
        node.style.pixelLeft = event.x + Ext.getDom("center").parentNode.scrollLeft;
        node.style.pixelTop = event.y + Ext.getDom("center").parentNode.scrollTop;
        node.style.zIndex = 1;
        node.style.pixelWidth = 110;
        node.style.pixelHeight = 50;
        node.strokeColor = "#27548d";
        node.fillcolor = '#EEEEEE';
        Ext.fly(node).addClass("node");
        switch (currentBtn) {
            case "start":
                node.id = newGuid();
                node.title = "流程开始";
                node.flowtype = "start";
                node.innerHTML = "<v:shadow on='T' type='single' color='#b3b3b3' offset='2px,2px' />"
			+ "<v:textbox class='node_start' inset='1pt,2pt,1pt,1pt'><b>Start</b><br />流程开始</v:textbox>";
                break
            case "task":
                node.id = newGuid();
                node.title = "任务节点";
                node.flowtype = "task";
                node.innerHTML = "<v:shadow on='T' type='single' color='#b3b3b3' offset='2px,2px' />"
			+ "<v:textbox class='node_task' inset='1pt,2pt,1pt,1pt'><b>TaskNode</b><br />任务节点</v:textbox>";
                break
            case "end":
                node.id = newGuid();
                node.title = "流程结束";
                node.flowtype = "end";
                node.innerHTML = "<v:shadow on='T' type='single' color='#b3b3b3' offset='2px,2px' />"
			+ "<v:textbox class='node_end' inset='1pt,2pt,1pt,1pt'><b>End</b><br />流程结束</v:textbox>";
                break;
            default:
        }
        document.getElementById("center").appendChild(node);
        addXmlNode(node);
    }

    //初始设置流程定义
    function initProcess() {
        presrc = null;
        createDashLine();
        //创建xml对象
        createXml();
        //设置显示属性
        XmlSetParams("process");
    }

    //XML的逆向转换，将XML转换成为流程图
    function XmlToProcess(loadXml) {
        //清空已有的流程图
        Ext.getDom("center").innerHTML = "";
        initProcess();
        if (loadXml.length > 0) {
            xml.loadXML(loadXml);
        }
        var root = findXmlNode("process");
        var rootChilds = root.childNodes;
        for (var i = 0; i < rootChilds.length; i++)
            XmltoNode(rootChilds[i]);

        var lines = xml.getElementsByTagName("transition");
        for (i = 0; i < lines.length; i++)
            XmltoLine(lines[i]);
    }


    //创建虚线
    function createDashLine() {
        if (document.getElementById("dashLine") == null) {
            dashLine = document.createElement("v:line");
            dashLine.style.display = "none";
            dashLine.style.position = "absolute";
            dashLine.id = "dashLine";
            dashLine.strokeWeight = "2pt";
            dashLine.fillcolor = "#f441ff";
            dashLine.strokeColor = "#f441ff";
            dashLine.innerHTML = "<v:stroke dashstyle='longDash'/><v:shadow on='t' type='single' color='#cccccc' offset='1px,1px'/>";
            document.getElementById("center").appendChild(dashLine);
        }
    }

    function createXml() {
        if (xml == null) {
            xml = new ActiveXObject("Microsoft.XMLDOM");
            var p = xml.createProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
            xml.appendChild(p);
            var root = xml.createElement("process");
            root.setAttribute("name", '<%=model.FlowName %>');
            root.setAttribute("ID", '<%=model.ID %>');
            xml.appendChild(root);
        }
    }

    //编辑节点对应的属性
    function modifyXmlNodeAttr(node, param, value) {
        node = findXmlNode(node);
        if (node != null)
            node.setAttribute(param, value);
    }

    //删除节点
    function deleteXmlNode(node) {
        //如果是文本节点，获取对应的transition节点，清空name属性
        if (node.tagName.toLowerCase() == "span") {
            node = findXmlNode(Ext.getDom(node.title));
            node.setAttribute("name", "");
            return false;
        }
        //如果不是文本节点，获取父节点，通过父节点删除自己
        node = findXmlNode(node);
        if (node != null)
            node.parentNode.removeChild(node);
    }

    //通过流程图节点查找XML节点
    function findXmlNode(node) {
        if (node == "process")
            return xml.documentElement; //返回根节点

        if (node == null || node.flowtype == null)
            return null;
        var nodes = xml.getElementsByTagName(node.flowtype);
        for (var i = 0; i < nodes.length; i++) {
            if (nodes[i].getAttribute("id") == node.id) {
                return nodes[i];
            }
        }
        return null;
    }

    function newGuid() {
        var guid = "";
        for (var i = 1; i <= 32; i++) {
            var n = Math.floor(Math.random() * 16.0).toString(16);
            guid += n;
            if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                guid += "-";
        }
        return guid;
    }

    //添加xml节点
    function addXmlNode(node, parentNode) {
        var newNode = null; //新节点
        var attr = null; //属性
        var parent = findXmlNode(parentNode);
        if (parent == null)
            parent = xml.documentElement; //指向根节点
        switch (node.flowtype) {
            case "transition":
                newNode = xml.createElement("transition");
                addXmlAttribute(newNode, "TextNode", node.TextNode);
                addXmlAttribute(newNode, "name", "to " + desRect.title);
                addXmlAttribute(newNode, "Remark", "to " + desRect.title);
                addXmlAttribute(newNode, "id", node.id);
                addXmlAttribute(newNode, "to", desRect.id);
                var font = Ext.DomQuery.select("span[target=" + node.id + "]")[0];
                addXmlAttribute(newNode, "g", font.style.pixelLeft + "," + font.style.pixelTop);
                parent.appendChild(newNode);
                break
            case "start":
                newNode = xml.createElement("start");
                break
            case "end":
                newNode = xml.createElement("end");
                break
            case "task":
                newNode = xml.createElement("task");
                break
        }
        if (node.flowtype != "transition") {
            addXmlAttribute(newNode, "id", node.id);
            addXmlAttribute(newNode, "name", node.title);
            addXmlAttribute(newNode, "Remark", node.Remark);
            addXmlAttribute(newNode, "g", node.style.pixelLeft + "," + node.style.pixelTop + "," + node.style.pixelWidth + "," + node.style.pixelHeight);
            parent.appendChild(newNode);
        }
    }

    //编辑节点对应的属性
    function modifyXmlNodeAttr(node, param, value) {
        node = findXmlNode(node);
        if (node != null)
            node.setAttribute(param, value);
    }

    //根据节点名字和类型查找XML节点
    function findXmlNodeByName(nodeType, nodeName) {
        var nodes = xml.getElementsByTagName(nodeType);
        for (var i = 0; i < nodes.length; i++)
            if (nodes[i].getAttribute("id") == nodeName)
                return nodes[i];
    }

    //根据节点名字和类型查找XML节点
    function findXmlNodesByName(nodeType) {
        var nodes = xml.getElementsByTagName(nodeType);
        return nodes;
    }

    //XML的逆向转换，生成节点
    function XmltoNode(child) {
        var showNode = true; //是否创建节点      
        var locations = child.getAttribute("g") != null ? child.getAttribute("g").split(",") : [0, 0, 110, 50];
        var node = document.createElement("v:roundrect");
        node.inset = '2pt,2pt,2pt,2pt';
        node.style.pixelLeft = locations[0];
        node.style.pixelTop = locations[1];
        node.style.pixelWidth = locations[2];
        node.style.pixelHeight = locations[3];
        node.strokeColor = "#27548d";
        node.fillcolor = '#EEEEEE';
        Ext.fly(node).addClass("node");
        node.id = child.getAttribute("id");
        node.title = child.getAttribute("name");
        switch (child.tagName) {
            case "start":
                node.flowtype = "start";
                node.innerHTML = "<v:shadow on='T' type='single' color='#b3b3b3' offset='2px,2px' />"
			+ "<v:textbox class='node_start' inset='1pt,2pt,1pt,1pt'><b>Start</b><br />" + child.getAttribute("name") + "</v:textbox>";
                break
            case "task":
                node.flowtype = "task";
                node.innerHTML = "<v:shadow on='T' type='single' color='#b3b3b3' offset='2px,2px' />"
			+ "<v:textbox class='node_task' inset='1pt,2pt,1pt,1pt'><b>TaskNode</b><br />" + child.getAttribute("name") + "</v:textbox>";
                break
            case "end":
                node.flowtype = "end";
                node.innerHTML = "<v:shadow on='T' type='single' color='#b3b3b3' offset='2px,2px' />"
			+ "<v:textbox class='node_end' inset='1pt,2pt,1pt,1pt'><b>End</b><br />" + child.getAttribute("name") + "</v:textbox>";
                break;
            default:
                showNode = false;
        }
        if (showNode)
            document.getElementById("center").appendChild(node);
    }

    //XML的逆向转换，生成连线及文本节点
    function XmltoLine(child) {
        srcRect = findNodeXml(child.parentNode);
        desRect = findNodeXml(child.getAttribute("to"));

        var locations = child.getAttribute("g") != null ? child.getAttribute("g").split(",") : [0, 0];
        var line = document.createElement("v:line");
        direction();
        line.from = x0 + "," + y0;
        line.to = x1 + "," + y1;
        line.style.pixelLeft = x0 + 'px';
        line.style.pixelTop = y0 + 'px';
        line.style.position = "absolute";
        line.style.display = "block";

        line.flowtype = "transition";
        line.strokeWeight = "1pt";
        line.style.cursor = "pointer";
        line.strokeColor = "#27548d";
        line.source = srcRect.id;
        line.project = desRect.id;
        //创建箭头
        line.innerHTML = "<v:stroke endarrow='Classic' />";
        document.getElementById("center").appendChild(line);
        line.title = child.getAttribute("name");
        line.id = child.getAttribute("id");

        //生成文本节点
        var textNode = document.createElement("span");
        textNode.style.pixelLeft = locations[0];
        textNode.style.pixelTop = locations[1];
        textNode.innerHTML = child.getAttribute("name");
        Ext.fly(textNode).addClass("font_node");
        textNode.target = child.getAttribute("id");
        textNode.title = child.getAttribute("name");
        textNode.id = child.getAttribute("TextNode");
        document.getElementById("center").appendChild(textNode);
    }

    //通过XML节点查找流程图节点
    function findNodeXml(xmlNode) {
        if (typeof xmlNode == "object") {
            return document.getElementById(xmlNode.getAttribute("id"));
        } else {
            return document.getElementById(xmlNode);
        }
    }

    //添加xml属性
    function addXmlAttribute(node, attr, value) {
        var attribute = xml.createAttribute(attr);
        attribute.value = value;
        node.setAttributeNode(attribute);
    }

    function noContextMenu() {
        event.cancelBubble = true
        event.returnValue = false;
        return false;
    }

    Ext.onReady(function () {
        DesignConfig.init();
        Ext.EventManager.addListener('<%=this.txtProcessName.ClientID %>', "keyup", function () {
            if (presrc != null) {
                var newValue = Ext.getCmp('<%=this.txtProcessName.ClientID%>').getValue();
                if (presrc.tagName.toLowerCase() == "roundrect") {
                    presrc.lastChild.lastChild.data = newValue;
                    modifyXmlNodeAttr(presrc, "name", newValue);
                } else if (presrc.tagName.toLowerCase() == "line") {
                    Ext.DomQuery.select("span[target=" + presrc.id + "]")[0].innerHTML = newValue;
                    modifyXmlNodeAttr(presrc, "name", newValue);
                } else {
                    presrc.innerHTML = newValue;
                    modifyXmlNodeAttr(Ext.getDom(presrc.target), "name", newValue);
                    Ext.getDom(presrc.target).title = newValue;
                }
                if (presrc.tagName.toLowerCase() != "span")
                    presrc.title = newValue;
            }
        });

        Ext.EventManager.addListener('<%=this.txtRemark.ClientID %>', "keyup", function () {
            if (presrc != null) {
                var newValue = Ext.getCmp('<%=this.txtRemark.ClientID%>').getValue();
                if (presrc.tagName.toLowerCase() == "roundrect") {
                    modifyXmlNodeAttr(presrc, "Remark", newValue);

                } else if (presrc.tagName.toLowerCase() == "line") {
                    modifyXmlNodeAttr(presrc, "Remark", newValue);
                } else {
                    modifyXmlNodeAttr(Ext.getDom(presrc.target), "Remark", newValue);
                }
            }
        });
        flag = setTimeout("loadProcess()", 500);
    });

    var flag;
    function loadProcess() {
        XmlToProcess(Ext.getCmp('<%=this.txtXML.ClientID %>').getValue());
        initGrid();
        clearTimeout(flag);
    }
</script>
