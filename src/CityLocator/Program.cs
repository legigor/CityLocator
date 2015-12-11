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

            var names = File.ReadAllLines(@"C:\temp\geo\ua.txt").Select(GeoName.Load).ToArray();

            var geo = new Geo(names);

            Console.WriteLine(geo.Reverse(46.022189f, 30.372775f).Name);
            Console.WriteLine(geo.Reverse(46.231371f, 29.937392f).Name);
            Console.WriteLine(geo.Reverse(45.333595f, 28.827672f).Name);

            Console.WriteLine($"Loaded {names.Length} cities in {sw.Elapsed}");
        }
    }
}
