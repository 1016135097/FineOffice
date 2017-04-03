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

public partial class Trader_FrmGradeList : PageBase
{
    FineOffice.BLL.CRM_Grade gradeBll = new FineOffice.BLL.CRM_Grade();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnNew.OnClientClick = newGradeWin.GetShowReference();

            btnModify.OnClientClick = gradeGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", gradeGrid.Title));
            btnDelete.OnClientClick = gradeGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", gradeGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中的{0}吗？", gradeGrid.Title);

            gradeGrid_Bind();
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            gradeGrid_Bind();
        }
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        gradeGrid.SelectAllRows();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = gradeGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((gradeGrid.DataKeys[keys[i]][0]).ToString()));
            }
            gradeBll.Delete(ids);
            gradeGrid_Bind();
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void gradeGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = gradeGrid.DataKeys[e.RowIndex];
                gradeBll.Delete(new FineOffice.Modules.CRM_Grade { ID = int.Parse(keys[0].ToString()) });
                gradeGrid_Bind();
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyGradeWin.IFrameUrl = string.Format("FrmModifyGrade.aspx?ID={0}", gradeGrid.DataKeys[gradeGrid.SelectedRowIndex][0]);
        modifyGradeWin.Hidden = false;
    }

    private void gradeGrid_Bind()
    {
        string type = ttbSearch.Text.Trim();
        List<FineOffice.Modules.CRM_Grade> list = gradeBll.GetList(t => t.Grade.Contains(type)).OrderBy(s => s.Ordering).ToList();
        gradeGrid.DataSource = list;
        gradeGrid.DataBind();
    }

    /// <summary>
    /// 清空查询条件
    /// </summary>
    protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
    {
        ttbSearch.Text = String.Empty;
        ttbSearch.ShowTrigger1 = false;
        gradeGrid_Bind();
    }

    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        gradeGrid_Bind();
        ttbSearch.ShowTrigger1 = true;
    }
}
