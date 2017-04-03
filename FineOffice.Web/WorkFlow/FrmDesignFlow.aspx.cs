using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Xml.Linq;
using System.Xml;
using System.Text;
using FineOffice.Modules.Helper;
using FineOffice.Web;

public partial class WorkFlow_FrmDesignFlow : PageBase
{
    FineOffice.BLL.OA_Flow flowBll = new FineOffice.BLL.OA_Flow();
    public FineOffice.Modules.OA_Flow model = new FineOffice.Modules.OA_Flow();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["ID"] != null)
            {
                int id = int.Parse(Request["ID"].ToString());
                txtID.Text = id.ToString();
                model = flowBll.GetModel(d => d.ID == id);
                txtXML.Text = model.XML;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string xml = txtXML.Text.Trim();
        model = flowBll.GetModel(f => f.ID == int.Parse(txtID.Text));
        model.XML = xml;

        if (xml.Length > 0)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            ChangeTrackingList<FineOffice.Modules.OA_FlowProcess> list = new ChangeTrackingList<FineOffice.Modules.OA_FlowProcess>();

            XmlNodeList processNodes = xmlDoc.SelectNodes("/process");
            int flowID = int.Parse(processNodes[0].Attributes["ID"].Value);

            XmlNodeList startNodes = xmlDoc.SelectNodes("/process/start");

            //开始节点
            if (startNodes.Count > 0)
            {
                FineOffice.Modules.OA_FlowProcess process = new FineOffice.Modules.OA_FlowProcess();
                process.ID = startNodes[0].Attributes["id"].Value;
                process.ProcessName = startNodes[0].Attributes["name"].Value;
                process.Remark = startNodes[0].Attributes["Remark"].Value;
                process.IsStart = true;
                process.IsEnd = false;
                process.FlowID = flowID;              

                XmlNodeList toNodes = xmlDoc.SelectNodes("/process/start/transition");
                StringBuilder next = new StringBuilder();
                foreach (XmlNode node in toNodes)
                {
                    next.Append(node.Attributes["to"].Value);
                    next.Append(",");
                }
                process.Next = next.ToString();
                list.Add(process);
            }

            XmlNodeList endNodes = xmlDoc.SelectNodes("/process/end");
            foreach (XmlNode node in endNodes)
            {
                FineOffice.Modules.OA_FlowProcess process = new FineOffice.Modules.OA_FlowProcess();
                process.ID = node.Attributes["id"].Value;
                process.ProcessName = node.Attributes["name"].Value;
                process.Remark = node.Attributes["Remark"].Value;
                process.IsEnd = true;
                process.IsStart = false;
                process.FlowID = flowID;
                list.Add(process);
            }

            XmlNodeList taskNodes = xmlDoc.SelectNodes("/process/task");
            foreach (XmlNode node in taskNodes)
            {
                FineOffice.Modules.OA_FlowProcess process = new FineOffice.Modules.OA_FlowProcess();
                process.ID = node.Attributes["id"].Value;
                process.ProcessName = node.Attributes["name"].Value;
                process.Remark = node.Attributes["Remark"].Value;
                process.FlowID = flowID;
                process.IsEnd = false;
                process.IsStart = false;

                XmlNodeList toNodes = xmlDoc.SelectNodes("/process/task/transition");
                StringBuilder next = new StringBuilder();
                foreach (XmlNode toNode in toNodes)
                {
                    next.Append(toNode.Attributes["to"].Value);
                    next.Append(",");
                }
                process.Next = next.ToString();
                list.Add(process);
            }
            model.OA_FlowProcessList = list;
        }
        try
        {
            flowBll.UpdateProcess(model);
            FineUI.Alert.ShowInParent("已保存到服务器！");
        }
        catch (Exception ex)
        {
            FineUI.Alert.ShowInParent(ex.Message);
        }
    }
}