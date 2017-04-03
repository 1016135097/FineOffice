using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_FrmAwardRole : PageBase
{
    FineOffice.BLL.SYS_User userBll = new FineOffice.BLL.SYS_User();
    FineOffice.BLL.SYS_Role roleBll = new FineOffice.BLL.SYS_Role();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();

            List<FineOffice.Modules.SYS_Role> list = roleBll.GetListAll();
            chkRole.DataSource = list;
            chkRole.DataTextField = "RoleName";
            chkRole.DataValueField = "ID";
            chkRole.DataBind();

            InitModule();
        }
    }

    private void InitModule()
    {
        int id = int.Parse(Request["id"]);
        FineOffice.Modules.SYS_User model = userBll.GetModel(d => d.ID == id);
        hiddenID.Text = id.ToString();

        List<int> ids = this.JsonToList<int>(model.RoleList);
        List<string> strIDs = new List<string>();
        foreach (int i in ids)
        {
            strIDs.Add(i.ToString());
        }
        string [] selectArray=strIDs.ToArray();
        chkRole.SelectedValueArray = selectArray;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenID.Text);
        FineOffice.Modules.SYS_User model = userBll.GetModel(d => d.ID == id);
        if (!model.IsModify.Value)
        {
            Alert.ShowInParent(string.Format("用户账号：{0}，不允许修改！",model.UserName ));
            return;
        }
        model.Password = FineOffice.Common.DEncrypt.DESEncrypt.Decrypt(model.Password);
        string[] strIDs = chkRole.SelectedValueArray;
        List<int> ids = new List<int>();
        foreach (string s in strIDs)
        {
            ids.Add(int.Parse(s));
        }
        model.RoleList = ListToJson(ids.ToList());
        try
        {
            userBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(string.Format("错误信息：{0}", ex.Message));
        }
    }
}
