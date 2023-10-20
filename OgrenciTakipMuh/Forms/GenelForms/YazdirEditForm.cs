using System;
using OgrenciTakipMuh.Tools;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using OgrenciTakipMuh.Forms.BaseForms;

namespace OgrenciTakipMuh.Forms.GenelForms
{
    public partial class YazdırEditForm : BaseEditForm
    {
        private GridView _tablo;
        private string _donemAdi;
        public YazdırEditForm(GridView tablo, string donemAdi = null)
        {
            InitializeComponent();
            _tablo = tablo;
            _donemAdi = donemAdi;
            Yukle();
        }


        void Yukle()
        {
            txtRaporBasligi.Text = _tablo.ViewCaption;
            txtYaziciAdi.Properties.Items.AddRange(GenelFunctions.YaziciListesi());
            txtYaziciAdi.EditValue = GenelFunctions.VarsayilanYazici();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrintFunctions.Yazdir(_tablo, YaziciAyarlariOlustur("Tablo Yazdır"));
            this.Close(); ;
        }

        private void btnBaskiOnizleme_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrintFunctions.Yazdir(_tablo, YaziciAyarlariOlustur("Tablo Önizleme"));
            this.Close();
        }

        private YazdirmaAyarlari YaziciAyarlariOlustur(string yazNes)
        {
            var yazAyr = new YazdirmaAyarlari
            {
                RaporBaslik = txtRaporBasligi.Text,
                BaslikEkle = txtBaslikEkle.Text,
                RaporuKagidaSigdir = txtRaporuKagidaSigdir.Text,
                YazdirmaYonu = txtYazdirmaYonu.Text,
                YatayCizgileriGoster = txtYatayCizgileriGoster.Text,
                DikeyCizgileriGoster = txtDikeyCizgileriGoster.Text,
                SutunBasliklariniGoster = txtSutunBasliklariniGoster.Text,
                YaziciAdi = txtYaziciAdi.Text,
                YazdirilacakAdet = (int)txtYazdirilacakAdet.Value,
                YazdirilacakNesne = yazNes// rapor olursa tekrar güncellenecek
            };
            return yazAyr;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBaslikEkle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Text == "Hayır")
            {
                txtRaporBasligi.Text = "";
                txtRaporBasligi.Enabled = false;
            }
            else
            {
                txtRaporBasligi.Text = _tablo.ViewCaption;
                txtRaporBasligi.Enabled = true;
            }
               
        }
    }
}