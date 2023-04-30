using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeauto
{
    public class Soda : Drink
    {

        public byte[] picture = System.IO.File.ReadAllBytes("C:\\Users\\zbcevlo\\source\\repos\\Flaskeauto\\Flaskeauto\\Resource\\soda.jpg");
        protected string sodaCan;

        public string SodaCan
        {
            get { return sodaCan; }
            set
            {
                sodaCan = Convert.ToBase64String(picture);
                RaisePropertyChanged("SodaCan");
            }
        }

        // Soda object class
        public Soda(string name) : base(name)
        {

        }
    }
}
