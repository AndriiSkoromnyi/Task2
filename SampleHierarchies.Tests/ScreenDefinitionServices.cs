using Microsoft.VisualStudio.TestPlatform.Utilities;
using SampleHierarchies.Gui;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Tests
{
    [TestClass]
    public class ScreenDefinitionServicesTests
    {

        private string isNullJsonFileNameLoad = "null.json";
        private string normalJsonFileNameSave = "normal.json";
        private string jsonFileNameNormalSave = "successfulSave.json";
        private string jsonFileNameNotNormalSave = "/.notSuccessfulSave.json";

        [TestMethod]
        public void Load_JsonFileIsNotNull_ReturnsScreenDefinition()
        {
            var screenDefinition = ScreenDefinitionService.Load(normalJsonFileNameSave);

            Assert.IsNotNull(screenDefinition);
        }

        [TestMethod]
        public void Load_JsonFileIsNull_ReturnsNull()
        {
            var screenDefinition = ScreenDefinitionService.Load(isNullJsonFileNameLoad);

            Assert.IsNull(screenDefinition);
        }

        [TestMethod]
        public void Save_SuccessfulSave_ReturnsTrue()
        {
            // Arrange
            var screenDefinition = new ScreenDefinition();
            
            // Act
            bool result = ScreenDefinitionService.Save(screenDefinition, jsonFileNameNormalSave);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Save_FailedSave_ReturnsFalse()
        {
            // Arrange
            var screenDefinition = new ScreenDefinition(); 

            // Act
            bool result = ScreenDefinitionService.Save(screenDefinition, jsonFileNameNotNormalSave);

            // Assert
            Assert.IsFalse(result);
        }
    }
}