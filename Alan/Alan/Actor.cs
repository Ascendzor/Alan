using Alan.ObservedModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan
{
    public class Actor
    {
        public void Act()
        {
            CheckHealth();
            Move();
        }

        private void CheckHealth()
        {
            if(Health.CurrentHealth < (Health.MaximumHealth - 40))
            {
                Input.DrinkPotion();
            }
        }

        private void Move()
        {
            Point leExplorer = new Point(Map.gridWidth / 2, Map.gridWidth / 2);
            int distanceFromRightEdge = 0;
            while(true)
            {
                if(Map.Segments[leExplorer.X][leExplorer.Y])
                {
                    leExplorer.X++;
                    distanceFromRightEdge++;
                }
            }

            if(distanceFromRightEdge < 2)
            {

            }
        }
    }
}
