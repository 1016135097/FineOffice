using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FineUI;
using System.Xml;
using Newtonsoft.Json.Linq;
using FineOffice.Web;
using System.Xml.Linq;

public partial class Main : PageBase
{
    /// <summary>
    /// 内存中的权限
    /// </summary>
    List<FineOffice.Modules.SYS_MenuList> authorityList = new List<FineOffice.Modules.SYS_MenuList>();

    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Init(object sender, EventArgs e)
    {
        authorityList = this.SessionMenuList.OrderBy(a => a.Ordering).ToList();

        JObject ids = GetClientIDS(btnExpandAll, btnCollapseAll, tbsRight, btnRefreshTab); // 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
        Accordion accordion = InitAccordionMenu();
        ids.Add("accMenu", accordion.ClientID);

        if (!Page.IsPostBack)
        {
            btnUser.Text = this.CookieUser.UserName;
            string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
            PageContext.RegisterStartupScript(idsScriptStr);
        }
    }

    /// <summary>
    /// 创建树的XML
    /// </summary>
    private XDocument CreateMenuXml()
    {
        List<FineOffice.Modules.SYS_MenuList> tempList = authorityList.Where(d => d.ParentID == 0).OrderBy(s => s.Ordering).ToList();
        XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));
        foreach (FineOffice.Modules.SYS_MenuList temp in tempList)
        {
            XElement sub = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.Text), 
                new XAttribute("SingleClickExpand", temp.SingleClickExpand),
                new XAttribute("IconUrl",temp.Icon==null?"":string.Format("~/icon/{0}.png",temp.Icon)),
                new XAttribute("NodeID",temp.ID),                
            });
            xdoc.Root.Add(sub);
            CreateXElement(sub, temp);
        }
        return xdoc;
    }

    private void CreateXElement(XElement root, FineOffice.Modules.SYS_MenuList model)
    {
        List<FineOffice.Modules.SYS_MenuList> tempList = authorityList.Where(d => d.ParentID == model.ID).ToList();
        foreach (FineOffice.Modules.SYS_MenuList temp in tempList)
        {
            XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.Text), 
                new XAttribute("SingleClickExpand", temp.SingleClickExpand),
                new XAttribute("IconUrl",temp.Icon==null?"":string.Format("~/icon/{0}.png",temp.Icon)),
                new XAttribute("NodeID",temp.TabID==null?"":temp.TabID),                
            });
            root.Add(xe);
            if (temp.NavigateUrl != null)
            {
                object[] xas = new object[] 
                { 
                    new XAttribute("NavigateUrl", temp.NavigateUrl), 
                };
                xe.Add(xas);
            }
            CreateXElement(xe, temp);
        }
    }

    /// <summary>
    /// 手风琴
    /// </summary>
    private Accordion InitAccordionMenu()
    {
        Accordion acc = new Accordion();
        acc.ID = "accMenu";
        acc.EnableFill = true;
        acc.ShowBorder = false;
        acc.ShowHeader = false;
        pnlMenu.Items.Add(acc);

        XmlDocument xmlDoc = new XmlDocument();
        CreateMenuXml();
        XDocument xml = this.CreateMenuXml();
        xmlDoc.LoadXml(xml.ToString());
        XmlNodeList xmlNodes = xmlDoc.SelectNodes("/Tree/TreeNode");
        foreach (XmlNode xmlNode in xmlNodes)
        {
            if (xmlNode.HasChildNodes)
            {
                AccordionPane accordionPane = new AccordionPane();
                accordionPane.Title = xmlNode.Attributes["Text"].Value;
                accordionPane.IconUrl = xmlNode.Attributes["IconUrl"].Value;
                accordionPane.Layout = Layout.Fit;
                accordionPane.BodyPadding = "2px 0 0 0";
                acc.Items.Add(accordionPane);

                Tree innerTree = new Tree();
                innerTree.ShowBorder = false;
                innerTree.ShowHeader = false;
                innerTree.AutoScroll = true;
                accordionPane.Items.Add(innerTree);

                XmlDocument innerXmlDoc = new XmlDocument();
                string temp = String.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><Tree>{0}</Tree>", xmlNode.InnerXml);
                innerXmlDoc.LoadXml(temp);
                innerTree.DataSource = innerXmlDoc;
                innerTree.DataBind();
                innerTree.ExpandAllNodes();
            }
        }
        return acc;
    }
}