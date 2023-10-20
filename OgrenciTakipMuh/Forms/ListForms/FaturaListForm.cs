using DevExpress.XtraBars;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.EditForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.MenuForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.ListForms
{
    public partial class FaturaListForm : BaseListForm
    {
        private bool _gelenFatura;
        public static long SeciliId;
        public bool _aktifPasif = true;
        private string _belgeTuru;
        private bool _dvm;
        public FaturaListForm(bool gelenFatura)
        {
            InitializeComponent();
            Yukle();
            _gelenFatura = gelenFatura;

            if (_gelenFatura)
            {
               Tablo.ViewCaption= Text = "Gelen Faturalar";
                _belgeTuru = "Alış";
            }
            else
            {
                Tablo.ViewCaption = Text = "Giden Faturalar";
                _belgeTuru = "Satış";
            }


            for (int i = DateTime.Now.Year; i <= FaturaF.EnKucukYil(); i++)
                txtYil.Properties.Items.Add(i);

            txtAy.Text = DateTime.Now.ToString("MMMM");
            txtYil.Text = DateTime.Now.Year.ToString();
            _dvm = true;

            btnAltToplamlar.Visibility = Tablo.OptionsView.ShowFooter ? BarItemVisibility.Always : BarItemVisibility.Never;
            Tablo.OptionsView.ShowFooter = false;
        }

        private void FaturaListForm_Load(object sender, EventArgs e)
        {
            YerelYetkiKontrol(Tag);
        }

        public override void YetkiKontrol(object tag)
        {
            //base.YetkiKontrol(tag); // base ptal
            
        }

        public void YerelYetkiKontrol(object tag)
        {
            if (KullaniciF.Secim(AnaForm.KullanicilId).KullaniciTuru == "Yönetici")
            {
                Ekleyebilir = true;
                Guncelleyebilir = true;
                Silebilir = true;
            }
            else
            {
                RolDetay kont = RolF.Kontroller(tag);
                Ekleyebilir = kont.Ekleyebilir == 1;
                Guncelleyebilir = kont.Guncelleyebilir == 1;
                Silebilir = kont.Silebilir == 1;
            }
        }
        void Yukle()
        {
            YetkiKontrol(Tag);
            Tablo = tablo;
            LblBilgi = lblBilgi;
            controlNavigator.NavigatableControl = tablo.GridControl;
            EventLoad();
        }

        void EventLoad()
        {
            BaseEventLoad();
            //buton event
            btnYeni.ItemClick += BtnYeni_ItemClick;
            btnSil.ItemClick += BtnSil_ItemClick;
            btnDuzelt.ItemClick += BtnDuzelt_ItemClick;
            btnYenile.ItemClick += BtnYenile_ItemClick;

            tablo.DoubleClick += Tablo_DoubleClick;
            txtAy.TextChanged += TxtAy_TextChanged;
            txtYil.TextChanged += TxtYil_TextChanged;
           
        }

        private void TxtYil_TextChanged(object sender, EventArgs e)
        {
            if (!_dvm) return;
            Listele(true);
        }

        private void TxtAy_TextChanged(object sender, EventArgs e)
        {
          
            switch (txtAy.Text)
            {
                case "Ocak": txtAy.Tag=1; break;
                case "Şubat": txtAy.Tag = 2; break;
                case "Mart": txtAy.Tag = 3; break;
                case "Nisan": txtAy.Tag = 4; break;
                case "Mayıs": txtAy.Tag = 5; break;
                case "Haziran": txtAy.Tag = 6; break;
                case "Temmuz": txtAy.Tag = 7; break;
                case "Ağustos": txtAy.Tag = 8; break;
                case "Eylül": txtAy.Tag = 9; break;
                case "Ekim": txtAy.Tag = 10; break;
                case "Kasım": txtAy.Tag = 11; break;
                case "Aralık": txtAy.Tag = 12; break;
            }
            if (!_dvm) return;
            Listele(true);
        }

  

        private void BtnYenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Listele(true);
        }

        void Listele(bool durum = true)
        {
            if (!durum) return;
            tablo.GridControl.DataSource = FaturaF.Liste(_belgeTuru,Convert.ToInt16(txtAy.Tag),Convert.ToInt16(txtYil.Text));
        }
        void SeciliKayitGuncelleme()
        {
            if (!Guncelleyebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            SeciliId = (long)tablo.GetFocusedRowCellValue("Id");
            FaturaEditForm fr = new FaturaEditForm(_belgeTuru) { Text = this.Text } ;
            fr.ShowDialog();
            Listele(fr.KayitVar);
            fr.Dispose();
            tablo.RowFocus("Id", SeciliId);
        }

        private void BtnDuzelt_ItemClick(object sender, ItemClickEventArgs e)
        {
            SeciliKayitGuncelleme();
        }

        private void Tablo_DoubleClick(object sender, EventArgs e)
        {

            SeciliKayitGuncelleme();
        }

        private void BtnSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Silebilir) { Messages.YetkinizYokMesaji(); return; }
            if (tablo.DataRowCount <= 0) return;
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                Listele(FaturaF.Sil((long)tablo.GetFocusedRowCellValue("Id")));
            }
            catch (Exception ex)
            {
                Messages.UyariMesaji(ex.Message);
            }

        }

        private void BtnYeni_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Ekleyebilir) { Messages.YetkinizYokMesaji(); return; }
            SeciliId = 0;
            FaturaEditForm fr = new FaturaEditForm(_belgeTuru) { Text=this.Text};
            fr.ShowDialog();
            Listele(fr.KayitVar);
            fr.Dispose();

        }

     
    }
}
