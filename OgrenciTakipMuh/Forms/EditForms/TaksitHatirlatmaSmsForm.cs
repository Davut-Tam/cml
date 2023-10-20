using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Data.Facade;
using OgrenciTakipMuh.Facade;
using OgrenciTakipMuh.Forms.BaseForms;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;

namespace OgrenciTakipMuh.Forms.EditForms
{
    public partial class TaksitHatirlatmaSmsForm : BaseEditForm
    {
        OgrenciCariOdemeL _op;
        public TaksitHatirlatmaSmsForm(OgrenciCariOdemeL op, List<OgrenciCariOdemeL> oplist)
        {
            InitializeComponent();
            _op = op;
            Text = oplist == null ? op.AdiSoyadi + " Ödenmeyen Taksit Hatırlatma" : oplist[0].AdiSoyadi + " Tahsilat Bilgilendirme";
            txtVeli1.Text = oplist == null ? op.Veli1AdiSoyadi : oplist[0].Veli1AdiSoyadi;
            txtTel1.Text = oplist == null ? op.Veli1Telefon : oplist[0].Veli1Telefon;
            chbTel1.Checked = txtTel1.Text != "";

            txtVeli2.Text = oplist == null ? op.Veli2AdiSoyadi : oplist[0].Veli2AdiSoyadi;
            txtTel2.Text = oplist == null ? op.Veli2Telefon : oplist[0].Veli2Telefon;
            chbTel2.Checked = txtTel2.Text != "";

            var msj = "";
            var taksitTutar = "";
            if (oplist != null)
                if (oplist.Count == 1)
                    msj = $"Sayın Velimiz, {oplist[0].DonemAdi} {oplist[0].AdiSoyadi} isimli öğrencinizin {oplist[0].TaksitNo} nolu {oplist[0].Odenen.ToString("n2")} tutarındaki taksidi tahsil edilmştir.\n(Kalan Ödemeniz: {OgrenciF.Secim(oplist[0].OgrenciId).KalanBakiye.ToString("n2")})";
                else
                {
                    foreach (var item in oplist)
                        taksitTutar += "(" + item.TaksitNo + " nolu - " + item.Odenen.ToString("n2") + @"), ";

                    taksitTutar = taksitTutar.Substring(0, taksitTutar.Length - 2);
                    msj = $"Sayın Velimiz, {oplist[0].DonemAdi} {oplist[0].AdiSoyadi} isimli öğrencinizin {taksitTutar} tutarlarındaki taksitleri tahsil edilmştir.\n(Kalan Ödemeniz: {OgrenciF.Secim(oplist[0].OgrenciId).KalanBakiye.ToString("n2")})";

                }




            txtMesaj.Text = oplist == null ?

                    AnaForm.GenAyr.OtoSmsMesaj
                    .Replace("[$AdıSoyadı]", op.AdiSoyadi)
                    .Replace("[$DönemAdı]", op.DonemAdi)
                    .Replace("[$GrupAdı]", op.GrupAdi)
                    .Replace("[$SınıfAdı]", op.SinifAdi)
                    .Replace("[$SonÖdemeTarihi]", op.SonOdemeTarihi.ToShortDateString())
                    .Replace("[$TaksitNo]", op.TaksitNo.ToString())
                    .Replace("[$Tutar]", op.Odenecek.ToString("n2")) :

                    msj;



            chbZamanliGonderim.CheckedChanged += ChbZamanliGonderim_CheckedChanged;
            btnGonder.Click += BtnGonder_Click;
            btnIptal.Click += BtnIptal_Click;

            ChbZamanliGonderim_CheckedChanged(null, null);
            txtMesaj.EnterMoveNextControl = false;
            txtMesaj.Select();
            txtMesaj.Focus();
        }

        private void ChbZamanliGonderim_CheckedChanged(object sender, EventArgs e)
        {
            layoutTarih.Enabled = layoutSaat.Enabled = chbZamanliGonderim.Checked;
            txtTarih.EditValue = txtSaat.EditValue = DateTime.Now;
            if (!chbZamanliGonderim.Checked)
                txtTarih.EditValue = txtSaat.EditValue = null;
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            if (!chbTel1.Checked && !chbTel2.Checked)

            {
                Messages.UyariMesaji("En Az 1 Veli Seçilmelidir.");
                return;
            }


            if (chbTel1.Checked)
                if (txtTel1.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Length != 10)
                {
                    Messages.UyariMesaji("Telefon 1 Hatalı");
                    return;
                }

            if (chbTel2.Checked)
                if (txtTel2.Text != "" && txtTel2.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Length != 10)
                {
                    Messages.UyariMesaji("Telefon 2 Hatalı");
                    return;
                }

            if (txtMesaj.Text.Replace(" ", "") == "")
            {
                Messages.UyariMesaji("Mesaj yazınız");
                return;
            }

            var list = new List<Sms>
          {

              new Sms
              {
                  Id=new List<long>(){_op!=null?_op.Id:0 },
                  Telefon=new string []{txtTel1.Text.Replace("(", "").Replace(")", "").Replace(" ", "") != "" && chbTel1.Checked? txtTel1.Text.Replace("(", "").Replace(")", "").Replace(" ", "") : null,txtTel2.Text!="" && chbTel2.Checked ? txtTel2.Text.Replace("(", "").Replace(")", "").Replace(" ", "") : null},
                  Mesaj=txtMesaj.Text

              }
          };

            var tar = chbZamanliGonderim.Checked ? new DateTime(txtTarih.DateTime.Year, txtTarih.DateTime.Month, txtTarih.DateTime.Day, ((DateTime)txtSaat.EditValue).Hour, ((DateTime)txtSaat.EditValue).Minute, ((DateTime)txtSaat.EditValue).Second) : (DateTime?)null;
            using (var smsF = new SmsFunctions())
                if (smsF.SmsGonder(list, true, tar))
                {
                    if (_op != null)
                        OgrenciOdemePlaniF.BirinciSmsKayit(_op.Id);
                    Close();
                }

        }
    }
}
