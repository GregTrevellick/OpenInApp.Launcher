using NUnit.Framework;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.IO;
using System.Linq;
using static System.Environment;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class GeneralOptionsHelperTests
    {
        private const string OverrideAtTestExecutionTime = "OverrideAtTestExecutionTime";

        [Test()]
        [TestCase(KeyToExecutableEnum.AltovaXMLSpy, @"C:\Program Files (x86)\Altova\XMLSpy2016\XMLSpy.exe")]
        [TestCase(KeyToExecutableEnum.ChromeCanary, OverrideAtTestExecutionTime)]
        [TestCase(KeyToExecutableEnum.Emacs, null)]
        [TestCase(KeyToExecutableEnum.FirefoxDeveloperEdition, @"C:\Program Files\Firefox Developer Edition\firefox.exe")]
        [TestCase(KeyToExecutableEnum.Gimp, @"C:\Program Files\GIMP 2\bin\gimp-2.8.exe")]
        [TestCase(KeyToExecutableEnum.MarkdownMonster, @"C:\Program Files (x86)\Markdown Monster\MarkdownMonster.exe")]
        [TestCase(KeyToExecutableEnum.MSPaint, OverrideAtTestExecutionTime)]
        [TestCase(KeyToExecutableEnum.Opera, @"C:\Program Files (x86)\Opera\opera.exe")]
        [TestCase(KeyToExecutableEnum.OperaDeveloperEdition, @"C:\Program Files\Opera developer\launcher.exe")]
        [TestCase(KeyToExecutableEnum.PaintDotNet, @"C:\Program Files\Paint.NET\PaintDotNet.exe")]
        //[TestCase(KeyToExecutableEnum.TreeSizeFree, @"C:\Program Files (x86)\JAM Software\TreeSize Free\TreeSizeFree.exe")]
        [TestCase(KeyToExecutableEnum.Vivaldi, OverrideAtTestExecutionTime)]
        [TestCase(KeyToExecutableEnum.VS2012, @"C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\devenv.exe")]
        [TestCase(KeyToExecutableEnum.VS2013, @"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\devenv.exe")]
        [TestCase(KeyToExecutableEnum.VS2015, @"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe")]
        [TestCase(KeyToExecutableEnum.VS2017Community, @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe")]
        [TestCase(KeyToExecutableEnum.VS2017Enterprise, @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\devenv.exe")]
        [TestCase(KeyToExecutableEnum.VS2017Professional, @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\devenv.exe")]
        [TestCase(KeyToExecutableEnum.XamarinStudio, @"C:\Program Files (x86)\Xamarin Studio\bin\XamarinStudio.exe")]
        [Category("U")]
        public void GetActualPathToExeTest(KeyToExecutableEnum keyToExecutableEnum, string expected)
        {
            //Arrange
            if (expected == OverrideAtTestExecutionTime)
            {
                var localApplicationData = GetFolderPath(SpecialFolder.LocalApplicationData);
                var windows = GetFolderPath(SpecialFolder.Windows);

                switch (keyToExecutableEnum)
                {
                    case KeyToExecutableEnum.ChromeCanary:
                        expected = Path.Combine(localApplicationData, @"Google\Chrome SxS\Application\chrome.exe");
                        break;
                    case KeyToExecutableEnum.MSPaint:
                        expected = Path.Combine(windows, @"system32\mspaint.exe");
                        break;
                    case KeyToExecutableEnum.Vivaldi:
                        expected = Path.Combine(localApplicationData, @"Vivaldi\Application\vivaldi.exe");
                        break;
                }
            }

            //Act
            var actual = GeneralOptionsHelper.GetSearchPaths(keyToExecutableEnum);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }

        [Test()]
        [Category("U")]
        public void GetMultipleYearPathsTest()
        {
            //Arrange
            var secondaryFilePathSegment = "abc2016d";

            //Act
            var actual = GeneralOptionsHelper.GetMultipleYearPaths("app.exe", InitialFolderType.ProgramFilesX86, secondaryFilePathSegment);

            //Assert
            
            Assert.IsFalse(actual.Contains(@"C:\Program Files (x86)\abc1995d\app.exe"));
            Assert.IsTrue(actual.Contains(@"C:\Program Files (x86)\abc1996d\app.exe"));
            Assert.IsTrue(actual.Contains(@"C:\Program Files (x86)\abc1996d\app.exe"));
            Assert.IsTrue(actual.Contains(@"C:\Program Files (x86)\abc2019d\app.exe"));
            Assert.IsTrue(actual.Contains(@"C:\Program Files (x86)\abc2020d\app.exe"));
            Assert.IsFalse(actual.Contains(@"C:\Program Files (x86)\abc2021d\app.exe"));
            Assert.AreEqual(25, actual.Count());
        }
    }
}