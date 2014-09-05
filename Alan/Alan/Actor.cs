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
        private enum Directions {Right = 0, Down = 1, Left = 2, Up = 3};
        private Directions alansDirection = Directions.Right;
        private int rotationsInOneDirectionInARow = 0;

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
            Point alansLocation = new Point(Map.gridWidth / 2, Map.gridWidth / 2);
            if (CanMove((Directions)(((int)alansDirection + 3) % 4), alansLocation))
            {
                alansDirection = (Directions)(((int)alansDirection + 3) % 4);
            }
            else if (!CanMove(alansDirection, alansLocation))
            {
                alansDirection = (Directions)(((int)alansDirection + 1) % 4);
            }
            MoveForward(alansDirection);
            Console.WriteLine(alansDirection);
        }

        private void MoveForward(Directions forward)
        {
            Console.WriteLine(forward);
            if (forward == Directions.Right)
            {
                Input.MoveRight();
            }
            if (forward == Directions.Down)
            {
                Input.MoveDown();
            }
            if (forward == Directions.Left)
            {
                Input.MoveLeft();
            }
            if (forward == Directions.Up)
            {
                Input.MoveUp();
            }
        }
       
        private bool CanMove(Directions leDirection, Point alansLocation)
        {
            if(leDirection == Directions.Right)
            {
                return Map.Segments[alansLocation.X + 1][alansLocation.Y] && Map.Segments[alansLocation.X + 2][alansLocation.Y];
            }
            if (leDirection == Directions.Down)
            {
                return Map.Segments[alansLocation.X][alansLocation.Y + 1] && Map.Segments[alansLocation.X][alansLocation.Y + 2];
            }
            if (leDirection == Directions.Left)
            {
                return Map.Segments[alansLocation.X - 1][alansLocation.Y] && Map.Segments[alansLocation.X - 2][alansLocation.Y];
            }
            if (leDirection == Directions.Up)
            {
                return Map.Segments[alansLocation.X][alansLocation.Y - 1] && Map.Segments[alansLocation.X][alansLocation.Y - 2];
            }

            return true;
        }
    }
}
