using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AbstractFactoryOCP.Models
{
    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("This coffee is delicious!");
        }
    }
}
