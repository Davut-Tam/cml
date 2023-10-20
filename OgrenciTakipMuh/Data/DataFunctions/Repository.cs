using Dapper;
using OgrenciTakipMuh.Data.Tools;
using OgrenciTakipMuh.Forms.GenelForms;
using OgrenciTakipMuh.Tools;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Data.DataFunctions
{
    public static class Repository
    {
        static AnaForm afrm;
        public static bool Kaydet(this DynamicParameters prm,string sql )
        {
            try
            {
                if (Connections.cnn.Execute(sql, prm) > 0)
                {
                    SesFunctions.IslemSesi(Enums.Ses.Kaydet);
                    afrm = Application.OpenForms["Anaform"] as AnaForm;
                    if (afrm != null)
                        afrm.Hatirlatma();
                    return true;
                }
                else
                    return false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new Exception("Mükerrer Kayıt Hatası");
                else
                    throw new Exception($"Hata No:{ex.Number}\n{ex.Message}");
               
            }


        }

        public static bool Guncelle(this DynamicParameters prm,string sql)
        {
            try
            {
                if (Connections.cnn.Execute(sql, prm) > 0)
                {
                    SesFunctions.IslemSesi(Enums.Ses.Güncelle);
                    afrm = Application.OpenForms["Anaform"] as AnaForm;
                    if (afrm != null)
                        afrm.Hatirlatma();
                    return true;
                }
                else
                    return false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    throw new Exception("Mükerrer Kayıt Hatası");
                else
                    throw new Exception($"Hata No:{ex.Number}\n{ex.Message}");
            }


        }

        public static bool Sil(string sql, params string[] prm)
        {
         
            try
            {
                if (Connections.cnn.Execute(sql) > 0)
                {
                    SesFunctions.IslemSesi(Enums.Ses.Sil);
                    afrm = Application.OpenForms["Anaform"] as AnaForm;
                    if (afrm != null)
                        afrm.Hatirlatma();
                    return true;
                }
                else
                    return false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {

                    throw new Exception("Bu Kaydın Başka Tablolarda Bağlı işlemleri olduğundan öncelikle bu Kayıtların Silinmesi Gerekiyor.");
                }
                   
                 else
                    throw new Exception($"Hata No:{ex.Number}\n{ex.Message}");
            }


        }





    }
}
