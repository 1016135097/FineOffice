
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    CheckBoxField.cs
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
using System.Collections.Generic;


namespace FineUI
{
    /// <summary>
    /// ���ѡ����
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class CheckBoxField : GridColumn
    {

        #region Properties

        private bool _enabled = true;

        /// <summary>
        /// �Ƿ���ã�ֻ��RenderAsStaticField=falseʱ��Ч��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("�Ƿ���ã�ֻ��RenderAsStaticField=falseʱ��Ч��")]
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

        private bool _autoPostBack = false;

        /// <summary>
        /// �Ƿ��Զ��ط���ֻ��RenderAsStaticField=falseʱ��Ч��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("�Ƿ��Զ��ط���ֻ��RenderAsStaticField=false����ShowHeaderCheckBox=falseʱ��Ч��")]
        public bool AutoPostBack
        {
            get
            {
                return _autoPostBack;
            }
            set
            {
                _autoPostBack = value;
            }
        }


        public string _dataField = "";

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


        public bool _renderAsStaticField = true;

        /// <summary>
        /// ��ȾΪ��̬ͼƬ��������ȾΪ�ɱ༭�ĸ�ѡ��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("��ȾΪ��̬ͼƬ��������ȾΪ�ɱ༭�ĸ�ѡ��")]
        public bool RenderAsStaticField
        {
            get
            {
                return _renderAsStaticField;
            }
            set
            {
                _renderAsStaticField = value;
            }
        }


        public bool _showHeaderCheckBox = false;

        /// <summary>
        /// ��ʾ��ͷ��ѡ��ֻ��RenderAsStaticField=falseʱ��Ч��
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("��ʾ��ͷ��ѡ��ֻ��RenderAsStaticField=falseʱ��Ч��")]
        public bool ShowHeaderCheckBox
        {
            get
            {
                return _showHeaderCheckBox;
            }
            set
            {
                _showHeaderCheckBox = value;
            }
        }

        #endregion

        #region CommandName

        private string _commandName = "";

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("")]
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

        private string _commandArgument = "";

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("")]
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

        #region GetHeaderValue/GetColumnValue

        internal override string GetHeaderValue()
        {
            if (!RenderAsStaticField && ShowHeaderCheckBox)
            {
                string result = String.Empty;

                string textAlignClass = String.Empty;
                if (TextAlign != TextAlign.Left)
                {
                    textAlignClass = "box-grid-checkbox-" + TextAlignName.GetName(TextAlign);
                }

                string onClickScript = "Ext.get(this).toggleClass('box-grid-checkbox-unchecked');";
                onClickScript += "X.util.stopEventPropagation.apply(null, arguments);";

                //string tooltip = String.Empty;
                //if (!String.IsNullOrEmpty(HeaderText))
                //{
                //    tooltip = String.Format(" ext:qtip=\"{0}\" ", HeaderText);
                //}

                result = String.Format("<div class=\"box-grid-checkbox box-grid-checkbox-unchecked {0}\" onclick=\"{1}\">{2}</div>", textAlignClass, onClickScript, HeaderText);

                return result;
            }
            else
            {
                return base.GetHeaderValue();
            }
        }


        internal override string GetColumnValue(GridRow row)
        {
            string result = String.Empty;

            bool checkState = Convert.ToBoolean(GetColumnState(row));

            result = GetColumnValue(row, checkState);

            string tooltip = GetTooltipString(row);
            if (!String.IsNullOrEmpty(tooltip))
            {
                result = result.ToString().Insert("<div".Length, tooltip);
            }

            return result;
        }

        /// <summary>
        /// ȡ�õ�Ԫ�������
        /// </summary>
        /// <param name="row"></param>
        /// <param name="checkState"></param>
        /// <returns></returns>
        private string GetColumnValue(GridRow row, bool checkState)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(DataField))
            {
                string textAlignClass = String.Empty;
                if (TextAlign != TextAlign.Left)
                {
                    textAlignClass = "box-grid-checkbox-" + TextAlignName.GetName(TextAlign);
                }

                if (RenderAsStaticField)
                {
                    if (checkState)
                    {
                        result = "<div class=\"box-grid-static-checkbox " + textAlignClass + "\"></div>";
                    }
                    else
                    {
                        result = "<div class=\"box-grid-static-checkbox box-grid-static-checkbox-unchecked " + textAlignClass + "\"></div>";
                    }
                }
                else
                {
                    string paramStr = String.Format("Command${0}${1}${2}${3}", row.RowIndex, ColumnIndex, CommandName.Replace("'", "\""), CommandArgument.Replace("'", "\""));
                    // �ӳ�ִ��
                    string postBackReference = JsHelper.GetDeferScript(Grid.GetPostBackEventReference(paramStr), 0);

                    // string onClickScript = String.Format("{0}_checkbox{1}(event,this,{2});", Grid.XID, ColumnIndex, row.RowIndex);
                    string onClickScript = "Ext.get(this).toggleClass('box-grid-checkbox-unchecked');";
                    if (!ShowHeaderCheckBox && AutoPostBack)
                    {
                        onClickScript += postBackReference;
                    }

                    onClickScript += "X.util.stopEventPropagation.apply(null, arguments);";

                    if (checkState)
                    {
                        if (Enabled)
                        {
                            result = String.Format("<div class=\"box-grid-checkbox {0}\" onclick=\"{1}\"></div>", textAlignClass, onClickScript);
                        }
                        else
                        {
                            result = String.Format("<div class=\"box-grid-checkbox box-grid-checkbox-disabled {0}\"></div>", textAlignClass);
                        }
                    }
                    else
                    {
                        if (Enabled)
                        {
                            result = String.Format("<div class=\"box-grid-checkbox box-grid-checkbox-unchecked {0}\" onclick=\"{1}\"></div>", textAlignClass, onClickScript);
                        }
                        else
                        {
                            result = String.Format("<div class=\"box-grid-checkbox box-grid-checkbox-disabled box-grid-checkbox-unchecked-disabled {0}\"></div>", textAlignClass);
                        }
                    }
                }
            }

            return result;
        }


        //public override string GetFieldType()
        //{
        //    return "string";
        //}

        #endregion

        #region SaveColumnState/LoadColumnState

        internal override bool PersistState
        {
            get
            {
                if (RenderAsStaticField)
                {
                    return false;
                }
                return true;
            }
        }

        internal override object GetColumnState(GridRow row)
        {
            if (row.DataItem == null)
            {
                return row.States[ColumnIndex];
            }
            else
            {
                return row.GetPropertyValue(DataField);
            }
        }

       

        ///// <summary>
        ///// ����״̬���浽�ַ���
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <returns></returns>
        //public override string SaveColumnState()
        //{
        //    //StringBuilder sb = new StringBuilder();

        //    //int columnIndex = GetColumnIndex(grid);

        //    List<int> rowIndexList = new List<int>();

        //    int rowIndex = 0;
        //    foreach (GridRow row in Grid.Rows)
        //    {
        //        bool check = Convert.ToBoolean(row.ExtraValues[ColumnIndex]);

        //        if (check)
        //        {
        //            //sb.AppendFormat("{0},", rowIndex);
        //            rowIndexList.Add(rowIndex);
        //        }

        //        rowIndex++;
        //    }

        //    return StringUtil.GetStringFromIntArray(rowIndexList.ToArray());
        //    //return sb.ToString();
        //}


        ///// <summary>
        ///// ���ַ��������е�״̬
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="state"></param>
        ///// <returns></returns>
        //public override void LoadColumnState(string state)
        //{
        //    // ����ѡ�е����б�
        //    int[] checkedArray = StringUtil.GetIntListFromString(state).ToArray();
        //    List<int> checkedList = new List<int>(checkedArray);

        //    // ��ǰ��һ��
        //    //int columnIndex = GetColumnIndex(grid);

        //    int startRowIndex, endRowIndex;
        //    Grid.ResolveStartEndRowIndex(out startRowIndex, out endRowIndex);

        //    for (int i = startRowIndex; i <= endRowIndex; i++)
        //    {
        //        GridRow row = Grid.Rows[i];

        //        if (checkedList.Contains(i))
        //        {
        //            row.ExtraValues[ColumnIndex] = true;
        //            row.Values[ColumnIndex] = GetColumnValue(row, true);
        //        }
        //        else
        //        {
        //            row.ExtraValues[ColumnIndex] = false;
        //            row.Values[ColumnIndex] = GetColumnValue(row, false);
        //        }
        //    }
        //}

        #endregion

        #region GetCheckedState

        /// <summary>
        /// ��ǰ�е������ѡ���Ƿ���ѡ��״̬
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public bool GetCheckedState(int rowIndex)
        {
            GridRow row = this.Grid.Rows[rowIndex];

            return Convert.ToBoolean(row.States[ColumnIndex]);
        }

        public void SetCheckedState(int rowIndex, bool isChecked)
        {
            GridRow row = this.Grid.Rows[rowIndex];

            row.States[ColumnIndex] = isChecked;
        } 

        #endregion

        #region old code

        ///// <summary>
        ///// ά��ҳ����CheckBox��ֵ
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public List<bool> Checked
        //{
        //    get
        //    {
        //        object obj = ViewState["Checked"];
        //        return obj == null ? (new List<bool>()) : (List<bool>)obj;
        //    }
        //    set
        //    {
        //        ViewState["Checked"] = value;
        //    }
        //}

        #endregion
    }
}



