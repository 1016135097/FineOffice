
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    WindowField.cs
 * CreatedOn:   2008-06-03
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description��
 *      ->
 *   
 * History��
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Reflection;

using System.Collections.Generic;
using System.Web.UI.Design;
using System.Drawing.Design;

namespace FineUI
{
    /// <summary>
    /// �������
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class WindowField : GridColumn
    {
        #region Properties

        private bool _enabled = true;

        /// <summary>
        /// �Ƿ����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("�Ƿ����")]
        public virtual bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }


        public string _windowID = String.Empty;

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("")]
        public string WindowID
        {
            get
            {
                return _windowID;
            }
            set
            {
                _windowID = value;
            }
        }

        public string _dataWindowTitleField = String.Empty;

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("")]
        public string DataWindowTitleField
        {
            get
            {
                return _dataWindowTitleField;
            }
            set
            {
                _dataWindowTitleField = value;
            }
        }


        public string _dataWindowTitleFormatString = String.Empty;

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("")]
        public string DataWindowTitleFormatString
        {
            get
            {
                return _dataWindowTitleFormatString;
            }
            set
            {
                _dataWindowTitleFormatString = value;
            }
        }


        public string _dataTextField = String.Empty;

        /// <summary>
        /// �ֶ�����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�ֶ�����")]
        public string DataTextField
        {
            get
            {
                return _dataTextField;
            }
            set
            {
                _dataTextField = value;
            }
        }


        public string _dataTextFormatString = String.Empty;

        /// <summary>
        /// �ֶθ�ʽ���ַ���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�ֶθ�ʽ���ַ���")]
        public string DataTextFormatString
        {
            get
            {
                return _dataTextFormatString;
            }
            set
            {
                _dataTextFormatString = value;
            }
        }



        private bool _htmlEncode = true;

        /// <summary>
        /// ��ʾ֮ǰ����HTML���루Ĭ��Ϊtrue��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("��ʾ֮ǰ����HTML���루Ĭ��Ϊtrue��")]
        public bool HtmlEncode
        {
            get
            {
                return _htmlEncode;
            }
            set
            {
                _htmlEncode = value;
            }
        }


        private bool _htmlEncodeFormatString = true;

        /// <summary>
        /// �Ƿ���Ӧ��DataFormatString����֮�����HTML���루Ĭ��Ϊtrue��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("�Ƿ���Ӧ��DataFormatString����֮�����HTML���루Ĭ��Ϊtrue��")]
        public bool HtmlEncodeFormatString
        {
            get
            {
                return _htmlEncodeFormatString;
            }
            set
            {
                _htmlEncodeFormatString = value;
            }
        }



        public string _dataIFrameUrlFields = String.Empty;

        /// <summary>
        /// �󶨵�IFrame��ַ���ֶ������б�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�󶨵�IFrame��ַ���ֶ������б�")]
        public string DataIFrameUrlFields
        {
            get
            {
                return _dataIFrameUrlFields;
            }
            set
            {
                _dataIFrameUrlFields = value;
            }
        }

        public string _dataIFrameUrlFormatString = String.Empty;

        /// <summary>
        /// �󶨵�IFrame��ַ���ֶθ�ʽ���ַ���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�󶨵�IFrame��ַ���ֶθ�ʽ���ַ���")]
        public string DataIFrameUrlFormatString
        {
            get
            {
                return _dataIFrameUrlFormatString;
            }
            set
            {
                _dataIFrameUrlFormatString = value;
            }
        }


        private bool _urlEncode = true;

        /// <summary>
        /// ��ÿ���󶨵�IFrame��ַ���ֶν���URL���루Ĭ��Ϊtrue��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("��ÿ���󶨵�IFrame��ַ���ֶν���URL����")]
        public bool UrlEncode
        {
            get
            {
                return _urlEncode;
            }
            set
            {
                _urlEncode = value;
            }
        }



        public string _iframeUrl = String.Empty;

        /// <summary>
        /// IFrame��ַ
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("IFrame��ַ")]
        public string IFrameUrl
        {
            get
            {
                return _iframeUrl;
            }
            set
            {
                _iframeUrl = value;
            }
        }


        public string _text = String.Empty;

        /// <summary>
        /// ��ʾ�ı�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��ʾ�ı�")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public string _title = String.Empty;

        /// <summary>
        /// ����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("����")]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public Icon _icon = Icon.None;

        /// <summary>
        /// ͼ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("ͼ��")]
        public Icon Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
            }
        }

        public string _iconUrl = String.Empty;

        /// <summary>
        /// ͼ���ַ
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("ͼ���ַ")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string IconUrl
        {
            get
            {
                return _iconUrl;
            }
            set
            {
                _iconUrl = value;
            }
        }

        #endregion

        #region Methods

        internal override string GetColumnValue(GridRow row)
        {
            HtmlNodeBuilder nb = new HtmlNodeBuilder("a");

            #region DataTextField

            if (!String.IsNullOrEmpty(DataTextField))
            {
                object value = row.GetPropertyValue(DataTextField);

                //if (!String.IsNullOrEmpty(DataTextFormatString))
                //{
                //    nb.InnerProperty = String.Format(DataTextFormatString, value);
                //}
                //else
                //{
                //    nb.InnerProperty = value.ToString();
                //}
                string text = String.Empty;
                if (!String.IsNullOrEmpty(DataTextFormatString))
                {
                    text = String.Format(DataTextFormatString, value);
                    if (HtmlEncodeFormatString)
                    {
                        text = HttpUtility.HtmlEncode(text);
                    }
                }
                else
                {
                    text = value.ToString();
                    if (HtmlEncode)
                    {
                        text = HttpUtility.HtmlEncode(text);
                    }
                }

                nb.InnerProperty = text;
            }
            else
            {
                nb.InnerProperty = Text;
            }

            #endregion

            if (Enabled)
            {
                string url = "#";

                #region DataIFrameUrlFields

                string hrefOriginal = String.Empty;

                if (!String.IsNullOrEmpty(DataIFrameUrlFields))
                {
                    string[] fields = DataIFrameUrlFields.Trim().TrimEnd(',').Split(',');

                    List<object> fieldValues = new List<object>();
                    foreach (string field in fields)
                    {
                        if (!String.IsNullOrEmpty(field))
                        {
                            //fieldValues.Add(row.GetPropertyValue(field));
                            string fieldValue = row.GetPropertyValue(field).ToString();
                            if (UrlEncode)
                            {
                                fieldValue = HttpUtility.UrlEncode(fieldValue);
                            }
                            fieldValues.Add(fieldValue);
                        }
                    }


                    if (!String.IsNullOrEmpty(DataIFrameUrlFormatString))
                    {
                        hrefOriginal = String.Format(DataIFrameUrlFormatString, fieldValues.ToArray());
                    }
                    else
                    {
                        if (fieldValues.Count > 0)
                        {
                            hrefOriginal = fieldValues[0].ToString();
                        }
                    }
                }
                else
                {
                    hrefOriginal = IFrameUrl;
                }

                url = Grid.ResolveUrl(hrefOriginal);

                #endregion

                string title = String.Empty;

                #region DataTextField

                if (!String.IsNullOrEmpty(DataWindowTitleField))
                {
                    object value = row.GetPropertyValue(DataWindowTitleField);

                    if (!String.IsNullOrEmpty(DataWindowTitleFormatString))
                    {
                        title = String.Format(DataWindowTitleFormatString, value);
                    }
                    else
                    {
                        title = value.ToString();
                    }
                }
                else
                {
                    title = Title;
                }

                #endregion

                #region WindowID

                if (!String.IsNullOrEmpty(WindowID))
                {
                    Window window = ControlUtil.FindControl(Grid.Page, WindowID) as Window;
                    if (window != null)
                    {
                        nb.SetProperty("href", "javascript:;");
                        nb.SetProperty("onclick", String.Format("javascript:{0}", window.GetShowReference(url, title)));
                        //nb.SetProperty("href", String.Format("javascript:X.{0}_show('{1}','{2}');", window.ClientID, url, title.Replace("'", "\"")));
                    }
                }

                #endregion

            }
            else
            {
                nb.SetProperty("class", "x-item-disabled");
                nb.SetProperty("disabled", "disabled");
            }

            string tooltip = GetTooltipString(row);

            #region Icon IconUrl

            string resolvedIconUrl = IconHelper.GetResolvedIconUrl(Icon, IconUrl);
            if (!String.IsNullOrEmpty(resolvedIconUrl))
            {
                nb.InnerProperty = String.Format("<img src=\"{0}\" {1} />", resolvedIconUrl, tooltip) + nb.InnerProperty;
            }

            #endregion

            //string result2 = nb.ToString();

            //#region Tooltip

            
            //if (!String.IsNullOrEmpty(tooltip))
            //{
            //    result2 = result2.ToString().Insert(2, tooltip);
            //} 

            //#endregion

            //return result2;

            string result = nb.ToString();

            if (!String.IsNullOrEmpty(tooltip))
            {
                result = result.ToString().Insert("<a".Length, tooltip);
            }

            return result;
        }


        //public override string GetFieldType()
        //{
        //    return "string";
        //}

        #endregion

    }
}



