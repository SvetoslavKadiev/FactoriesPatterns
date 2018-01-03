using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryOCP.Models;
using static System.Console;

namespace AbstractFactoryOCP
{
    class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            //var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 300);
            //drink.Consume();

            IHotDrink drink = machine.MakeDrink();
            drink.Consume();

            ReadLine();
        }
    }
}
