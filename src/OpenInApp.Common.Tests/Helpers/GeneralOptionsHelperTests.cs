using NUnit.Framework;
using OpenInApp.Common.Helpers;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class GeneralOptionsHelperTests
    {
        [Test()]
        [TestCase("Altova", "XMLSpy", "XmlSpy.exe", @"C:\Program Files (x86)\Altova\XMLSpy2016\XMLSpy.exe")]
        [TestCase("Paint.NET", null, "PaintDotNet.exe", @"C:\Program Files\Paint.NET\PaintDotNet.exe")]
        [TestCase("Microsoft Visual Studio", @"2017\Community\Common7\IDE", "devenv.exe", @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe")]
        [Category("I")]
        public void GetActualPathToExeTest(string appFolderName, string appSubFolderName, string executableFileToBrowseFor, string expected)
        {
            //Act
            var actual = GeneralOptionsHelper.GetActualPathToExe(appFolderName, appSubFolderName, executableFileToBrowseFor);

            //Assert
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
        }
    }
}