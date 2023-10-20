using Dapper;
using DevExpress.XtraEditors;
using OgrenciTakipMuh.Data.Entities.Entity;
using OgrenciTakipMuh.Forms.GenelForms;
using System;

namespace OgrenciTakipMuh.Data.Tools
{
    public static class ComboboxFunctions
    {
        static string _sql;
        public static void AddItems(this ComboBoxEdit cmb, bool tumkayitlar = false,string islemTuru=null,long dnmId=0, long grupId=0)
        {

            switch (cmb.Name)
            {

                case "txtDonemAdi":
                    _sql = $"SELECT DonemAdi FROM Donem";
                    break;

                case "txtGrupAdi":
                    _sql = $"SELECT GrupAdi FROM Grup WHERE DonemId=" + dnmId;
                    break;

                case "txtSinifAdi":

                    _sql = $"SELECT SinifAdi FROM Sinif WHERE DonemId={dnmId} AND GrupId={grupId}";
                    break;

                case "txtBankaHesaplari":
                    _sql = $"SELECT HesapAdi FROM BankaHesap WHERE Durum='True' order By Id";
                    break;

                case "txtMiktarBrim":
                    _sql = $"SELECT MiktarBrimAdi From MalHizmetMiktarBrim order by MiktarBrimAdi";
                    break;

                case "txtNakitIslemAdi":
                    _sql = $"Select IslemAdi From NakitIslemler where IslemTuru='{islemTuru}' order by Id";
                    break;

                case "txtBankaIslemAdi":
                    _sql = $"Select IslemAdi From BankaIslemler where IslemTuru='{islemTuru}' order by Id";
                    break;

                case "txtCekIslemAdi":
                    _sql = $"Select IslemAdi From CekIslemler where IslemTuru='{islemTuru}' order by Id";
                    break;


            }

            if (_sql == null) return;
            cmb.Properties.Items.Clear();
            cmb.Text = "";
            var rd = Connections.cnn.ExecuteReader(_sql);
            while (rd.Read())
                cmb.Properties.Items.Add(rd[0].ToString());
            rd.Close();
            if (tumkayitlar)
            {
                cmb.Properties.Items.Add("-Tüm Kayıtlar-");
                cmb.Text = "-Tüm Kayıtlar-";
            }
               
        }
        public static void AddItems(this LookUpEdit lkp,long donemId)// sadece Dönem için kullanılacak
        {
            _sql = $"SELECT * FROM Donem order by Id";
            lkp.Properties.DataSource= Connections.cnn.Query<Donem>(_sql);
            lkp.EditValue = donemId;
        }

        public static long ItemsId(this ComboBoxEdit cmb,long dmnId=0)
        {
            switch (cmb.Name)
            {
                case "txtDonemAdi":
                    _sql = $"SELECT Id FROM Donem where DonemAdi='{cmb.Text}'";
                    break;

                case "txtGrupAdi":
                    _sql = $"SELECT Id FROM Grup WHERE GrupAdi='{cmb.Text}' AND DonemId=" + dmnId;
                    break;

                case "txtSinifAdi":
                    _sql = $"SELECT Id FROM Sinif WHERE SinifAdi='{cmb.Text}' AND DonemId=" + dmnId;
                    break;

                case "txtBankaHesaplari":
                    _sql = $"SELECT Id FROM BankaHesap WHERE HesapAdi='{cmb.Text}'";
                    break;

                case "txtMiktarBrim":
                    _sql = $"SELECT Id FROM MiktarBrimAdi WHERE MiktarBrimAdi='{cmb.Text}'";
                    break;

                case "txtNakitIslemAdi":
                    _sql = $"Select Id From NakitIslemler where IslemAdi='{cmb.Text}'";
                    break;

                case "txtBankaIslemAdi":
                    _sql = $"Select Id From BankaIslemler where IslemAdi='{cmb.Text}'";
                    break;

                case "txtCekIslemAdi":
                    _sql = $"Select Id From CekIslemler where IslemAdi='{cmb.Text}'";
                    break;


            }

                return Convert.ToInt64( Connections.cnn.ExecuteScalar(_sql));
             
        }

    }
}