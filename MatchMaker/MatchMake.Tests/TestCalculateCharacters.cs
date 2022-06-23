using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using MatchMaker.Interfaces;
using MatchMaker.Core;

namespace MatchMaker.UnitTests
{
    [TestClass]
    public class TestCalculateCharacters
    {
        private readonly CalculateCharacters _calculateCharacters;
        public TestCalculateCharacters()
        {
            _calculateCharacters = new CalculateCharacters();
        }
        [TestMethod]
        public async Task Calculate_TwoEntries_ReturnIsNotZero()
        {
            // Arrange
            Entry entry1 = new Entry();
            Entry entry2 = new Entry();
            entry1.Text = "Nick";
            entry2.Text = "Bowie";

            // Act
            int result = await _calculateCharacters.CalculateAsync(entry1, entry2);

            // Assert
            Assert.AreNotEqual(0, result);
        }
        [TestMethod]
        public async Task Calculate_NumberOfVowels_ReturnThree()
        {
            // Arrange
            Entry entry = new Entry() { Text = "Johannas" };
            string vowels = "aeiouy";
            bool inverse = false;

            // Act
            int result = await _calculateCharacters.CountVowelsOrConsonantsAsync(entry.Text, vowels, false);

            // Assert
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public async Task Calculate_TwoSameFirstLetterType_ReturnTen()
        {
            // Arrange
            Entry entry1 = new Entry() { Text = "Josie" };
            Entry entry2 = new Entry() { Text = "William" };

            // Act
            int result = await _calculateCharacters.SameFirstLetterTypeAsync(entry1.Text, entry2.Text);

            // Assert
            Assert.AreEqual(10, result);
        }
        [TestMethod]
        public async Task Calculate_TwoSameValueIntergers_ReturnInputedReward()
        {
            // Arrange
            int value1 = 10;
            int value2 = 10;
            int reward = 20;

            // Act
            int result = await _calculateCharacters.IsEqualAsync(value1, value2, reward);

            // Assert
            Assert.AreEqual(reward, result);
        }
    }
}
