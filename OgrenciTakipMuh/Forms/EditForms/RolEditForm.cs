using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Forms.ListForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class RolEditForm : BaseEditForm
    {
        private bool _yeniKayit;
        public bool kayitVar;
        public Rol Rol;
        List<RolDetay> roldetaylistesi = new List<RolDetay>();
        public RolEditForm()
        {
            InitializeComponent();
            controlNavigator.NavigatableControl = tablo.GridControl;
            EventLoad();

            if (RolListForm.SeciliId > 0)
            {
                Rol = RolF.Secim(RolListForm.SeciliId);
                txtRolAdi.Text = Rol.RolAdi;
                txtAciklama.Text = Rol.Aciklama;

                tablo.GridControl.DataSource = RolF.RolDetayListesi(RolListForm.SeciliId);
                this.Text += " ( Kayıt Güncelleme )";
                btnKaydet.Text = "Güncelle";
                _yeniKayit = false;
            }
            else
            {
                tablo.GridControl.DataSource = RolF.RolDetayBosListe();
                btnSil.Enabled = false;
                this.Text += " ( Yeni Kayıt )";
                _yeniKayit = true;
            }



        }

        void EventLoad()
        {
            repositorySecim.CheckedChanged += RepositorySecim_CheckedChanged;

            btnKaydet.Click += BtnKaydet_Click;
            btnSil.Click += BtnSil_Click;
            btnIptal.Click += BtnIptal_Click;

            tablo.FocusedColumnChanged += Tablo_FocusedColumnChanged;
            tablo.CellValueChanged += Tablo_CellValueChanged;


        }



        bool dvm = true;
        private void Tablo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!dvm) return;
            if (tablo.FocusedColumn.FieldName == "Gorebilir")
            {
                if ((byte)tablo.GetFocusedRowCellValue("Gorebilir") == 1 &&
                    (int)tablo.GetFocusedRowCellValue("MenuId") != 4 &&
                    (int)tablo.GetFocusedRowCellValue("MenuId") != 21 &&
                    (int)tablo.GetFocusedRowCellValue("MenuId") != 22 &&
                    (int)tablo.GetFocusedRowCellValue("MenuId") != 23 &&
                    (int)tablo.GetFocusedRowCellValue("MenuId") != 24 &&
                    (int)tablo.GetFocusedRowCellValue("MenuId") != 26)
                {
                    dvm = false;
                    tablo.SetRowCellValue(tablo.FocusedRowHandle, "Ekleyebilir", 0);
                    tablo.SetRowCellValue(tablo.FocusedRowHandle, "Guncelleyebilir", 0);
                    tablo.SetRowCellValue(tablo.FocusedRowHandle, "Silebilir", 0);
                    dvm = true;
                }
                else
                {
                    dvm = false;
                    tablo.SetRowCellValue(tablo.FocusedRowHandle, "Ekleyebilir", 2);
                    tablo.SetRowCellValue(tablo.FocusedRowHandle, "Guncelleyebilir", 2);
                    tablo.SetRowCellValue(tablo.FocusedRowHandle, "Silebilir", 2);
                    dvm = true;
                }
            }

        }



        private void Tablo_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (tablo.RowCount <= 0) return;
            byte deger = (byte)tablo.GetFocusedRowCellValue("Gorebilir");
            colEkleyebilir.OptionsColumn.AllowEdit = colGuncelleyebilir.OptionsColumn.AllowEdit = colSilebilir.OptionsColumn.AllowEdit = deger == 1;

            if ((int)tablo.GetFocusedRowCellValue("MenuId") == 4 ||
                (int)tablo.GetFocusedRowCellValue("MenuId") == 21 ||
                (int)tablo.GetFocusedRowCellValue("MenuId") == 22 ||
                (int)tablo.GetFocusedRowCellValue("MenuId") == 23 ||
                (int)tablo.GetFocusedRowCellValue("MenuId") == 24 ||
                (int)tablo.GetFocusedRowCellValue("MenuId") == 26)
            {
                colEkleyebilir.OptionsColumn.AllowEdit = false;
                colGuncelleyebilir.OptionsColumn.AllowEdit = false;
                colSilebilir.OptionsColumn.AllowEdit = false;

            }


        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            kayitVar = false;
            Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Messages.SoruHayirSeciliEvetHayir("Kayıt Silinecektir Onaylıyor musunuz", "Kayıt Silme") == DialogResult.No) return;
            try
            {
                kayitVar = RolF.Sil(RolListForm.SeciliId);
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                kayitVar = false;
            }
            if (kayitVar)
                this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                roldetaylistesi = (List<RolDetay>)tablo.DataSource;
                Rol rol = new Rol()
                {
                    Id = GenelFunctions.IdOlustur(),
                    RolAdi = txtRolAdi.Text,
                    Aciklama = txtAciklama.Text,
                    KullaniciId = AnaForm.KullanicilId,
                    IslemTarihi = DateTime.Now
                };


                if (_yeniKayit)
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Yeni Kayıt Yapılacak Onaylıyor musunuz", "Yeni Kayıt") == DialogResult.No)
                        return;
                    kayitVar = RolF.Ekle(roldetaylistesi, rol);
                }

                else
                {
                    if (Messages.SoruEvetSeciliEvetHayir("Kayıt Güncellenecek Onaylıyor musunuz", "Kayıt Güncelleme") == DialogResult.No)
                        return;

                    kayitVar = RolF.Guncelle(roldetaylistesi, rol, RolListForm.SeciliId);
                }
            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
            }
            if (kayitVar)
                this.Close();


        }

        private void RepositorySecim_CheckedChanged(object sender, EventArgs e)
        {
            controlNavigator.Buttons.DoClick(controlNavigator.Buttons.EndEdit);
        }
    }
}
