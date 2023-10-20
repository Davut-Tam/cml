using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Tools
{
    public class Messages
    {
        public static void HataMesaji(string hataMesaji)
        {
            XtraMessageBox.Show(hataMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void BilgiMesaji(string bilgiMesaji)
        {
            XtraMessageBox.Show(bilgiMesaji, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void UyariMesaji(string uyariMesaji)
        {
            XtraMessageBox.Show(uyariMesaji, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult SoruEvetSeciliEvetHayir(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult SoruHayirSeciliEvetHayir(string mesaj, string baslik)
        {
            return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        public static void YetkinizYokMesaji(string yetkiMesaji= "Yetkiniz Yok")
        {
            XtraMessageBox.Show(yetkiMesaji, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        public static void OgrenciTutarlariGormeyeYetkinizYokMesaji()
        {
            XtraMessageBox.Show("Öğrenci Tutarlarını Görmeye Yetkiniz Yok", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void InternetBaglantisiYok()
        {
            XtraMessageBox.Show("İnternet Bağlantınız Olmadığı İçin İşlem Gerçekleştirilemiyor...", "İnternet Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

