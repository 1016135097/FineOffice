
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    Accordion.cs
 * CreatedOn:   2008-06-12
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
    /// 手风琴控件
    /// </summary>
    [Designer("FineUI.Design.AccordionDesigner, FineUI.Design")]
    [ToolboxData("<{0}:Accordion Title=\"Accordion\" ShowCollapseTool=\"false\" ShowBorder=\"false\" ShowHeader=\"false\" runat=\"server\"><Panes><{0}:AccordionPane runat=\"server\" Title=\"AccordionPane1\" BodyPadding=\"5px\" ShowBorder=\"false\"></{0}:AccordionPane><{0}:AccordionPane runat=\"server\" Title=\"AccordionPane2\" BodyPadding=\"5px\" ShowBorder=\"false\"></{0}:AccordionPane></Panes></{0}:Accordion>")]
    [ToolboxBitmap(typeof(Accordion), "res.toolbox.Accordion.bmp")]
    [Description("手风琴控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Accordion : CollapsablePanel
    {
        #region Constructor

        public Accordion()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();
        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ControlBaseCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableIFrame
        {
            get
            {
                return base.EnableIFrame;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameUrl
        {
            get
            {
                return base.IFrameUrl;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameName
        {
            get
            {
                return base.IFrameName;
            }
        }

        /// <summary>
        /// 布局类型
        /// </summary>
        [ReadOnly(true)]
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(Layout.Accordion)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                return Layout.Accordion;
            }
        }


        #endregion

        #region Properties

        /// <summary>
        /// 是否启用折叠按钮
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用折叠按钮")]
        public bool ShowCollapseTool
        {
            get
            {
                object obj = XState["ShowCollapseTool"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["ShowCollapseTool"] = value;
            }
        }


        /// <summary>
        /// 是否启用激活在最上面
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用激活在最上面")]
        public bool EnableActiveOnTop
        {
            get
            {
                object obj = XState["EnableActiveOnTop"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableActiveOnTop"] = value;
            }
        }

        /// <summary>
        /// 是否启用填充整个区域
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用填充整个区域")]
        public bool EnableFill
        {
            get
            {
                object obj = XState["EnableFill"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableFill"] = value;
            }
        }


        //private bool EnableAnimate_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否启用动画")]
        //public bool EnableAnimate
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableAnimate"];
        //        return obj == null ? EnableAnimate_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableAnimate"] = value;
        //    }
        //}


        //private bool PersistActiveIndexInCookie_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("将ActiveIndex保持在Cookie中，以便在页面跳转过程中位置状态")]
        //public bool PersistActiveIndexInCookie
        //{
        //    get
        //    {
        //        object obj = BoxState["PersistActiveIndexInCookie"];
        //        return obj == null ? PersistActiveIndexInCookie_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["PersistActiveIndexInCookie"] = value;
        //    }
        //}


        #endregion

        #region ActiveIndex

        private int _activeIndex = -1;

        /// <summary>
        /// 激活面板的索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(0)]
        [Description("激活面板的索引")]
        public int ActiveIndex
        {
            get
            {
                int activeIndex = 0;
                for (int i = 0, count = Panes.Count; i < count; i++)
                {
                    if (!Panes[i].Collapsed)
                    {
                        activeIndex = i;
                        break;
                    }
                }
                return activeIndex;
            }
            set
            {
                // We cann't set children AccordionPane's Collapsed property now, because they may not been loaded yet.
                _activeIndex = value;
            }
        }


        #endregion

        #region Panes

        private AccordionPaneCollection _panes;

        /// <summary>
        /// 手风琴面板集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public AccordionPaneCollection Panes
        {
            get
            {
                if (_panes == null)
                {
                    _panes = new AccordionPaneCollection(this);
                }
                return _panes;
            }
        }

        #endregion

        #region old code

        //protected override void CreateChildControls()
        //{
        //    base.CreateChildControls();


        //    //foreach (AccordionPanel row in Items)
        //    //{
        //    //    row.RenderWrapperDiv = false;
        //    //    Controls.Add(row);
        //    //}
        //}

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Text"))
            //{
            //    sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(Text));
            //}

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            #region Reset ActiveIndex

            // ActiveIndex has been changed, reset Panes's Collapsed property.
            if (_activeIndex != -1)
            {
                foreach (AccordionPane pane in Panes)
                {
                    pane.Collapsed = true;
                }

                Panes[_activeIndex].Collapsed = false;
            }

            #endregion

            #region Panes

            if (Panes.Count > 0)
            {
                JsArrayBuilder ab = new JsArrayBuilder();
                foreach (AccordionPane item in Panes)
                {
                    if (item.Visible)
                    {
                        ab.AddProperty(String.Format("{0}", item.XID), true);
                    }
                }
                OB.AddProperty("items", ab.ToString(), true);
            }

            #endregion

            #region LayoutConfig

            JsObjectBuilder configBuilder = new JsObjectBuilder();
            configBuilder.AddProperty("animate", false);
            configBuilder.AddProperty("activeOnTop", EnableActiveOnTop);
            configBuilder.AddProperty("fill", EnableFill);
            configBuilder.AddProperty("hideCollapseTool", !ShowCollapseTool);
            //configBuilder.AddProperty(OptionName.TitleCollapse, true);
            //if (EnableLargeHeader)
            //{
            //    // 删除对CtCls的定义
            //    OB.RemoveProperty(OptionName.CtCls);
            //    configBuilder.AddProperty(OptionName.ExtraCls, "box-panel-big-header");
            //}

            OB.AddProperty("layoutConfig", configBuilder);

            #endregion


            string jsContent = String.Format("var {0}=new Ext.Panel({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

        #region override IPostBackDataHandler Members

        //public override bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        //{
        //    base.LoadPostData(postDataKey, postCollection);

        //    string postValue = postCollection[ActiveIndexHiddenFieldID];
        //    int postActiveIndex = Convert.ToInt32(postValue);
        //    if (ActiveIndex != postActiveIndex)
        //    {
        //        ActiveIndex = postActiveIndex;
        //    }

        //    return false;
        //}

        #endregion

    }
}
