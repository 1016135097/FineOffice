
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    BoundField.cs
 * CreatedOn:   2008-05-27
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


namespace FineUI
{
    /// <summary>
    /// ������ݰ���
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class BoundField : GridColumn
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


        private string _dataField = String.Empty;

        /// <summary>
        /// �ֶ�����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�ֶ�����")]
        public string DataField
        {
            get
            {
                return _dataField;
            }
            set
            {
                _dataField = value;
            }
        }


        private string _dataFormatString = String.Empty;

        /// <summary>
        /// �ֶθ�ʽ���ַ���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�ֶθ�ʽ���ַ���")]
        public string DataFormatString
        {
            get
            {
                return _dataFormatString;
            }
            set
            {
                _dataFormatString = value;
            }
        }


        private string _nullDisplayText = String.Empty;

        /// <summary>
        /// �������ݿ���nullֵ��Ĭ��Ϊ���ַ���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�������ݿ���nullֵ��Ĭ��Ϊ���ַ���")]
        public string NullDisplayText
        {
            get
            {
                return _nullDisplayText;
            }
            set
            {
                _nullDisplayText = value;
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

        #endregion

        #region Methods

        internal override string GetColumnValue(GridRow row)
        {
            string text = String.Empty;

            if (!String.IsNullOrEmpty(DataField))
            {
                object value = row.GetPropertyValue(DataField);

                if (value == null)
                {
                    text = NullDisplayText;
                }
                else
                {
                    if (!String.IsNullOrEmpty(DataFormatString))
                    {
                        text = String.Format(DataFormatString, value);
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
                }
            }

            HtmlNodeBuilder nb = new HtmlNodeBuilder("span");

            nb.InnerProperty = text;

            if (!Enabled)
            {
                nb.SetProperty("class", "x-item-disabled");
                nb.SetProperty("disabled", "disabled");
            }


            string result = nb.ToString();

            string tooltip = GetTooltipString(row);
            if (!String.IsNullOrEmpty(tooltip))
            {
                result = result.ToString().Insert("<span".Length, tooltip);
            }

            // �������� <span>�󶨵�����</span>
            if (result.StartsWith("<span>"))
            {
                result = result.Substring("<span>".Length, result.Length - "<span></span>".Length);
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



