using NUnit.Framework;
using OpenInApp.Common.Helpers;
using System.Linq;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class GeneralOptionsHelperTests
    {
        [Test()]
        [TestCase("chrome.exe", @"C:\Users\greg\AppData\Local\Google\Chrome SxS\Application\chrome.exe")]
        [TestCase("devenv.exeVS2012", @"C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\devenv.exe")]
        [TestCase("devenv.exeVS2013", @"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\devenv.exe")]
        [TestCase("devenv.exeVS2015", @"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe")]
        [TestCase("devenv.exeVS2017Community", @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe")]
        [TestCase("devenv.exeVS2017Enterprise", @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\devenv.exe")]
        [TestCase("devenv.exeVS2017Professional", @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\devenv.exe")]
        [TestCase("firefox.exe", @"C:\Program Files\Firefox Developer Edition\firefox.exe")]
        [TestCase("gimp-2.8.exe", @"C:\Program Files\GIMP 2\bin\gimp-2.8.exe")]
        [TestCase("launcher.exe", @"C:\Program Files\Opera developer\launcher.exe")]
        [TestCase("MarkdownMonster.exe", @"C:\Program Files (x86)\Markdown Monster\MarkdownMonster.exe")]
        [TestCase("mspaint.exe", @"C:\WINDOWS\system32\mspaint.exe")]
        [TestCase("opera.exe", @"C:\Program Files (x86)\Opera\opera.exe")]
        [TestCase("PaintDotNet.exe", @"C:\Program Files\Paint.NET\PaintDotNet.exe")]
        [TestCase("runemacs.exe", null)]
        [TestCase("vivaldi.exe", @"C:\Users\greg\AppData\Local\Vivaldi\Application\vivaldi.exe")]
        [TestCase("XamarinStudio.exe", @"C:\Program Files (x86)\Xamarin Studio\bin\XamarinStudio.exe")]
        [TestCase("XMLSpy.exe", @"C:\Program Files (x86)\Altova\XMLSpy2016\XMLSpy.exe")]
        [Category("U")]
        public void GetActualPathToExeTest(string executableFileToBrowseFor, string expected)
        {
            //Act
            var actual = GeneralOptionsHelper.GetSearchPaths(executableFileToBrowseFor);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }
    }
}