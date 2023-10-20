
using DevExpress.XtraEditors;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.GenelForms;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.BaseForms
{
    public partial class BaseEditForm :XtraForm
    {
        public bool Ekleyebilir, Guncelleyebilir, Silebilir,Gorebilir;
        public long Id;
        private bool _formSablonKayitEdilecek;

        private void BaseEditForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        public BaseEditForm()
        {
            InitializeComponent();
            this.Load += BaseEditForm_Load;
            this.FormClosing += BaseEditForm_FormClosing;
            this.LocationChanged += BaseEditForm_LocationChanged; ;
            this.SizeChanged += BaseEditForm_SizeChanged;

        }

        private void BaseEditForm_LocationChanged(object sender, System.EventArgs e)
        {
            if (!IsMdiChild)
                _formSablonKayitEdilecek = true;
        }

        private void BaseEditForm_SizeChanged(object sender, System.EventArgs e)
        {
            if (!IsMdiChild)
                _formSablonKayitEdilecek = true;
        }

   

        private void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsMdiChild && _formSablonKayitEdilecek)
                Name.FormSablonKaydet(Left, Top, Width, Height, WindowState);
       
        }

        private void BaseEditForm_Load(object sender, System.EventArgs e)
        {
            Name.FormSablonYukle(this);
        }

        public virtual void YetkiKontrol(object tag)
        {
            if (KullaniciF.Secim(AnaForm.KullanicilId).KullaniciTuru == "Yönetici")
            {
                Gorebilir = true;
                Ekleyebilir = true;
                Guncelleyebilir = true;
                Silebilir = true;
            }
            else
            {
                RolDetay kont = RolF.Kontroller(tag);

                if (kont == null) return;
                Gorebilir = kont.Gorebilir == 1;
                Ekleyebilir = kont.Ekleyebilir == 1;
                Guncelleyebilir = kont.Guncelleyebilir == 1;
                Silebilir = kont.Silebilir == 1;
            }
        }

    }
}