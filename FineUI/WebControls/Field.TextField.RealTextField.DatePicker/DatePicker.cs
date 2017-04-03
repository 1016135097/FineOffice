
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    js_css_resource.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *       
 *      ->2008-4-28     改名为 DatePicker
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
using System.Globalization;

namespace FineUI
{
    /// <summary>
    /// 日期选择框控件
    /// </summary>
    [Designer("FineUI.Design.DatePickerDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:DatePicker Label=\"Label\" runat=\"server\"></{0}:DatePicker>")]
    [ToolboxBitmap(typeof(DatePicker), "res.toolbox.DatePicker.bmp")]
    [DefaultEvent("DateSelect")]
    [Description("日期选择框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class DatePicker : RealTextField, IPostBackEventHandler
    {

        #region Properties


        /// <summary>
        /// 选择的日期
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("选择的日期")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? SelectedDate
        {
            get
            {
                if (DesignMode)
                {
                    object obj = XState["SelectedDate"];
                    return obj == null ? null : (DateTime?)obj;
                }
                else
                {
                    if (String.IsNullOrEmpty(Text))
                    {
                        return null;
                    }
                    else
                    {
                        try
                        {
                            //return DateTime.Parse(Text);

                            // OktaEndy - return null when DateFormatString = "dd/MM/yyyy" - Trying to Parse DateTime using it's DateFormatString
                            // http://stackoverflow.com/questions/1368636/why-cant-datetime-parseexact-parse-9-1-2009-using-m-d-yyyy
                            return DateTime.ParseExact(Text, DateFormatString, CultureInfo.InvariantCulture);
                        }
                        catch (Exception)
                        {
                            // Text is not valid DateTime fomat.
                            return null;
                        }
                    }
                }
            }
            set
            {
                if (DesignMode)
                {
                    XState["SelectedDate"] = value;
                }
                else
                {
                    if (value == null)
                    {
                        Text = String.Empty;
                    }
                    else
                    {
                        Text = value.Value.ToString(DateFormatString);
                    }
                }
            }
        }


        /// <summary>
        /// 启用中文智能识别，手工输入时如果不匹配指定格式，会尝试按照下面几种格式解析：yyyy-MM-dd、yyyy-M-d、yyyyMMdd、yyyyMd、yy-MM-dd、yy-M-d、yyMMdd、yyMd
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用中文智能识别，手工输入时如果不匹配指定格式，会尝试按照下面几种格式解析：yyyy-MM-dd、yyyy-M-d、yyyyMMdd、yyyyMd、yy-MM-dd、yy-M-d、yyMMdd、yyMd")]
        public bool EnableChineseAltFormats
        {
            get
            {
                object obj = XState["EnableChineseAltFormats"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableChineseAltFormats"] = value;
            }
        }


        /// <summary>
        /// 尝试解析日期的格式列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("尝试解析日期的格式列表")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] AltFormats
        {
            get
            {
                object obj = XState["AltFormats"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                XState["AltFormats"] = value;
            }
        }

        /// <summary>
        /// 日期格式
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("yyyy-MM-dd")]
        [Description("日期格式")]
        public string DateFormatString
        {
            get
            {
                object obj = XState["DateFormatString"];
                return obj == null ? "yyyy-MM-dd" : (string)obj;
            }
            set
            {
                XState["DateFormatString"] = value;
            }
        }

        /// <summary>
        /// 最大日期
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最大日期")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? MaxDate
        {
            get
            {
                object obj = XState["MaxDate"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                XState["MaxDate"] = value;
            }
        }

        /// <summary>
        /// 最小日期
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最小日期")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? MinDate
        {
            get
            {
                object obj = XState["MinDate"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                XState["MinDate"] = value;
            }
        }


        /// <summary>
        /// 选择日期是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("选择日期是否自动回发")]
        public bool EnableDateSelect
        {
            get
            {
                object obj = XState["EnableDateSelect"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableDateSelect"] = value;
            }
        }

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Readonly"))
            //{
            //    sb.AppendFormat("{0}.setReadOnly({1});", XID, Readonly.ToString().ToLower());
            //}

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            //// 日期选择器也需要菜单组件的支持
            //ResourceManager.Instance.AddJavaScriptComponent("menu");

            // extjs 的日期格式化字符串
            string extjsDateFormatString = ExtDateTimeConvertor.ConvertToExtDateFormat(DateFormatString);
            OB.AddProperty("format", extjsDateFormatString);

            if (EnableChineseAltFormats)
            {
                OB.AddProperty("altFormats", "Y-m-d|Y-n-j|Ymd|Ynj|y-m-d|y-n-j|ymd|ynj");
            } 
            else if (AltFormats != null)
            {
                StringBuilder formats = new StringBuilder();
                foreach (string format in AltFormats)
                {
                    formats.Append(ExtDateTimeConvertor.ConvertToExtDateFormat(format));
                    formats.Append("|");
                }
                 OB.AddProperty("altFormats", formats.ToString().TrimEnd('|'));
            }

            //// 当前选中的日期值，这个在父类中已经设置了
            //OB.RemoveProperty(OptionName.Value);
            //if (SelectedDate != null) OB.AddProperty(OptionName.Value, Text);

            if (MaxDate != null)
            {
                OB.AddProperty("maxValue", MaxDate.Value.ToString(DateFormatString));
            }
            if (MinDate != null)
            {
                OB.AddProperty("minValue", MinDate.Value.ToString(DateFormatString));
            }


            if (EnableDateSelect)
            {
                OB.Listeners.AddProperty("select", JsHelper.GetFunction(GetPostBackEventReference("Select")), true);
            }

            string jsContent = String.Format("var {0}=new Ext.form.DateField({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

        #region RaisePostBackEvent

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.StartsWith("Select"))
            {
                OnDateSelect(EventArgs.Empty);
            }
        }

        #endregion

        #region OnDateSelect

        private object _handlerKey = new object();

        /// <summary>
        /// 选择日期事件（需要启用EnableDateSelect）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("选择日期事件（需要启用EnableDateSelect）")]
        public virtual event EventHandler DateSelect
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

        protected virtual void OnDateSelect(EventArgs e)
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
