using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Trader_FrmNewTrader : PageBase
{
    FineOffice.BLL.CRM_Industry industryBll = new FineOffice.BLL.CRM_Industry();
    FineOffice.BLL.CRM_TraderType typeBll = new FineOffice.BLL.CRM_TraderType();
    FineOffice.BLL.CRM_Source sourceBll = new FineOffice.BLL.CRM_Source();
    FineOffice.BLL.CRM_Grade gradeBll = new FineOffice.BLL.CRM_Grade();
    FineOffice.BLL.CRM_Trader traderBll = new FineOffice.BLL.CRM_Trader();
    FineOffice.Common.PinyinCodeHelper pinyin = new FineOffice.Common.PinyinCodeHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();

            txtArea.OnClientTriggerClick = wndSelectArea.GetSaveStateReference(txtArea.ClientID, hiddenAreaID.ClientID)
                + wndSelectArea.GetShowReference("../common/FrmSelectArea.aspx");

            txtHandler.OnClientTriggerClick = wndHandler.GetSaveStateReference(txtHandler.ClientID, hiddenHandler.ClientID)
                + wndHandler.GetShowReference("../common/FrmRadioPersonnel.aspx");
        }
    }

    private void LoadData()
    {
        #region 行业
        List<FineOffice.Modules.CRM_Industry> industryList = industryBll.GetListAll();
        ddlIndustry.Items.Add("请选择", "");
        foreach (FineOffice.Modules.CRM_Industry industry in industryList)
        {
            ddlIndustry.Items.Add(industry.Industry, industry.ID.ToString());
        }
        #endregion

        #region 企业性质
        List<FineOffice.Modules.CRM_TraderType> typeList = typeBll.GetListAll();
        ddlTraderType.Items.Add("请选择", "");
        foreach (FineOffice.Modules.CRM_TraderType type in typeList)
        {
            ddlTraderType.Items.Add(type.TraderType, type.ID.ToString());
        }
        #endregion

        #region 企业来源
        List<FineOffice.Modules.CRM_Source> sourceList = sourceBll.GetListAll();
        ddlSource.Items.Add("请选择", "");
        foreach (FineOffice.Modules.CRM_Source source in sourceList)
        {
            ddlSource.Items.Add(source.Source, source.ID.ToString());
        }
        #endregion

        #region 企业等级
        List<FineOffice.Modules.CRM_Grade> gradeList = gradeBll.GetListAll();
        ddlGrade.Items.Add("请选择", "");
        foreach (FineOffice.Modules.CRM_Grade grade in gradeList)
        {
            ddlGrade.Items.Add(grade.Grade, grade.ID.ToString());
        }
        #endregion

        dtpCreateTime.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.CRM_Trader model = new FineOffice.Modules.CRM_Trader();
        model.Address = txtAddress.Text.Trim();        
            model.AreaID = int.Parse(hiddenAreaID.Text);       
        model.CreateTime = DateTime.Parse(dtpCreateTime.Text);
        model.Email = txtEmail.Text.Trim();
        model.Fax = txtFax.Text.Trim();
        if (ddlGrade.SelectedIndex > 0)
        {
            model.GradeID = int.Parse(ddlGrade.SelectedValue);
        }
        if (hiddenHandler.Text.Length > 0)
        {
            model.Handler = int.Parse(hiddenHandler.Text);
        }
        model.Incorporator = txtIncorporator.Text.Trim();
        if (ddlIndustry.SelectedIndex > 0)
        {
            model.IndustryID = int.Parse(ddlIndustry.SelectedValue);
        }
        string[] rule = chkRule.SelectedValueArray;
        if (rule.Contains("Client"))
            model.IsClient = true;
        if (rule.Contains("Supplier"))
            model.IsSupplier = true;

        model.Linkman = txtLinkman.Text.Trim();
        model.Mobile = txtMobile.Text.Trim();
        if(txtNumberOfPeople.Text.Length>0)
        {
            model.NumberOfPeople = int.Parse(txtNumberOfPeople.Text);
        }
        model.PinyinCode = txtPinyinCode.Text.Trim();
        model.Post = txtPost.Text.Trim();
        model.Remark = txtRemark.Text.Trim();
        model.ShortName = txtShortName.Text.Trim();

        if (ddlSource.SelectedIndex > 0)
        {
            model.SourceID = int.Parse(ddlSource.SelectedValue);
        }
        model.Stop = true;
        model.Tel = txtTel.Text.Trim();
        model.TraderName = txtTraderName.Text.Trim();
        model.TraderNO = txtTraderNO.Text.Trim();
        if (ddlTraderType.SelectedIndex > 0)
        {
            model.TypeID = int.Parse(ddlTraderType.SelectedValue);
        }
        model.WebSite = txtWebSite.Text.Trim();

        try
        {
            traderBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void Pinyin_TextChanged(object sender, EventArgs e)
    {
        txtPinyinCode.Text = pinyin.GetFirstLetter(txtShortName.Text.Trim());
    }
}
