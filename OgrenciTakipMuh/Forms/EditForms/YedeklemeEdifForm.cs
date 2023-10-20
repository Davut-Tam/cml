using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class YedeklemeEdifForm : BaseEditForm
    {

        public YedeklemeEdifForm()
        {
           
            InitializeComponent();
            txtYdeklemeDizini.Text = VarsayilanAyarlarF.Secim() != null ? VarsayilanAyarlarF.Secim().YedeklemeYolu : "";
            txtYedeklemeMailAdres.Text = AnaForm.GenAyr.OtoYedeklemeMailAdres;
            EventLoad();
            tablo.GridControl.DataSource = YedeklemeKayitlariF.Liste();
        }

   
        void EventLoad()
        {
            txtYdeklemeDizini.ButtonClick += TxtYdeklemeDizini_ButtonClick;
            btnIptal.Click += BtnIptal_Click;
            btnYedekAl.Click += BtnYedekAl_Click;
        }

        private void BtnYedekAl_Click(object sender, EventArgs e)
        {
            try
            {
                if (YedeklemeKayitlariF.YedekAl(txtYdeklemeDizini.Text, "Manuel Yedekleme"))
                {
                    tablo.GridControl.DataSource = YedeklemeKayitlariF.Liste();
                    if (Messages.SoruHayirSeciliEvetHayir($"Veri Tabanı Yedeklendi... \n\"{txtYedeklemeMailAdres.Text}\" adresine e-meil olarakta yedeklemek istermisiniz?", "Yedekleme") == DialogResult.No) return;
                    // İnternet Kontrolü
                    if (!NetworkInterface.GetIsNetworkAvailable())
                    {
                        Messages.UyariMesaji("İnternet Bağlantınız Yok...");
                        return;
                    }
                    Cursor.Current = Cursors.WaitCursor;
                    MailFunctions.MailGonder(txtYedeklemeMailAdres.Text, YedeklemeKayitlariF.yedeklemeyolu + "MuhData.zip", "Veri Tabanı Yedekleme");
                    Messages.BilgiMesaji("e-mail Yedeklemesi Başarılı");

                }
            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
            }
 


        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtYdeklemeDizini_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtYdeklemeDizini.Text = folderBrowserDialog1.SelectedPath;
            }
        }


    }
}
