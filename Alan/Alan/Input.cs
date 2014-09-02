using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alan
{
    public static class Input
    {
        public static void DrinkPotion()
        {
            SendKeys.SendWait("{1}");
        }
    }
}
