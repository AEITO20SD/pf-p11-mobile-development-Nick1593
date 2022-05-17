using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using MatchMaker;

namespace MatchMaker.Tests
{
    [TestClass]
    public class TestCalculateCharMatch
    {
        private readonly MainPage _mainPage;
        public TestCalculateCharMatch()
        {
            _mainPage = new MainPage();
        }
        [TestMethod]
        public void IsStringNotNull()
        {
            string result = _mainPage.CalculateCharMatch("Hello", "World");

            Assert.IsNotNull(result, "it's not null");
        }
    }
}
