
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ToolbarItemsEditor.cs
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
    public class ToolbarItemsEditor : CollectionEditor
    {
        private Type[] types;

        public ToolbarItemsEditor(Type type)
            : base(type)
        {
            types = new Type[] { 
                typeof(ToolbarFill), 
                typeof(ToolbarSeparator), 
                typeof(ToolbarText), 
                typeof(Button), 
                typeof(SplitButton),
                typeof(CheckBox),
                typeof(CheckBoxList),
                typeof(Label),
                typeof(HyperLink),
                typeof(Image),
                typeof(LinkButton),
                typeof(RadioButton),
                typeof(RadioButtonList),
                typeof(DropDownList),
                typeof(DatePicker),
                typeof(FileUpload),
                typeof(HiddenField),
                typeof(NumberBox),
                typeof(TextArea),
                typeof(TextBox),
                typeof(TimePicker),
                typeof(TriggerBox),
                typeof(TwinTriggerBox)
            };
        }

        protected override Type[] CreateNewItemTypes()
        {
            return types;
        }

    }
}
