
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OgrenciTakipMuh.Tools
{
    public static class TableClass
    {
        public static void TabloDisariAktar(this GridView tablo, string AktarılacakFormat, string dosyaFormati, string excelSayfaAdi = null)
        {
            if (Messages.SoruEvetSeciliEvetHayir(dosyaFormati+ " olarak Dışarı Aktarılacak Emin misiniz.","Tablo Aktarma") == DialogResult.No) return;

            if (!Directory.Exists( @"C:\Öğrenci Muh Dosyaları\Temp")) // klasör var mı
                Directory.CreateDirectory(@"C:\Öğrenci Muh Dosyaları\Temp");// klasör ekle

            var dosyaAdi = Guid.NewGuid().ToString();
            var filePath = $@"C:\Öğrenci Muh Dosyaları\Temp\{dosyaAdi}";
            switch (AktarılacakFormat)
            {
                case "Excel":
                    {
                        var opt = new XlsxExportOptionsEx
                        {
                            ExportType = DevExpress.Export.ExportType.WYSIWYG,
                            SheetName = excelSayfaAdi,
                            TextExportMode = TextExportMode.Text
                        };
                        filePath = filePath + ".Xlsx";
                        tablo.ExportToXlsx(filePath, opt);
                    }
                    break;
                case "Word":
                    {
                        filePath = filePath + ".Rtf";
                        tablo.ExportToRtf(filePath);
                    }

                    break;
                case "Pdf":
                    {
                        filePath = filePath + ".Pdf";
                        tablo.ExportToPdf(filePath);
                    }
                    break;
                case "Txt":
                    {
                        var opt = new TextExportOptions { TextExportMode = TextExportMode.Text };
                        filePath = filePath + ".Txt";
                        tablo.ExportToText(filePath, opt);
                    }
                    break;

            }
            if (!File.Exists(filePath))
            {
                Messages.HataMesaji("Tablo Verileri Dosyaya Aktarılamadı");
                return;
            }
            else
            {
                Process.Start(filePath);
            }
        }
    }
}
