using OgrenciTakipMuh.Controls.Components;
using DevExpress.XtraBars;
using OgrenciTakipMuh.Tools;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace AbcYazilim.OgrenciTakip.UI.Win.Functions
{
    public static class PictureFunctions
    {
        #region Veriables
        private static MyPictureEdit _pictureEdit;
        private static PopupMenu _popupMenu;
        #endregion

        private static void RemoveEvents()
        {
            if (_pictureEdit == null) return;

            _pictureEdit.KeyDown -= PictureEdit_KeyDown;
            _pictureEdit.DoubleClick -= PictureEdit_DoubleClick;
            _pictureEdit.MouseUp -= PictureEdit_MouseUp;
            _popupMenu.Popup -= PopupMenu_Popup;
            foreach (BarItemLink link in _popupMenu.ItemLinks)
                link.Item.ItemClick -= Buttons_ItemClick;
        }
        public static void Sec(this MyPictureEdit pictureEdit, PopupMenu popupMenu)
        {
            RemoveEvents();
            _pictureEdit = pictureEdit;
            _popupMenu = popupMenu;
            _pictureEdit.KeyDown += PictureEdit_KeyDown;
            _pictureEdit.DoubleClick += PictureEdit_DoubleClick;
            _pictureEdit.MouseUp += PictureEdit_MouseUp;
            _popupMenu.Popup += PopupMenu_Popup;
            foreach (BarItemLink link in _popupMenu.ItemLinks)
                link.Item.ItemClick += Buttons_ItemClick;
        }

        private static void ResimSec()
        {
            var resim = ResimYukle();
            if (resim == null) return;
            _pictureEdit.EditValue = resim;
        }

        private static void ResimSil()
        {
            if (_pictureEdit.Image == null) return;
            //if (Messages.SoruEvetSeciliEvetHayir("Resim Silinecek Emin","") != DialogResult.Yes) return;
            _pictureEdit.Image = null;
        }

        private static void PictureEdit_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Delete:
                    ResimSil();
                    break;

                case Keys.Insert:
                case Keys.F4:
                case Keys.Down when e.Modifiers == Keys.Alt:

                    ResimSec();

                    break;
            }
        }



        private static void PictureEdit_DoubleClick(object sender, EventArgs e)
        {
            ResimSec();
        }
        private static void PictureEdit_MouseUp(object sender, MouseEventArgs e)
        {
            e.ShowPopupMenu(_popupMenu);
        }

        private static void PopupMenu_Popup(object sender, EventArgs e)
        {
            _popupMenu.ItemLinks[1].Item.Enabled = _pictureEdit.Image != null;// resim nulsa pasif yap
        }
        private static void Buttons_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == _popupMenu.ItemLinks[0].Item)
                ResimSec();
            else if (e.Item == _popupMenu.ItemLinks[1].Item)
                ResimSil();
        }


        public static byte[] ResimYukle()
        {
            var dialog = new OpenFileDialog
            {
                Title = "Resim Seç",
                Filter = "Resim Dosyaları (*.bmp,*.gif,*.jpg*.png)|*.bmp;*.gif;*.jpg;*.png|Bmp Dosyaları|*.bmp|Gif Dosyaları|*.gif|Jpg Dosyaları|*.jpg|Png Dosyaları|*.png",
                InitialDirectory = @"C:\",

            };

            byte[] Resim()
            {
                using (var stream = new MemoryStream())
                {
                    Image.FromFile(dialog.FileName).Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }

            }

            return dialog.ShowDialog() != DialogResult.OK ? null : Resim();
        }

        public static Image ToImage(this byte[] byteArrayIn)
        {

            return byteArrayIn == null ? null : (Bitmap)((new ImageConverter()).ConvertFrom(byteArrayIn));
        }

        public static byte[] ToByte(this Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

    }
}
