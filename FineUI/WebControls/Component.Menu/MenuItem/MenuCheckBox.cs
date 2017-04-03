
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    MenuCheckBox.cs
 * CreatedOn:   2012-11-09
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design.WebControls;

using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

namespace FineUI
{
    /// <summary>
    /// 菜单项复选框控件（单选框）
    /// </summary>
    [Designer("FineUI.Design.MenuCheckBoxDesigner, FineUI.Design")]
    [ToolboxData("<{0}:MenuCheckBox runat=\"server\"></{0}:MenuCheckBox>")]
    [ToolboxBitmap(typeof(MenuCheckBox), "res.toolbox.MenuCheckBox.bmp")]
    [Description("菜单项复选框控件（单选框）")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    [DefaultEvent("Click")]
    public class MenuCheckBox : MenuItem, IPostBackDataHandler
    {
        #region Constructor

        public MenuCheckBox()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("Checked");
        }

        #endregion

        #region Properties

        /// <summary>
        /// 分组名（如果指定分组名，则此控件被渲染为单选框）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("分组名（如果指定分组名，则此控件被渲染为单选框）")]
        public string GroupName
        {
            get
            {
                object obj = XState["GroupName"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["GroupName"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]是否选中
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("[AJAX属性]是否选中")]
        public bool Checked
        {
            get
            {
                object obj = XState["Checked"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["Checked"] = value;
            }
        }

        /// <summary>
        /// 是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动回发")]
        public bool AutoPostBack
        {
            get
            {
                object obj = XState["AutoPostBack"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["AutoPostBack"] = value;
            }
        }

        #endregion

        #region CheckedHiddenFieldID


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected string CheckedHiddenFieldID
        {
            get
            {
                return String.Format("{0}_Checked", ClientID);
            }
        }

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("Checked"))
            {
                sb.AppendFormat("{0}.x_setChecked();", XID);
            }


            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            #region options

            OB.AddProperty("checked", Checked);

            if (!String.IsNullOrEmpty(GroupName))
            {
                OB.AddProperty("group", GroupName);
            }

            #endregion

            #region AutoPostBack

            string checkScript = String.Empty;
            if (!String.IsNullOrEmpty(GroupName))
            {
                checkScript = "if(X.util.checkGroupLastTime('" + GroupName + "')){" + GetPostBackEventReference() + "}";
            }
            else
            {
                checkScript = GetPostBackEventReference();
            }

            OB.Listeners.AddProperty("checkchange", JsHelper.GetFunction(checkScript), true);

            #endregion

            string jsContent = String.Format("var {0}=new Ext.menu.CheckItem({1});", XID, OB.ToString());
            AddStartupScript(jsContent);

        }

        #endregion

        #region IPostBackDataHandler

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            bool postChecked = Convert.ToBoolean(postCollection[CheckedHiddenFieldID]);
            if (Checked != postChecked)
            {
                Checked = postChecked;
                XState.BackupPostDataProperty("Checked");
                return true;
            }

            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            OnCheckedChanged(EventArgs.Empty);
        }

        #endregion

        #region OnCheckedChanged

        private object _handlerKey = new object();

        /// <summary>
        /// 复选框状态改变事件（需要启用AutoPostBack）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("复选框状态改变事件（需要启用AutoPostBack）")]
        public event EventHandler CheckedChanged
        {
            add
            {
                Events.AddHandler(_handlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_handlerKey, value);
            }
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

    }
}
