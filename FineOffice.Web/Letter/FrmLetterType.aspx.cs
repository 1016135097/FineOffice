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

public partial class Letter_FrmLetterType : PageBase
{
    FineOffice.BLL.ADM_LetterType letterTypeBll = new FineOffice.BLL.ADM_LetterType();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            letterTypeGird_Bind();
            btnNew.OnClientClick = wndNewLetterType.GetShowReference();
            btnModify.OnClientClick = letterTypeGird.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", letterTypeGird.Title));
            btnDelete.OnClientClick = letterTypeGird.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", letterTypeGird.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", letterTypeGird.Title);
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            letterTypeGird_Bind();
        }
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        letterTypeGird.SelectAllRows();
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = letterTypeGird.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((letterTypeGird.DataKeys[keys[i]][0]).ToString()));
            }
            letterTypeBll.Delete(deleteList);
            letterTypeGird_Bind();
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void letterTypeGird_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = letterTypeGird.DataKeys[e.RowIndex];
                letterTypeBll.Delete(new FineOffice.Modules.ADM_LetterType { ID = int.Parse(keys[0].ToString()) });
                letterTypeGird_Bind();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        wndModifyLetterType.IFrameUrl = string.Format("FrmModifyLetterType.aspx?ID={0}", letterTypeGird.DataKeys[letterTypeGird.SelectedRowIndex][0]);
        wndModifyLetterType.Hidden = false;
    }

    private void letterTypeGird_Bind()
    {
        string letterType = ttbSearch.Text.Trim();
        List<FineOffice.Modules.ADM_LetterType> list = letterTypeBll.GetList(t => t.LetterType.Contains(letterType));
        letterTypeGird.DataSource = list;
        letterTypeGird.DataBind();
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
        letterTypeGird_Bind();
    }

    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        letterTypeGird_Bind();
        ttbSearch.ShowTrigger1 = true;
    }
}
