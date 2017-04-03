
#region Comment

/*
 * Project��    FineUI
 * 
 * FileName:    GridCommandEventArgs.cs
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
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;


namespace FineUI
{
    /// <summary>
    /// ����������¼�����
    /// </summary>
    public class GridCommandEventArgs : EventArgs
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

        private int _columnIndex;

        /// <summary>
        /// ������
        /// </summary>
        public int ColumnIndex
        {
            get { return _columnIndex; }
            set { _columnIndex = value; }
        }


        private string _commandName;

        /// <summary>
        /// ��������
        /// </summary>
        public string CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }


        private string _commandArgument;

        /// <summary>
        /// �������
        /// </summary>
        public string CommandArgument
        {
            get { return _commandArgument; }
            set { _commandArgument = value; }
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="rowIndex">������</param>
        /// <param name="columnIndex">������</param>
        /// <param name="commandName">��������</param>
        /// <param name="commandArgument">�������</param>
        public GridCommandEventArgs(int rowIndex, int columnIndex, string commandName, string commandArgument)
        {
            _rowIndex = rowIndex;
            _columnIndex = columnIndex;
            _commandName = commandName;
            _commandArgument = commandArgument;
        }

    }
}



