<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmFlowView.aspx.cs" Inherits="WorkFlow_FrmFlowView"
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
    <form id="frmFlowDesigner" runat="server">
    <x:PageManager ID="pageManager" AutoSizePanelID="pnlMain" runat="server" />
    <x:RegionPanel ID="pnlMain" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="regionDesinger" ShowHeader="false" Layout="Fit" Margins="0 0 0 0" Position="Center"
                runat="server">
                <Toolbars>
                    <x:Toolbar ID="toolbar" Position="Top" runat="server">
                        <Items>
                            <x:Button ID="btnGrid" IconUrl="FlowDesigner/images/icon/grid.gif" Text="栅格" runat="server"
                                OnClientClick="setGrid();" EnablePostBack="false" />
                            <x:Button ID="btnRefreshFlow" Icon="ArrowRefresh" Text="刷新" OnClientClick="resetProcess();"
                                EnablePostBack="false" runat="server" />
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
                            <x:TextBox ID="txtGUID" Label="节&nbsp;点&nbsp;&nbsp;ID" runat="server" Readonly="true" />
                            <x:TextBox ID="txtProcessName" Label="节点名称" runat="server" Readonly="true" />
                            <x:TextArea ID="txtRemark" Label="备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注" runat="server"
                                Readonly="true" />
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
            dragable = true;
            eventsrc = null; //eventsrc是当前触发事件的节点对象
            presrc = null; //前一个选中的对象
            xmlNode = null; //当前选中的XML节点          

            //连线的源和目标
            srcRect = null;
            desRect = null;

            x0 = 0, x1 = 0, y0 = 0, y1 = 0;   //连线的头尾坐标

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
            //            dashLine = null;
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

    //左键释放时方法
    function upAction() {
        if (!Ext.get(eventsrc).findParent("div[id=center]", Ext.getBody()))
            return false;
        switch (currentBtn) {
            case "select":
                dragable = false;
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
            default:
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
                    font.style.pixelLeft = fontX;
                    font.style.pixelTop = fontY;
                }
            }
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

    //初始设置流程定义
    function initProcess() {
        presrc = null;
        //        createDashLine();
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

    function noContextMenu() {
        event.cancelBubble = true
        event.returnValue = false;
        return false;
    }

    Ext.onReady(function () {
        DesignConfig.init();       
        flag = setTimeout("loadProcess()", 500);
    });

    var flag;
    function loadProcess() {
        XmlToProcess(Ext.getCmp('<%=this.txtXML.ClientID %>').getValue());
        initGrid();
        clearTimeout(flag);
    }

    function resetProcess() {
        XmlToProcess(Ext.getCmp('<%=this.txtXML.ClientID %>').getValue());
    }
</script>
