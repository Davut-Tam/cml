using DevExpress.XtraEditors;
using OgrenciTakipMuh.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace OgrenciTakipMuh.Data.Tools
{
    public static class FormFunctions
    {
    

        public static void FormSablonKaydet(this string sablonAdi, int left, int top, int width, int height, FormWindowState windowState)
        {
            try
            {
                if (!Directory.Exists(@"C:\Öğrenci Muh Dosyaları\Location")) // klasör var mı
                    Directory.CreateDirectory( @"C:\Öğrenci Muh Dosyaları\Location");// klasör ekle
                var settings = new XmlWriterSettings { Indent = true };
                var writer = XmlWriter.Create( $@"C:\Öğrenci Muh Dosyaları\Location\{sablonAdi}_location.xml", settings);// xml dosya oluşturma
                writer.WriteStartDocument();
                writer.WriteComment("DT Yazılım tarafından oluşturmuştur.");
                writer.WriteStartElement("Tablo");
                writer.WriteStartElement("Location");
                writer.WriteAttributeString("Left", left.ToString());
                writer.WriteAttributeString("Top", top.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("FormSize");
                if (windowState == FormWindowState.Maximized)
                {
                    writer.WriteAttributeString("Width", "-1");
                    writer.WriteAttributeString("Height", "-1");
                }
                else
                {
                    writer.WriteAttributeString("Width", width.ToString());
                    writer.WriteAttributeString("Height", height.ToString());
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();

            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
            }
        }

        public static void FormSablonYukle(this string sablonAdi, XtraForm frm)
        {
            var list = new List<string>();
            try
            {
                if (File.Exists($@"C:\Öğrenci Muh Dosyaları\Location\{sablonAdi}_location.xml"))
                { // dosya var mı
                    var reader = XmlReader.Create($@"C:\Öğrenci Muh Dosyaları\Location\{sablonAdi}_location.xml");
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Location")
                        {
                            list.Add(reader.GetAttribute(0));
                            list.Add(reader.GetAttribute(1));
                        }
                        else if (reader.NodeType == XmlNodeType.Element && reader.Name == "FormSize")
                        {
                            list.Add(reader.GetAttribute(0));
                            list.Add(reader.GetAttribute(1));
                        }
                    }
                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {

                Messages.HataMesaji(ex.Message);
            }
            if (list.Count <= 0) return;

            frm.Location = new System.Drawing.Point(int.Parse(list[0]), int.Parse(list[1]));
            if (list[2] == "-1" && list[3] == "-1")
                frm.WindowState = FormWindowState.Maximized;
            else
                frm.Size = new System.Drawing.Size(int.Parse(list[2]), int.Parse(list[3]));
        }
    }
}
