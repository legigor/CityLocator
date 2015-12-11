using System;
using NUnit.Framework;

namespace CityLocator.Tests
{
    public class GeoNameTests
    {
        [Test]
        public void Should_load_all_fields_from_the_String_in_the_data_file()
        {
            var record = GeoName.Load("698740	Odessa	Odessa	Ades,Gorad Adehsa,ODS,Odesa,Odess,Odessa,Odessae,Odesse,Odessos,Odessus,Odessza,Oděsa,Udessa,ao de sa,awdsa,awdysa,odesa,odessa,Ódessa,Οδησσός,Горад Адэса,Одеса,Одесс,Одессæ,Одесса,Одессе,Օդեսա,אדעס,אודסה,أوديسا,اودسا,اوديسا,اودیسا,ओदेसा,အိုဒက်ဆာမြို့,ოდესა,オデッサ,敖德薩,오데사	46.47747	30.73262	P	PPLA	UA		17				1001558		58	Europe/Kiev	2015-02-06");

            Assert.AreEqual(698740, record.GeoNameId);
            Assert.AreEqual("Odessa", record.Name);
            Assert.AreEqual("Odessa", record.AsciiName);
            Assert.AreEqual("Ades,Gorad Adehsa,ODS,Odesa,Odess,Odessa,Odessae,Odesse,Odessos,Odessus,Odessza,Oděsa,Udessa,ao de sa,awdsa,awdysa,odesa,odessa,Ódessa,Οδησσός,Горад Адэса,Одеса,Одесс,Одессæ,Одесса,Одессе,Օդեսա,אדעס,אודסה,أوديسا,اودسا,اوديسا,اودیسا,ओदेसा,အိုဒက်ဆာမြို့,ოდესა,オデッサ,敖德薩,오데사", record.AlternateNames);
            Assert.AreEqual(46.4774704f, record.Latitude);
            Assert.AreEqual(30.7326202f, record.Longitude);
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
    }
}