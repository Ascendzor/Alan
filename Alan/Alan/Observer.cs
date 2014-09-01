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

        //Return the observable information
        public void Observe()
        {
            VisualInformation leVisuals = new VisualInformation();

            ObserveHealth(leVisuals.GetHealthVisual());
        }

        

        private int ObserveHealth(Bitmap leHealthVisual)
        {

            return 0;
        }
    }
}
