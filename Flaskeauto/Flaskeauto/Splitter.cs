using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskeauto
{
    public class Splitter
    {
        public static void SplitterQ()
        {
            // Valueable to hold my objects
            Drink drink;
            ViewModel model = new ViewModel();

            // A splitter that acts as a consumer and recieves everything from the previous buffer,
            // and sort the objects by name and pulse the objects out to the next buffers as a producer.
            while (true)
            {
                try
                {
                    if (Monitor.TryEnter(Starter.drinks))
                    {
                        if (Starter.drinks.Count == 0)
                        {
                            Monitor.Wait(Starter.drinks);
                        }
                        else
                        {
                            drink = Starter.drinks.Dequeue();

                            if (drink.Name == "Beer")
                            {
                                if (Monitor.TryEnter(Starter.beers))
                                {
                                    while (Starter.beers.Count < 10)
                                    {
                                        Starter.beers.Enqueue(drink);

                                        Monitor.PulseAll(Starter.beers);
                                        Thread.Sleep(500);
                                    }

                                    Monitor.Exit(Starter.beers);
                                }


                            }
                            else if (drink.Name == "Soda")
                            {
                                if (Monitor.TryEnter(Starter.sodas))
                                {
                                    while (Starter.sodas.Count < 10)
                                    {
                                        Starter.sodas.Enqueue(drink);
                                        //model.Soda.Add();
                                        Monitor.PulseAll(Starter.sodas);
                                        Thread.Sleep(500);

                                    }

                                    Monitor.Exit(Starter.sodas);
                                }
                            }


                        }

                    }
                }
                finally
                {
                    if (Monitor.IsEntered(Starter.drinks))
                    {
                        Monitor.Exit(Starter.drinks);
                    }

                    //Console.Clear();
                    Debug.WriteLine("{0} unsorted", Starter.drinks.Count);
                    Debug.WriteLine("{0} Beers", Starter.sodas.Count);
                    Debug.WriteLine("{0} Sodas", Starter.beers.Count);

                    Thread.Sleep(200);

                }

            }
        }
    }
}
