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
using Alan.ObservedModels;

namespace Alan
{
    class Observer
    {
        private Ocr ocr;
        private VisualInformation leVisuals;
        private Grid[][] grid;

        public Observer()
        {
            ocr = new Ocr();
            ocr.DataPath = AppDomain.CurrentDomain.BaseDirectory;

            leVisuals = new VisualInformation();
            DefineWalkabilityGrid(leVisuals.GetMapVisual());
        }

        //Return the observable information
        public void Observe()
        {
            leVisuals.SetupFrame();
            ObserveHealth(leVisuals.GetHealthVisual());
            ObserveSpace(leVisuals.GetMapVisual());
        }

        private void DefineWalkabilityGrid(Bitmap leMiniMap)
        {
            int meshCount = 20;
            int gridSquare = leMiniMap.Width / meshCount;
            grid = new Grid[meshCount][];
            for (int row = 0; row < meshCount; row++)
            {
                grid[row] = new Grid[meshCount];
            }
            for (int x = 0; x < meshCount; x++)
            {
                for (int y = 0; y < meshCount; y++)
                {
                    grid[x][y] = new Grid(x * gridSquare, y * gridSquare, gridSquare, gridSquare);
                }
            }
        }

        private void ObserveHealth(Bitmap leHealthVisual)
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

                Health.CurrentHealth = currentHealth;
                Health.MaximumHealth = maximumHealth;

                Health.Print();
            }
            catch(Exception e)
            {
                Console.WriteLine("prolly just misread the health");
            }
        }

        public void ObserveSpace(Bitmap leMiniMap)
        {
            for(int x=0; x<grid.Length; x++)
            {
                for(int y=0; y<grid[0].Length; y++)
                {
                    grid[x][y].CalculateWalkability(leMiniMap);
                }
            }
        }
    }
}
