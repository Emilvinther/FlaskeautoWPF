using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeauto
{
    public class Beer : Drink
    {


        public byte[] picture = System.IO.File.ReadAllBytes("C:\\Users\\zbcevlo\\source\\repos\\Flaskeauto\\Flaskeauto\\Resource\\soda.jpg");
        protected string beerCan;

        

        

        public string BeerCan
        {
            get { return beerCan; }
            set 
            { 
                beerCan = Convert.ToBase64String(picture);
                if (beerCan != value)
                {
                    beerCan = value;
                    RaisePropertyChanged("BeerCan");
                }
            }
        }

        internal Beer(string name) : base(name)
        {
            
        }
    

    }
}
