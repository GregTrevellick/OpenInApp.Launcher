using NUnit.Framework;
using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class AllAppsHelperTests
    {
        [Test()]
        [Category("U")]
        public void GetDefaultTypicalFileExtensionsAsCsvTest()
        {
            //Arrange
            var testList = new List<string> { "a", "b", "c" };

            //Act
            var actual = AllAppsHelper.GetDefaultTypicalFileExtensionsAsCsv(testList);

            //Assert
            Assert.AreEqual("a,b,c", actual);
        }

        [Test()]
        [Category("I")]
        public void DoesActualPathToExeExistTest()
        {
            //Act
            var actual = AllAppsHelper.DoesActualPathToExeExist(null);

            //Assert
            Assert.IsFalse(actual);
        }
    }
}