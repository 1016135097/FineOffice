
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridColumn.cs
 * CreatedOn:   2008-05-19
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
using System.Data;
using System.Reflection;
using System.Web.UI.WebControls;


namespace FineUI
{
    /// <summary>
    /// ����л��ࣨ�����ࣩ
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [DefaultProperty("HeaderText")]
    public abstract class GridColumn
    {
        #region Grid/ColumnIndex

        private Grid _grid;

        /// <summary>
        /// ������
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("������")]
        public Grid Grid
        {
            get
            {
                return _grid;
            }
            set
            {
                _grid = value;
            }
        }

        private int _columnIndex;

        /// <summary>
        /// ������
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("������")]
        public int ColumnIndex
        {
            get
            {
                return _columnIndex;
            }
            set
            {
                _columnIndex = value;
            }
        }

        #endregion

        #region SortField

        ///// <summary>
        ///// ��ǰ�е�������ʽ
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string SortExpression
        //{
        //    get
        //    {
        //        return String.Format("{0} {1}", SortField, SortDirection);
        //    }
        //}

        //public string _sortDirection = "ASC";

        ///// <summary>
        ///// ������
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string SortDirection
        //{
        //    get
        //    {
        //        return _sortDirection;
        //    }
        //    set
        //    {
        //        _sortDirection = value;
        //    }
        //}

        private string _sortField = String.Empty;

        /// <summary>
        /// �����ֶ�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("�����ֶ�")]
        public string SortField
        {
            get
            {
                return _sortField;
            }
            set
            {
                _sortField = value;
            }
        }

        #endregion

        #region Properties




        private bool _hidden = false;

        /// <summary>
        /// �Ƿ�������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ�������")]
        public bool Hidden
        {
            get
            {
                return _hidden;
            }
            set
            {
                _hidden = value;
            }
        }


        private string _dataSimulateTreeLevelField = String.Empty;

        /// <summary>
        /// ����ģ������ʾʱ�Ĳ���ֶ�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("����ģ������ʾʱ�Ĳ���ֶ�")]
        public string DataSimulateTreeLevelField
        {
            get
            {
                return _dataSimulateTreeLevelField;
            }
            set
            {
                _dataSimulateTreeLevelField = value;
            }
        }


        private string _columnID = String.Empty;

        /// <summary>
        /// ��ID
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��ID")]
        public string ColumnID
        {
            get
            {
                if (String.IsNullOrEmpty(_columnID))
                {
                    return String.Format("ct{0}", ColumnIndex);
                }
                return _columnID;
            }
            set
            {
                _columnID = value;
            }
        }


        private string _headerText = String.Empty;

        /// <summary>
        /// ��������ʾ������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��������ʾ������")]
        public string HeaderText
        {
            get
            {
                return _headerText;
            }
            set
            {
                _headerText = value;
            }
        }

        #region fengshengde
        private bool _Sortable = true;
        /// <summary>
        /// �Ƿ�֧������
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("�Ƿ�֧������")]
        public bool Sortable
        {
            get
            {
                return _Sortable;
            }
            set
            {
                _Sortable = value;
            }
        }

        private bool _Hideable = true;
        /// <summary>
        /// �Ƿ���ʾ���в˵���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("�Ƿ���ʾ���в˵���")]
        public bool Hideable
        {
            get
            {
                return _Hideable;
            }
            set
            {
                _Hideable = value;
            }
        }
        #endregion

        private Unit _width = Unit.Empty;

        /// <summary>
        /// �п��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("�п��")]
        public Unit Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }


        private bool _expandUnusedSpace = false;

        /// <summary>
        /// ���л���չ����δʹ�õĿ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("���л���չ����δʹ�õĿ��")]
        public bool ExpandUnusedSpace
        {
            get
            {
                return _expandUnusedSpace;
            }
            set
            {
                _expandUnusedSpace = value;
            }
        }


        private TextAlign _textalign = TextAlign.Left;

        /// <summary>
        /// �ı�������λ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(TextAlign.Left)]
        [Description("�ı�������λ��")]
        public TextAlign TextAlign
        {
            get
            {
                return _textalign;
            }
            set
            {
                _textalign = value;
            }
        }


        #endregion

        #region DataTooltipField/DataTooltipFormatString

        private string _tooltip = String.Empty;

        /// <summary>
        /// ��ʾ�ı�
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��ʾ�ı�")]
        public string ToolTip
        {
            get
            {
                return _tooltip;
            }
            set
            {
                _tooltip = value;
            }
        }



        private string _dataToolTipField = String.Empty;

        /// <summary>
        /// ��ʾ�ֶ�����
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��ʾ�ֶ�����")]
        public string DataToolTipField
        {
            get
            {
                return _dataToolTipField;
            }
            set
            {
                _dataToolTipField = value;
            }
        }

        private string _dataToolTipFormatString = String.Empty;

        /// <summary>
        /// ��ʾ�ֶθ�ʽ���ַ���
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("��ʾ�ֶθ�ʽ���ַ���")]
        public string DataToolTipFormatString
        {
            get
            {
                return _dataToolTipFormatString;
            }
            set
            {
                _dataToolTipFormatString = value;
            }
        }

        #endregion

        #region virtual GetColumnValue/GetColumnState/PersistState

        /// <summary>
        /// ȡ����ͷ��Ⱦ���HTML
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        internal virtual string GetHeaderValue()
        {
            return String.IsNullOrEmpty(HeaderText) ? "&nbsp;" : HeaderText;
        }

        /// <summary>
        /// ȡ������Ⱦ���HTML
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        internal virtual string GetColumnValue(GridRow row)
        {
            return String.Empty;
        }


        internal virtual bool PersistState
        {
            get
            {
                return false;
            }
        }


        internal virtual object GetColumnState(GridRow row)
        {
            return null;
        }

        ///// <summary>
        ///// �������ɵ�JS�ű��У�ָ�����е�����
        ///// </summary>
        ///// <returns></returns>
        //public virtual string GetFieldType()
        //{
        //    return "string";
        //}

        ///// <summary>
        ///// ���е�״̬���浽
        ///// </summary>
        ///// <returns></returns>
        //public virtual string SaveColumnState()
        //{
        //    return String.Empty;
        //}

        ///// <summary>
        ///// �����е�״̬
        ///// </summary>
        ///// <returns></returns>
        //public virtual void LoadColumnState(string state)
        //{

        //}

        #endregion

        #region GetTooltipString

        #region old code
        //public string GetSimulateTreeString(string originalStr)
        //{
        //    string result = originalStr;

        //    if (!String.IsNullOrEmpty(DataSimulateTreeLevelField))
        //    {

        //    }

        //    return result;
        //}


        //public string GetColumnID()
        //{
        //    //if (!String.IsNullOrEmpty(SortField))
        //    //{
        //    //    return String.Format(COLUMN_ID_TEMPLATE, ColumnIndex, SortField);
        //    //}
        //    //else
        //    //{
        //    //    return String.Format("ct{0}", ColumnIndex);
        //    //}

        //    return String.Format("ct{0}", ColumnIndex);
        //}

        ///// <summary>
        ///// �����ǵڼ���
        ///// </summary>
        ///// <param name="columns"></param>
        ///// <returns></returns>
        //public int GetColumnIndex(Grid grid)
        //{
        //    for (int i = 0, count = grid.Columns.Count; i < count; i++)
        //    {
        //        if (grid.Columns[i] == this)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //} 
        #endregion

        /// <summary>
        /// ȡ����ʾ�ַ���
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        protected string GetTooltipString(GridRow row)
        {
            string result = null;

            if (!String.IsNullOrEmpty(DataToolTipField))
            {
                object value = row.GetPropertyValue(DataToolTipField);

                if (!String.IsNullOrEmpty(DataToolTipFormatString))
                {
                    result = String.Format(DataToolTipFormatString, value);
                }
                else
                {
                    result = value.ToString();
                }
            }
            else if (!String.IsNullOrEmpty(ToolTip))
            {
                result = ToolTip;
            }

            return result == null ? "" : String.Format(" ext:qtip=\"{0}\" ", result);
            //return String.IsNullOrEmpty(result) ? String.Empty : result;
        }

        #endregion
    }
}



