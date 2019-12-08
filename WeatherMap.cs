using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Stylelabs.MQA.WebApiTesting.Tests
{
    public class WeatherMap
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver(@"C:\Users\dicleba");
        }
        [Test]
        public void TestCity()
        {
            const string cityString = "New York";
            ApiResponse apiResponse = new ApiResponse();
            string expectedResult = apiResponse.GetResponse(cityString);
            Thread.Sleep(1000);

            //string displayedResponse = responseElement.Text;
            //Assert.IsTrue(expectedResult.max_temperature > 10degree);
        }

       [TearDown]
        public void Teardown()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }
    }
}