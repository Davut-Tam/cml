using System;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Data.Facade;
using DevExpress.XtraBars;
using OgrenciTakipMuh.Forms.EditForms;
using System.Collections.Generic;
using OgrenciTakipMuh.Data.Entities.Entity;
using System.Linq;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class OgrenciHatirlatma : BaseListForm
    {
        List<OgrenciCariOdemeL> list;
        public OgrenciHatirlatma()
        {
            InitializeComponent();
            Tablo = tablo;
            LblBilgi = lblBilgi;
            controlNavigator.NavigatableControl = Tablo.GridControl;
            list = OgrenciOdemePlaniF.OdenmeyenTaksitlerListesiTumu();
            txtTarih.DateTime = DateTime.Now;
            Eventload();
         

            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;
            Listele();
        }

        public override void ButonGizle(bool secimFormuolarakAcilma)
        {
            base.ButonGizle(secimFormuolarakAcilma);
            btnYeni.Visibility = btnSil.Visibility = btnDuzelt.Visibility = BarItemVisibility.Never;
            btnSmsGonder.Visibility = BarItemVisibility.Always;
        }

        void Eventload()
        {
            BaseEventLoad();
            btnYenile.ItemClick += BtnYenile_ItemClick;
            btnSmsGonder.ItemClick += BtnSmsGonder_ItemClick;
            chbTarihAraligi.CheckedChanged += ChbTarihAraligi_CheckedChanged;
            txtTarih.EditValueChanged += TxtTarih_EditValueChanged;
            txtBaslama.EditValueChanged += TxtBaslama_EditValueChanged;
            txtBitis.EditValueChanged += TxtBaslama_EditValueChanged;
        }

        private void TxtBaslama_EditValueChanged(object sender, EventArgs e)
        {

            if (txtBaslama.DateTime.Date > txtBitis.DateTime.Date) return;
            Listele();
        }

        private void TxtTarih_EditValueChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void ChbTarihAraligi_CheckedChanged(object sender, EventArgs e)
        {
            txtBitis.Visible = txtBaslama.Visible = chbTarihAraligi.Checked;
            if(chbTarihAraligi.Checked)
            {
                txtBaslama.DateTime = DateTime.Now.AddMonths(-1);
                txtBitis.DateTime = DateTime.Now;
                txtTarih.Enabled = false;
                txtTarih.Text = null;
            }
            else
            {
                txtTarih.Enabled = true;
                txtTarih.DateTime = DateTime.Now;
            }
        }

        private void BtnYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            Listele();
        }

        private void BtnSmsGonder_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tablo.DataRowCount <= 0 || tablo.FocusedRowHandle < -1) return;
            using (var frm = new TaksitHatirlatmaSmsForm(OgrenciOdemePlaniF.Secim(Convert.ToInt64(tablo.GetFocusedRowCellValue(colId))), null))
                frm.ShowDialog();
        }


        void Listele()
        {
            tablo.GridControl.DataSource =chbTarihAraligi.Checked? list.Where(x =>x.SonOdemeTarihi>=txtBaslama.DateTime.Date && x.SonOdemeTarihi.Date <= txtBitis.DateTime.Date ): list.Where(x => x.SonOdemeTarihi.Date == txtTarih.DateTime.Date);
            tablo.ViewCaption = chbTarihAraligi.Checked ? $"{txtBaslama.DateTime.ToShortDateString()}-{txtBitis.DateTime.ToShortDateString()} Arası Vadesi Geçmiş Ödenmeyen Taksitler": $"({txtTarih.DateTime.ToShortDateString()}) Tarihli Ödenmeyen Taksitler" ;

        }
    }

}