using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineOffice.Web;

public partial class _Default : PageBase
{
    FineOffice.BLL.SYS_User userBll = new FineOffice.BLL.SYS_User();
    FineOffice.BLL.HR_Personnel personnelBll = new FineOffice.BLL.HR_Personnel();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitCaptchaCode();
        }
    }

    /// <summary>
    /// 初始化验证码
    /// </summary>
    private void InitCaptchaCode()
    {
        imgCaptcha.ImageUrl = "~/CreateValidate.aspx?w=70&h=25&t=" + DateTime.Now.Ticks;
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        InitCaptchaCode();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        btnLogin.Visible = false;
        string valiString = txtCaptcha.Text.Trim();
        FineOffice.Modules.SYS_User model = new FineOffice.Modules.SYS_User();
        model.UserName = txtUserName.Text.Trim();
        model.Password = this.txtPassword.Text.Trim();

        if (HttpContext.Current.Session["IdentifyingCode"] == null)
        {
            lblValrUser.Text = "验证码异常，请重新输入！";
            InitCaptchaCode();
            return;
        }
        if (String.Compare(HttpContext.Current.Session["IdentifyingCode"].ToString(), valiString, true) != 0)
        {
            lblValrUser.Text = "验证码错误！";
            return;
        }
        string pwd = FineOffice.Common.DEncrypt.DESEncrypt.Encrypt(model.Password);
        FineOffice.Modules.SYS_User temp = userBll.GetModel(u => u.UserName == model.UserName && u.Password == pwd);
        if (temp == null)
        {
            lblValrUser.Text = "用户名或密码错误！";
            btnLogin.Visible = true;
            return;
        }
        else
        {
            this.CookieUser = temp;          
            this.SessionMenuList = this.GetMenuList(temp);
            this.SessionAuthorityList = this.GetAuthorityList(temp);           

            FineOffice.Modules.HR_Personnel personnel = personnelBll.GetModel(p => p.ID == temp.PersonnelID);
            this.CookiePersonnel = personnel;
            Response.Redirect("Main.aspx");
        }
    }
}