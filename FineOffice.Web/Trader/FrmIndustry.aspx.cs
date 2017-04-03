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

public partial class Trader_FrmIndustry : PageBase
{
    FineOffice.BLL.CRM_Industry industryBll = new FineOffice.BLL.CRM_Industry();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnNew.OnClientClick = newIndustryWin.GetShowReference();
            btnModify.OnClientClick = industryGrid.GetNoSelectionAlertInParentReference("请选择要编辑的" + industryGrid.Title + "！");
            btnDelete.OnClientClick = industryGrid.GetNoSelectionAlertInParentReference("请选择要删除的" + industryGrid.Title + "！");
            btnDelete.ConfirmText = "你确认要删除选中的" + industryGrid.Title + "吗？";
            industryGrid_Bind();
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            industryGrid_Bind();
        }
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        industryGrid.SelectAllRows();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int[] keys = industryGrid.SelectedRowIndexArray;
        List<int> ids = new List<int>();
        for (int i = 0; i < keys.Length; i++)
        {
            ids.Add(int.Parse((industryGrid.DataKeys[keys[i]][0]).ToString()));
        } try
        {
            industryBll.Delete(ids); industryGrid_Bind();
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void industryGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = industryGrid.DataKeys[e.RowIndex];
                industryBll.Delete(new FineOffice.Modules.CRM_Industry { ID = int.Parse(keys[0].ToString()) });
                industryGrid_Bind();
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyIndustryWin.IFrameUrl = string.Format("FrmModifyIndustry.aspx?ID={0}", industryGrid.DataKeys[industryGrid.SelectedRowIndex][0]);
        modifyIndustryWin.Hidden = false;
    }

    private void industryGrid_Bind()
    {
        string type = ttbSearch.Text.Trim();
        List<FineOffice.Modules.CRM_Industry> list = industryBll.GetList(t => t.Industry.Contains(type)).OrderBy(s => s.Ordering).ToList();
        industryGrid.DataSource = list;
        industryGrid.DataBind();
    }

    /// <summary>
    /// 清空查询条件
    /// </summary>
    protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
    {
        ttbSearch.Text = String.Empty;
        ttbSearch.ShowTrigger1 = false;
        industryGrid_Bind();
    }

    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        industryGrid_Bind();
        ttbSearch.ShowTrigger1 = true;
    }
}
