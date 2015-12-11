using System;
using System.Globalization;

namespace CityLocator
{
    class GeoName
    {
        // public string GeonameId { get; set; } // : integer id of record in geonames database
        public string Name { get; set; } // : name of geographical point (utf8) varchar(200)
        // public string AsciiName { get; set; } // : name of geographical point in plain ascii characters, varchar(200)
        // public string AlternateNames { get; set; } // : alternatenames, comma separated, ascii names automatically transliterated, convenience attribute from alternatename table, varchar(10000)
        public float Latitude { get; set; } // : latitude in decimal degrees (wgs84)
        public float Longitude { get; set; } // : longitude in decimal degrees (wgs84)
        // public string FeatureClass { get; set; } // : see http://www.geonames.org/export/codes.html, char(1)
        // public string FeatureCode { get; set; } // : see http://www.geonames.org/export/codes.html, varchar(10)
        public string CountryCode { get; set; } // : ISO-3166 2-letter country code, 2 characters
        // public string Cc2 { get; set; } // : alternate country codes, comma separated, ISO-3166 2-letter country code, 200 characters
        // public string Admin1Code { get; set; } // : fipscode (subject to change to iso code), see exceptions below, see file admin1Codes.txt for display names of this code; varchar(20)
        // public string Admin2Code { get; set; } // : code for the second administrative division, a county in the US, see file admin2Codes.txt; varchar(80) 
        // public string Admin3Code { get; set; } // : code for third level administrative division, varchar(20)
        // public string Admin4Code { get; set; } // : code for fourth level administrative division, varchar(20)
        public long Population { get; set; } // : bigint (8 byte int)
        // public string Elevation { get; set; } // : in meters, integer
        // public string Dem { get; set; } // : digital elevation model, srtm3 or gtopo30, average elevation of 3''x3'' (ca 90mx90m) or 30''x30'' (ca 900mx900m) area in meters, integer. srtm processed by cgiar/ciat.
        // public string Timezone { get; set; } // : the timezone id (see file timeZone.txt) varchar(40)
        // public string ModificationDate { get; set; } // : date of last modification in yyyy-MM-dd format

        public static GeoName Load(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input string could not be null or empty", nameof(input));

            var fields = input.Split('\t');

            if(fields.Length != 19)
                throw new FormatException("Insufficient fields numbber");

            return new GeoName
            {
                Name = fields[1],
                CountryCode = fields[8],
                Latitude = float.Parse(fields[4], CultureInfo.InvariantCulture),
                Longitude = float.Parse(fields[5], CultureInfo.InvariantCulture),
                Population = string.IsNullOrWhiteSpace(fields[14]) ? 0 : long.Parse(fields[14])
            };
        }
    }
}