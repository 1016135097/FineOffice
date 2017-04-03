
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    LinkButtonField.cs
 * CreatedOn:   2008-06-23
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
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Drawing.Design;

namespace FineUI
{
    /// <summary>
    /// ������Ӱ�ť��
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class LinkButtonField : GridColumn
    {

        #region Properties


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


        public string _text = String.Empty;

        /// <summary>
        /// ��ť�ı�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��ť�ı�")]
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

        #region Properties

        private bool _enablePostBack = true;

        /// <summary>
        /// �Ƿ���Իط�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("�Ƿ���Իط�")]
        public bool EnablePostBack
        {
            get
            {
                return _enablePostBack;
            }
            set
            {
                _enablePostBack = value;
            }
        }

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

        private string _onClientClick = String.Empty;

        /// <summary>
        /// �����ťʱ��Ҫִ�еĿͻ��˽ű�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�����ťʱ��Ҫִ�еĿͻ��˽ű�")]
        public string OnClientClick
        {
            get
            {
                return _onClientClick;
            }
            set
            {
                _onClientClick = value;
            }
        }

        public string[] _validateForms = null;

        /// <summary>
        /// �ύ֮ǰ��Ҫ��֤�ı������б�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("�ύ֮ǰ��Ҫ��֤�ı������б�")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] ValidateForms
        {
            get
            {
                return _validateForms;
            }
            set
            {
                _validateForms = value;
            }
        }

        public Target _validateTarget = Target.Self;

        /// <summary>
        /// ��֤ʧ��ʱ��ʾ�Ի��򵯳�λ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("��֤ʧ��ʱ��ʾ�Ի��򵯳�λ��")]
        public Target ValidateTarget
        {
            get
            {
                return _validateTarget;
            }
            set
            {
                _validateTarget = value;
            }
        }

        public bool _validateMessageBox = true;

        /// <summary>
        /// ��֤ʧ��ʱ�Ƿ������ʾ�Ի���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("��֤ʧ��ʱ�Ƿ������ʾ�Ի���")]
        public bool ValidateMessageBox
        {
            get
            {
                return _validateMessageBox;
            }
            set
            {
                _validateMessageBox = value;
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

        #region ConfirmText/ConfirmTitle/ConfirmIcon

        private string _confirmTitle = "";

        /// <summary>
        /// ȷ�϶Ի������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("ȷ�϶Ի������")]
        public string ConfirmTitle
        {
            get
            {
                return _confirmTitle;
            }
            set
            {
                _confirmTitle = value;
            }
        }

        private string _confirmText = String.Empty;

        /// <summary>
        /// ȷ�϶Ի�������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("ȷ�϶Ի�������")]
        public string ConfirmText
        {
            get
            {
                return _confirmText;
            }
            set
            {
                _confirmText = value;
            }
        }

        private MessageBoxIcon _confirmIcon = MessageBoxIcon.Warning;

        /// <summary>
        /// ȷ�϶Ի�����ʾͼ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(MessageBoxIcon.Warning)]
        [Description("ȷ�϶Ի�����ʾͼ��")]
        public MessageBoxIcon ConfirmIcon
        {
            get
            {
                return _confirmIcon;
            }
            set
            {
                _confirmIcon = value;
            }
        }

        public Target _confirmTarget = Target.Self;

        /// <summary>
        /// ȷ�϶Ի��򵯳�λ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("ȷ�϶Ի��򵯳�λ��")]
        public Target ConfirmTarget
        {
            get
            {
                return _confirmTarget;
            }
            set
            {
                _confirmTarget = value;
            }
        }

        #endregion

        #region CommandName/CommandArgument

        public string _commandName = String.Empty;

        /// <summary>
        /// ��������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��������")]
        public string CommandName
        {
            get
            {
                return _commandName;
            }
            set
            {
                _commandName = value;
            }
        }

        public string _commandArgument = String.Empty;

        /// <summary>
        /// �������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�������")]
        public string CommandArgument
        {
            get
            {
                return _commandArgument;
            }
            set
            {
                _commandArgument = value;
            }
        }


        #endregion

        #region Methods

        internal override string GetColumnValue(GridRow row)
        {
            //string result = String.Empty;

            #region DataTextField

            string text = String.Empty;

            if (!String.IsNullOrEmpty(DataTextField))
            {
                object value = row.GetPropertyValue(DataTextField);

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
            }
            else
            {
                text = Text;
            }

            #endregion

            HtmlNodeBuilder nb;

            #region Enabled

            nb = new HtmlNodeBuilder("a");

            if (Enabled)
            {
                nb.SetProperty("href", "javascript:;");

                // click
                string paramStr = String.Format("Command${0}${1}${2}${3}", row.RowIndex, ColumnIndex, CommandName.Replace("'", "\""), CommandArgument.Replace("'", "\""));
                string postBackReference = Grid.GetPostBackEventReference(paramStr);

                string clientScript = Button.ResolveClientScript(ValidateForms, ValidateTarget, ValidateMessageBox, EnablePostBack, postBackReference,
                  ConfirmText, ConfirmTitle, ConfirmIcon, ConfirmTarget, OnClientClick, String.Empty);

                clientScript = JsHelper.GetDeferScript(clientScript, 0) + "X.util.stopEventPropagation.apply(null, arguments);";

                nb.SetProperty("onclick", clientScript);

                //result = nb.ToString();
            }
            else
            {
                nb.SetProperty("class", "x-item-disabled");
                nb.SetProperty("disabled", "disabled");

                //nb = new HtmlNodeBuilder("span");
                //nb.SetProperty("class", "gray");
                //nb.InnerProperty = text;
                //result = String.Format("<span class=\"gray\">{0}</span>", text);
            }

            nb.InnerProperty = text;

            #endregion

            string tooltip = GetTooltipString(row);

            #region Icon IconUrl

            string resolvedIconUrl = IconHelper.GetResolvedIconUrl(Icon, IconUrl);
            if (!String.IsNullOrEmpty(resolvedIconUrl))
            {
                nb.InnerProperty = String.Format("<img src=\"{0}\" {1} />", resolvedIconUrl, tooltip) + nb.InnerProperty;
            }

            #endregion

            //string result = nb.ToString();
            //#region Tooltip

            //if (!String.IsNullOrEmpty(tooltip))
            //{
            //    if (result.StartsWith("<a "))
            //    {
            //        result = result.ToString().Insert(2, tooltip);
            //    }
            //    else if (result.StartsWith("<span "))
            //    {
            //        result = result.ToString().Insert(5, tooltip);
            //    }
            //} 

            //#endregion

            //return result;

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



