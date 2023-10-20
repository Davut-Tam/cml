using DevExpress.XtraEditors.Mask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakipMuh.Controls.Components
{
   public class MyIbanNo:MyTextEdit
    {
        public MyIbanNo()
        {
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"TR\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;

        }
    }
}
