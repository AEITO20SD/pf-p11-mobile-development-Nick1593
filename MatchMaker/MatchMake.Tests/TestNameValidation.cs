using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;
using MatchMaker.Interfaces;
using MatchMaker.Core;

namespace MatchMaker.UnitTests
{
    [TestClass]
    public class TestNameValidation
    {
        private readonly NameValidation _nameValidation;
        public TestNameValidation()
        {
            _nameValidation = new NameValidation();
        }
        [TestMethod]
        public async Task Validate_ListOfEntries_ReturnTrue()
        {
            // Arrange
            IList<Entry> list = new List<Entry>();
            list.Add(new Entry() { Text = "Jossy" });
            list.Add(new Entry() { Text = "Newt" });

            // Act
            bool result = await _nameValidation.IsValidAsync(list);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task ValidateNull_SingleEntry_ReturnFalse()
        {
            // Arrange
            Entry entry = new Entry() { Text = string.Empty };

            // Act
            bool result = await _nameValidation.IsNotNullAsync(entry);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public async Task ValidateAlphabetical_SingleEntry_ReturnTrue()
        {
            // Arrange
            Entry entry = new Entry() { Text = "Bob" };    
            
            // Act
            bool result = await _nameValidation.IsAlphabetical(entry);
            
            // Assert
            Assert.IsTrue(result);
        }
    }
}
