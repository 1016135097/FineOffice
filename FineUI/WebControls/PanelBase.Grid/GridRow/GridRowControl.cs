#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridRowControl.cs
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
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Globalization;


namespace FineUI
{
    /// <summary>
    /// ������Ϊģ���е����ݰ�������ʵ����IDataItemContainer�ӿ�
    /// </summary>
    [ToolboxItem(false)]
    public class GridRowControl : WebControl, IDataItemContainer, INamingContainer
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="dataItem">����Դ</param>
        /// <param name="rowIndex">������</param>
        public GridRowControl(object dataItem, int rowIndex)
        {
            _dataItem = dataItem;
            _dataItemIndex = _displayIndex = rowIndex;
            
        }

        #region RenderBeginTag

        /// <summary>
        /// ��Ⱦ��ʼ��ǩ
        /// </summary>
        /// <param name="writer">ASP.NET�������ؼ������</param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            //base.RenderBeginTag(writer);

            writer.Write(String.Format("<div class=\"x-grid-tpl\" id=\"{0}\">", ClientID));
        }

        /// <summary>
        /// ��Ⱦ������ǩ
        /// </summary>
        /// <param name="writer">ASP.NET�������ؼ������</param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            //base.RenderEndTag(writer);

            writer.Write("</div>");
        } 

        #endregion

        #region IDataItemContainer Members

        private object _dataItem;

        /// <summary>
        /// ����Դ��IDataItemContainer��Ա��
        /// </summary>
        public object DataItem
        {
            get { return _dataItem; }
        }

        private int _dataItemIndex;

        /// <summary>
        /// ������������IDataItemContainer��Ա��
        /// </summary>
        public int DataItemIndex
        {
            get { return _dataItemIndex; }
        }

        private int _displayIndex;

        /// <summary>
        /// �������ڿؼ�����ʾλ�õ�������IDataItemContainer��Ա��
        /// </summary>
        public int DisplayIndex
        {
            get { return _displayIndex; }
        }

        #endregion

    }
}



