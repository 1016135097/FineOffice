using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Letter_FrmWriteLetter : PageBase
{
    FineOffice.BLL.HR_Personnel personnelBll = new FineOffice.BLL.HR_Personnel();
    FineOffice.BLL.HR_Department departmentBll = new FineOffice.BLL.HR_Department();
    FineOffice.BLL.ADM_LetterChannel chanelBll = new FineOffice.BLL.ADM_LetterChannel();
    FineOffice.BLL.ADM_LetterType typeBll = new FineOffice.BLL.ADM_LetterType();
    FineOffice.BLL.ADM_Letter letterBll = new FineOffice.BLL.ADM_Letter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            btnClose.OnClientClick = string.Format("parent.closeTabWindow('{0}');", this.hiddenTabID.Text);
            if (Request["Write"] == null)
            {
                hiddenWrite.Text = "new";               
            }
            else
            {
                int id = int.Parse(Request["ID"]);
                hiddenTabID.Text = this._FrmWriteLetter.ID + id;
                FineOffice.Modules.ADM_Letter model = letterBll.GetModel(t => t.ID == id);
                InitModule(model);
            }           
        }
    }

    private void InitModule(FineOffice.Modules.ADM_Letter model)
    {
        hiddenWrite.Text = "modify";
        hiddenID.Text = model.ID.ToString();
        txtAddress.Text = model.Address;
        txtAge.Text = model.Age.ToString();
        txtArea.Text = model.Area;
        if (model.ChannelID != null)
            ddlChannel.SelectedValue = model.ChannelID.ToString();
        txtEmail.Text = model.Email;
        if (model.HandleDepartmentID != null)
        {
            ddlHandleDepartment.SelectedValue = model.HandleDepartmentID.ToString();
            ddlHandleDepartment_SelectedIndexChanged(null, null);
            ddlHandler.SelectedValue = model.Handler.ToString();
        }
        if (model.ReceiveDepartmentID != null)
        {
            ddlReceiveDepartment.SelectedValue = model.ReceiveDepartmentID.ToString();
            ddlReceiveDepartment_SelectedIndexChanged(null, null);
            ddlReceiver.SelectedValue = model.Receiver.ToString();
        }
        txtIDCard.Text = model.IDCard;
        txtLetterNO.Text = model.LetterNO;
        if (model.TypeID != null)
        {
            ddlType.SelectedValue = model.TypeID.ToString();
        }
        dtpDate.Text = string.Format("{0:yyyy-MM-dd}", model.VisitTime);
        dtpTime.Text = string.Format("{0:HH:mm}", model.VisitTime);
        txtTransmitAdvice.Text = model.Matter;
        txtMobile.Text = model.Mobile;
        if (model.NumberOfpeople != null)
        {
            txtNumberOfpeople.Text = model.NumberOfpeople.ToString();
        }
        txtOccupation.Text = model.Occupation;
        txtRecorder.Text = model.RecorderName;
        txtRecordTime.Text = string.Format("{0:yyyy-MM-dd HH:mm}", model.RecordTime);
        txtRemark.Text = model.Remark;
        ddlSex.SelectedValue = model.Sex.ToString();
        txtTel.Text = model.Tel;
        txtTitle.Text = model.Title;
        txtVisitor.Text = model.Visitor;
    }

    private void LoadData()
    {
        #region 部门员工
        List<FineOffice.Modules.HR_Department> departmentList = departmentBll.GetListAll();
        ddlHandleDepartment.Items.Clear();
        ddlReceiveDepartment.Items.Clear();
        ddlHandleDepartment.Items.Add("<请选择>", "");
        ddlReceiveDepartment.Items.Add("<请选择>", "");
        foreach (FineOffice.Modules.HR_Department dep in departmentList)
        {
            ddlReceiveDepartment.Items.Add(dep.DepartmentName, dep.ID.ToString());
            ddlHandleDepartment.Items.Add(dep.DepartmentName, dep.ID.ToString());
        }
        ddlReceiver.Items.Add("<请选择>", "");
        ddlHandler.Items.Add("<请选择>", "");
        #endregion

        #region 渠道
        List<FineOffice.Modules.ADM_LetterChannel> channelList = chanelBll.GetListAll();
        ddlChannel.Items.Add("<请选择>", "");
        foreach (FineOffice.Modules.ADM_LetterChannel channel in channelList)
        {
            ddlChannel.Items.Add(channel.Channel, channel.ID.ToString());
        }
        #endregion

        #region 问题分类
        List<FineOffice.Modules.ADM_LetterType> typeList = typeBll.GetListAll();
        ddlType.Items.Add("<请选择>", "");
        foreach (FineOffice.Modules.ADM_LetterType type in typeList)
        {
            ddlType.Items.Add(type.LetterType, type.ID.ToString());
        }
        #endregion

        txtRecorder.Text = this.CookiePersonnel.Name;
        dtpDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
        dtpTime.Text = string.Format("{0:HH:mm}", DateTime.Now);
    }

    protected void ddlReceiveDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReceiveDepartment.SelectedIndex == 0)
        {
            ddlReceiver.Items.Clear();
            ddlReceiver.Items.Add("<请选择>", "");
        }
        else
        {
            int departmentID = int.Parse(ddlReceiveDepartment.SelectedValue);
            List<FineOffice.Modules.HR_Personnel> personnelList = personnelBll.GetList(p => p.DepartmentID == departmentID);
            ddlReceiver.Items.Clear();
            ddlReceiver.Items.Add("<请选择>", "");
            foreach (FineOffice.Modules.HR_Personnel person in personnelList)
            {
                ddlReceiver.Items.Add(person.Name, person.ID.ToString());
            }
            ddlReceiver.SelectedIndex = 0;
        }
    }

    protected void ddlHandleDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHandleDepartment.SelectedIndex == 0)
        {
            ddlHandler.Items.Clear();
            ddlHandler.Items.Add("<请选择>", "");
        }
        else
        {
            int departmentID = int.Parse(ddlHandleDepartment.SelectedValue);
            List<FineOffice.Modules.HR_Personnel> personnelList = personnelBll.GetList(p => p.DepartmentID == departmentID);
            ddlHandler.Items.Clear();
            ddlHandler.Items.Add("<请选择>", "");
            foreach (FineOffice.Modules.HR_Personnel person in personnelList)
            {
                ddlHandler.Items.Add(person.Name, person.ID.ToString());
            }
            ddlHandler.SelectedIndex = 0;
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {        
        if (hiddenWrite.Text.Equals("modify"))
        {
            int letterID = int.Parse(hiddenID.Text);
            FineOffice.Modules.ADM_Letter model = letterBll.GetModel(t => t.ID == letterID);
            InitModule(model);
        }
        else
        {
            txtAddress.Text = "";
            txtAge.Text = "";
            txtArea.Text = "";
            ddlChannel.SelectedIndex = 0;
            txtEmail.Text = "";
            ddlHandler.SelectedIndex = 0;
            txtIDCard.Text = "";
            txtLetterNO.Text = "";
            ddlType.SelectedIndex = 0;
            dtpDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
            dtpTime.Text = string.Format("{0:HH:mm}", DateTime.Now);
            txtTransmitAdvice.Text = "";
            txtMobile.Text = "";
            txtNumberOfpeople.Text = "";
            txtOccupation.Text = "";
            ddlReceiver.SelectedIndex = 0;
            txtRemark.Text = "";
            ddlSex.SelectedIndex = 0;
            txtTel.Text = "";
            txtTitle.Text = "";
            txtVisitor.Text = "";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.CookiePersonnel == null)
        {
            Alert.ShowInParent("当前用户不存在职员信息！");
            return;
        }
        FineOffice.Modules.ADM_Letter model = new FineOffice.Modules.ADM_Letter();
        bool modify = false;
        if (hiddenWrite.Text.Equals("modify"))
        {
            int letterID = int.Parse(hiddenID.Text);
            model = letterBll.GetModel(t => t.ID == letterID);
            modify = true;
        }
        model.Address = txtAddress.Text.Trim();
        if (txtAge.Text.Length > 0)
            model.Age = int.Parse(txtAge.Text);
        else
            model.Age = null;

        model.Area = txtArea.Text.Trim();
        if (ddlChannel.SelectedIndex > 0)
        {
            model.ChannelID = int.Parse(ddlChannel.SelectedValue);
        }
        else
        {
            model.ChannelID = null;
        }
        model.Email = txtEmail.Text.Trim();
        if (ddlHandler.SelectedIndex > 0)
        {
            model.Handler = int.Parse(ddlHandler.SelectedValue);
        }
        else
        {
            model.Handler = null;
        }
        model.IDCard = txtIDCard.Text.Trim();
        model.LetterNO = txtLetterNO.Text.Trim();
        if (ddlType.SelectedIndex > 0)
        {
            model.TypeID = int.Parse(ddlType.SelectedValue);
        }
        else
        {
            model.TypeID = null;
        }
        model.VisitTime = DateTime.Parse(dtpDate.Text + " " + dtpTime.Text);
        model.Matter = txtTransmitAdvice.Text.Trim();
        model.Mobile = txtMobile.Text.Trim();
        if (txtNumberOfpeople.Text.Length > 0)
        {
            model.NumberOfpeople = int.Parse(txtNumberOfpeople.Text);
        }
        else
        {
            model.NumberOfpeople = null;
        }
        model.Occupation = txtOccupation.Text.Trim();
        if (ddlReceiver.SelectedIndex > 0)
        {
            model.Receiver = int.Parse(ddlReceiver.SelectedValue);
        }
        else
        {
            model.Receiver = null;
        }

        model.Recorder = this.CookiePersonnel.ID;
        model.RecordTime = DateTime.Now;
        model.Remark = txtRemark.Text.Trim();
        model.Sex = short.Parse(ddlSex.SelectedValue);
        model.Tel = txtTel.Text.Trim();
        model.Title = txtTitle.Text.Trim();
        model.Visitor = txtVisitor.Text.Trim();

        try
        {
            if (modify)
                model = letterBll.Update(model);
            else
                model = letterBll.Add(model);
               
            InitModule(model);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }
}
