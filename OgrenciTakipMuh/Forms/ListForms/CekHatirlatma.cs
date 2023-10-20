using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.MenuForms;
using System;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class CekHatirlatma : BaseListForm
    {
        public CekHatirlatma()
        {
            InitializeComponent();
            Tablo = tablo;
            LblBilgi = lblBilgi;
            controlNavigator.NavigatableControl = Tablo.GridControl;
            Eventload();
            TglDurum_Toggled(null, null);

            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;
        }

        public override void ButonGizle(bool secimFormuolarakAcilma)
        {
            base.ButonGizle(secimFormuolarakAcilma);
            btnYeni.Visibility = btnSil.Visibility = btnDuzelt.Visibility = BarItemVisibility.Never;
        }

        void Eventload()
        {
            BaseEventLoad();
            tglDurum.Toggled += TglDurum_Toggled;
        }

        private void TglDurum_Toggled(object sender, EventArgs e)
        {
            tablo.GridControl.DataSource = CekF.VadesiBugunOlanCekListesi(tglDurum.IsOn);


            if (tglDurum.IsOn)
            {
                tablo.ViewCaption = $"Vade Tarihi Bu Gün Olan Çekler";

            }

            else
            {
                tablo.ViewCaption = $"Vadesi Geçmiş Çekler";

            }



        }
    }
}
