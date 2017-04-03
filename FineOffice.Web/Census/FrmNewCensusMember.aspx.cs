using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Census_FrmNewCensusMember : PageBase
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
        txtRegisterNO.Text = Request["RegisterNO"];

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

        FineOffice.Modules.CNS_CensusMember model = new FineOffice.Modules.CNS_CensusMember
        {
            Address = txtAddress.Text.Trim(),
            Brithday = brithday,
            CancelDate = cancelDate,
            CancelReason = txtCancelReason.Text.Trim(),
            Company = txtCompany.Text.Trim(),
            EducationID = int.Parse(ddlEducation.SelectedValue),
            Height = txtHeight.Text.Trim(),
            IDCard = txtIDCard.Text.Trim(),
            IngoingDate = ingoingDate,
            IngoingReason = txtIngoingReason.Text.Trim(),
            IsCanceled = chkIsCanceled.Checked,
            Marriage = txtMarriage.Text.Trim(),
            MilitaryService = txtMilitaryService.Text.Trim(),
            MoveOutDate = moveOutDate,
            MoveToAddress = txtMoveToAddress.Text.Trim(),
            Name = txtName.Text.Trim(),
            Nationalilty = txtNationalilty.Text.Trim(),
            Occupation = txtOccupation.Text.Trim(),
            PoliticalID = int.Parse(ddlPolitical.SelectedValue),
            TypeOfBlood = txtTypeOfBlood.Text.Trim(),
            Tel = txtTel.Text.Trim(),
            Sex = short.Parse(ddlSex.SelectedValue),
            Religion = txtReligion.Text.Trim(),
            OtherName = txtOtherName.Text.Trim(),
            Relation = ddlRelation.SelectedText,
            PreviousAddress = txtPreviousAddress.Text.Trim(),
            PlaceOfAncestral = txtPlaceOfAncestral.Text.Trim(),
            PlaceOfBirth = txtPlaceOfBirth.Text.Trim(),
            RegisterNO = txtRegisterNO.Text.Trim(),
        };
        memberBll.Add(model);
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("member_close"));
    }
}
