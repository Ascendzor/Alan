using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Alan
{
    class VisualInformation
    {
        private Bitmap leFullInformation;

        public VisualInformation()
        {
            this.leFullInformation = GenerateImage();
        }

        public Bitmap GetHealthVisual()
        {
            var bounds = new Rectangle(0, 0, 100, 100);
            var bmp = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            
            leFullInformation.Save("asd.jpg");
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.DrawImage(leFullInformation, new Rectangle(0, 0, 100, 100), new Rectangle(110, 850, 100, 100), GraphicsUnit.Pixel);
            
            bmp.Save("Le.jpg");

            return bmp;
            
        }

        private Bitmap GenerateImage()
        {
            var bounds = Screen.PrimaryScreen.Bounds;
            var bmp = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);

            using (var gfx = Graphics.FromImage(bmp))
            {
                gfx.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            }
            
            return bmp;
        }
    }
}
