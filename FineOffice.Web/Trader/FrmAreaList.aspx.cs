using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineOffice.Web;
using FineUI;
using FineOffice.Modules.Helper;
using FineOffice.Common.ListHelper;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using FineOffice.Common.SerializeHelper;

public partial class Trader_FrmAreaList : PageBase
{
    FineOffice.BLL.CRM_Area areaBll = new FineOffice.BLL.CRM_Area();
    FineOffice.BLL.CRM_Trader traderBll = new FineOffice.BLL.CRM_Trader();

    List<FineOffice.Modules.CRM_Area> areaList = new List<FineOffice.Modules.CRM_Area>();
    string[] expandeds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnNew.OnClientClick = newAreaWin.GetShowReference();
            tvwArea_Bind();
            GeneralSituation();
            btnModify.OnClientClick = tvwArea.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", tvwArea.Title));
            btnDelete.OnClientClick = tvwArea.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", tvwArea.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中的{0}吗？", tvwArea.Title);
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            tvwArea_Bind();
            GeneralSituation();
        }
    }

    protected void tvwArea_NodeCommand(object sender, TreeCommandEventArgs e)
    {
        GeneralSituation();
    }

    /// <summary>
    /// 详细信息
    /// </summary>
    protected void GeneralSituation()
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        if (tvwArea.SelectedNodeID.Length == 0)
        {
            lblArea.Text = "全部";
            lblAreaNumber.Text = areaList.Count.ToString();
            lblTraderNumber.Text = traderBll.GetCount(changeTrackingList).ToString();
        }
        else
        {
            EntitySearcher search = new EntitySearcher();
            int id = int.Parse(tvwArea.SelectedNodeID);
            FineOffice.Modules.CRM_Area model = areaBll.GetModel(a => a.ID == id);
            List<FineOffice.Modules.CRM_Area> tempList = areaBll.GetSubList(model);
            StringBuilder area = new StringBuilder();
            foreach (FineOffice.Modules.CRM_Area a in tempList)
            {
                area.Append(a.ID);
                area.Append(",");
            }
            string strArea = area.ToString();
            search = new EntitySearcher();
            search.Field = "AreaID";
            search.Relation = "AND";
            search.Operator = "in";
            search.Content = "(" + strArea.Substring(0, strArea.Length - 1) + ")";
            changeTrackingList.Add(search);
            lblAreaNumber.Text = tempList.Count.ToString();
            lblTraderNumber.Text = traderBll.GetCount(changeTrackingList).ToString();
            lblArea.Text = model.Area;
            lblOrdering.Text = model.Ordering.ToString();
            lblRemark.Text = model.Remark;
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        ViewState["Expanded"] = tvwArea.GetExpandedNodeIDs();
        modifyAreaWin.IFrameUrl = string.Format("FrmModifyArea.aspx?ID={0}", tvwArea.SelectedNode.NodeID);
        modifyAreaWin.Hidden = false;
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    protected void btnDelelte_Click(object sender, EventArgs e)
    {
        ViewState["Expanded"] = tvwArea.GetExpandedNodeIDs();
        FineUI.TreeNode node = tvwArea.SelectedNode;
        int id = int.Parse(node.NodeID);
        try
        {
            areaBll.Delete(new FineOffice.Modules.CRM_Area { ID = id });
            tvwArea_Bind();
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 收起全部
    /// </summary>
    protected void btnCollapseAll_Click(object sender, EventArgs e)
    {
        tvwArea.CollapseAllNodes();
    }

    /// <summary>
    /// 展开全部
    /// </summary>
    protected void btnExpandAll_Click(object sender, EventArgs e)
    {
        tvwArea.ExpandAllNodes();
    }

    /// <summary>
    /// 刷新地区
    /// </summary>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        tvwArea_Bind();
        tvwArea.ExpandAllNodes();
    }

    /// <summary>
    /// 绑定地区树控件
    /// </summary>
    private void tvwArea_Bind()
    {
        areaList = areaBll.GetListAll();
        List<FineOffice.Modules.CRM_Area> tempList = areaList.Where(a => a.ParentID == 0).OrderBy(t => t.Ordering).ToList();
        XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));

        foreach (FineOffice.Modules.CRM_Area model in tempList)
        {
            XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", model.Area),  
                new XAttribute("EnablePostBack",true),
                new XAttribute("SingleClickExpand", false),
                new XAttribute("NodeID",model.ID)
            });
            xdoc.Root.Add(xe);
            CreateXElement(xe, model);
        }        
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xdoc.Document.ToString());
        tvwArea.DataSource = xmlDoc;
        tvwArea.DataBind();

        expandeds = ViewState["Expanded"] as string[];
        if (expandeds == null)
            return;
        ExpandNodes(tvwArea.Nodes);
    }

    /// <summary>
    /// 递归设置节点
    /// </summary>
    private void ExpandNodes(FineUI.TreeNodeCollection treeNodes)
    {
        foreach (FineUI.TreeNode node in treeNodes)
        {
            if (expandeds.Contains(node.NodeID))
            {
                node.Expanded = true;               
            }
            ExpandNodes(node.Nodes);
        }
    }


    /// <summary>
    /// 创建地区的子节点
    /// </summary>
    private void CreateXElement(XElement root, FineOffice.Modules.CRM_Area model)
    {
        List<FineOffice.Modules.CRM_Area> tempList = areaList.Where(a => a.ParentID == model.ID).OrderBy(t => t.Ordering).ToList();

        foreach (FineOffice.Modules.CRM_Area temp in tempList)
        {
            XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.Area), 
                new XAttribute("EnablePostBack",true),
                new XAttribute("SingleClickExpand", false),
                new XAttribute("NodeID",temp.ID),                
            });
            root.Add(xe);
            CreateXElement(xe, temp);
        }
    }
}