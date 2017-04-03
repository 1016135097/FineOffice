
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridRowSelectEventArgs.cs
 * CreatedOn:   2013-02-27
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
    /// �����ѡ���¼�����
    /// </summary>
    public class GridRowSelectEventArgs : EventArgs
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
        public GridRowSelectEventArgs(int rowIndex)
        {
            _rowIndex = rowIndex;
        }

    }
}



