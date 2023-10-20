using DevExpress.XtraEditors;
using OgrenciTakipMuh.Forms.GenelForms;
using System;
using System.ComponentModel;
using System.Drawing;

namespace OgrenciTakipMuh.Controls.Components
{
    [ToolboxItem(true)]
    public class MyMemoEdit : MemoEdit
    {
        public MyMemoEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AppearanceFocused.ForeColor = Color.Black;
            Properties.MaxLength = 500;
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
