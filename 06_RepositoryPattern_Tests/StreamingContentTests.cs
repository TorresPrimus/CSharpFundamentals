using _06_RepositoryPatern_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _06_RepositoryPattern_Tests
{
    [TestClass]
    public class StreamingContentTests
    {
        [TestMethod]
        public void SetTitle_ShouldSetCorrectString()
        {
            StreamingContent content = new StreamingContent();

            content.Title = "Toy Story";

            string expected = "Toy Story";

            string actual = content.Title;

            Assert.AreEqual(expected, actual);
        }
    }
}
