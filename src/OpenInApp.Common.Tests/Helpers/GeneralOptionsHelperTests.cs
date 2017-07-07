using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenInApp.Common.Helpers;
using System.IO;
using System.Linq;
using System.Reflection;
using static System.Environment;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class GeneralOptionsHelperTests
    {
        private const string OverrideAtTestExecutionTime = "OverrideAtTestExecutionTime";

        [Test()]
        [Category("I")]
        //[TestCase(KeyToExecutableEnum.AltovaXMLSpy, FileToBeOpenedKind.Xml)]
        //[TestCase(KeyToExecutableEnum.ChromeCanary, FileToBeOpenedKind.Any)]
        //[TestCase(KeyToExecutableEnum.FirefoxDeveloperEdition, FileToBeOpenedKind.Any)]
        //[TestCase(KeyToExecutableEnum.Gimp, FileToBeOpenedKind.StillImage)]
        //[TestCase(KeyToExecutableEnum.MarkdownMonster, FileToBeOpenedKind.Markdown)]
        //[TestCase(KeyToExecutableEnum.MSPaint, FileToBeOpenedKind.StillImage)]
        //[TestCase(KeyToExecutableEnum.Opera, FileToBeOpenedKind.Any)]
        //[TestCase(KeyToExecutableEnum.OperaDeveloperEdition, FileToBeOpenedKind.Any)]
        //[TestCase(KeyToExecutableEnum.PaintDotNet, FileToBeOpenedKind.StillImage)]
        //[TestCase(KeyToExecutableEnum.Vivaldi, FileToBeOpenedKind.Any)]
        //[TestCase(KeyToExecutableEnum.XamarinStudio, FileToBeOpenedKind.Any)]
        //[TestCase(KeyToExecutableEnum.TreeSizeFree, ArtefactTypeToOpen.Folder)]
        //[TestCase(KeyToExecutableEnum.VS2012, FileToBeOpenedKind.Code)]
        //[TestCase(KeyToExecutableEnum.VS2013, FileToBeOpenedKind.Code)]
        //[TestCase(KeyToExecutableEnum.VS2015, FileToBeOpenedKind.Code)]
        //[TestCase(KeyToExecutableEnum.VS2017Community, FileToBeOpenedKind.Code)]
        //[TestCase(KeyToExecutableEnum.VS2017Enterprise, FileToBeOpenedKind.Code)]
        //[TestCase(KeyToExecutableEnum.VS2017Professional, FileToBeOpenedKind.Code)]
        //[TestCase(KeyToExecutableEnum.Emacs, FileToBeOpenedKind.Code)]
        //[TestCase(KeyToExecutableEnum.WinDirStat, ArtefactTypeToOpen.Folder)]
        //[TestCase(KeyToExecutableEnum.SQLServerManagementStudio, ArtefactTypeToOpen.File)]

        //                              C:\Program Files (x86)\Microsoft SQL Server\70\Tools\Binn\VSShell\Common7\IDE\ssmsee.exe
        //                              C:\Program Files (x86)\Microsoft SQL Server\80\Tools\Binn\VSShell\Common7\IDE\ssmsee.exe
        //                              C:\Program Files (x86)\Microsoft SQL Server\90\Tools\Binn\VSShell\Common7\IDE\ssmsee.exe
        //                             C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\VSShell\Common7\IDE\ssmsee.exe
        //                             C:\Program Files (x86)\Microsoft SQL Server\110\Tools\Binn\ManagementStudio\Ssms.exe
        //                             C:\Program Files (x86)\Microsoft SQL Server\120\Tools\Binn\ManagementStudio\Ssms.exe
        //                             C:\Program Files (x86)\Microsoft SQL Server\130\Tools\Binn\ManagementStudio\Ssms.exe
        //                             C:\Program Files (x86)\Microsoft SQL Server\140\Tools\Binn\ManagementStudio\Ssms.exe

        public void InvokeCommandTest(KeyToExecutableEnum keyToExecutableEnum, FileToBeOpenedKind fileToBeOpenedKind)
        {
            // Arrange
            List<string> actualFilesToBeOpened;

            #region Set files to be opened
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            switch (fileToBeOpenedKind)
            {
                case FileToBeOpenedKind.Any:
                case FileToBeOpenedKind.Code:
                case FileToBeOpenedKind.Markdown:
                case FileToBeOpenedKind.Xml:
                    actualFilesToBeOpened = new List<string>
                    {
                        path + @"\TestFiles\AnyText1.txt",
                        path + @"\TestFiles\AnyText2.TXT",
                    };
                    break;
                case FileToBeOpenedKind.MovingImage:
                    actualFilesToBeOpened = new List<string>
                    {
                        path + @"\TestFiles\MovingImage1.mpg",
                        path + @"\TestFiles\MovingImage2.mpeg",
                    };
                    break;
                case FileToBeOpenedKind.StillImage:
                    actualFilesToBeOpened = new List<string>
                    {
                        path + @"\TestFiles\StillImage1.jpg",
                        path + @"\TestFiles\StillImage2.JPG",
                    };
                    break;
                default:
                    throw new NotImplementedException();
            }
            #endregion

            var actualPathToExeHelper = new ApplicationToOpenHelper();
            var applicationToOpenDto = actualPathToExeHelper.GetApplicationToOpenDto(keyToExecutableEnum);
            var executableFullPath = GeneralOptionsHelper.GetActualPathToExe(keyToExecutableEnum);

            // Act
            OpenInAppHelper.InvokeCommand(
                actualFilesToBeOpened,
                executableFullPath,
                applicationToOpenDto.SeparateProcessPerFileToBeOpened,
                applicationToOpenDto.UseShellExecute,
                applicationToOpenDto.ArtefactTypeToOpen);
        }

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
        [TestCase(KeyToExecutableEnum.TreeSizeFree, @"C:\Program Files (x86)\JAM Software\TreeSize Free\TreeSizeFree.exe")]
        [TestCase(KeyToExecutableEnum.TreeSizeProfessional, @"C:\Program Files (x86)\JAM Software\TreeSize\TreeSize.exe")]
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
            var actual = GeneralOptionsHelper.GetSearchPathsForThirdPartyExe(keyToExecutableEnum);

            //Assert
            Assert.IsTrue(actual.Contains(expected));
        }
    }
}