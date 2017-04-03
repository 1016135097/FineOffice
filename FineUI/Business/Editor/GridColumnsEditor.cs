
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    GridColumnsEditor.cs
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
    public class GridColumnsEditor : CollectionEditor
    {
        private Type[] types;

        public GridColumnsEditor(Type type)
            : base(type)
        {
            types = new Type[] { 
                typeof(BoundField), 
                typeof(CheckBoxField), 
                typeof(HyperLinkField), 
                typeof(TemplateField), 
                typeof(ImageField),
                typeof(WindowField),
                typeof(LinkButtonField)
            };
        }

        protected override Type[] CreateNewItemTypes()
        {
            return types;
        }

    }
}
