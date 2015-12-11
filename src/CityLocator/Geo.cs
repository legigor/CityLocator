using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace CityLocator
{
    class Geo
    {
        readonly Dictionary<ZoneKey, List<GeoName>> _zones = new Dictionary<ZoneKey, List<GeoName>>();

        public void Initialize(IEnumerable<GeoName> names)
        {
            foreach (var name in names)
            {
                var key = ZoneKey.Create(name.Latitude, name.Longitude);

                List<GeoName> zone;

                if (_zones.ContainsKey(key))
                    zone = _zones[key];
                else
                {
                    zone = new List<GeoName>();
                    _zones.Add(key, zone);
                }
                zone.Add(name);    
            }
        }

        List<GeoName> FindClosestZone(float latitude, float longitude)
        {
            if(_zones.Count == 0)
                throw new InvalidOperationException("Not initialized");

            var key = ZoneKey.Create(latitude, longitude);
            var distances = from z in _zones
                            let zKey = z.Key
                            select new
                            {
                                Zone = z,
                                Distance = GetDistance(zKey.Latitude, zKey.Longitude, key.Latitude, key.Longitude)
                            };


            return distances.OrderBy(x => x.Distance).First().Zone.Value;
        }

        public GeoName Reverse(float latitude, float longitude)
        {
            var zone = FindClosestZone(latitude, longitude);

            var distances = from n in zone
                            select new
                            {
                                Name = n,
                                Distance = GetDistance(latitude, longitude, n.Latitude, n.Longitude)
                            };

            return distances.OrderBy(x => x.Distance).Select(x => x.Name).First();
        }

        private static double GetDistance(float latitude1, float longitude1, float latitude2, float longitude2)
        {
            return Math.Sqrt(Math.Pow(latitude2 - latitude1, 2) + Math.Pow(longitude2 - longitude1, 2));
        }

        struct ZoneKey
        {
            public int Latitude;
            public int Longitude;

            public static ZoneKey Create(float latitude, float longitude)
            {
                const int precition = 20;

                return new ZoneKey
                {
                    Latitude = (int) latitude / precition,
                    Longitude = (int) longitude / precition
                };
            }
        }
    }
}