using Alan.ObservedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alan
{
    class Program
    {
        static void Main(string[] args)
        {
            Observer leObserver = new Observer();
            Actor leActor = new Actor();

            while(true)
            {
                leObserver.Observe();
                leActor.Act();

                Thread.Sleep(1000);
            }
        }
    }
}
