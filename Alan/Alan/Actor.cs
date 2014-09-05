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
        private enum Directions {Right, Down, Left, Up};
        private Directions alansDirection = Directions.Right;

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
            Console.WriteLine("le move");
            Point leExplorer = new Point(Map.gridWidth / 2, Map.gridWidth / 2);
            
            if(alansDirection == Directions.Right)
            {
                if (Map.Segments[leExplorer.X + 1][leExplorer.Y])
                {
                    Input.MoveRight();
                }
                else
                {
                    alansDirection = Directions.Down;
                }
            }

            if(alansDirection == Directions.Down)
            {
                Input.MoveDown();
            }
        }
    }
}
