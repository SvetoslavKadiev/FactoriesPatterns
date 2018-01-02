using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PointFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point = PointFactory.NewPolarPoint(1, Math.PI / 2);
            WriteLine(point);

            var innerpoint = PointInner.Factory.NewCartesianPoint(1, Math.PI / 2);
            WriteLine(innerpoint);

            ReadLine();
        }
    }
}
