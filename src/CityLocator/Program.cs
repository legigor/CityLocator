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

            Measure(() => geo.Initialize(@"C:\temp\geo\ua.txt"), "Load geo for UA");
            Measure(() => geo.Initialize(@"C:\temp\geo\by.txt"), "Load geo for BY");
            Measure(() => geo.Initialize(@"C:\temp\geo\ru.txt"), "Load geo for RU");
            Measure(() => geo.Initialize(@"C:\temp\geo\kz.txt"), "Load geo for KZ");
            Measure(() => geo.Initialize(@"C:\temp\geo\us.txt"), "Load geo for US");

            Measure(() => Print(geo.Reverse(46.022189f, 30.372775f)), "Reverse");            // UA, Serhiyivka
            Measure(() => Print(geo.Reverse(46.231371f, 29.937392f)), "Reverse");            // UA, Khadzhider
            Measure(() => Print(geo.Reverse(45.333595f, 28.827672f)), "Reverse");            // UA, Izmayil
            Measure(() => Print(geo.Reverse(53.297608f, 29.302425f)), "Reverse");            // BY, Kostrichskaya Slobodka
            Measure(() => Print(geo.Reverse(65.709181f, 153.818920f)), "Reverse");           // RU, Khrebet Krest-Tass
            Measure(() => Print(geo.Reverse(46.424308f, 69.565042f)), "Reverse");            // KZ, Sor-Bulak
            Measure(() => Print(geo.Reverse(36.888045f, -92.756167f)), "Reverse");           // US, MO, McKnight Cemetery

            Console.ReadKey(false);
        }

        static void Measure(Action act, string description)
        {
            var sw = Stopwatch.StartNew();

            act();

            Console.WriteLine($">>> {description} in {sw.Elapsed}");
        }

        static void Print(GeoName geo)
        {
            Console.WriteLine($"{geo.CountryCode}, {geo.Admin1Code}, {geo.Name}");
        }
    }
}
