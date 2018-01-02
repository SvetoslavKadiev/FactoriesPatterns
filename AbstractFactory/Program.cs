using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AbstractFactory
{

    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffee is delicious!");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
       
        public enum AvailableDrink // violates open-closed
        {
            Coffee,
            Tea
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories =
            new Dictionary<AvailableDrink, IHotDrinkFactory>();

        //private List<Tuple<string, IHotDrinkFactory>> namedFactories =
        //  new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                Type factoryType = Type.GetType($"AbstractFactory.{Enum.GetName(typeof(AvailableDrink), drink)}Factory");
                var factory = (IHotDrinkFactory)Activator.CreateInstance(factoryType);

                factories.Add(drink, factory);
            }

            //foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            //{
            //    if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
            //    {
            //        namedFactories.Add(Tuple.Create(
            //          t.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(t)));
            //    }
            //}
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }

    class Program
    {


        static void Main(string[] args)
        {

            var machine = new HotDrinkMachine();

            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 300);
            drink.Consume();

            drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 200);
            drink.Consume();

            ReadLine();
        }
    }
}
