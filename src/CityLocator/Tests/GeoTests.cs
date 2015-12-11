using System;
using NUnit.Framework;

namespace CityLocator.Tests
{
    [TestFixture]
    public class GeoTests
    {
        const float LatitudeOdessa = 46.4774704f;
        const float LongitudeOdessa = 30.7326202f;
        const string NameOdessa = "Odessa";

        const float LatitudeKuchurhan = 47.16302f;
        const float LongitudeKuchurhan = 29.78937f;
        const string NameKuchurhan = "Kuchurhan";

        const float LatitudeOvidiopol = 46.24998f;
        const float LongitudeOvidiopol = 30.44127f;
        const string NameOvidiopol = "Ovidiopol";

        [Test]
        public void Should_construct_geo_name_from_datasource()
        {
            var record = GeoName.Load("698740	Odessa	Odessa	Ades,Gorad Adehsa,ODS,Odesa,Odess,Odessa,Odessae,Odesse,Odessos,Odessus,Odessza,Oděsa,Udessa,ao de sa,awdsa,awdysa,odesa,odessa,Ódessa,Οδησσός,Горад Адэса,Одеса,Одесс,Одессæ,Одесса,Одессе,Օդեսա,אדעס,אודסה,أوديسا,اودسا,اوديسا,اودیسا,ओदेसा,အိုဒက်ဆာမြို့,ოდესა,オデッサ,敖德薩,오데사	46.47747	30.73262	P	PPLA	UA		17				1001558		58	Europe/Kiev	2015-02-06");

            Assert.AreEqual(698740, record.GeoNameId);
            Assert.AreEqual(NameOdessa, record.Name);
            Assert.AreEqual(NameOdessa, record.AsciiName);
            Assert.AreEqual("Ades,Gorad Adehsa,ODS,Odesa,Odess,Odessa,Odessae,Odesse,Odessos,Odessus,Odessza,Oděsa,Udessa,ao de sa,awdsa,awdysa,odesa,odessa,Ódessa,Οδησσός,Горад Адэса,Одеса,Одесс,Одессæ,Одесса,Одессе,Օդեսա,אדעס,אודסה,أوديسا,اودسا,اوديسا,اودیسا,ओदेसा,အိုဒက်ဆာမြို့,ოდესა,オデッサ,敖德薩,오데사", record.AlternateNames);
            Assert.AreEqual(LatitudeOdessa, record.Latitude);
            Assert.AreEqual(LongitudeOdessa, record.Longitude);
            Assert.AreEqual("P", record.FeatureClass);
            Assert.AreEqual("PPLA", record.FeatureCode);
            Assert.AreEqual("UA", record.CountryCode);
            Assert.AreEqual("", record.Cc2);
            Assert.AreEqual("17", record.Admin1Code);
            Assert.AreEqual("", record.Admin2Code);
            Assert.AreEqual("", record.Admin3Code);
            Assert.AreEqual("", record.Admin4Code);
            Assert.AreEqual(1001558, record.Population);
            Assert.AreEqual(null, record.Elevation);
            Assert.AreEqual("58", record.Dem);
            Assert.AreEqual("Europe/Kiev", record.Timezone);
            Assert.AreEqual(new DateTime(2015, 2, 6), record.ModificationDate);
        }

        [Test]
        public void Should_reverse_coordinates_to_geo_name()
        {
            var geo = new Geo();
            geo.Initialize(new[]
            {
                new GeoName { CountryCode = "UA", Name = NameOdessa,    Latitude = LatitudeOdessa,    Longitude = LongitudeOdessa },
                new GeoName { CountryCode = "UA", Name = NameKuchurhan, Latitude = LatitudeKuchurhan, Longitude = LongitudeKuchurhan },
                new GeoName { CountryCode = "UA", Name = NameOvidiopol, Latitude = LatitudeOvidiopol, Longitude = LongitudeOvidiopol },
            });

            var nameInBoundaries = geo.Reverse(46.022189f, 30.372775f);
            Assert.AreEqual(NameOvidiopol, nameInBoundaries.Name);

            var nameOutOfBoundaries = geo.Reverse(36.888045f, -92.756167f); 
            Assert.AreEqual("UA", nameOutOfBoundaries.CountryCode); // US, Missouri
        }
    }
}