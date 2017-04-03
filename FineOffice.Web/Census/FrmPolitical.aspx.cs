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

public partial class Census_FrmPolitical : PageBase
{
    FineOffice.BLL.CNS_PoliticalAffiliation politicalBll = new FineOffice.BLL.CNS_PoliticalAffiliation();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            politicalGrid_Bind();
            btnNew.OnClientClick = frmNewPolitical.GetShowReference();
            btnModify.OnClientClick = politicalGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", politicalGrid.Title));
            btnDelete.OnClientClick = politicalGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", politicalGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", politicalGrid.Title);
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            politicalGrid_Bind();
        }
    }

    #region politicalGrid_Bind

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        politicalGrid.SelectAllRows();
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = politicalGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((politicalGrid.DataKeys[keys[i]][0]).ToString()));
            }
            politicalBll.Delete(deleteList);
            politicalGrid_Bind();
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void politicalGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = politicalGrid.DataKeys[e.RowIndex];
                politicalBll.Delete(new FineOffice.Modules.CNS_PoliticalAffiliation { ID = int.Parse(keys[0].ToString()) });
                politicalGrid_Bind();
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        frmModifyCensusType.IFrameUrl = string.Format("FrmModifyPolitical.aspx?ID={0}", politicalGrid.DataKeys[politicalGrid.SelectedRowIndex][0]);
        frmModifyCensusType.Hidden = false;
    }

    private void politicalGrid_Bind()
    {        
        string type= ttbSearch.Text.Trim();
        List<FineOffice.Modules.CNS_PoliticalAffiliation> list = politicalBll.GetList(t => t.Political.Contains(type));
        politicalGrid.DataSource = list;
        politicalGrid.DataBind();       
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
        politicalGrid_Bind();
    }

    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        politicalGrid_Bind();
        ttbSearch.ShowTrigger1 = true;
    }
}
