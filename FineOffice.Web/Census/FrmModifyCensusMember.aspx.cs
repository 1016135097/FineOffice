using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Census_FrmModifyCensusMember : PageBase
{
    FineOffice.BLL.CNS_PoliticalAffiliation affiliationBll = new FineOffice.BLL.CNS_PoliticalAffiliation();
    FineOffice.BLL.CNS_CensusMember memberBll = new FineOffice.BLL.CNS_CensusMember();
    FineOffice.BLL.CNS_CensusRelation relationBll = new FineOffice.BLL.CNS_CensusRelation();
    FineOffice.BLL.AM_Kind kindBll = new FineOffice.BLL.AM_Kind();

    FineOffice.BLL.CNS_CensusRegister registerBll = new FineOffice.BLL.CNS_CensusRegister();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            LoadData();
        }
    }

    private void LoadData()
    {
        List<FineOffice.Modules.CNS_CensusRelation> relationList = relationBll.GetListAll();
        foreach (FineOffice.Modules.CNS_CensusRelation relation in relationList)
        {
            ddlRelation.Items.Add(relation.Relation, relation.Relation);
        }

        List<FineOffice.Modules.CNS_PoliticalAffiliation> affiliationList = affiliationBll.GetListAll();
        foreach (FineOffice.Modules.CNS_PoliticalAffiliation affiliation in affiliationList)
        {
            ddlPolitical.Items.Add(affiliation.Political, affiliation.ID.ToString());
        }

        List<FineOffice.Modules.AM_Kind> educationList = kindBll.GetList(d => d.KindID == 1);
        foreach (FineOffice.Modules.AM_Kind kind in educationList)
        {
            ddlEducation.Items.Add(kind.Name, kind.ID.ToString());
        }

        if (Request["ID"] != null)
        {
            int id = int.Parse(Request["ID"]);
            hiddenID.Text = Request["ID"];
            FineOffice.Modules.CNS_CensusMember model = memberBll.GetModel(d => d.ID == id);
            txtRegisterNO.Text = model.RegisterNO;
            txtAddress.Text = model.Address;
            dtpBrithday.Text = string.Format("{0:yyyy-MM-dd}", model.Brithday);
            dtpCancelDate.Text = string.Format("{0:yyyy-MM-dd}", model.CancelDate);
            txtCancelReason.Text = model.CancelReason;
            txtCompany.Text = model.Company;
            ddlEducation.SelectedValue = model.EducationID.ToString();
            txtHeight.Text = model.Height;
            txtIDCard.Text = model.IDCard;
            dtpIngoingDate.Text = string.Format("{0:yyyy-MM-dd}", model.IngoingDate);
            txtIngoingReason.Text = model.IngoingReason;
            chkIsCanceled.Checked = model.IsCanceled.Value;
            txtMarriage.Text = model.Marriage;
            txtMilitaryService.Text = model.MilitaryService;
            dtpMoveOutDate.Text = string.Format("{0:yyyy-MM-dd}", model.MoveOutDate);
            txtMoveToAddress.Text = model.MoveToAddress;
            txtName.Text = model.Name;
            txtNationalilty.Text = model.Nationalilty;
            txtOccupation.Text = model.Occupation;
            ddlPolitical.SelectedValue = model.PoliticalID.ToString();
            txtTypeOfBlood.Text = model.TypeOfBlood;
            txtTel.Text = model.Tel;
            ddlSex.SelectedValue = model.Sex.ToString();
            txtReligion.Text = model.Religion;
            txtOtherName.Text = model.OtherName;
            ddlRelation.SelectedValue = model.Relation;
            txtPreviousAddress.Text = model.PreviousAddress;
            txtPlaceOfAncestral.Text = model.PlaceOfAncestral;
            txtPlaceOfBirth.Text = model.PlaceOfBirth;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string registerNO = txtRegisterNO.Text.Trim();
        if (registerBll.GetModel(r => r.RegisterNO == registerNO) == null)
        {
            FineUI.Alert.ShowInParent("该户号不存在！");
            return;
        }

        DateTime? brithday = null;
        if (dtpBrithday.Text.Length > 0)
            brithday = DateTime.Parse(dtpBrithday.Text);

        DateTime? cancelDate = null;
        if (dtpCancelDate.Text.Length > 0)
            cancelDate = DateTime.Parse(dtpCancelDate.Text);

        DateTime? ingoingDate = null;
        if (dtpIngoingDate.Text.Length > 0)
            ingoingDate = DateTime.Parse(dtpIngoingDate.Text);

        DateTime? moveOutDate = null;
        if (dtpMoveOutDate.Text.Length > 0)
            moveOutDate = DateTime.Parse(dtpMoveOutDate.Text);

        int id = int.Parse(hiddenID.Text);
        FineOffice.Modules.CNS_CensusMember model = memberBll.GetModel(d => d.ID == id);

        model.Address = txtAddress.Text.Trim();
        model.Brithday = brithday;
        model.CancelDate = cancelDate;
        model.CancelReason = txtCancelReason.Text.Trim();
        model.Company = txtCompany.Text.Trim();
        model.EducationID = int.Parse(ddlEducation.SelectedValue);
        model.Height = txtHeight.Text.Trim();
        model.IDCard = txtIDCard.Text.Trim();
        model.IngoingDate = ingoingDate;
        model.IngoingReason = txtIngoingReason.Text.Trim();
        model.IsCanceled = chkIsCanceled.Checked;
        model.Marriage = txtMarriage.Text.Trim();
        model.MilitaryService = txtMilitaryService.Text.Trim();
        model.MoveOutDate = moveOutDate;
        model.MoveToAddress = txtMoveToAddress.Text.Trim();
        model.Name = txtName.Text.Trim();
        model.Nationalilty = txtNationalilty.Text.Trim();
        model.Occupation = txtOccupation.Text.Trim();
        model.PoliticalID = int.Parse(ddlPolitical.SelectedValue);
        model.TypeOfBlood = txtTypeOfBlood.Text.Trim();
        model.Tel = txtTel.Text.Trim();
        model.Sex = short.Parse(ddlSex.SelectedValue);
        model.Religion = txtReligion.Text.Trim();
        model.OtherName = txtOtherName.Text.Trim();
        model.Relation = ddlRelation.SelectedText;
        model.PreviousAddress = txtPreviousAddress.Text.Trim();
        model.PlaceOfAncestral = txtPlaceOfAncestral.Text.Trim();
        model.PlaceOfBirth = txtPlaceOfBirth.Text.Trim();
        model.RegisterNO = txtRegisterNO.Text.Trim();
        memberBll.Update(model);
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("member_close"));
    }
}
