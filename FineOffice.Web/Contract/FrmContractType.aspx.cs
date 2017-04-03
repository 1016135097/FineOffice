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

public partial class Contract_FrmContractType : PageBase 
{
    FineOffice.BLL.OA_ContractType typeBll = new FineOffice.BLL.OA_ContractType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnNew.OnClientClick = newTypeWin.GetShowReference();
            btnModify.OnClientClick = typeGrid.GetNoSelectionAlertInParentReference("请选择要编辑的" + typeGrid.Title + "！");
            btnDelete.OnClientClick = typeGrid.GetNoSelectionAlertInParentReference("请选择要删除的" + typeGrid.Title + "！");
            btnDelete.ConfirmText = "你确认要删除选中的" + typeGrid.Title + "吗？";
            btnDelete.ConfirmTarget = Target.Parent;
            typeGrid_Bind();
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            typeGrid_Bind();
        }
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        typeGrid.SelectAllRows();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = typeGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((typeGrid.DataKeys[keys[i]][0]).ToString()));
            }
            typeBll.Delete(ids);
            typeGrid_Bind();
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void typeGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = typeGrid.DataKeys[e.RowIndex];
                typeBll.Delete(new FineOffice.Modules.OA_ContractType { ID = int.Parse(keys[0].ToString()) });
                typeGrid_Bind();
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyTypeWin.IFrameUrl = string.Format("FrmModifyContractType.aspx?ID={0}", typeGrid.DataKeys[typeGrid.SelectedRowIndex][0]);
        modifyTypeWin.Hidden = false;
    }

    private void typeGrid_Bind()
    {
        string type = ttbSearch.Text.Trim();
        List<FineOffice.Modules.OA_ContractType> list = typeBll.GetList(t => t.TypeName.Contains(type));
        typeGrid.DataSource = list;
        typeGrid.DataBind();
    }

    /// <summary>
    /// 清空查询条件
    /// </summary>
    protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
    {
        ttbSearch.Text = String.Empty;
        ttbSearch.ShowTrigger1 = false;
        typeGrid_Bind();
    }

    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        typeGrid_Bind();
        ttbSearch.ShowTrigger1 = true;
    }
}
