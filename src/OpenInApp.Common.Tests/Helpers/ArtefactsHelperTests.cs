using NUnit.Framework;
using OpenInApp.Common.Helpers;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class ArtefactsHelperTests
    {
        [Test()]
        [Category("I")]
        public void DoesActualPathToExeExistTest()
        {
            //Act
            var actual = ArtefactsHelper.DoesActualPathToExeExist(null);

            //Assert
            Assert.IsFalse(actual);
        }
    }
}