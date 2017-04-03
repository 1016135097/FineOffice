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

public partial class Trader_FrmSourceList : PageBase
{
    FineOffice.BLL.CRM_Source sourceBll = new FineOffice.BLL.CRM_Source();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnNew.OnClientClick = newSourceWin.GetShowReference();

            btnModify.OnClientClick = sourceGrid.GetNoSelectionAlertInParentReference("请选择要编辑的" + sourceGrid.Title + "！");
            btnDelete.OnClientClick = sourceGrid.GetNoSelectionAlertInParentReference("请选择要删除的" + sourceGrid.Title + "！");
            btnDelete.ConfirmText = "你确认要删除选中的" + sourceGrid.Title + "吗？";

            sourceGrid_Bind();
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            sourceGrid_Bind();
        }
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        sourceGrid.SelectAllRows();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = sourceGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((sourceGrid.DataKeys[keys[i]][0]).ToString()));
            }
            sourceBll.Delete(ids);
            sourceGrid_Bind();
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void sourceGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = sourceGrid.DataKeys[e.RowIndex];
                sourceBll.Delete(new FineOffice.Modules.CRM_Source { ID = int.Parse(keys[0].ToString()) });
                sourceGrid_Bind();
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifySourceWin.IFrameUrl = string.Format("FrmModifySource.aspx?ID={0}", sourceGrid.DataKeys[sourceGrid.SelectedRowIndex][0]);
        modifySourceWin.Hidden = false;
    }

    private void sourceGrid_Bind()
    {
        string type = ttbSearch.Text.Trim();
        List<FineOffice.Modules.CRM_Source> list = sourceBll.GetList(t => t.Source.Contains(type)).OrderBy(s => s.Ordering).ToList();
        sourceGrid.DataSource = list;
        sourceGrid.DataBind();
    }

    /// <summary>
    /// 清空查询条件
    /// </summary>
    protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
    {
        ttbSearch.Text = String.Empty;
        ttbSearch.ShowTrigger1 = false;
        sourceGrid_Bind();
    }

    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        sourceGrid_Bind();
        ttbSearch.ShowTrigger1 = true;
    }
}
