using Alan.ObservedModels;
using System;
using System.Collections.Generic;
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
        }

        private void CheckHealth()
        {
            if(Health.CurrentHealth < (Health.MaximumHealth/2))
            {
                Input.DrinkPotion();
            }
        }
    }
}
