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

public partial class Letter_FrmLetterChannel : PageBase
{
    FineOffice.BLL.ADM_LetterChannel letterChannelBll = new FineOffice.BLL.ADM_LetterChannel();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            letterChannelGird_Bind();
            btnNew.OnClientClick = wndNewLetterChannel.GetShowReference();
            btnModify.OnClientClick = letterChannelGird.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", letterChannelGird.Title));
            btnDelete.OnClientClick = letterChannelGird.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", letterChannelGird.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", letterChannelGird.Title);
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            letterChannelGird_Bind();
        }
    }

    #region BindGrid

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        letterChannelGird.SelectAllRows();
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = letterChannelGird.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((letterChannelGird.DataKeys[keys[i]][0]).ToString()));
            }
            letterChannelBll.Delete(deleteList);
            letterChannelGird_Bind();
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void letterChannelGird_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = letterChannelGird.DataKeys[e.RowIndex];
                letterChannelBll.Delete(new FineOffice.Modules.ADM_LetterChannel { ID = int.Parse(keys[0].ToString()) });
                letterChannelGird_Bind();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        wndModifyLetterChannel.IFrameUrl = string.Format("FrmModifyLetterChannel.aspx?ID={0}", letterChannelGird.DataKeys[letterChannelGird.SelectedRowIndex][0]);
        wndModifyLetterChannel.Hidden = false;
    }

    private void letterChannelGird_Bind()
    {
        string channel = ttbSearch.Text.Trim();
        List<FineOffice.Modules.ADM_LetterChannel> list = letterChannelBll.GetList(t => t.Channel.Contains(channel));
        letterChannelGird.DataSource = list;
        letterChannelGird.DataBind();
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
        letterChannelGird_Bind();
    }

    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        letterChannelGird_Bind();
        ttbSearch.ShowTrigger1 = true;
    }
}
