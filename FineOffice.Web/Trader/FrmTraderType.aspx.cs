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

public partial class Trader_FrmTraderType : PageBase
{
    FineOffice.BLL.CRM_TraderType traderTypeBll = new FineOffice.BLL.CRM_TraderType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnNew.OnClientClick = newTraderTypeWin.GetShowReference();
            btnModify.OnClientClick = traderTypeGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", traderTypeGrid.Title));
            btnDelete.OnClientClick = traderTypeGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", traderTypeGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中的{0}吗？", traderTypeGrid.Title);

            traderTypeGrid_Bind();
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            traderTypeGrid_Bind();
        }
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        traderTypeGrid.SelectAllRows();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = traderTypeGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((traderTypeGrid.DataKeys[keys[i]][0]).ToString()));
            }
            traderTypeBll.Delete(ids);
            traderTypeGrid_Bind();
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void traderTypeGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = traderTypeGrid.DataKeys[e.RowIndex];
                traderTypeBll.Delete(new FineOffice.Modules.CRM_TraderType { ID = int.Parse(keys[0].ToString()) });
                traderTypeGrid_Bind();
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyTraderTypeWin.IFrameUrl = string.Format("FrmModifyTraderType.aspx?ID={0}", traderTypeGrid.DataKeys[traderTypeGrid.SelectedRowIndex][0]);
        modifyTraderTypeWin.Hidden = false;
    }

    private void traderTypeGrid_Bind()
    {
        string type = ttbSearch.Text.Trim();
        List<FineOffice.Modules.CRM_TraderType> list = traderTypeBll.GetList(t => t.TraderType.Contains(type)).OrderBy(s=>s.Ordering).ToList();
        traderTypeGrid.DataSource = list;
        traderTypeGrid.DataBind();
    }

    /// <summary>
    /// 清空查询条件
    /// </summary>
    protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
    {
        ttbSearch.Text = String.Empty;
        ttbSearch.ShowTrigger1 = false;
        traderTypeGrid_Bind();
    }

    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        traderTypeGrid_Bind();
        ttbSearch.ShowTrigger1 = true;
    }
}
