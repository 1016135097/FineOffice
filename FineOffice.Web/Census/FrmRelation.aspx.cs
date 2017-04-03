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

public partial class Census_FrmRelation : PageBase
{
    FineOffice.BLL.CNS_CensusRelation relationBll = new FineOffice.BLL.CNS_CensusRelation();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            relationGrid_Bind();
            btnNew.OnClientClick = frmNewRelation.GetShowReference();
            btnModify.OnClientClick = relationGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", relationGrid.Title));
            btnDelete.OnClientClick = relationGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", relationGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", relationGrid.Title);
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            relationGrid_Bind();
        }
    }

    #region relationGrid_Bind

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        relationGrid.SelectAllRows();
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = relationGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((relationGrid.DataKeys[keys[i]][0]).ToString()));
            }
            relationBll.Delete(deleteList);
            relationGrid_Bind();
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void relation_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = relationGrid.DataKeys[e.RowIndex];
                relationBll.Delete(new FineOffice.Modules.CNS_CensusRelation { ID = int.Parse(keys[0].ToString()) });
                relationGrid_Bind();
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        frmModifyRelation.IFrameUrl = string.Format("FrmModifyRelation.aspx?ID={0}", relationGrid.DataKeys[relationGrid.SelectedRowIndex][0]);
        frmModifyRelation.Hidden = false;
    }

    private void relationGrid_Bind()
    {
        string type = ttbSearch.Text.Trim();
        List<FineOffice.Modules.CNS_CensusRelation> list = relationBll.GetList(t => t.Relation.Contains(type));
        relationGrid.DataSource = list;
        relationGrid.DataBind();
    }


    #endregion


    /// <summary>
    /// 清空查询条件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
    {
        ttbSearch.Text = String.Empty;
        ttbSearch.ShowTrigger1 = false;
        relationGrid_Bind();
    }

    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        relationGrid_Bind();
        ttbSearch.ShowTrigger1 = true;
    }
}
