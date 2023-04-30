using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskeauto
{
    public class Producer
    {
        // Drinks generator, its generated in a random and added to the buffer
        public static void ProducerQ()
        {
            Random random = new Random();
            int rando;
            ViewModel model = new ViewModel(); 

            while (true)
            {
                Monitor.Enter(Starter.drinks);
                try
                {
                    if (Starter.drinks.Count < 3)
                    {


                        while (Starter.drinks.Count < 10)
                        {
                            rando = random.Next(1, 5);

                            if (rando == 1 || rando == 2)
                            {
                                Starter.drinks.Enqueue(new Soda("Soda"));
                                model.Drinks.Add(new Soda("Soda"));
                            }
                            else if (rando == 3 || rando == 4)
                            {
                                Starter.drinks.Enqueue(new Beer("Beer"));
                                model.Drinks.Add(new Beer("Beer"));
                            }
                            Monitor.PulseAll(Starter.drinks);
                            Thread.Sleep(500);
                        }

                    }
                }
                finally
                {
                    Debug.WriteLine("Produced");
                    Monitor.Exit(Starter.drinks);
                    Thread.Sleep(500);


                }


            }
        }
    }
}
