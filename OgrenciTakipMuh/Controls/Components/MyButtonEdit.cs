using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Drawing;
using System;
using System.ComponentModel;

namespace OgrenciTakipMuh.Controls.Components
{
    [ToolboxItem(true)]
    public class MyButtonEdit : ButtonEdit
    {

        public MyButtonEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;// Text kısmına yazıyı engelleme
            Properties.AppearanceFocused.BackColor = Color.LightCyan;// Fkuslanınca Arka Plan Değiştirme
            this.KeyDown += MyButtonEdit_KeyDown;

        }

        private void MyButtonEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                this.Tag = 0;
                this.Text = "";
            }
        }

        public override bool EnterMoveNextControl { get; set; } = true; // Entere Basılınca Sonraki Kontrole geçme override ile default özellik değiştirme

    }


}
