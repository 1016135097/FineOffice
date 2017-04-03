
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    MenuItemsEditor.cs
 * CreatedOn:   2013-01-02
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
using System.Text;
using System.ComponentModel.Design;

namespace FineUI
{
    public class MenuItemsEditor : CollectionEditor
    {
        private Type[] types;

        public MenuItemsEditor(Type type)
            : base(type)
        {
            types = new Type[] { 
                typeof(MenuButton), 
                typeof(MenuCheckBox), 
                typeof(MenuHyperLink), 
                typeof(MenuSeparator), 
                typeof(MenuText)
            };
        }

        protected override Type[] CreateNewItemTypes()
        {
            return types;
        }

    }
}
