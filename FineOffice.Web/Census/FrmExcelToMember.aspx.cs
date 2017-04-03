using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Reflection;
using FineOffice.Common.Tool;
using FineOffice.Common.Excel;

public partial class Census_FrmExcelToMember : PageBase
{
    FineOffice.BLL.CNS_PoliticalAffiliation politicalBll = new FineOffice.BLL.CNS_PoliticalAffiliation();
    FineOffice.BLL.CNS_CensusMember memberBll = new FineOffice.BLL.CNS_CensusMember();
    FineOffice.BLL.CNS_CensusType typeBll = new FineOffice.BLL.CNS_CensusType();
    FineOffice.BLL.CNS_CensusRegister registerBll = new FineOffice.BLL.CNS_CensusRegister();
    FineOffice.BLL.AM_Kind kindBll = new FineOffice.BLL.AM_Kind();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }
    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        try
        {
            if (uploadFile.HasFile)
            {
                HttpPostedFile excel = uploadFile.PostedFile;
                Stream fileStream = excel.InputStream;

                FineOffice.Web.WebExcelHelper excelHelper = new FineOffice.Web.WebExcelHelper();

                FineOffice.Common.Excel.ExcelHelper toExcel = new FineOffice.Common.Excel.ExcelHelper();
                string serverPath = Server.MapPath("~/Config/Template/CNS_CensusMember.xml");
                List<ExcelHeader> headerList = toExcel.GetHeaderList(serverPath);

                List<FineOffice.Modules.CNS_CensusMember> list = toExcel.Import<FineOffice.Modules.CNS_CensusMember>(fileStream, 0, 0, headerList);
                fileStream.Close();
                uploadFile.Reset();

                gridMember.DataSource = list;
                gridMember.DataBind();
            }
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    /// <summary>
    /// 保存导入数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Common.Excel.ExcelHelper toExcel = new FineOffice.Common.Excel.ExcelHelper();
        FineOffice.Web.WebExcelHelper excelHelper = new FineOffice.Web.WebExcelHelper();
        string serverPath = Server.MapPath("~/Config/Template/CNS_CensusMember.xml");
        List<ExcelHeader> headerList = toExcel.GetHeaderList(serverPath);
        try
        {
            foreach (GridRow row in gridMember.Rows)
            {
                gridMember.SelectedRowIndex = row.RowIndex;
                Dictionary<string, object> valueMap = new Dictionary<string, object>();
                foreach (GridColumn column in gridMember.Columns)
                {
                    FineUI.BoundField field = column as FineUI.BoundField;
                    string value = row.Values[column.ColumnIndex].ToString();
                    if (field != null)
                        valueMap.Add(field.DataField, value);
                }
                FineOffice.Modules.CNS_CensusMember model = toExcel.Create<FineOffice.Modules.CNS_CensusMember>(headerList, valueMap);
                FineOffice.Modules.CNS_CensusRegister register = registerBll.GetModel(m => m.RegisterNO == model.RegisterNO);
                if (register == null)
                {
                    register = new FineOffice.Modules.CNS_CensusRegister();
                    register.RegisterNO = model.RegisterNO;
                    register.HouseHolder = model.HouseHolder;
                    FineOffice.Modules.CNS_CensusType type = typeBll.GetModel(t => t.CensusTypeName == model.CensusTypeName);
                    if (type == null)
                    {
                        type = new FineOffice.Modules.CNS_CensusType();
                        type.CensusTypeName = model.CensusTypeName;
                        type = typeBll.Add(type);
                    }
                    register.CensusTypeID = type.ID;
                    registerBll.Add(register);
                }
                if (model.Gender == "男")                
                    model.Sex = 1;
                else
                    model.Sex = 0;

                FineOffice.Modules.CNS_PoliticalAffiliation political = politicalBll.GetModel(m => m.Political == model.Political);
                if (political == null)
                {
                    political = new FineOffice.Modules.CNS_PoliticalAffiliation();
                    political.Political = model.Political;
                    political = politicalBll.Add(political);
                }
                model.PoliticalID = political.ID;

                FineOffice.Modules.AM_Kind kind = kindBll.GetModel(m => m.Name == model.Education);
                if (kind != null)
                {
                    model.EducationID = kind.ID;
                }
                memberBll.Add(model);
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("member_close"));
        }
        catch (Exception ex)
        {
            FineUI.Alert.ShowInParent(ex.Message);
        }
    }
}
