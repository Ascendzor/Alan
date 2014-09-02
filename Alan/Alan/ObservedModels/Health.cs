using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alan.ObservedModels
{
    public class Health
    {
        public static int CurrentHealth;
        public static int MaximumHealth;

        public static void Print()
        {
            Console.WriteLine("Health");
            Console.WriteLine("Current Health: " + CurrentHealth);
            Console.WriteLine("Maximum Health: " + MaximumHealth);
        }
    }
}
