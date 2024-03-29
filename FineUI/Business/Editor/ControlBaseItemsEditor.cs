﻿
#region Comment

/*
 * Project：    FineUI
 * 
 * FileName:    ControlBaseItemsEditor.cs
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
    public class ControlBaseItemsEditor : CollectionEditor
    {
        private Type[] types;

        public ControlBaseItemsEditor(Type type)
            : base(type)
        {
            types = new Type[] { 
                typeof(Button), 
                typeof(Calendar), 
                typeof(SplitButton), 
                typeof(Timer), 
                typeof(UserControlConnector),
                typeof(CheckBox),
                typeof(CheckBoxList),
                typeof(HtmlEditor),
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
                typeof(TwinTriggerBox),
                typeof(Accordion),
                typeof(ContentPanel),
                typeof(Form),
                typeof(GroupPanel),
                typeof(Panel),
                typeof(SimpleForm),
                typeof(Tree),
                typeof(Window),
                typeof(Grid),
                typeof(RegionPanel),
                typeof(TabStrip)
            };
        }

        protected override Type[] CreateNewItemTypes()
        {
            return types;
        }

    }
}
