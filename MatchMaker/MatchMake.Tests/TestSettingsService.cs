using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;
using MatchMaker.Interfaces;
using MatchMaker.Services;

namespace MatchMaker.UnitTests
{
    [TestClass]
    public class TestSettingsService
    {
        private readonly ISettingsService _mockSettingService;
        public TestSettingsService()
        {
            _mockSettingService = new SettingsService();
        }
        [TestMethod]
        public void Set_SettingMathType_ReturnTrue()
        {
            // Arrange
            string settingsName = "math_type";
            bool setting = true;

            // Act
            _mockSettingService.SetSetting(settingsName, setting);
            bool result = _mockSettingService.GetSetting(settingsName);

            // Assert
            Assert.AreEqual(setting, result);
        }
        [TestMethod]
        public void Get_SettingMathType_ReturnFalse()
        {
            // Arrange
            string settingsName = "math_type";
            bool setting = false;

            // Act
            _mockSettingService.SetSetting(settingsName, setting);
            bool result = _mockSettingService.GetSetting(settingsName);

            // Assert
            Assert.AreEqual(setting, result);

        }
    }
}
