using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryOCP.Models;

namespace AbstractFactoryOCP.Factories
{
    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
}
