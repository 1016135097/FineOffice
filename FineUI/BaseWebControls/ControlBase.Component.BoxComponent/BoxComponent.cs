
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Component.cs
 * CreatedOn:   2008-04-14
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


namespace FineUI
{
    /// <summary>
    /// 控件基类（抽象类）
    /// </summary>
    public abstract class BoxComponent : Component
    {
        #region Constructor

        public BoxComponent()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();

        }

        #endregion

        #region Properties

        /// <summary>
        /// 宽度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("宽度")]
        public Unit Width
        {
            get
            {
                object obj = XState["Width"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["Width"] = value;
            }
        }


        /// <summary>
        /// 高度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("高度")]
        public Unit Height
        {
            get
            {
                object obj = XState["Height"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["Height"] = value;
            }
        }


        #endregion

        #region Layout Properties

        /// <summary>
        /// 锚点值（当父容器的Layout=Anchor时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("")]
        [Description("锚点值（当父容器的Layout=Anchor时有效）")]
        public string AnchorValue
        {
            get
            {
                object obj = XState["AnchorValue"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["AnchorValue"] = value;
            }
        }


        /// <summary>
        /// 列的宽度（当父容器的Layout=Column时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("")]
        [Description("列的宽度（当父容器的Layout=Column时有效）")]
        public string ColumnWidth
        {
            get
            {
                object obj = XState["ColumnWidth"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ColumnWidth"] = value;
            }
        }


        /// <summary>
        /// 行的宽度（当父容器的Layout=Row时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("")]
        [Description("行的宽度（当父容器的Layout=Row时有效）")]
        public string RowHeight
        {
            get
            {
                object obj = XState["RowHeight"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["RowHeight"] = value;
            }
        }


        /// <summary>
        /// 绝对定位的X坐标（当父容器的Layout=Absolute时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("绝对定位的X坐标（当父容器的Layout=Absolute时有效）")]
        public Unit AbsoluteX
        {
            get
            {
                object obj = XState["AbsoluteX"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["AbsoluteX"] = value;
            }
        }


        /// <summary>
        /// 绝对定位的Y坐标（当父容器的Layout=Absolute时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("绝对定位的Y坐标（当父容器的Layout=Absolute时有效）")]
        public Unit AbsoluteY
        {
            get
            {
                object obj = XState["AbsoluteY"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["AbsoluteY"] = value;
            }
        }


        /// <summary>
        /// 表格列数（当父容器的Layout=Table时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(3)]
        [Description("表格列数（当父容器的Layout=Table时有效）")]
        public int TableConfigColumns
        {
            get
            {
                object obj = XState["TableConfigColumns"];
                return obj == null ? 3 : (int)obj;
            }
            set
            {
                XState["TableConfigColumns"] = value;
            }
        }

        /// <summary>
        /// 表格合并行（当父容器的Layout=Table时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(1)]
        [Description("表格合并行（当父容器的Layout=Table时有效）")]
        public int TableRowspan
        {
            get
            {
                object obj = XState["TableRowspan"];
                return obj == null ? 1 : (int)obj;
            }
            set
            {
                XState["TableRowspan"] = value;
            }
        }

        /// <summary>
        /// 表格合并列（当父容器的Layout=Table时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(1)]
        [Description("表格合并列（当父容器的Layout=Table时有效）")]
        public int TableColspan
        {
            get
            {
                object obj = XState["TableColspan"];
                return obj == null ? 1 : (int)obj;
            }
            set
            {
                XState["TableColspan"] = value;
            }
        }

        /// <summary>
        /// 控制子控件的位置（当本容器的Layout=VBox或者HBox时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(BoxLayoutAlign.Start)]
        [Description("控制子控件的位置（当本容器的Layout=VBox或者HBox时有效）")]
        public BoxLayoutAlign BoxConfigAlign
        {
            get
            {
                object obj = XState["BoxConfigAlign"];
                return obj == null ? BoxLayoutAlign.Start : (BoxLayoutAlign)obj;
            }
            set
            {
                XState["BoxConfigAlign"] = value;
            }
        }

        /// <summary>
        /// 控制子控件的位置（当本容器的Layout=VBox或者HBox时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(BoxLayoutPosition.Start)]
        [Description("控制子控件的位置（当本容器的Layout=VBox或者HBox时有效）")]
        public BoxLayoutPosition BoxConfigPosition
        {
            get
            {
                object obj = XState["BoxConfigPosition"];
                return obj == null ? BoxLayoutPosition.Start : (BoxLayoutPosition)obj;
            }
            set
            {
                XState["BoxConfigPosition"] = value;
            }
        }

        /// <summary>
        /// 内边距（当本容器的Layout=VBox或者HBox时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("0")]
        [Description("内边距（当本容器的Layout=VBox或者HBox时有效）")]
        public string BoxConfigPadding
        {
            get
            {
                object obj = XState["BoxConfigPadding"];
                return obj == null ? "0" : (string)obj;
            }
            set
            {
                XState["BoxConfigPadding"] = value;
            }
        }

        /// <summary>
        /// 子控件的外边距（当本容器的Layout=VBox或者HBox时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("0")]
        [Description("子控件的外边距（当本容器的Layout=VBox或者HBox时有效）")]
        public string BoxConfigChildMargin
        {
            get
            {
                object obj = XState["BoxConfigChildMargin"];
                return obj == null ? "0" : (string)obj;
            }
            set
            {
                XState["BoxConfigChildMargin"] = value;
            }
        }

        /// <summary>
        /// 控制子控件的尺寸（当父容器的Layout=VBox或者HBox时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(0)]
        [Description("控制子控件的尺寸（当父容器的Layout=VBox或者HBox时有效）")]
        public int BoxFlex
        {
            get
            {
                object obj = XState["BoxFlex"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                XState["BoxFlex"] = value;
            }
        }


        /// <summary>
        /// 外边距（当父容器的Layout=VBox或者HBox时有效）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("")]
        [Description("外边距（当父容器的Layout=VBox或者HBox时有效）")]
        public string BoxMargin
        {
            get
            {
                object obj = XState["BoxMargin"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["BoxMargin"] = value;
            }
        }

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();
            
            
            if (Width != Unit.Empty)
            {
                OB.AddProperty("width", Width.Value);
            }
            if (Height != Unit.Empty)
            {
                OB.AddProperty("height", Height.Value);
            }


            #region Controls in Layout

            Container parentControl = null;

            // 此面板放在用户控件中的情况
            if (Parent is UserControl)
            {
                if (Parent.Parent is UserControlConnector)
                {
                    parentControl = Parent.Parent.Parent as Container;
                }
            }
            else
            {
                parentControl = Parent as Container;
            }


            if (parentControl != null)
            {
                if (parentControl.Layout == Layout.Anchor)
                {
                    // 如果父节点是Anchor布局
                    if (!String.IsNullOrEmpty(AnchorValue))
                    {
                        OB.AddProperty("anchor", AnchorValue);
                    }
                }
                else if (parentControl.Layout == Layout.Column)
                {
                    if (!String.IsNullOrEmpty(ColumnWidth))
                    {
                        string columnWidth = StringUtil.ConvertPercentageToDecimalString(ColumnWidth);

                        // 1.00 在IE下会有BUG，把1.00转换为0.999
                        if (columnWidth == "1.00")
                        {
                            columnWidth = "0.999";
                        }
                        OB.AddProperty("columnWidth", columnWidth, true);
                    }
                }
                else if (parentControl.Layout == Layout.Absolute)
                {
                    if (AbsoluteX != Unit.Empty)
                    {
                        OB.AddProperty("x", AbsoluteX.Value);
                    }
                    if (AbsoluteY != Unit.Empty)
                    {
                        OB.AddProperty("y", AbsoluteY.Value);
                    }
                }
                else if (parentControl.Layout == Layout.Row)
                {
                    if (!String.IsNullOrEmpty(RowHeight))
                    {
                        string rowHeight = StringUtil.ConvertPercentageToDecimalString(RowHeight);

                        // 1.00 在IE下会有BUG，把1.00转换为0.999
                        if (rowHeight == "1.00")
                        {
                            rowHeight = "0.999";
                        }
                        OB.AddProperty("rowHeight", rowHeight, true);
                    }
                }
                else if (parentControl.Layout == Layout.Table)
                {
                    if (TableRowspan != 1)
                    {
                        OB.AddProperty("rowspan", TableRowspan);
                    }

                    if (TableColspan != 1)
                    {
                        OB.AddProperty("colspan", TableColspan);
                    }
                }
                else if (parentControl.Layout == Layout.HBox || parentControl.Layout == Layout.VBox)
                {
                    if (BoxFlex != 0)
                    {
                        OB.AddProperty("flex", BoxFlex);
                    }

                    // 用户可能会设置 BoxMargin="0" 来覆盖 BoxConfigChildMargin 属性。
                    if (BoxMargin != "")
                    {
                        OB.AddProperty("margins", BoxMargin);
                    }

                }
            }

            #endregion

        }

        #endregion

    }
}
