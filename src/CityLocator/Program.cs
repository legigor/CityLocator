using System;
using System.IO;
using System.Linq;
using Stopwatch = System.Diagnostics.Stopwatch;

namespace CityLocator
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();

            var allCities = File.ReadAllLines(@"C:\temp\geo\ua.txt").Select(GeoName.Load).ToArray();

            Console.WriteLine($"Loaded {allCities.Length} cities in {sw.Elapsed}");
        }
    }
}
