using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace Alan
{
    public static class Input
    {
        private static InputSimulator leInputs = new InputSimulator();
        private static int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        private static int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        public static void MoveRight()
        {
            leInputs.Mouse.MoveMouseTo(65535 / 2 + 65535 / 10, 65535 / 2);
            Thread.Sleep(50);
            leInputs.Mouse.LeftButtonClick();
        }

        public static void MoveDown()
        {
            leInputs.Mouse.MoveMouseTo(65535 / 2, 65535 / 2 + 65535 / 10);
            Thread.Sleep(50);
            leInputs.Mouse.LeftButtonClick();
        }
        
        public static void MoveUp()
        {
            leInputs.Mouse.MoveMouseTo(65535 / 2 / 10, 65535 / 2 - 65535 / 10);
            Thread.Sleep(50);
            leInputs.Mouse.LeftButtonClick();
        }

        public static void MoveLeft()
        {
            leInputs.Mouse.MoveMouseTo(65535 / 2 - 65535 / 10, 65535 / 2);
            Thread.Sleep(50);
            leInputs.Mouse.LeftButtonClick();
        }

        public static void DrinkPotion()
        {
            SendKeys.SendWait("{1}");
        }
    }
}
