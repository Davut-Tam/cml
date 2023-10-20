using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Facade;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class OgrenciTaksitSecimListForm : BaseListForm
    {

        private bool _farklikisi;
        private bool _devam;
        public bool secim;
        public long OgrenciFormundanAcilmaOgrenciId;

        public List<OgrenciCariOdemeL> SecimListesi;

        Color clr = new Color();


        public OgrenciTaksitSecimListForm(bool secimFormuOlarakAcilma = false, long ogrenciFormundansecilmeOgrenciIdId = 0)
        {
            InitializeComponent();
            btnSmsGonder.Visibility = BarItemVisibility.Always;
            YetkiKontrol(Tag);
            Tablo = tablo;
            LblBilgi = lblBilgi;
            controlNavigator.NavigatableControl = Tablo.GridControl;
            SecimFormuOlarakAcilma = secimFormuOlarakAcilma;
            BaseEventLoad();

            btnSec.ItemClick += BtnSec_ItemClick;
            tablo.SelectionChanged += Tablo_SelectionChanged;
            btnYenile.ItemClick += BtnYenile_ItemClick;
            btnSmsGonder.ItemClick += BtnSmsGonder_ItemClick;


            OgrenciFormundanAcilmaOgrenciId = ogrenciFormundansecilmeOgrenciIdId;
            if (ogrenciFormundansecilmeOgrenciIdId != 0)
                Tablo.ViewCaption += " - " + OgrenciF.Secim(OgrenciFormundanAcilmaOgrenciId).AdiSoyadi;


            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;
            clr = txtDonemAdi.ForeColor;
            txtDonemAdi.AddItems(AnaForm.DonemId);
            _devam = true;
        }

        private void BtnSmsGonder_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tablo.DataRowCount <= 0 || tablo.FocusedRowHandle < -1) return;

            var tarih = Convert.ToDateTime(tablo.GetFocusedRowCellValue(colSonOdemeTarihi));
            if (tarih.Date > DateTime.Now.Date)
            {
                Messages.UyariMesaji("Seçili taksidin vade tarihi gelmediği için Sms gönderemezsiniz.");
                return;
            }

            using (var frm = new TaksitHatirlatmaSmsForm(OgrenciOdemePlaniF.Secim(Convert.ToInt64(tablo.GetFocusedRowCellValue(colId))),null))
                frm.ShowDialog();
            

        }

        private void Tablo_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //int sayi = 0;
            double taksit = 0;
            if (SecimFormuOlarakAcilma)
                foreach (int i in tablo.GetSelectedRows())
                    taksit += Convert.ToDouble(tablo.GetRowCellValue(i, colKAlan));

            lblBilgi1.Caption = "Seçilen Taksit Sayısı : " + tablo.SelectedRowsCount;
            lblBilgi2.Caption = "Seçilen Taksit Tutarı : " + taksit.ToString("n2");

        }


        public override void ButonGizle(bool secimFormuolarakAcilma)
        {
            base.ButonGizle(secimFormuolarakAcilma);
            btnYeni.Visibility = btnSil.Visibility = btnDuzelt.Visibility = BarItemVisibility.Never;
            lblBilgi1.Visibility = lblBilgi2.Visibility = secimFormuolarakAcilma ? BarItemVisibility.Always : BarItemVisibility.Never;
            tablo.OptionsSelection.MultiSelect = secimFormuolarakAcilma;


        }
        void Listele()
        {
            if (OgrenciFormundanAcilmaOgrenciId == 0)
                tablo.GridControl.DataSource = OgrenciOdemePlaniF.OdenmeyenTaksitlerListesiTumu((long)txtDonemAdi.EditValue);
            else
                tablo.GridControl.DataSource = OgrenciOdemePlaniF.OdenmeyenTaksitlerListesiTumuOgrenciyeGore(OgrenciFormundanAcilmaOgrenciId);


        }
        private void BtnYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            Listele();
        }


        private void BtnSec_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliKayitSecme();
        }

        void SeciliKayitSecme()
        {
            _farklikisi = false;
            if (tablo.DataRowCount <= 0) return;

            SecimListesi = new List<OgrenciCariOdemeL>();
            foreach (int i in tablo.GetSelectedRows())
            {
                var odemecari = new OgrenciCariOdemeL()
                {
                    Id = (long)tablo.GetRowCellValue(i, colId),
                    OgrenciId = (long)tablo.GetRowCellValue(i, colOgrenciId),
                    OdemePlaniId = (long)tablo.GetRowCellValue(i, colId),
                    AdiSoyadi = tablo.GetRowCellValue(i, colAdiSoyadi).ToString(),
                    TaksitNo = (int)tablo.GetRowCellValue(i, colTaksitNo),
                    Kalan = (decimal)tablo.GetRowCellValue(i, colKAlan),
                    TcKimlikNo = tablo.GetRowCellValue(i, colTcKimlik).ToString(),
                    DonemAdi = tablo.GetRowCellValue(i, colDonemAdi).ToString()
                };


                SecimListesi.Add(odemecari);
                if (SecimListesi.Count > 1)
                {
                    if (SecimListesi[0].OgrenciId != odemecari.OgrenciId)
                        _farklikisi = true;
                    continue;
                }

            }


            if (_farklikisi)
            {
                Messages.UyariMesaji("Seçim Listenizde Farklı Öğrenciler Var!! Sadece Aynı Öğrencinin Ödenmemiş Taksitleri Seçebilirsiniz.");
                return;
            }

            this.Close();
        }

        private void TxtDonemAdi_EditValueChanged(object sender, EventArgs e)
        {
            if (!_devam) return;
            if (AnaForm.DonemId != (long)txtDonemAdi.EditValue)
                txtDonemAdi.ForeColor = Color.Red;
            else
                txtDonemAdi.ForeColor = clr;
            Listele();
        }
    }
}
