using System;
using System.IO;
using System.Linq;
using Stopwatch = System.Diagnostics.Stopwatch;

namespace CityLocator
{
    class Program
    {
        static void Main()
        {
            var sw = Stopwatch.StartNew();

            var geo = new Geo();
            geo.Initialize(@"C:\temp\geo\ua.txt");

            Print(geo.Reverse(46.022189f, 30.372775f));            // UA, Serhiyivka
            Print(geo.Reverse(46.231371f, 29.937392f));            // UA, Khadzhider
            Print(geo.Reverse(45.333595f, 28.827672f));            // UA, Izmayil
            Print(geo.Reverse(36.888045f, -92.756167f));           // US, Missouri

            Console.WriteLine($"Processed in {sw.Elapsed}");
        }

        static void Print(GeoName geo)
        {
            Console.WriteLine($"{geo.CountryCode}, {geo.Name}");
        }
    }
}
