using System;
using System.Linq;

namespace CityLocator
{
    class Geo
    {
        readonly GeoName[] _names;

        public Geo(GeoName[] names)
        {
            _names = names;
        }

        public GeoName Reverse(float latitude, float longitude)
        {
            var distances = from n in _names
                            select new
                            {
                                Name = n,
                                Distance = Math.Sqrt(Math.Pow( n.Latitude - latitude, 2) + Math.Pow(n.Longitude - longitude, 2))
                            };

            return distances.OrderBy(x => x.Distance).Select(x => x.Name).First();
        }
    }
}