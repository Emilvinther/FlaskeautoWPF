using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeauto
{
    public abstract class Drink : INotifyPropertyChanged
    {
        // Super class with 1 valueable
        protected string name;

        

        public string Name 
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
         

        public Drink(string name)
        {
            this.name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
       

        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }

}
