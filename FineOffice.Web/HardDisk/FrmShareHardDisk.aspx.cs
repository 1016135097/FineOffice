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
using System.Xml.Linq;
using System.Xml;
using FineOffice.Common.SerializeHelper;

public partial class HardDisk_FrmShareHardDisk : PageBase
{
    FineOffice.BLL.HD_Folder folderBll = new FineOffice.BLL.HD_Folder();
    FineOffice.BLL.HD_Attachment fileBll = new FineOffice.BLL.HD_Attachment();

    List<FineOffice.Modules.HD_Folder> folderList = new List<FineOffice.Modules.HD_Folder>();
    string[] expandeds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tvwFolder_Bind();

            btnModifyFolder.OnClientClick = tvwFolder.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", tvwFolder.Title));
            btnMoveFolder.OnClientClick = tvwFolder.GetNoSelectionAlertReference(string.Format("请选择要移动的{0}！", tvwFolder.Title));
            btnDeleteFolder.OnClientClick = tvwFolder.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", tvwFolder.Title));
            btnDeleteFolder.ConfirmText = string.Format("你确认要删除选中的{0}吗？", tvwFolder.Title);

            btnCopyToPerson.OnClientClick = fileGrid.GetNoSelectionAlertReference(string.Format("请选择要复制的{0}！", fileGrid.Title));
            btnModifyFile.OnClientClick = fileGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", fileGrid.Title));
            btnMoveFile.OnClientClick = fileGrid.GetNoSelectionAlertReference(string.Format("请选择要移动的{0}！", fileGrid.Title));
            btnDownFile.OnClientClick = fileGrid.GetNoSelectionAlertReference(string.Format("请选择要下载的{0}！", fileGrid.Title));
            btnDeleteFile.ConfirmText = string.Format("你确认要删除选中{0}吗！", fileGrid.Title);

            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            fileDataBind();
        }
        if (Request.Form["__EVENTARGUMENT"] == "folder_close")
        {
            tvwFolder_Bind();
        }
        if (Request.Form["__EVENTARGUMENT"] == "refresh_File")
        {
            fileDataBind();
        }
    }

    /// <summary>
    /// 树菜单
    /// </summary>
    private void tvwFolder_Bind()
    {
        XDocument xdoc = CreateMenuXml();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xdoc.Document.ToString());

        // 绑定 XML 数据源到树控件
        tvwFolder.DataSource = xmlDoc;
        tvwFolder.DataBind();

        tvwFolder.Nodes[0].Expanded = true;
        expandeds = ViewState["Expanded"] as string[];
        if (expandeds == null)
            return;
        TreeExpandNodes(tvwFolder.Nodes);
    }

    /// <summary>
    /// 递归设置节点
    /// </summary>
    private void TreeExpandNodes(FineUI.TreeNodeCollection treeNodes)
    {
        foreach (FineUI.TreeNode node in treeNodes)
        {
            if (expandeds.Contains(node.NodeID))
            {
                node.Expanded = true;
            }
            TreeExpandNodes(node.Nodes);
        }
    }

    /// <summary>
    /// 创建树的XML
    /// </summary>
    private XDocument CreateMenuXml()
    {
        folderList = folderBll.GetList(i => i.IsPublic == true);
        XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));
        XElement xe = new XElement("TreeNode", new object[] 
        { 
               new XAttribute("Text", "公共硬盘"),             
               new XAttribute("EnablePostBack",true),
               new XAttribute("NodeID","0"),
         });
        xdoc.Root.Add(xe);
        List<FineOffice.Modules.HD_Folder> tempList = folderList.Where(d => d.ParentID == 0).ToList();
        foreach (FineOffice.Modules.HD_Folder temp in tempList)
        {
            XElement sub = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.FolderName), 
                new XAttribute("EnablePostBack",true),
                new XAttribute("NodeID",temp.ID),                
            });
            xe.Add(sub);
            CreateXElement(sub, temp);
        }
        return xdoc;
    }

    /// <summary>
    /// 创建树第一级节点
    /// </summary>
    private void CreateXElement(XElement root, FineOffice.Modules.HD_Folder model)
    {
        List<FineOffice.Modules.HD_Folder> tempList = folderList.Where(d => d.ParentID == model.ID).ToList();
        foreach (FineOffice.Modules.HD_Folder temp in tempList)
        {
            XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.FolderName), 
                new XAttribute("EnablePostBack",true),
                new XAttribute("NodeID",temp.ID),                
            });
            root.Add(xe);
            CreateXElement(xe, temp);
        }
    }

    /// <summary>
    /// 新建文件夹
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNewFolder_Click(object sender, EventArgs e)
    {
        string folderID = "0";
        if (tvwFolder.SelectedNode != null)
        {
            folderID = tvwFolder.SelectedNodeID;
        }
        ViewState["Expanded"] = tvwFolder.GetExpandedNodeIDs();
        folderWin.Title = "新增";
        folderWin.IFrameUrl = string.Format("FrmNewFolder.aspx?parentid={0}&ispublic={1}", folderID, "true");
        folderWin.Hidden = false;
    }

    protected void btnModifyFolder_Click(object sender, EventArgs e)
    {
        string folderID = tvwFolder.SelectedNodeID;
        ViewState["Expanded"] = tvwFolder.GetExpandedNodeIDs();
        folderWin.Title = "编辑";
        folderWin.IFrameUrl = "FrmModifyFolder.aspx?id=" + folderID;
        folderWin.Hidden = false;
    }

    protected void btnMoveFolder_Click(object sender, EventArgs e)
    {
        string folderID = tvwFolder.SelectedNodeID;
        ViewState["Expanded"] = tvwFolder.GetExpandedNodeIDs();
        moveWin.Title = "移动至";
        moveWin.IFrameUrl = string.Format("FrmMoveFolder.aspx?id={0}&ispublic={1}", folderID, "true");
        moveWin.Hidden = false;
    }

    /// <summary>
    /// 清空查询条件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
    {
        ttbSearch.Text = String.Empty;
        ttbSearch.ShowTrigger1 = false;
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        ViewState["sql"] = changeTrackingList;
        fileDataBind();
    }

    /// <summary>
    /// 查询
    /// </summary>
    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "FileName";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        ViewState["sql"] = changeTrackingList;
        ttbSearch.ShowTrigger1 = true;
        fileDataBind();
    }

    protected void btnModifyFile_Click(object sender, EventArgs e)
    {
        modifyFileWin.IFrameUrl = string.Format("../HardDisk/FrmModifyFile.aspx?id={0}", fileGrid.DataKeys[fileGrid.SelectedRowIndex][0]);
        modifyFileWin.Hidden = false;
    }

    /// <summary>
    /// 刷新附件信息
    /// </summary>
    protected void btnRefreshFile_Click(object sender, EventArgs e)
    {
        fileDataBind();
    }

    protected void btnDownFile_Click(object sender, EventArgs e)
    {
        int id = int.Parse(fileGrid.DataKeys[fileGrid.SelectedRowIndex][0].ToString());
        FineOffice.Modules.HD_Attachment model = fileBll.GetModel(d => d.ID == id);
        this.OutputStream(model.AttachmentData, model.FileName, model.XType);
    }

    /// <summary>
    /// 上传文件
    /// </summary>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string folderID = "";
        FineUI.TreeNode node = tvwFolder.SelectedNode;
        if (node != null && node.NodeID != "0")
            folderID = node.NodeID;
        uploadFileWin.IFrameUrl = string.Format("../HardDisk/FrmUploadFile.aspx?folderid={0}&tabid={1}", folderID, this._FrmShareHardDisk.ID);
        uploadFileWin.Hidden = false;
    }

    protected void chkContainFolder_CheckedChanged(object sender, EventArgs e)
    {
        fileDataBind();
    }

    public void fileDataBind()
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = fileGrid.FindColumn(fileGrid.SortColumn);
        fileGrid_Bind(changeTrackingList, column.SortField, fileGrid.SortDirection);
    }

    /// <summary>
    /// 全局变量，递归取子节点ID
    /// </summary>
    StringBuilder strNodes;

    private void fileGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        ChangeTrackingList<EntitySearcher> tempTrackingList = new ChangeTrackingList<EntitySearcher>();
        foreach (EntitySearcher s in changeTrackingList)
        {
            tempTrackingList.Add(s);
        }

        EntitySearcher search = new EntitySearcher();
        search.Field = "IsPublic";
        search.Relation = "AND";
        search.Operator = "=";
        search.Content = "True";
        tempTrackingList.Add(search);

        FineUI.TreeNode node = tvwFolder.SelectedNode;
        if (node != null && node.NodeID != "0")
        {
            if (chkContainFolder.Checked)
            {
                strNodes = new StringBuilder();
                string nodes = GetSubNodes(node);
                nodes = nodes.Remove(nodes.Length - 1);
                string content = string.Format("({0})", nodes);
                search = new EntitySearcher();
                search.Field = "FolderID";
                search.Relation = "AND";
                search.Operator = "in";
                search.Content = content;
                tempTrackingList.Add(search);
            }
            else
            {
                search = new EntitySearcher();
                search.Field = "FolderID";
                search.Relation = "AND";
                search.Operator = "=";
                search.Content = tvwFolder.SelectedNodeID;
                tempTrackingList.Add(search);
            }
        }
        fileGrid.RecordCount = fileBll.GetCount(tempTrackingList);
        ExtBindingList<FineOffice.Modules.HD_Attachment> list = fileBll.GetList(tempTrackingList, fileGrid.PageIndex, fileGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        fileGrid.DataSource = list;
        fileGrid.DataBind();
    }

    /// <summary>
    /// 取所有子节点
    /// </summary>
    private string GetSubNodes(FineUI.TreeNode node)
    {
        strNodes.Append(node.NodeID);
        strNodes.Append(",");
        foreach (FineUI.TreeNode temp in node.Nodes)
        {
            GetSubNodes(temp);
        }
        return strNodes.ToString();
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void fileGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.fileGrid.PageIndex = e.NewPageIndex;
        fileDataBind();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void fileGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        fileDataBind();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDeleteFile_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = fileGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((fileGrid.DataKeys[keys[i]][0]).ToString()));
            }
            fileBll.Delete(ids);
            fileDataBind();
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 批量移动文件
    /// </summary>
    protected void btnMoveFile_Click(object sender, EventArgs e)
    {
        int[] keys = fileGrid.SelectedRowIndexArray;
        List<string> ids = new List<string>();
        for (int i = 0; i < keys.Length; i++)
        {
            ids.Add(fileGrid.DataKeys[keys[i]][0].ToString());
        }
        string files = CommonSerialize.Serialize(ListToJson(ids));
        moveWin.Title = "移动文件至";
        moveWin.IFrameUrl = string.Format("../HardDisk/FrmMoveFiles.aspx?files={0}&ispublic={1}", files,"true");
        moveWin.Hidden = false;
    }

    /// <summary>
    /// 批量移动文件到用户
    /// </summary>
    protected void btnCopyToPerson_Click(object sender, EventArgs e)
    {
        int[] keys = fileGrid.SelectedRowIndexArray;
        List<string> ids = new List<string>();
        for (int i = 0; i < keys.Length; i++)
        {
            ids.Add(fileGrid.DataKeys[keys[i]][0].ToString());
        }
        string files = CommonSerialize.Serialize(ListToJson(ids));
        copyPersonWin.Title = "复制到共享硬盘";
        copyPersonWin.IFrameUrl = string.Format("../HardDisk/FrmCopyToPersonnel.aspx?files={0}", files);
        copyPersonWin.Hidden = false;
    }

    /// <summary>
    /// 删除附件的方法
    /// </summary>
    protected void fileGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            object[] keys = fileGrid.DataKeys[e.RowIndex];
            int id = int.Parse(keys[0].ToString());
            if (e.CommandName == "delete")
            {
                fileBll.Delete(new FineOffice.Modules.HD_Attachment { ID = id });
                fileDataBind();
            }
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 展开树节点
    /// </summary>
    protected void btnExpandAll_Click(object sender, EventArgs e)
    {
        tvwFolder.ExpandAllNodes();
    }

    protected void btnDeleteFolder_Click(object sender, EventArgs e)
    {
        int folderID = int.Parse(tvwFolder.SelectedNodeID);
        if (folderID == 0)
            return;
        folderBll.Delete(new FineOffice.Modules.HD_Folder { ID = folderID });
        ViewState["Expanded"] = tvwFolder.GetExpandedNodeIDs();
        tvwFolder_Bind();
    }

    protected void tvwFolder_NodeCommand(object sender, TreeCommandEventArgs e)
    {
        ttbSearch_Trigger2Click(null, null);
    }

    protected void btnCollapseAll_Click(object sender, EventArgs e)
    {
        tvwFolder.CollapseAllNodes();
    }
}