
using DevExpress.XtraEditors;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Properties;
using OgrenciTakipMuh.Tools;
using System;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.GenelForms
{
    public partial class LoginForm : XtraForm
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public LoginForm()
        {
            InitializeComponent();

            var color = SeciliRenk();
            panelControl1.Appearance.BackColor2 = label1.ForeColor = Renk.ChangeColorBrightness(color, -0.4);
            pcLogo.Properties.Appearance.BorderColor = Renk.ChangeColorBrightness(color, 0.2);
            txtSifre.BackColor=txtKullaniciAdi.BackColor= Renk.ChangeColorBrightness(color, 0.8);
            Opacity = 0;
            timer1.Start();


            pcLogo.EditValue = VarsayilanAyarlarF.Secim().KurumLogo;
            long BilgisayarKullanicisi = KullaniciF.BeniHatirlaKontrolu();

            if (BilgisayarKullanicisi != 0)
            {
                KullaniciL kllnc = KullaniciF.Secim(BilgisayarKullanicisi);
                txtKullaniciAdi.Text = kllnc.KullaniciAdi;
                txtSifre.Text = kllnc.Sifre;
                chkBeniHatirla.Checked = true;
                panelControl1.Select();
                panelControl1.Focus();
            }

            label1.Text = "Versiyon :" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            
        }
        private Color SeciliRenk()
        {
            string color = Renk.Renkler[new Random().Next(0, Renk.Renkler.Count - 1)];
            return ColorTranslator.FromHtml(color);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            AnaForm.KullanicilId = KullaniciF.SifreKont(txtKullaniciAdi.Text, txtSifre.Text);
            if (AnaForm.KullanicilId > 0)
                timer2.Start();
            else
                Messages.UyariMesaji("Kullanıcı Adı veya Şifre Hatalı!");
        }

        private void TxtKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PanelControl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

 

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0.40) Opacity -= 0.10;
            else
            {
                timer2.Stop();
                Hide();
                
                AnaForm fr = new AnaForm();
                fr.Show();
                bool _SesAyar = AnaForm.GenAyr.KayitSesi;
                AnaForm.GenAyr.KayitSesi = false;
                KullaniciF.BeniHatirlaGuncelle(AnaForm.KullanicilId, chkBeniHatirla.Checked, Dns.GetHostName());
                AnaForm.GenAyr.KayitSesi = _SesAyar;
            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity < 0.95) Opacity += 0.05; else timer1.Stop();
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnGiris.PerformClick();
        }

        private void pcLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnGiris.PerformClick();
        }
    }
}