using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskeauto
{
    internal class Consumer
    {
        // Beer consumer method that recieve and dequeues if there is any beers in the queue
        public static void BeerConsumer()
        {
            while (true)
            {
                try
                {
                    if (Monitor.TryEnter(Starter.beers))
                    {
                        if (Starter.beers.Count == 0)
                        {
                            Monitor.Wait(Starter.beers);
                        }
                        else
                        {
                            Starter.beers.Dequeue();
                        }
                        Monitor.Exit(Starter.beers);
                    }
                }
                finally
                {

                    Thread.Sleep(200);

                }
            }
        }

        // Soda consumer method that recieve and dequeues if there is any soda in the queue
        public static void SodaComsumer()
        {
            while (true)
            {
                try
                {
                    if (Monitor.TryEnter(Starter.sodas))
                    {
                        if (Starter.sodas.Count == 0)
                        {
                            Monitor.Wait(Starter.sodas);
                        }
                        else
                        {
                            Starter.sodas.Dequeue();
                        }
                        Monitor.Exit(Starter.sodas);
                    }
                }
                finally
                {

                    Thread.Sleep(200);
                }
            }
        }
    }
}
