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
                try
                {
                    leObserver.Observe();
                    leActor.Act();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Something somewhere fucked up");
                }

                Thread.Sleep(1000);
            }
        }
    }
}
