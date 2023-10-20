using System;
using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
namespace OgrenciTakipMuh.Controls.Components
{
    [ToolboxItem(true)]
    public class MyTcKimlikNoTextEdit : MyTextEdit
    {
        public MyTcKimlikNoTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"\d?\d?\d? \d?\d?\d? \d?\d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;
        }

    }
}
