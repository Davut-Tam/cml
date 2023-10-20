using DevExpress.XtraLayout.Utils;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.ListForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Properties;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class FaturaEditForm : BaseEditForm
    {
        public static long SeciliId;
        public bool _yeniKayit;
        public bool KayitVar;
        private string _belgeTuru;
        private FaturaL ftrL;
        private long _faturaId;
        private bool _goruntuleme;

        List<FaturaDetayL> DetayListe = new List<FaturaDetayL>();


        public FaturaEditForm(string belgeTuru, bool goruntuleme = false)
        {
            InitializeComponent();
            _belgeTuru = belgeTuru;
            _goruntuleme = goruntuleme;
            if (_goruntuleme)
                FormuGoruntuOlarakAcma();
            txtKayitTarihi.DateTime = DateTime.Now;
            EventLoad();
            controlNavigator.NavigatableControl = tablo.GridControl;
            txtBelgeTarihi.Properties.MaxValue = txtKayitTarihi.Properties.MaxValue = DateTime.Now.Date;
            txtBelgeTarihi.Text = "";
        }


        private void FaturaEditForm_Load(object sender, EventArgs e)
        {

            if (FaturaListForm.SeciliId > 0)
            {
                _faturaId = FaturaListForm.SeciliId;
                ftrL = FaturaF.Secim(_faturaId);

                txtBelgeTipi.Text = ftrL.BelgeTipi;
                txtBelgeNo.Text = ftrL.BelgeNo;
                txtBelgeTarihi.EditValue = ftrL.BelgeTarihi;
                txtKayitTarihi.EditValue = ftrL.BelgeKayitTarihi;
                chVeli.Checked = ftrL.Veli;
                if (ftrL.Veli)
                    txtFirmaKisiAdi.Text = VeliF.Secim(ftrL.FirmaId).VeliAdiSoyadi;

                else
                    txtFirmaKisiAdi.Text = FirmaF.Secim(ftrL.FirmaId).FirmaAdi;

                txtFirmaKisiAdi.Tag = ftrL.FirmaId;
                txtAciklama.Text = ftrL.Aciklama;

                DetayListe = (List<FaturaDetayL>)FaturaF.DetayListe(_faturaId);
                tablo.GridControl.DataSource = DetayListe;
                GenelToplamlarHesapla();

                if (_goruntuleme)
                    Text += " ( Görüntüleme )";
                else
                    Text += " ( Kayıt Güncelleme )";

                btnKaydet.Text = "Güncelle";
                _yeniKayit = false;

            }
            else
            {
                btnSil.Enabled = false;
                this.Text += " ( Yeni Kayıt )";
                _yeniKayit = true;
                _faturaId = GenelFunctions.IdOlustur();
            }
        }

        void EventLoad()
        {
            txtBelgeTipi.TextChanged += TxtBelgeTipi_TextChanged;

            btnKaydet.Click += BtnKaydet_Click;
            btnSil.Click += BtnSil_Click;
            btnIptal.Click += BtnIptal_Click;
            btnSatirEkle.Click += BtnSatirEkle_Click;
            btnSatirSil.Click += BtnSatirSil_Click;
            btnYenile.Click += BtnYenile_Click;

            txtFirmaKisiAdi.ButtonClick += TxtFirmaKisiAdi_ButtonClick;
            tablo.MouseUp += Tablo_MouseUp;
            tablo.CellValueChanged += Tablo_CellValueChanged;

            btnPSatirEkle.ItemClick += BtnSatirEkle_Click;
            btnPSatirSil.ItemClick += BtnSatirSil_Click;
            btnPYenile.ItemClick += BtnPYenile_ItemClick;

            chVeli.CheckedChanged += ChVeli_CheckedChanged;

        }

        private void ChVeli_CheckedChanged(object sender, EventArgs e)
        {
            txtFirmaKisiAdi.Text = "";
            txtFirmaKisiAdi.Tag = 0;
        }


        void FormuGoruntuOlarakAcma()
        {
            for (int i = 0; i < tablo.Columns.Count; i++)
            {
                tablo.Columns[i].OptionsColumn.AllowEdit = false;
                tablo.Columns[i].OptionsColumn.AllowFocus = false;
            }
            
            lytKaydet.Visibility = lytIptal.Visibility = lytSil.Visibility = LayoutVisibility.Never;
            chVeli.ReadOnly=txtBelgeTipi.ReadOnly = txtFirmaKisiAdi.ReadOnly = txtKayitTarihi.ReadOnly = txtBelgeTarihi.ReadOnly = txtBelgeNo.ReadOnly = txtAciklama.ReadOnly = true;
            panelControl1.Enabled = false;
            myGridControl1.Select();
            myGridControl1.Focus();
        }
        private void BtnYenile_Click(object sender, EventArgs e)
        {
            tablo.GridControl.DataSource = DetayListe;
            tablo.RefreshData();
        }

        private void Tablo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            controlNavigator.Buttons.DoClick(controlNavigator.Buttons.EndEdit);
            GenelToplamlarHesapla();
        }

        private void BtnPYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tablo.GridControl.DataSource = DetayListe;
            tablo.RefreshData();
        }


        private void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            if (_goruntuleme) return;
            btnPSatirSil.Enabled = tablo.RowCount > 0;// gösterilen row sayısı 0 dan küçükse pasifleştir
            e.ShowPopupMenu(popupMenu1);
        }

        private void BtnSatirSil_Click(object sender, EventArgs e)
        {
            if (tablo.FocusedRowHandle < 0) return;
            if (tablo.RowCount <= 0) return;

            DetayListe.RemoveAt(tablo.FocusedRowHandle);
            GenelToplamlarHesapla();

        }

        private void BtnSatirEkle_Click(object sender, EventArgs e)
        {
            long YeniId = GenelFunctions.IdOlustur();
            int YeniSira;

            if (DetayListe.Count <= 0)
                YeniSira = 1;
            else
                YeniSira = DetayListe[DetayListe.Count - 1].Sira + 1;


            FaturaDetayL ftrDty = new FaturaDetayL
            {
                Id = YeniId,
                FaturaId = _faturaId,
                Sira = YeniSira,
                IslemTarihi = DateTime.Now,
                KullaniciId = AnaForm.KullanicilId
            };
            DetayListe.Add(ftrDty);
            tablo.GridControl.DataSource = DetayListe;
            tablo.RefreshData();
            tablo.MoveLast();
            tablo.Focus();

        }

        private void TxtFirmaKisiAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (_goruntuleme) return;
            if (!chVeli.Checked)
            {
                FirmaListForm fr = new FirmaListForm(true);
                fr.ShowDialog();

                txtFirmaKisiAdi.Text = fr.FirmaAdi;
                txtFirmaKisiAdi.Tag = fr.FirmaId;
                fr.Dispose();
            }
            else
            {
                VeliListForm fr = new VeliListForm(true);
                fr.ShowDialog();
                if (fr.SeciliId == 0) return;
                var veli = VeliF.Secim(fr.SeciliId);
                txtFirmaKisiAdi.Text = veli.VeliAdiSoyadi;
                txtFirmaKisiAdi.Tag = fr.SeciliId;
                fr.Dispose();
            }


        }

        private void TxtBelgeTipi_TextChanged(object sender, EventArgs e)
        {
            if (txtBelgeTipi.Text == "Fatura")
            {
                lblBelgeNo.Text = "Fatura No";
                lblBelgeTarihi.Text = "Fatura Tarihi";
                colKdv.OptionsColumn.AllowEdit = true;
            }
            else
            {
                lblBelgeNo.Text = "Fİş No";
                lblBelgeTarihi.Text = "Fiş Tarihi";
                colKdv.OptionsColumn.AllowEdit = false;
            }
        }
        private void BtnIptal_Click(object sender, EventArgs e)
        {
            KayitVar = false;
            Close();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                KayitVar = FaturaF.Sil(_faturaId);
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
                KayitVar = false;
            }

            if (KayitVar)
                this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {


            try
            {
                Fatura ftr = new Fatura
                {
                    Id = _faturaId,
                    BelgeTipi = txtBelgeTipi.Text,
                    BelgeNo = txtBelgeNo.Text,
                    BelgeTarihi = txtBelgeTarihi.DateTime,
                    BelgeTuru = _belgeTuru,
                    FirmaId = Convert.ToInt64(txtFirmaKisiAdi.Tag),
                    BelgeKayitTarihi = txtKayitTarihi.DateTime,
                    Aciklama = txtAciklama.Text,
                    KullaniciId = AnaForm.KullanicilId,
                    IslemTarihi = DateTime.Now,
                    Veli = chVeli.Checked
                };

                if (_yeniKayit)
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Yeni Kayıt Yapılacak Onaylıyor musunuz", "Yeni Kayıt") == DialogResult.No)
                        return;
                    KayitVar = FaturaF.Ekle(ftr, DetayListe);
                }

                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    KayitVar = FaturaF.Guncelle(ftr, _faturaId, DetayListe);
                }
            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
            }
            if (KayitVar)
                this.Close();


        }



        private void RepMalHizmetAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            MalHizmetListForm fr = new MalHizmetListForm() { Text = "Mal - Hizmet Seç" };
            fr.SecimFormuOlarakAcilma = true;
            fr.ShowDialog();

            if (fr.MalHizmetId == 0) return;
            DetayListe[tablo.FocusedRowHandle].MalHizmetAdi = fr.MalHizmetAdi;
            DetayListe[tablo.FocusedRowHandle].MalHizmetId = fr.MalHizmetId;
            DetayListe[tablo.FocusedRowHandle].MiktarBrim = MalHizmetF.Secim(fr.MalHizmetId).MiktarBrim;
            tablo.RefreshData();
            tablo.FocusedColumn = tablo.Columns["Miktar"];
            fr.Dispose();
        }


        void GenelToplamlarHesapla()
        {
            tablo.RefreshData();
            decimal TopIskonto = 0;
            decimal TopTutar = 0;
            decimal TopKdv = 0;

            int a = 1;

            foreach (var item in DetayListe)
            {
                item.Sira = a;
                TopIskonto += item.IskontoTutari;
                TopTutar += item.Tutar;
                TopKdv += (item.Tutar - item.IskontoTutari) * item.KdvOrani / 100;
                a++;
            }
            txtToplamTutar.EditValue = TopTutar;
            txtToplamIskonto.EditValue = TopIskonto;
            txtToplamKdv.EditValue = TopKdv;
            txtOdenecek.EditValue = TopTutar - TopIskonto + TopKdv;
        }


    }
}
