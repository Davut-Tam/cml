using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Drawing;
using System.Drawing.Printing;
using OgrenciTakipMuh.Forms.GenelForms;

namespace OgrenciTakipMuh.Tools
{
    public class PrintFunctions
    {
        private static GridView _tablo;
        private static PrintableComponentLink _link;
        private static PrintingSystem _ps;
        private static YazdirmaAyarlari _yazdirmaAyarlari;

        public static void Yazdir(GridView tablo, YazdirmaAyarlari yazdirmaAyarlari)
        {
            _link = new PrintableComponentLink();
            _ps = new PrintingSystem();
            _tablo = tablo;
            _yazdirmaAyarlari = yazdirmaAyarlari;

            RasporDokumu();
        }

        private static void RasporDokumu()
        {
            BaslikEkle();
            RaporuKagidaSigdir();

            _tablo.OptionsPrint.PrintHorzLines = _yazdirmaAyarlari.YatayCizgileriGoster == "Evet";
            _tablo.OptionsPrint.PrintHorzLines = _yazdirmaAyarlari.DikeyCizgileriGoster == "Evet";
            _tablo.OptionsPrint.PrintHeader = _yazdirmaAyarlari.SutunBasliklariniGoster == "Evet";
            _tablo.OptionsView.ShowViewCaption = false;

            _link.Component = _tablo.GridControl;
            _link.PaperKind = PaperKind.Letter;
            _link.Margins = new Margins(59, 59, 115, 48);
            _link.CreateMarginalHeaderArea += Link_CreateMarginalHeaderArea;
            _link.CreateDocument(_ps);


            switch (_yazdirmaAyarlari.YazdirilacakNesne)
            {
                case "Tablo Önizleme":
                    YazdirBaskiOnizleme fr = new YazdirBaskiOnizleme(_ps, _yazdirmaAyarlari.RaporBaslik);
                    fr.ShowDialog();
                    fr.Dispose();
                    break;
                case "Tablo Yazdır":
                    for (int i = 0; i < _yazdirmaAyarlari.YazdirilacakAdet; i++)
                        _link.Print(_yazdirmaAyarlari.YaziciAdi);
                    break;
                //case "Rapor Yazdır":
                //    break;
                //case "Rapor Önizleme":
                //    break;

            }

            _tablo.OptionsView.ShowViewCaption = true;



        }

        private static void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            if (_yazdirmaAyarlari.BaslikEkle == "Hayır") return;
            var boldFont = new Font("Tahoma", 7, FontStyle.Bold);
            var regularFont = new Font("Tahoma", 7, FontStyle.Regular);

            var sayfaBrick = new PageInfoBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            {
                Font = regularFont,
                PageInfo = PageInfo.NumberOfTotal,
                Format = "Sayfa : {0} / {1}",
                Alignment = BrickAlignment.Far,
                AutoWidth = true

            };
            _ps.Graph.DrawBrick(sayfaBrick, new RectangleF(200, 25, 40, 15));


            var tarihBrick = new PageInfoBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            {
                Font = regularFont,
                PageInfo = PageInfo.DateTime,
                Format = "Tarih : {0:dd.MM.yyyy}",
                Alignment = BrickAlignment.Far,
                AutoWidth = true

            };
            _ps.Graph.DrawBrick(tarihBrick, new RectangleF(0, 40, 50, 15));


            var subeBaslikBrick = new TextBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            {
                Font = boldFont,
                Text = "Okul Adı",
            };
            _ps.Graph.DrawBrick(subeBaslikBrick, new RectangleF(0, 25, 50, 15));


            var subeValueBrick = new TextBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            {
                Font = regularFont,
                Text = ": " + AnaForm.GenAyr.KurumUnvan,
            };
            _ps.Graph.DrawBrick(subeValueBrick, new RectangleF(65, 25, 500, 15));



            //var donemBaslikBrick = new TextBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            //{
            //    Font = boldFont,
            //    Text = "Dönem",
            //};
            //_ps.Graph.DrawBrick(donemBaslikBrick, new RectangleF(0, 40, 50, 15));


            //var donemValueBrick = new TextBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            //{
            //    Font = regularFont,
            //    Text = $": {AnaForm.DonemAdi}",
            //};
            //_ps.Graph.DrawBrick(donemValueBrick, new RectangleF(65, 40, 200, 15));




        }

        private static void RaporuKagidaSigdir()
        {
            YazdirmaYonuAyarla();
            switch (_yazdirmaAyarlari.RaporuKagidaSigdir)
            {
                case "Sütunları Daraltarak Sığdır":
                    _tablo.OptionsPrint.AutoWidth = true;

                    break;

                case "Yazı Boyutunu Küçülterek Sığdır":
                    _tablo.OptionsPrint.AutoWidth = false;
                    _ps.Document.AutoFitToPagesWidth = 1;
                    break;

                default:// işlem yapma
                    _tablo.OptionsPrint.AutoWidth = false;
                    _ps.Document.ScaleFactor = 1.0f;
                    break;
            }
        }

        private static void YazdirmaYonuAyarla()
        {
            switch (_yazdirmaAyarlari.YazdirmaYonu)
            {
                case "Dikey":
                    _link.Landscape = false;
                    break;

                case "Yatay":
                    _link.Landscape = true;
                    break;

                case "Otomatik":
                    _link.Landscape = OtomatikYazdirmaYonu();
                    break;
            }
        }


        private static bool OtomatikYazdirmaYonu()
        {
            const int sayfaGenisligi = 703;
            var tabloStunGenizlikleri = 0;

            for (int i = 0; i < _tablo.Columns.Count; i++)
                if (_tablo.Columns[i].Visible)
                    tabloStunGenizlikleri += _tablo.Columns[i].Width;

            return tabloStunGenizlikleri > sayfaGenisligi;
        }

        private static void BaslikEkle()
        {
            if (_yazdirmaAyarlari.BaslikEkle == "Hayır") return;
            var headerArea = new PageHeaderArea();
            headerArea.Content.AddRange(new[] { "", _yazdirmaAyarlari.RaporBaslik, "" });
            headerArea.Font = new Font("Arial Narrow", 10F, FontStyle.Bold);
            headerArea.LineAlignment = BrickAlignment.Far;
            _link.PageHeaderFooter = new PageHeaderFooter(headerArea, null);
        }
    }

    public class YazdirmaAyarlari
    {
        public string RaporBaslik { get; set; }
        public string BaslikEkle { get; set; }
        public string RaporuKagidaSigdir { get; set; }
        public string YazdirmaYonu { get; set; }
        public string YatayCizgileriGoster { get; set; }
        public string DikeyCizgileriGoster { get; set; }
        public string SutunBasliklariniGoster { get; set; }
        public string YaziciAdi { get; set; }
        public int YazdirilacakAdet { get; set; }
        public string YazdirilacakNesne { get; set; }
    }
}