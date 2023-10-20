using System;
using System.Windows.Forms;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Facade;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Tools;
using OgrenciTakipMuh.Forms.ListForms;
using OgrenciTakipMuh.Data.Tools;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class VeliEditForm : BaseEditForm
    {
        private bool _yeniKayit;
        public bool kayitVar;
        public Veli ogr;
        public VeliL veliL;


        public VeliEditForm(long id)
        {
            InitializeComponent();
            Id = id;
            txtMeslakAdi.Properties.DataSource = GorevF.Liste();
            txtDonemAdi.AddItems(AnaForm.DonemId);
            txtDonemAdi.EditValue = AnaForm.DonemId;
            if (Id > 0)
            {
                veliL = VeliF.Secim(Id);
                txtAdiSoyadi.Text = veliL.VeliAdiSoyadi;
                txtTcKimlikNo.Text = veliL.TcKimlikNo;
                txtTelefon.Text = veliL.Telefon;
                txtAciklama.Text = veliL.Aciklama;
                txtMeslakAdi.EditValue = veliL.GorevId;
                txtAdres.Text = veliL.Adres;
                tglDurum.IsOn = veliL.Durum;
               
                this.Text += " ( Kayıt Güncelleme )";
                btnKaydet.Text = "Güncelle";
                _yeniKayit = false;
            }
            else
            {
                btnSil.Enabled = false;
                this.Text += " ( Yeni Kayıt )";
                _yeniKayit = true;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Veli veli = new Veli
            {
                Id = GenelFunctions.IdOlustur(),
                VeliAdiSoyadi = txtAdiSoyadi.Text,
                TcKimlikNo = txtTcKimlikNo.Text,
                Telefon = txtTelefon.EditValue==null?null: txtTelefon.Text==""?null: txtTelefon.Text,
                Adres = txtAdres.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn,
                GorevId=Convert.ToInt64( txtMeslakAdi.EditValue),
                KullaniciId = AnaForm.KullanicilId,
                IslemTarihi = DateTime.Now
            };

            try
            {
                if (_yeniKayit)
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Yeni Kayıt Yapılacak Onaylıyor musunuz", "Yeni Kayıt") == DialogResult.No)
                        return;
                    kayitVar = VeliF.Ekle(veli);
                }

                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    kayitVar = VeliF.Guncelle(veli, Id);
                }
            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
            }
            if (kayitVar)
            {

                this.Close();
                Id = veli.Id;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                kayitVar = VeliF.Sil(Id);
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                kayitVar = false;
            }
            if (kayitVar)
                this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            kayitVar = false;
            Close();
        }


        private void MySimpleButton1_Click(object sender, EventArgs e)
        {
            MeslekListForm fr = new MeslekListForm() { Text = "Meslek Seç" };
            fr.SecimFormuOlarakAcilma = true;
            fr.ShowDialog();
            if (fr.SeciliId <= 0) { fr.Dispose(); return; }
            txtMeslakAdi.Properties.DataSource = GorevF.Liste();
            txtMeslakAdi.EditValue = fr.SeciliId;
            fr.Dispose();
        }

        private void txtDonemAdi_EditValueChanged(object sender, EventArgs e)
        {
            tablo.GridControl.DataSource = OgrenciF.VeliOgrenciListe(Id,Convert.ToInt64(txtDonemAdi.EditValue));
        }
    }
}