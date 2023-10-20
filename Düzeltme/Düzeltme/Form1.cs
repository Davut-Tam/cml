using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Düzeltme.OgrenciTahakkukF;

namespace Düzeltme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /// düzeltme
            try { Connections.cnn.Execute("IF COL_LENGTH('[dbo].[Ogrenci]', 'Veli2Id') IS NULL begin  ALTER TABLE [dbo].[Ogrenci] ADD [Veli2Id] Bigint null DEFAULT(Null) end"); } catch { }


            var ogrenci = OgrenciF.Liste(true).Where(x => x.Tel2 != null).ToList();
            long id = 2022111312105204841;
            foreach (var item in ogrenci)
            {
                if (item.AnaAdi == "" || item.AnaAdi == null) continue;
                var soyad = item.AdiSoyadi.Split(' ');
                var veli = new Veli
                {
                    Id = id,
                    VeliAdiSoyadi = item.AnaAdi + " " + soyad[soyad.Length - 1],
                    Durum = true,
                    Tel1 = item.Tel2,
                    IslemTarihi = DateTime.Now,
                    KullaniciId = 2021031312474139748,

                };

                var velilistesi = VeliF.Liste();
             
                    if (velilistesi.Any(x => x.Tel1 == veli.Tel1))
                    {
                        var yeniID = velilistesi.FirstOrDefault(x => x.Tel1 == veli.Tel1).Id;
                        Connections.cnn.Execute($"Update Ogrenci Set Veli2Id={veli.Id} Where Id={yeniID}");
                    }
                    else
                    {
                        if (VeliF.Ekle(veli))
                        {
                            Connections.cnn.Execute($"Update Ogrenci Set Veli2Id={veli.Id} Where Id={item.Id}");
                            label1.Text = veli.VeliAdiSoyadi;
                            Application.DoEvents();

                            id++;
                        }
                    }
                
               



            }


            try { Connections.cnn.Execute("IF COL_LENGTH('[dbo].[Ogrenci]', 'AnaAdi') IS NOT NULL begin   ALTER TABLE Ogrenci DROP COLUMN AnaAdi end"); } catch { }

            try { Connections.cnn.Execute("IF COL_LENGTH('[dbo].[Ogrenci]', 'BabaAdi') IS NOT NULL begin   ALTER TABLE Ogrenci DROP COLUMN BabaAdi end"); } catch { }
            try { Connections.cnn.Execute("EXEC sp_rename '[dbo].[Ogrenci].[VeliId]', Veli1Id, 'COLUMN'"); } catch { }



            try { Connections.cnn.Execute("IF COL_LENGTH('[dbo].[Veli]', 'Tel2') IS NOT NULL begin   ALTER TABLE Veli DROP COLUMN Tel2 end"); } catch { }
            try { Connections.cnn.Execute("EXEC sp_rename '[dbo].[Veli].[Tel1]', Telefon, 'COLUMN'"); } catch { }
            try { Connections.cnn.Execute("IF COL_LENGTH('[dbo].[Personel]', 'Tel2') IS NOT NULL begin   ALTER TABLE Personel DROP COLUMN Tel2 end"); } catch { }
            try { Connections.cnn.Execute("EXEC sp_rename '[dbo].[Personel].[Tel1]', Telefon, 'COLUMN'"); } catch { }
            try { Connections.cnn.Execute("IF COL_LENGTH('[dbo].[Firma]', 'Tel2') IS NOT NULL begin   ALTER TABLE Firma DROP COLUMN Tel2 end"); } catch { }
            try { Connections.cnn.Execute("EXEC sp_rename '[dbo].[Firma].[Tel1]', Telefon, 'COLUMN'"); } catch { }




            // View Güncelleme
            try
            {
                Connections.cnn.Execute(@"alter view [dbo].[viewOgrenciListesi]
                                                as
                                                SELECT        o.Id, o.TcKimlikNo, o.AdiSoyadi, o.Veli1Id, o.Veli2Id, o.EmailAdresi, o.GeldigiOkul, o.Adres, o.DonemId, o.GrupId, o.SinifId, o.KayitTarihi, o.Aciklama, o.Durum, o.Resim, o.KayitTutari, o.TahakkukNo, o.TahakkukTutari, 
                         o.KullaniciId, o.IslemTarihi, o.OtoSms, v1.VeliAdiSoyadi AS Veli1AdiSoyadi, v1.Telefon AS Veli1Telefon, v2.VeliAdiSoyadi AS Veli2AdiSoyadi, v2.Telefon AS Veli2Telefon, d.DonemAdi, g.GrupAdi, s.SinifAdi,gr.GorevAdi as Veli1MeslekAdi,gr2.GorevAdi as Veli2MeslekAdi,
						 COALESCE (ot2.Toplam,0) AS TahsilatTutari, COALESCE (ot2.Iade, 0) AS GeriIadeTutari, COALESCE (o.TahakkukTutari, 0) + COALESCE (ot2.Iade, 0) - COALESCE (ot2.Toplam, 0) AS KalanBakiye
                            FROM            dbo.Ogrenci AS o LEFT OUTER JOIN
                         dbo.Veli AS v1 ON o.Veli1Id = v1.Id LEFT OUTER JOIN
                         dbo.Veli AS v2 ON o.Veli2Id = v2.Id LEFT OUTER JOIN
                         dbo.Donem AS d ON o.DonemId = d.Id LEFT OUTER JOIN
                         dbo.Grup AS g ON o.GrupId = g.Id LEFT OUTER JOIN
                         dbo.Sinif AS s ON o.SinifId = s.Id LEFT OUTER JOIN
						 dbo.Gorev AS gr ON v1.GorevId = gr.Id LEFT OUTER JOIN
						 dbo.Gorev AS gr2 ON v2.GorevId = gr2.Id LEFT OUTER JOIN
                         dbo.viewOgrTahsList2 AS ot2 ON ot2.OgrenciId = o.Id");


            }
            catch { }


            try
            {
                Connections.cnn.Execute(@"alter view [dbo].[viewPersonelListesi]
                                                as
                        SELECT        p.Id, p.TcKimlikNo, p.AdiSoyadi, p.GorevId, p.BaslamaTarihi, p.Maas, p.MaasOdemeGunu, p.Resim, p.EmailAdresi, p.Telefon, p.Adres, p.BankaAdi, p.IbanNo, p.Aciklama, p.IslemTarihi, p.KullaniciId, p.Durum, p.OtomatikMaas, 
                         CASE p.OtomatikMaas WHEN 1 THEN 'Otomatik' ELSE 'Manuel' END AS TahakkukSekli, g.GorevAdi,
                             (SELECT        COALESCE (SUM(Maas), 0) AS Expr1
                               FROM            dbo.PersonelOdemePlani
                               WHERE        (p.Id = PersonelId)) AS HakedilenMaas,
                             (SELECT        COALESCE (SUM(Tutar), 0) AS Expr1
                               FROM            dbo.viewPersTumOdemeListesi
                               WHERE        (PersonelId = p.Id)) AS OdenenMaas,
                             (SELECT        COALESCE (SUM(Tutar), 0) AS Expr1
                               FROM            dbo.viewPersTumIadeListesi
                               WHERE        (PersonelId = p.Id)) AS ToplamIade,
                             (SELECT        COALESCE (SUM(Maas), 0) AS Expr1
                               FROM            dbo.PersonelOdemePlani AS PersonelOdemePlani_2
                               WHERE        (p.Id = PersonelId)) +
                             (SELECT        COALESCE (SUM(Tutar), 0) AS Expr1
                               FROM            dbo.viewPersTumIadeListesi AS viewPersTumIadeListesi_1
                               WHERE        (PersonelId = p.Id)) -
                             (SELECT        COALESCE (SUM(Tutar), 0) AS Expr1
                               FROM            dbo.viewPersTumOdemeListesi AS viewPersTumOdemeListesi_1
                               WHERE        (PersonelId = p.Id)) AS KalanBakiye,
                             (SELECT        MAX(SonOdemeTarihi) AS Expr1
                               FROM            dbo.PersonelOdemePlani AS PersonelOdemePlani_1
                               WHERE        (PersonelId = p.Id)) AS SonMaasTahakkukTarihi
FROM            dbo.Personel AS p LEFT OUTER JOIN
                         dbo.Gorev AS g ON p.GorevId = g.Id

");


            }
            catch { }
            Application.Exit();


        }


    }
}
