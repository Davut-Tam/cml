using DevExpress.XtraEditors;
using OgrenciTakipMuh.Forms.GenelForms;
using System;
using System.ComponentModel;
using System.Drawing;

namespace OgrenciTakipMuh.Controls.Components
{
    public class MyTextEdit : TextEdit
    {
        [ToolboxItem(true)]
        public MyTextEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AppearanceFocused.ForeColor = Color.Black;
            Properties.MaxLength = 50;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (AnaForm.OtoKapanma)// otomatik kapanma açma
                AnaForm.OtoKapanmaZamani = AnaForm.OtoKapanmaSuresi;
        }

    }
}

