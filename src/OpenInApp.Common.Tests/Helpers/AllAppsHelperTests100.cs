using NUnit.Framework;
using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class AllAppsHelperTests100
    {
        [Test()]
        [Category("U")]
        public void GetDefaultTypicalFileExtensionsAsCsvTest_PopulatedList()
        {
            //Arrange
            var testList = new List<string> { "a", "b", "c" };

            //Act
            var actual = AllAppsHelper.GetDefaultTypicalFileExtensionsAsCsv(testList);

            //Assert
            Assert.AreEqual("a,b,c", actual);
        }

        [Test()]
        [Category("U")]
        public void GetDefaultTypicalFileExtensionsAsCsvTest_EmptyList()
        {
            //Arrange
            var testList = new List<string>();

            //Act
            var actual = AllAppsHelper.GetDefaultTypicalFileExtensionsAsCsv(testList);

            //Assert
            Assert.AreEqual("a,b,c", actual);
        }

        [Test()]
        [Category("U")]
        public void GetDefaultTypicalFileExtensionsAsCsvTest_NullList()
        {
            //Arrange
            List<string> testList = null;

            //Act
            var actual = AllAppsHelper.GetDefaultTypicalFileExtensionsAsCsv(testList);

            //Assert
            Assert.AreEqual(string.Empty, actual);
        }

        [Test()]
        [Category("U")]
        public void GetDefaultTypicalFileExtensionsAsCsvTest_DuplicateEntryList()
        {
            //Arrange
            var testList = new List<string> { "a", "a", "a" };

            //Act
            var actual = AllAppsHelper.GetDefaultTypicalFileExtensionsAsCsv(testList);

            //Assert
            Assert.AreEqual("a,a,a", actual);
        }
    }
}