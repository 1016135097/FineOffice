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

public partial class Census_FrmCensusType : PageBase
{
    FineOffice.BLL.CNS_CensusType censusTypeBll = new FineOffice.BLL.CNS_CensusType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            censusTypeGrid_Bind();
            btnNew.OnClientClick = frmNewCensusType.GetShowReference();
            btnModify.OnClientClick = censusTypeGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！",censusTypeGrid.Title));
            btnDelete.OnClientClick = censusTypeGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", censusTypeGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", censusTypeGrid.Title);
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            censusTypeGrid_Bind();
        }
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        censusTypeGrid.SelectAllRows();
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = censusTypeGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((censusTypeGrid.DataKeys[keys[i]][0]).ToString()));
            }
            censusTypeBll.Delete(deleteList);
            censusTypeGrid_Bind();
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void censusTypeGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = censusTypeGrid.DataKeys[e.RowIndex];
                censusTypeBll.Delete(new FineOffice.Modules.CNS_CensusType { ID = int.Parse(keys[0].ToString()) });
                censusTypeGrid_Bind();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        frmModifyCensusType.IFrameUrl = string.Format("FrmModifyCensusType.aspx?ID={0}", censusTypeGrid.DataKeys[censusTypeGrid.SelectedRowIndex][0]);
        frmModifyCensusType.Hidden = false;
    }

    private void censusTypeGrid_Bind()
    {        
        string type= ttbSearch.Text.Trim();
        List<FineOffice.Modules.CNS_CensusType> list = censusTypeBll.GetList(t => t.CensusTypeName.Contains(type));
        censusTypeGrid.DataSource = list;
        censusTypeGrid.DataBind();       
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
        censusTypeGrid_Bind();
    }

    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        censusTypeGrid_Bind();
        ttbSearch.ShowTrigger1 = true;
    }
}
