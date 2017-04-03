
#region Comment

/*
 * Project£º    FineUI
 * 
 * FileName:    WindowCloseEventArgs.cs
 * CreatedOn:   2008-06-27
 * CreatedBy:   30372245@qq.com
 * 
 * 
 * Description£º
 *      ->
 *   
 * History£º
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
    
    public class WindowCloseEventArgs : EventArgs
    {

        private string _closeArgument;

        public string CloseArgument
        {
            get { return _closeArgument; }
            set { _closeArgument = value; }
        }


        public WindowCloseEventArgs(string closeArgument)
        {
            _closeArgument = closeArgument;
        }

    }
}



