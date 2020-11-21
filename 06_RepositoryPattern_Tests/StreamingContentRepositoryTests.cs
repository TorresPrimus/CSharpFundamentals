using _06_RepositoryPatern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _06_RepositoryPattern_Tests
{
    [TestClass]
    public class StreamingContentRepositoryTests
    {
        private StreamingContentRepository _repo;
        private StreamingContent _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new StreamingContentRepository();
            _content = new StreamingContent("Revenge of the Sith", "You were a brother to me!", "PG-13", 9.9, true, GenreType.Documentary);

            _repo.AddContentToList(_content);
        }

        // Add Method

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            // Arrange --> Setting up the playing field
            StreamingContent content = new StreamingContent();
            content.Title = "Toy Story";
            StreamingContentRepository repository = new StreamingContentRepository();

            // Act --> Get/run the code we want to test
            repository.AddContentToList(content);
            StreamingContent contentFromDirectory = repository.GetContentByTitle("Toy Story");

            // Assert --> Use the assert class to verify the expected outcome
            Assert.IsNotNull(contentFromDirectory);
        }

        // Update

        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            // Arrange
            // Test Initialize
            StreamingContent newContent = new StreamingContent("Revenge of the Sith", "You were a brother to me!", "PG-13", 9.9, true, GenreType.Documentary);

            // Act
            bool updateresult = _repo.UpdateExistingContent("Revenge of the Sith", newContent);

            // Assert
            Assert.IsTrue(updateresult);
        }

        [DataTestMethod]
        [DataRow("Revenge of the Sith", true)]
        [DataRow("Toy Story", false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(string originalTitle, bool shouldUpdate)
        {
            // Arrange
            // Test Initialize
            StreamingContent newContent = new StreamingContent("Revenge of the Sith", "You were a brother to me!", "PG-13", 9.9, true, GenreType.Documentary);

            // Act
            bool updateresult = _repo.UpdateExistingContent(originalTitle, newContent);

            // Assert
            Assert.AreEqual(shouldUpdate, updateresult);
        }

        // Delete
        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            // Arrange

            // Act
            bool deleteResult = _repo.RemoveContentFromList(_content.Title);

            // Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
