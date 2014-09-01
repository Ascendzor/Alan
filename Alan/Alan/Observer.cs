using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;
using System.Drawing.Imaging;

namespace Alan
{
    class Observer
    {
        public Observer()
        {

        }

        public void Observe()
        {
            GenerateImage();
        }

        private void GenerateImage()
        {
            var bounds = Screen.PrimaryScreen.Bounds;
            using (var bmp = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb))
            {
                using (var gfx = Graphics.FromImage(bmp))
                {
                    gfx.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
                    bmp.Save("shot.png");
                }
            }
        }
    }
}
