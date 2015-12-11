using NUnit.Framework;

namespace CityLocator.Tests
{
    public class GeoNameTests
    {
        [Test]
        public void Should_load_all_fields_from_the_String_in_the_data_file()
        {
            var record = GeoName.Load("704697  Kotlovyna   Kotlovyna   Bolboaca,Bolboaka,Bolboka,Bulboka,Kotlovina,Kotlovyna,Котловина 45.50661    28.5747 P   PPL UA      17              0       29  Europe/Kiev 2015-01-07");

            Assert.AreEqual("Kotlovyna", record.Name);
            Assert.AreEqual("UA", record.CountryCode);
            Assert.AreEqual(45.50661f, record.Latitude);
            Assert.AreEqual(28.5747f, record.Longitude);
        }
    }
}