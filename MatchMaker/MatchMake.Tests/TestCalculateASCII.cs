using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using MatchMaker.Interfaces;
using MatchMaker.Core;

namespace MatchMaker.UnitTests
{
    [TestClass]
    public class TestCalculateASCII
    {
        private readonly CalculateASCII _calculateASCII;
        public TestCalculateASCII()
        {
            _calculateASCII = new CalculateASCII();
        }
        [TestMethod]
        public async Task Calculate_TwoEntries_ReturnNotHundredAndTwentyFive()
        {
            // Arrange
            Entry entry1 = new Entry() { Text = "John" };
            Entry entry2 = new Entry() { Text = "Missy" };

            // Act
            int result = await _calculateASCII.CalculateAsync(entry1, entry2);

            // Assert
            Assert.AreNotEqual(125, result);
        }
        [TestMethod]
        public async Task Calculate_EntryASCII_Return()
        {
            // Arrange
            Entry entry = new Entry() { Text = "Johan" };

            // Act
            int result = await _calculateASCII.GetASCIIAsync(entry);

            // Assert
            Assert.AreEqual(496, result);
        }
    }
}
