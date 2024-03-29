﻿using System;
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

        public void SetupFrame()
        {
            this.leFullInformation = GenerateImage();
        }

        public Bitmap GetHealthVisual()
        {
            var bounds = new Rectangle(0, 0, 300, 70);
            var bmp = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.DrawImage(leFullInformation, new Rectangle(0, 0, 500, 70), new Rectangle(100, 1600, 800, 70), GraphicsUnit.Pixel);
            bmp.Save("LeHealth.jpg");
            return bmp;
        }

        public Bitmap GetMapVisual()
        {
            var bounds = new Rectangle(0, 0, 420, 420);
            var bmp = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);

            Graphics gfx = Graphics.FromImage(bmp);
            gfx.DrawImage(leFullInformation, new Rectangle(0, 0, 420, 420), new Rectangle(3345, 75, 420, 420), GraphicsUnit.Pixel);
            bmp.Save("leMiniMap.jpg");
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
