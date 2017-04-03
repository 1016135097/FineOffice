
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridRowClickEventArgs.cs
 * CreatedOn:   2008-06-25
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


namespace FineUI
{
    /// <summary>
    /// ����е���¼�����
    /// </summary>
    public class GridRowClickEventArgs : EventArgs
    {

        private int _rowIndex;

        /// <summary>
        /// ������
        /// </summary>
        public int RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="rowIndex">������</param>
        public GridRowClickEventArgs(int rowIndex)
        {
            _rowIndex = rowIndex;
        }

    }
}



