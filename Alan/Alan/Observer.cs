using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;
using System.IO;
using Winsoft.Ocr;

namespace Alan
{
    class Observer
    {
        private Ocr ocr;

        public Observer()
        {
            ocr = new Ocr();
            ocr.DataPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        //Return the observable information
        public void Observe()
        {
            VisualInformation leVisuals = new VisualInformation();

            ObserveHealth(leVisuals.GetHealthVisual());
        }

        private int ObserveHealth(Bitmap leHealthVisual)
        {
            try
            {
                ocr.Picture = leHealthVisual;
                ocr.Active = true;
                ocr.Recognize();
                string health = ocr.Text;
                ocr.Active = false;
                health = health.Substring(6);
                string[] healths = health.Split('/');
                int currentHealth = Convert.ToInt32(healths[0]);
                int maximumHealth = Convert.ToInt32(healths[1]);
                Console.WriteLine(currentHealth);
                return currentHealth;
            }
            catch(Exception e)
            {
                Console.WriteLine("prolly just misread the health");
            }
            return 999999;
        }
    }
}
