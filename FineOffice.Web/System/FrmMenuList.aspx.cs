using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineOffice.Web;
using FineUI;
using System.Data;
using System.Text;
using FineOffice.Modules.Helper;
using FineOffice.Common.ListHelper;
using System.Xml.Linq;
using System.Xml;

public partial class System_FrmMenuList : PageBase
{
    FineOffice.BLL.SYS_MenuList menuBll = new FineOffice.BLL.SYS_MenuList();
    List<FineOffice.Modules.SYS_MenuList> menuList = new List<FineOffice.Modules.SYS_MenuList>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            menuGrid_Bind();
            btnModify.OnClientClick = menuGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", this.menuGrid));
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            menuGrid_Bind();
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    private void menuGrid_Bind()
    {
        menuList = menuBll.GetListAll();
        List<FineOffice.Modules.SYS_MenuList> tempList = BuildTree();
        menuGrid.DataSource = tempList;
        menuGrid.DataBind();
    }

    List<FineOffice.Modules.SYS_MenuList> treeList = new List<FineOffice.Modules.SYS_MenuList>();
    private List<FineOffice.Modules.SYS_MenuList> BuildTree()
    {
        List<FineOffice.Modules.SYS_MenuList> tempList = menuList.Where(s => s.ParentID == 0).OrderBy(d => d.Ordering).ToList();
        foreach (FineOffice.Modules.SYS_MenuList a in tempList)
        {
            a.TreeLevel = 1;
            treeList.Add(a);
            BuildSubTree(a, 1);
        }
        return treeList;
    }

    private void BuildSubTree(FineOffice.Modules.SYS_MenuList model, int level)
    {
        List<FineOffice.Modules.SYS_MenuList> tempList = menuList.Where(s => s.ParentID == model.ID).OrderBy(d => d.Ordering).ToList();
        level++;
        foreach (FineOffice.Modules.SYS_MenuList a in tempList)
        {
            a.TreeLevel = level;
            treeList.Add(a);
            BuildSubTree(a, level);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void menuGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = menuGrid.DataKeys[e.RowIndex];
                menuBll.Delete(new FineOffice.Modules.SYS_MenuList { ID = int.Parse(keys[0].ToString()) });
                menuGrid_Bind();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        menuWin.IFrameUrl = string.Format("FrmModifyMenu.aspx?id={0}&t", menuGrid.DataKeys[menuGrid.SelectedRowIndex][0], DateTime.Now.Ticks);
        menuWin.Title = "编辑";
        menuWin.Hidden = false;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        menuWin.IFrameUrl = "FrmNewMenu.aspx?t=" + DateTime.Now.Ticks;
        menuWin.Title = "新增";
        menuWin.Hidden = false;
    }

    /// <summary>
    /// 刷新菜单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        menuGrid_Bind();
    }
}
