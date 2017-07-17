using NUnit.Framework;
using OpenInApp.Common.Helpers;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class EnumHelperTests
    {
        [Test()]
        [Category("U")]
        public void DescriptionTest()
        {
            //Arrange
            var e = KeyToExecutableEnum.VS2012;

            //Act
            var actual = e.Description();

            //Assert
            Assert.AreEqual("devenv.exe", actual);
        }

        [Test()]
        [Category("U")]
        public void DescriptionTest_NoDescription()
        {
            //Arrange
            var e = KeyToExecutableEnum.Abracadabra;

            //Act
            var actual = e.Description();

            //Assert
            Assert.AreEqual("Description Not Found", actual);
        }
    }
}