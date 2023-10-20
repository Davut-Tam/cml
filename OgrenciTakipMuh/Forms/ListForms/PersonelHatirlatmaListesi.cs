using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.MenuForms;
using System;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class PersonelHatirlatmaListesi : BaseListForm
    {
        public PersonelHatirlatmaListesi()
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
            tablo.GridControl.DataSource = PersonelOdemePlaniF.MaasOdemeGunuListesi(tglDurum.IsOn);


            if (tglDurum.IsOn)
            {
                tablo.ViewCaption = $"Bu Gün ({DateTime.Now.ToString("d")}) Ödenmesi Gereken Maaşlar";

            }

            else
            {
                tablo.ViewCaption = $"Geçmiş Dönem Alacaklı Personeller ";

            }



        }
    }
}
