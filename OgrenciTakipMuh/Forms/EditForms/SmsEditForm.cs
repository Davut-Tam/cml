using DevExpress.XtraLayout.Utils;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Facade;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OgrenciTakipMuh.Forms.GenelForms
{
    public partial class SmsEditForm : BaseEditForm
    {
        List<Sms> _liste;
        bool _dvm;
        public SmsEditForm()
        {
            InitializeComponent();
            EventLoad();
            txtDonem.Properties.DataSource = DonemF.Liste();
            txtDonem.EditValue = AnaForm.DonemId;
            controlNavigator.NavigatableControl = tablo.GridControl;
            _dvm = true;
        }

        void EventLoad()
        {
            Load += SmsEditForm_Load;
            btnGonder.Click += BtnGonder_Click;
            btnTemizle.Click += BtnTemizle_Click;
            btnIptal.Click += BtnIptal_Click;
            txtGonderiGrubu.SelectedIndexChanged += TxtGonderiGrubu_SelectedIndexChanged;
            tablo.SelectionChanged += Tablo_SelectionChanged;
            txtMesaj.EditValueChanged += TxtMesaj_EditValueChanged;
            rdbtnTekli.CheckedChanged += SmsTuru_CheckedChanged;
            rdBtnCoklu.CheckedChanged += SmsTuru_CheckedChanged;
            chbZamanliGonderim.CheckedChanged += ChbZamanliGonderim_CheckedChanged;
            txtDonem.EditValueChanged += TxtDonem_EditValueChanged;
        }

        private void TxtDonem_EditValueChanged(object sender, EventArgs e)
        {
            if (!_dvm) return;
            if (txtGonderiGrubu.SelectedIndex == 0)
                tablo.GridControl.DataSource = OgrenciF.Liste(true, Convert.ToInt64(txtDonem.EditValue)).Where(x => x.Veli1Telefon != null || x.Veli2Telefon != null);
            if (txtGonderiGrubu.SelectedIndex == 1)
                tablo.GridControl.DataSource = ((List<VeliL>)VeliF.Liste(true, Convert.ToInt64(txtDonem.EditValue))).Where(x => x.Telefon != null && x.OgrenciSayisi > 0).ToList();

        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            txtMesaj.EditValue = null;
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {

            if (txtMesaj.Text == "" || txtMesaj.Text.Replace(" ", "") == "")
            {
                Messages.UyariMesaji("Lütfen mesaj metni giriniz...");
                return;
            }

            if (rdbtnTekli.Checked && txtTelefon.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Length != 10)
            {
                Messages.UyariMesaji("Lütfen telefon no giriniz");
                return;
            }

            if (rdBtnCoklu.Checked && tablo.SelectedRowsCount <= 0)
            {
                Messages.UyariMesaji("Lütfen listeden telefon seçiniz");
                return;
            }


            using (var smsF = new SmsFunctions())
            {
                _liste = new List<Sms>();
                if (rdbtnTekli.Checked)
                {
                    var sms = new Sms { Telefon = new string[] { txtTelefon.Text.Replace("(", "").Replace(")", "").Replace(" ", "") }, Mesaj = txtMesaj.Text.Replace("\r\n", "\\n") + "\\n" };
                    _liste.Add(sms);

                }
                else
                {

                    foreach (int i in tablo.GetSelectedRows())
                    {

                        var tel1 = tablo.GetRowCellValue(i, colTelefon1);
                        var tel2 = tablo.GetRowCellValue(i, ColTelefon2);
                        var telefonlar = new string[2];
                        if (tel1 != null) telefonlar[0] = tel1.ToString().Replace("(", "").Replace(")", "").Replace(" ", "");
                        if (tel2 != null) telefonlar[1] = tel2.ToString().Replace("(", "").Replace(")", "").Replace(" ", "");

                        _liste.Add(new Sms
                        {

                            Telefon = telefonlar,
                            Mesaj = txtMesaj.Text.Replace("\r\n", "\\n") + "\\n"
                        });

                    }
                }
                var tar = chbZamanliGonderim.Checked ? new DateTime(txtTarih.DateTime.Year, txtTarih.DateTime.Month, txtTarih.DateTime.Day, ((DateTime)txtSaat.EditValue).Hour, ((DateTime)txtSaat.EditValue).Minute, ((DateTime)txtSaat.EditValue).Second) : (DateTime?)null;

                smsF.SmsGonder(_liste, true, tar);

            }
        }

        private void SmsEditForm_Load(object sender, EventArgs e)
        {
            SmsTuru_CheckedChanged(null, null);
            ChbZamanliGonderim_CheckedChanged(null, null);
        }

        private void ChbZamanliGonderim_CheckedChanged(object sender, EventArgs e)
        {

            layoutTarih.Enabled = layoutSaat.Enabled = chbZamanliGonderim.Checked;
            txtTarih.EditValue = txtSaat.EditValue = DateTime.Now;
            if (!chbZamanliGonderim.Checked)
                txtTarih.EditValue = txtSaat.EditValue = null;
        }

        private void TxtMesaj_EditValueChanged(object sender, EventArgs e)
        {
            SmsSayisi();
        }

        private void Tablo_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            txtTelefon.Text = "Listeden Seçilen: " + tablo.SelectedRowsCount.ToString();
            SmsSayisi();
        }

        private void SmsTuru_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTekli.Checked)// tek
            {
                txtTelefon.Text = null;
                txtTelefon.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None;
                txtTelefon.Properties.Mask.EditMask = "(\\d?\\d?\\d?) \\d?\\d?\\d? \\d?\\d? \\d?\\d?";
                txtTelefon.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
                layoutListe.Visibility = layoutGrup.Visibility = layoutDonem.Visibility = LayoutVisibility.Never;
                txtTelefon.ReadOnly = false;
                Size = MinimumSize = new System.Drawing.Size { Height = 250, Width = 580 };
                txtTelefon.Focus();


            }
            else
            {
                txtTelefon.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None;
                txtTelefon.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                layoutListe.Visibility = layoutGrup.Visibility = layoutDonem.Visibility = LayoutVisibility.Always;
                txtTelefon.ReadOnly = true;
                txtTelefon.Text = "Listeden Seçilen: " + tablo.SelectedRowsCount.ToString();
                Size = MinimumSize = new System.Drawing.Size { Height = 540, Width = 580 };
                txtGonderiGrubu.SelectedIndex = 0;
            }
        }

        private void TxtGonderiGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {

            colAdiSoyadi.Caption = txtGonderiGrubu.SelectedIndex == 3 ? "Firma Adı" : "Adı Soyadı";


            if (txtGonderiGrubu.SelectedIndex == 0)
            {
                ColTelefon2.Visible = true;
                colGrup.Visible = colSinif.Visible = true;
                colMeslek.Visible = false;
                ColTelefon2.VisibleIndex = tablo.VisibleColumns.Count - 1;
                colTelefon1.VisibleIndex = tablo.VisibleColumns.Count - 2;
                colSinif.VisibleIndex = tablo.VisibleColumns.Count - 3;
                colGrup.VisibleIndex = tablo.VisibleColumns.Count - 4;
                colAdiSoyadi.FieldName = "AdiSoyadi";
                colTelefon1.FieldName = "Veli1Telefon";



                tablo.GridControl.DataSource = (OgrenciF.Liste(true, Convert.ToInt64(txtDonem.EditValue))).Where(x => x.Veli1Telefon != null || x.Veli2Telefon != null);




            }
            else if (txtGonderiGrubu.SelectedIndex == 1)
            {
                colAdiSoyadi.FieldName = "VeliAdiSoyadi";
                colTelefon1.FieldName = "Telefon";
                colMeslek.Visible = true;
                ColTelefon2.Visible = false;
                colGrup.Visible = colSinif.Visible = false;
                tablo.GridControl.DataSource = ((List<VeliL>)VeliF.Liste(true, Convert.ToInt64(txtDonem.EditValue))).Where(x => x.Telefon != null && x.OgrenciSayisi > 0).ToList();
                colTelefon1.VisibleIndex = tablo.VisibleColumns.Count - 1;
                colMeslek.VisibleIndex = tablo.VisibleColumns.Count - 2;
                colAdiSoyadi.VisibleIndex = tablo.VisibleColumns.Count - 3;

            }
            else if (txtGonderiGrubu.SelectedIndex == 2)
            {
                colAdiSoyadi.FieldName = "AdiSoyadi";
                colTelefon1.FieldName = "Telefon";
                colMeslek.Visible = true;
                ColTelefon2.Visible = false;
                colGrup.Visible = colSinif.Visible = false;
                tablo.GridControl.DataSource = ((List<PersonelL>)PersonelF.Liste(true)).Where(x => x.Telefon != null || x.Telefon != "");
                colTelefon1.VisibleIndex = tablo.VisibleColumns.Count - 1;
                colMeslek.VisibleIndex = tablo.VisibleColumns.Count - 2;
                colAdiSoyadi.VisibleIndex = tablo.VisibleColumns.Count - 3;

            }
            else if (txtGonderiGrubu.SelectedIndex == 3)
            {
                colAdiSoyadi.FieldName = "FirmaAdi";
                colTelefon1.FieldName = "Telefon";
                colMeslek.Visible = false;
                ColTelefon2.Visible = false;
                colGrup.Visible = colSinif.Visible = false;
                tablo.GridControl.DataSource = ((List<FirmaL>)FirmaF.Liste(true)).Where(x => x.Telefon != null || x.Telefon != "");
                colTelefon1.VisibleIndex = tablo.VisibleColumns.Count - 1;
                colMeslek.VisibleIndex = tablo.VisibleColumns.Count - 2;
                colAdiSoyadi.VisibleIndex = tablo.VisibleColumns.Count - 3;
            }

            layoutDonem.Visibility = (txtGonderiGrubu.SelectedIndex == 0 || txtGonderiGrubu.SelectedIndex == 1) ? LayoutVisibility.Always : LayoutVisibility.Never;


        }
        void SmsSayisi()
        {
            var carpan = rdbtnTekli.Checked ? 1 : tablo.SelectedRowsCount;
            lblBilgi.Text = txtMesaj.Text.Length != 0 ? "SMS Sayısı : " + txtMesaj.Text.Length + " / " + Math.Ceiling(txtMesaj.Text.Length / 160f) * carpan : "SMS Sayısı : 0 / 0";
        }





    }
}
