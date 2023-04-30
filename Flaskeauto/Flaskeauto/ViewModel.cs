using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flaskeauto
{
    public class ViewModel
    {

        public ObservableCollection<Drink> Drinks { get; set; }
        public ObservableCollection<Soda> Soda { get; set; }
        public ObservableCollection<Beer> Beer { get; set; }

        public void LoadDrinks()
        {
            ObservableCollection<Drink> beverages = new ObservableCollection<Drink>();
            Thread producers = new Thread(Producer.ProducerQ);
            producers.Start();


        }

        public void LoadSodas()
        {
            ObservableCollection<Soda> pepsi = new ObservableCollection<Soda>();
            Thread sodacons = new Thread(Consumer.SodaComsumer);
            sodacons.Start();

        }
    }
}
