using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FineUI;
using FineOffice.Common;
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression;
using FineOffice.Common.SerializeHelper;

namespace FineOffice.Web
{
    public class PageBase : System.Web.UI.Page
    {
        FineOffice.BLL.SYS_Role roleBll = new FineOffice.BLL.SYS_Role();
        FineOffice.BLL.SYS_MenuList menuBll = new FineOffice.BLL.SYS_MenuList();
        FineOffice.BLL.SYS_PageAuthority authorityBll = new FineOffice.BLL.SYS_PageAuthority();

        List<string> controlList = new List<string>();
        FineOffice.Modules.SYS_MenuList currentMenu = new Modules.SYS_MenuList();

        #region 页面初始化
        protected override void OnInit(EventArgs e)
        {
            WebPageAuthority webPageAuthority = this.FindControl("pageAuthority") as WebPageAuthority;
            if (webPageAuthority != null)  //权限控制
            {
                controlList = this.JsonToList<string>(webPageAuthority.PageAuthority);
                string currentForm = this.Form.ID;
                currentMenu = this.SessionMenuList.Where(m => m.TabID == currentForm).FirstOrDefault();
                CheckPowerEdit(this.Form.Controls);
            }
            base.OnInit(e);
        }

        /// <summary>
        /// 获取当前页面上所有的权限按钮
        /// </summary>
        private void CheckPowerEdit(ControlCollection controls)
        {
            for (int i = 0; i < controls.Count; i++)
            {
                ControlBase ctrl = controls[i] as ControlBase;
                if (ctrl == null)
                    continue;
                if (ctrl is FineUI.Grid)
                {
                    #region Grid的权限控制
                    FineUI.Grid grid = ctrl as FineUI.Grid;
                    foreach (GridColumn column in grid.Columns)
                    {
                        if (!controlList.Contains(column.ColumnID))
                            continue;

                        Modules.SYS_PageAuthority auth = SessionAuthorityList.Where(a => a.MenuID == currentMenu.ID && a.ControlID == column.ColumnID).FirstOrDefault();
                        if (auth == null)
                        {
                            if (column is LinkButtonField)
                            {
                                LinkButtonField c = (LinkButtonField)column;
                                c.Enabled = false;
                                c.ToolTip = Resources.Resource.CHECK_POWER_FAIL_ACTION_MESSAGE;
                            }
                            else if (column is WindowField)
                            {
                                WindowField c = (WindowField)column;
                                c.Enabled = false;
                                c.ToolTip = Resources.Resource.CHECK_POWER_FAIL_ACTION_MESSAGE;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region 其他控件的权限控制
                    if (controlList.Contains(ctrl.ID) && !IsPostBack)
                    {
                        Modules.SYS_PageAuthority auth = SessionAuthorityList.Where(a => a.MenuID == currentMenu.ID && a.ControlID == ctrl.ID).FirstOrDefault();
                        if (auth == null)
                            ctrl.Enabled = false;
                    }
                    CheckPowerEdit(ctrl.Controls);
                    #endregion
                }
            }
        }

        #endregion

        #region 页面的公共方法

        /// <summary>
        /// Json转字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<T> JsonToList<T>(string str)
        {
            JArray idsArray = new JArray();
            if (!String.IsNullOrEmpty(str))
                idsArray = JArray.Parse(str);
            return new List<T>(idsArray.ToObject<List<T>>());
        }

        /// <summary>
        /// List<string>转Json字符串
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public string ListToJson<T>(List<T> ids)
        {
            return new JArray(ids).ToString(Newtonsoft.Json.Formatting.None);
        }

        /// <summary>
        /// json转byte
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public byte[] JsonTobyte(string str)
        {
            JArray idsArray = new JArray();
            if (!String.IsNullOrEmpty(str))
                idsArray = JArray.Parse(str);
            List<byte> list = idsArray.ToObject<List<byte>>();
            return list.ToArray();
        }

        /// <summary>
        /// btye[]转字符串
        /// </summary>
        /// <param name="byt"></param>
        /// <returns></returns>
        public string ByteToJson(byte[] byt)
        {
            List<byte> list = byt.ToList();
            return new JArray(list).ToString(Newtonsoft.Json.Formatting.None);
        }

        /// <summary>
        /// 下载文件方法
        /// </summary>
        /// <param name="data">二进制流</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileType">后缀后</param>
        protected virtual void OutputStream(byte[] data, string fileName, string fileType)
        {
            byte[] attachment = SharpZipLib.DeCompress(data);
            FineOffice.Web.FileTypeHelper typeHelper = new FineOffice.Web.FileTypeHelper();
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "utf-8";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + typeHelper.ToHexString(fileName + "." + fileType));
            Response.AddHeader("Content-Length", attachment.Length.ToString());
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.OutputStream.Write(attachment, 0, attachment.Length);
            Response.Flush();
        }

        #endregion

        #region 压缩ViewState
        protected override void SavePageStateToPersistenceMedium(Object pViewState)
        {
            Pair pair;
            object viewState;
            PageStatePersister persister = this.PageStatePersister;
            if (pViewState is Pair)
            {
                pair = (Pair)pViewState;
                persister.ControlState = pair.First;
                viewState = pair.Second;
            }
            else
            {
                viewState = pViewState;
            }
            persister.ViewState = VeiwStateSerialize.Serialize(viewState);
            persister.Save();
        }

        protected override Object LoadPageStateFromPersistenceMedium()
        {
            PageStatePersister persister = this.PageStatePersister;
            persister.Load();
            string viewState = persister.ViewState.ToString();
            return new Pair(persister.ControlState, VeiwStateSerialize.Deserialize(viewState));
        }
        #endregion

        #region 取脚本相关操作
        /// <summary>
        /// 取客户端的ID
        /// </summary>
        protected JObject GetClientIDS(params ControlBase[] ctrls)
        {
            JObject jo = new JObject();
            foreach (ControlBase ctrl in ctrls)
            {
                jo.Add(ctrl.ID, ctrl.ClientID);
            }
            return jo;
        }
        #endregion

        #region 获取菜单和权限

        /// <summary>
        /// 取出用户的菜单
        /// </summary>
        protected List<FineOffice.Modules.SYS_MenuList> GetMenuList(FineOffice.Modules.SYS_User user)
        {
            List<int> roleIDs = this.JsonToList<int>(user.RoleList);
            List<FineOffice.Modules.SYS_Role> roleList = roleBll.GetList(r => roleIDs.Contains(r.ID));

            List<int> menuIDs = new List<int>();
            foreach (FineOffice.Modules.SYS_Role temp in roleList)
            {
                List<int> tempIDs = this.JsonToList<int>(temp.MenuList);
                menuIDs.AddRange(tempIDs);
            }
            return menuBll.GetList(m => menuIDs.Contains(m.ID));
        }

        /// <summary>
        /// 取出用户的页面权限
        /// </summary>
        protected List<FineOffice.Modules.SYS_PageAuthority> GetAuthorityList(FineOffice.Modules.SYS_User user)
        {
            List<int> roleIDs = this.JsonToList<int>(user.RoleList);
            List<FineOffice.Modules.SYS_Role> roleList = roleBll.GetList(r => roleIDs.Contains(r.ID));

            List<int> authorityIDs = new List<int>();
            foreach (FineOffice.Modules.SYS_Role role in roleList)
            {
                List<int> tempIDs = this.JsonToList<int>(role.AuthorityList);
                authorityIDs.AddRange(tempIDs);
            }
            return authorityBll.GetList(m => authorityIDs.Contains(m.ID));
        }

        /// <summary>
        /// 取出用户的菜单
        /// </summary>
        public List<FineOffice.Modules.SYS_MenuList> SessionMenuList
        {
            get
            {
                List<FineOffice.Modules.SYS_MenuList> list = Session["MenuList"] as List<FineOffice.Modules.SYS_MenuList>;
                if (list != null)
                    return list;

                list = GetMenuList(CookieUser);
                Session["MenuList"] = GetMenuList(CookieUser);
                return list;
            }
            set
            {
                Session["MenuList"] = value;
            }
        }

        /// <summary>
        /// 取出用户的页面权限
        /// </summary>
        public List<FineOffice.Modules.SYS_PageAuthority> SessionAuthorityList
        {
            get
            {
                List<FineOffice.Modules.SYS_PageAuthority> list = Session["AuthorityList"] as List<FineOffice.Modules.SYS_PageAuthority>;
                if (list != null)
                    return list;

                list = GetAuthorityList(CookieUser);
                Session["AuthorityList"] = GetMenuList(CookieUser);
                return list;
            }
            set
            {
                Session["AuthorityList"] = value;
            }
        }

        /// <summary>
        /// 获取当前登录的用户信息
        /// </summary>
        public FineOffice.Modules.SYS_User CookieUser
        {
            get
            {
                FineOffice.Modules.SYS_User user = null;
                if (Request.Cookies["User"] != null)
                    user = VeiwStateSerialize.Deserialize(Request.Cookies["User"].Value) as FineOffice.Modules.SYS_User;
                return user;
            }
            set
            {
                HttpCookie cookies = Request.Cookies["User"];
                if (cookies == null)
                    cookies = new HttpCookie("User");
                if (value != null)
                    cookies.Value = VeiwStateSerialize.Serialize(value);
                else
                    cookies.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookies);
            }
        }

        /// <summary>
        /// 获取当前登录的员工信息
        /// </summary>
        public FineOffice.Modules.HR_Personnel CookiePersonnel
        {
            get
            {
                FineOffice.Modules.HR_Personnel person = null;
                if (Request.Cookies["Personnel"] != null)
                    person = VeiwStateSerialize.Deserialize(Request.Cookies["Personnel"].Value) as FineOffice.Modules.HR_Personnel;
                return person;
            }
            set
            {
                HttpCookie cookies = Request.Cookies["Personnel"];
                if (cookies == null)
                    cookies = new HttpCookie("Personnel");
                if (value != null)
                    cookies.Value = VeiwStateSerialize.Serialize(value);
                else
                    cookies.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookies);
            }
        }
        #endregion

        public string GetPathUri()
        {
            string url = "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + Request.ServerVariables["PATH_INFO"].ToString();  //获得URL的值            
            url = url.Substring(0, url.LastIndexOf("/"));
            return url;
        }

        public string GetServerUri()
        {
            return "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + ResolveUrl("~/");  //获得URL的值 
        }
    }
}