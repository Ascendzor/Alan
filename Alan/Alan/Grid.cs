using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan
{
    public class Grid
    {
        private int x;
        private int y;
        private int width;
        private int height;
        private bool goodWalkability;

        public Grid(int x, int y, int width, int height)
        {
            Console.WriteLine("created new grid" + x + " " + y);
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.goodWalkability = true;
        }

        public void CalculateWalkability(Bitmap leMiniMap)
        {
            int totalRed = 0;
            int totalGreen = 0;
            int totalBlue = 0;
            int pixelCount = 0;

            for(int x=this.x; x<(this.x+this.width); x++)
            {
                for(int y=this.y; y<(this.y+this.height); y++)
                {
                    totalRed += leMiniMap.GetPixel(x, y).R;
                    totalGreen += leMiniMap.GetPixel(x, y).G;
                    totalBlue += leMiniMap.GetPixel(x, y).B;
                    pixelCount++;
                }
            }

            int averageRed = totalRed / pixelCount;
            int averageGreen = totalGreen / pixelCount;
            int averageBlue = totalBlue / pixelCount;

            Console.WriteLine("grid: " + this.x + " " + this.y + "\t averageColour: " + averageRed + " " + averageGreen + " " + averageBlue);
            if(averageRed > 75)
            {
                this.goodWalkability = false;
            }else if(averageBlue > 65)
            {
                this.goodWalkability = false;
            }

            Console.WriteLine(goodWalkability);
        }
    }
}
