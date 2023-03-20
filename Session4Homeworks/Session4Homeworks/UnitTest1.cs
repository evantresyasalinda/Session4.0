using ServiceReference1;



namespace Session4Homeworks
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ServiceReference1.CountryInfoServiceSoapTypeClient countryTest =
             new ServiceReference1.CountryInfoServiceSoapTypeClient(ServiceReference1.CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);

        [TestMethod]
        public void ListofCountryCodes()
        {

            var result = countryTest.ListOfCountryNamesByCode();
            var expectedCountryCode = result.OrderBy(x => x.sISOCode);
            Assert.IsTrue(result.SequenceEqual(expectedCountryCode));
        }

        [TestMethod]
        public void ValidateInvalidCountryCode()
        {
            var invalidCountryCode = "OOO";
            var response = countryTest.CountryName(invalidCountryCode);
            Assert.IsTrue(response.Contains("Country not found in the database"), $"Country code {invalidCountryCode} was found");

        }

        [TestMethod]
        public void GetLastCountryCode()
        {

            var result = countryTest.ListOfCountryNamesByCode();
            var lastItem = result.Last();
            var last = countryTest.CountryName(lastItem.sISOCode);
            Assert.AreEqual(lastItem.sName, last);

        }
    }
}