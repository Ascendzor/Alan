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
            goodWalkability = true;
            for(int x=this.x; x<(this.x+this.width); x++)
            {
                for(int y=this.y; y<(this.y+this.height); y++)
                {
                    Color lePixel = leMiniMap.GetPixel(x, y);

                    //check for cliff
                    if(lePixel.R > 82 && lePixel.R < 89)
                    {
                        if(lePixel.G > 51 && lePixel.G < 57) 
                        {
                            if (lePixel.B > 41 && lePixel.B < 47)
                            {
                                goodWalkability = false;
                            }
                        }
                    }
                    
                    //check for water
                    if(lePixel.R > 88 && lePixel.R < 92)
                    {
                        if(lePixel.G > 123 && lePixel.G < 127) 
                        {
                            if (lePixel.B > 121 && lePixel.B < 125)
                            {
                                goodWalkability = false;
                            }
                        }
                    }
                }
            }
        }

        public bool IsWalkable()
        {
            return goodWalkability;
        }
    }
}
