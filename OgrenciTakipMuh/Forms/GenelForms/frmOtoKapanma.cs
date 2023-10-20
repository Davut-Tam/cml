using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace OgrenciTakipMuh.Forms.GenelForms
{
    public partial class frmOtoKapanma : DevExpress.XtraEditors.XtraForm
    {
        int kalan = 10;
        public frmOtoKapanma()
        {
            InitializeComponent();
            lblkapanmaSuresi.Text = kalan.ToString() + " sn Sonra Program Otomatik Kapanacak...";
            timer1.Start();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            AnaForm.OtoKapanmaZamani = AnaForm.OtoKapanmaSuresi;
            this.Close();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            kalan--;
     
            lblkapanmaSuresi.Text = kalan.ToString() + " sn Sonra Program Otomatik Kapanacak...";

            if (kalan <= 5)
            {
                lblkapanmaSuresi.ForeColor = Color.Red;
                SoundPlayer audio = new SoundPlayer(Properties.Resources.sonsayim);
                audio.Play();
            }
            if (kalan <= 0)
            {
                this.Hide();
                Application.Exit();
            }
             
            else
                timer1.Start();
        }

      
    }
}