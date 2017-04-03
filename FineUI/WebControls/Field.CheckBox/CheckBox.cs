
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    CheckBox.cs
 * CreatedOn:   2008-04-23
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

namespace FineUI
{
    /// <summary>
    /// 复选框控件
    /// </summary>
    [Designer("FineUI.Design.CheckBoxDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CheckBox Label=\"Label\" Text=\"CheckBox\" runat=\"server\"></{0}:CheckBox>")]
    [ToolboxBitmap(typeof(CheckBox), "res.toolbox.CheckBox.bmp")]
    [DefaultEvent("CheckedChanged")]
    [Description("复选框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class CheckBox : Field, IPostBackDataHandler
    {
        #region Constructor

        public CheckBox()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("Checked");
        }

        #endregion

        #region Properties

        /// <summary>
        /// 文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("文本")]
        public virtual string Text
        {
            get
            {
                object obj = XState["Text"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Text"] = value;
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

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("Checked"))
            {
                //if (ClientPropertyModifiedInServer("Checked"))

                sb.AppendFormat("{0}.x_setValue();", XID);

            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            OB.AddProperty("checked", Checked);

            // In CheckBox control, Text is the showing beside the checkbox.
            if (!String.IsNullOrEmpty(Text))
            {
                OB.AddProperty("boxLabel", Text);
            }


            if (AutoPostBack)
            {
                // We should attach the "check" event after the control is rendered.
                // Because in the rendering process, the control will also trigger the "check" event, then we cann't distinguish it from the actual event.

                // We don't need delay here, because every PostBack has been delayed in global "ajaxPostBack" function.
                //string checkEventScript = String.Format("{0}.on('check',{1},X,{{delay:0}});", XID, JsHelper.GetFunction(GetPostBackEventReference()));
                //string renderScript = "(function(){" + checkEventScript + "}).defer(20);";

                //// 既然不需要延迟执行回发请求，那么就没必要放在render事件中了
                //string checkEventScript = String.Format("this.on('check',{0});", JsHelper.GetFunction(GetPostBackEventReference()));
                //OB.Listeners.AddProperty("render", "function(){" + checkEventScript + "}", true);

                OB.Listeners.AddProperty("check", JsHelper.GetFunction(GetPostBackEventReference()), true);
            }


            string jsContent = String.Format("var {0}=new Ext.form.Checkbox({1});", XID, OB.ToString());
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
            string postValue = postCollection[postDataKey];

            bool postChecked = !String.IsNullOrEmpty(postValue);
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
