
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    TimePicker.cs
 * CreatedOn:   2012-11-01
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
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
    /// 时间选择框控件
    /// </summary>
    [Designer("FineUI.Design.TimePickerDesigner, FineUI.Design")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TimePicker Label=\"Label\" runat=\"server\"></{0}:TimePicker>")]
    [ToolboxBitmap(typeof(TimePicker), "res.toolbox.TimePicker.bmp")]
    [DefaultEvent("DateSelect")]
    [Description("时间选择框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class TimePicker : RealTextField, IPostBackEventHandler
    {

        #region Properties

        /// <summary>
        /// 选择的时间
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("选择的时间")]
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
                            // OktaEndy - return null when DateFormatString = "dd/MM/yyyy" - Trying to Parse DateTime using it's DateFormatString
                            // http://stackoverflow.com/questions/1368636/why-cant-datetime-parseexact-parse-9-1-2009-using-m-d-yyyy
                            return DateTime.ParseExact(Text, TimeFormatString, CultureInfo.InvariantCulture);
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
                        Text = value.Value.ToString(TimeFormatString);
                    }
                }
            }
        }

        
        /// <summary>
        /// 尝试解析时间的格式列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("尝试解析时间的格式列表")]
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
        /// 时间格式（默认为HH:mm，24小时制，比如“20:30”）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("HH:mm")]
        [Description("时间格式")]
        public string TimeFormatString
        {
            get
            {
                object obj = XState["TimeFormatString"];
                return obj == null ? "HH:mm" : (string)obj;
            }
            set
            {
                XState["TimeFormatString"] = value;
            }
        }

        /// <summary>
        /// 最大时间
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最大时间")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? MaxTime
        {
            get
            {
                object obj = XState["MaxTime"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                XState["MaxTime"] = value;
            }
        }

        /// <summary>
        /// 最大时间的字符串形式
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最大时间的字符串形式")]
        public string MaxTimeText
        {
            get
            {
                object obj = XState["MaxTimeText"];
                return obj == null ? null : (string)obj;
            }
            set
            {
                XState["MaxTimeText"] = value;
            }
        }

        /// <summary>
        /// 最小时间
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最小时间")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? MinTime
        {
            get
            {
                object obj = XState["MinTime"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                XState["MinTime"] = value;
            }
        }

        /// <summary>
        /// 最小时间的字符串形式
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最小时间的字符串形式")]
        public string MinTimeText
        {
            get
            {
                object obj = XState["MinTimeText"];
                return obj == null ? null : (string)obj;
            }
            set
            {
                XState["MinTimeText"] = value;
            }
        }


        private const short INCREMENT_DEFAULT = 15;

        /// <summary>
        /// 列表中每个时间值相差的分钟数（默认为15分钟）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(INCREMENT_DEFAULT)]
        [Description("列表中每个时间值相差的分钟数（默认为15分钟）")]
        public short Increment 
        {
            get
            {
                object obj = XState["Increment"];
                return obj == null ? INCREMENT_DEFAULT : (short)obj;
            }
            set
            {
                XState["Increment"] = value;
            }
        }


        /// <summary>
        /// 选择时间是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("选择时间是否自动回发")]
        public bool EnableTimeSelect
        {
            get
            {
                object obj = XState["EnableTimeSelect"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableTimeSelect"] = value;
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
            string extjsDateFormatString = ExtDateTimeConvertor.ConvertToExtDateFormat(TimeFormatString);
            OB.AddProperty("format", extjsDateFormatString);

            if (AltFormats != null)
            {
                StringBuilder formats = new StringBuilder();
                foreach (string format in AltFormats)
                {
                    formats.Append(ExtDateTimeConvertor.ConvertToExtDateFormat(format));
                    formats.Append("|");
                }
                OB.AddProperty("altFormats", formats.ToString().TrimEnd('|'));
            }

            if (Increment != INCREMENT_DEFAULT)
            {
                OB.AddProperty("increment", Increment); 
            }


            ////// 当前选中的日期值，这个在父类中已经设置了
            ////OB.RemoveProperty(OptionName.Value);
            ////if (SelectedDate != null) OB.AddProperty(OptionName.Value, Text);


            if (MaxTime.HasValue)
            {
                OB.AddProperty("maxValue", MaxTime.Value.ToString(TimeFormatString));
            }
            else if (!String.IsNullOrEmpty(MaxTimeText))
            {
                OB.AddProperty("maxValue", MaxTimeText);
            }

            if (MinTime.HasValue)
            {
                OB.AddProperty("minValue", MinTime.Value.ToString(TimeFormatString));
            }
            else if (!String.IsNullOrEmpty(MinTimeText))
            {
                OB.AddProperty("minValue", MinTimeText);
            }


            if (EnableTimeSelect)
            {
                OB.Listeners.AddProperty("select", JsHelper.GetFunction(GetPostBackEventReference("Select")), true);
            }


            string jsContent = String.Format("var {0}=new Ext.form.TimeField({1});", XID, OB.ToString());
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
