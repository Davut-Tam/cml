using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.EditForms
{

    public partial class PersonelTahakkukEditForm : BaseEditForm
    {
        private bool _yeniKayit = true;
        private long _personelId;
        private long _IslemId;
        public bool KayitVar;

        public PersonelTahakkukEditForm(long personelId)
        {
            InitializeComponent();
            YetkiKontrol(Tag);
            EventLoad();
            _personelId = personelId;
            PersonelBilgileri();
        }

        void PersonelBilgileri()
        {
            PersonelL prsl = PersonelF.Secim(_personelId);
            txtAdiSoyadi.Text = prsl.AdiSoyadi;
            txtTcKimlikNo.Text = prsl.TcKimlikNo;
            txtGorev.Text = prsl.GorevAdi;
            txtMaas.Text = prsl.Maas.ToString("n2");


            txtBaslamaTarihi.Text = prsl.BaslamaTarihi.ToString("d");
            txtToplamHakedilen.Text = prsl.HakedilenMaas.ToString("n2");
            txtToplamOdenen.Text = prsl.OdenenMaas.ToString("n2");
            txtBakiye.Text = prsl.KalanBakiye.ToString("n2");
            txtToplamIade.Text = prsl.ToplamIade.ToString("n2");
            myPictureEdit1.EditValue = prsl.Resim;

            txtMaasNo.Text = PersonelOdemePlaniF.TahakkukNoBul(_personelId).ToString();
            Listele();

        }
        void Listele()
        {
            tabloCariHareket.GridControl.DataSource = PersonelOdemePlaniF.CariHareket(_personelId);
            tabloOdemePlani.GridControl.DataSource = PersonelOdemePlaniF.OdemePlaniListesi(_personelId);
        }
        void EventLoad()
        {

            tabloOdemePlani.MouseUp += TabloOdemePlani_MouseUp;

            btnListedenSil.ItemClick += BtnListedenSil_ItemClick;
            btnGuncelle.ItemClick += BtnGuncelle_ItemClick;

            btnEkle.Click += BtnKaydet_Click;
            btnIptal.Click += BtnIptal_Click;
            btnSil.Click += BtnSil_Click;

            txtMaasTuru.TextChanged += TxtMaasTuru_TextChanged;
            txtBakiye.TextChanged += TxtBakiye_TextChanged;
        }

        private void TxtBakiye_TextChanged(object sender, EventArgs e)
        {
            if (txtBakiye.Text.ToDouble() <= 0)
                txtBakiye.ForeColor = Color.Red;
            else
                txtBakiye.ForeColor = Color.Green;

        }

        private void TxtMaasTuru_TextChanged(object sender, EventArgs e)
        {
            if (txtMaasTuru.Text == "Maaş")
            {
                Personel prs = PersonelF.Secim(_personelId);
                try { try { try { txtSonOdemeTarihi.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, prs.MaasOdemeGunu); } catch (Exception) { txtSonOdemeTarihi.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, prs.MaasOdemeGunu - 1); } } catch (Exception) { txtSonOdemeTarihi.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, prs.MaasOdemeGunu - 2); } } catch (Exception) { txtSonOdemeTarihi.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, prs.MaasOdemeGunu - 3); }
                txtTahakkukTutari.Value = prs.Maas;
                txtTahakkukTutari.Enabled = txtSonOdemeTarihi.Enabled = false;
            }
            else
            {
                txtSonOdemeTarihi.Text = "";
                txtTahakkukTutari.Text = "";
                txtTahakkukTutari.Enabled = txtSonOdemeTarihi.Enabled = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (!Silebilir) { Messages.YetkinizYokMesaji(); return; }
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            if (KayitVar = PersonelOdemePlaniF.Sil(_IslemId))
                PersonelBilgileri();
            Temizle();
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            if (btnEkle.Text == "Güncelle")
                Temizle();
            else
                Close();

        }

        void Temizle()
        {
            _yeniKayit = true;
            btnEkle.Text = "Ekle";
            btnSil.Enabled = false;
            txtMaasNo.Text = "";
            txtMaasTuru.Text = "";
            txtTahakkukTutari.Text = "";
            txtSonOdemeTarihi.Text = "";
            txtTahakkukAciklama.Text = "";
            _IslemId = 0;
        }
        private void BtnGuncelle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _IslemId = (long)tabloOdemePlani.GetFocusedRowCellValue("Id");
            PersonelOdemePlani Op = PersonelOdemePlaniF.Secim(_IslemId);
            _yeniKayit = false;
            btnEkle.Text = "Güncelle";
            btnSil.Enabled = true;
            txtMaasNo.Text = Op.TahakkukNo.ToString();
            txtMaasTuru.Text = Op.Tur;
            txtTahakkukTutari.Value = Op.Maas;
            txtSonOdemeTarihi.DateTime = Op.SonOdemeTarihi;
            txtTahakkukAciklama.Text = Op.Aciklama;



        }

        private void BtnListedenSil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            if (KayitVar = PersonelOdemePlaniF.Sil((long)tabloOdemePlani.GetFocusedRowCellValue("Id")))
                PersonelBilgileri();
        }

        private void TabloOdemePlani_MouseUp(object sender, MouseEventArgs e)
        {
            btnListedenSil.Enabled = btnGuncelle.Enabled = tabloOdemePlani.RowCount > 0;// gösterilen row sayısı 0 dan küçükse pasifleştir
            if (tabloOdemePlani.RowCount > 0)
                e.ShowPopupMenu(popupMenu1);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (Messages.SoruEvetSeciliEvetHayir("Yeni Kayıt Yapılacak Onaylıyor musunuz", "Yeni Kayıt") == DialogResult.No) return;


            try
            {
                PersonelOdemePlani prsO = new PersonelOdemePlani
                {
                    Id = GenelFunctions.IdOlustur(),
                    TahakkukNo = PersonelOdemePlaniF.TahakkukNoBul(_personelId),
                    PersonelId = _personelId,
                    SonOdemeTarihi = txtSonOdemeTarihi.DateTime,
                    Maas = txtTahakkukTutari.Value,
                    Aciklama = txtTahakkukAciklama.Text,
                    KullaniciId = AnaForm.KullanicilId,
                    IslemTarihi = DateTime.Now,
                    Tur = txtMaasTuru.Text,
                    OtomatikMaas = false
                };

                if (_yeniKayit)
                {
                    if (!Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
                    KayitVar = PersonelOdemePlaniF.Ekle(prsO);
                }

                else
                {
                    if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
                    KayitVar = PersonelOdemePlaniF.Guncelle(prsO, _IslemId);
                }
                

                PersonelBilgileri();
                Temizle();

            }
            catch (Exception ex)
            {

                Messages.UyariMesaji(ex.Message);
            }



        }
    }
}
