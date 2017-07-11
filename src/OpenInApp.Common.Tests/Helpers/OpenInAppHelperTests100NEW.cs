using NUnit.Framework;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class OpenInAppHelperTests100NEW
    {
        [Test()]
        [Category("E2E")]
        public void AltovaXMLSpy_Single()
        {
            InvokeApplication(KeyToExecutableEnum.AltovaXMLSpy, altovaXMLSpy, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void AltovaXMLSpy_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.AltovaXMLSpy, altovaXMLSpy, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void FirefoxDeveloperEdition_Single()
        {
            InvokeApplication(KeyToExecutableEnum.FirefoxDeveloperEdition, firefoxDeveloperEdition, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void FirefoxDeveloperEdition_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.FirefoxDeveloperEdition, firefoxDeveloperEdition, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void Gimp_Single()
        {
            InvokeApplication(KeyToExecutableEnum.Gimp, gimp, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void Gimp_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.Gimp, gimp, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void MarkdownMonster_Single()
        {
            InvokeApplication(KeyToExecutableEnum.MarkdownMonster, markdownMonster, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void MarkdownMonster_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.MarkdownMonster, markdownMonster, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void MSPaint_Single()
        {
            InvokeApplication(KeyToExecutableEnum.MSPaint, msPaint, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void MSPaint_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.MSPaint, msPaint, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void Opera_Single()
        {
            InvokeApplication(KeyToExecutableEnum.Opera, opera, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void Opera_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.Opera, opera, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void OperaDeveloperEdition_Single()
        {
            InvokeApplication(KeyToExecutableEnum.OperaDeveloperEdition, operaDeveloperEdition, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void OperaDeveloperEdition_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.OperaDeveloperEdition, operaDeveloperEdition, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void PaintDotNet_Single()
        {
            InvokeApplication(KeyToExecutableEnum.PaintDotNet, paintDotNet, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void PaintDotNet_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.PaintDotNet, paintDotNet, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void TreeSizeFree_Single()
        {
            InvokeApplication(KeyToExecutableEnum.TreeSizeFree, treeSizeFree, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void TreeSizeFree_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.TreeSizeFree, treeSizeFree, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void Vivaldi_Single()
        {
            InvokeApplication(KeyToExecutableEnum.Vivaldi, vivaldi, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void Vivaldi_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.Vivaldi, vivaldi, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void VS2015_Single()
        {
            InvokeApplication(KeyToExecutableEnum.VS2015, vs2015, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void VS2015_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.VS2015, vs2015, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void VS2017Community_Single()
        {
            InvokeApplication(KeyToExecutableEnum.VS2017Community, vs2017Community, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void VS2017Community_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.VS2017Community, vs2017Community, "Multiple");
        }

        [Test()]
        [Category("E2E")]
        public void WinDirStat_Single()
        {
            InvokeApplication(KeyToExecutableEnum.WinDirStat, winDirStat, "Single");
        }

        [Test()]
        [Category("E2E")]
        public void WinDirStat_Multiple()
        {
            InvokeApplication(KeyToExecutableEnum.WinDirStat, winDirStat, "Multiple");
        }

        private const string altovaXMLSpy = @"D:\Program Files (x86)\Altova\XMLSpy2017\XMLSpy.exe";
        private const string firefoxDeveloperEdition = @"C:\Program Files\Firefox Developer Edition\firefox.exe";
        private const string gimp = @"D:\Program Files\GIMP 2\bin\gimp-2.8.exe";
        //private const string markdownMonster = @"C:\Program Files (x86)\Markdown Monster\MarkdownMonster.exe";
        private const string markdownMonster = @"D:\Program Files (x86)\Markdown Monster\MarkdownMonster.exe";
        private const string msPaint = @"C:\Windows\system32\mspaint.exe";
        private const string opera = @"D:\Program Files\Opera\launcher.exe";
        private const string operaDeveloperEdition = @"D:\Program Files\Opera developer\launcher.exe";
        private const string paintDotNet = @"C:\Program Files\paint.net\PaintDotNet.exe";
        private const string treeSizeFree = @"D:\Program Files (x86)\JAM Software\TreeSize Free\TreeSizeFree.exe";
        //private const string vivaldi = @"C:\Users\GregoryT\AppData\Local\Vivaldi\Application\vivaldi.exe";
        private const string vivaldi = @"D:\Users\gtrev\AppData\Local\Vivaldi\Application\vivaldi.exe";
        private const string vs2015 = @"D:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe";
        private const string vs2017Community = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe";
        private const string winDirStat = @"D:\Program Files (x86)\WinDirStat\windirstat.exe";

        private void InvokeApplication(KeyToExecutableEnum keyToExecutableEnum, string executableFullPath, string singleOrMultipleArtefacts)
        {
            // Arrange
            var dto = new ApplicationToOpenHelper().GetApplicationToOpenDto(keyToExecutableEnum);
            var artefactsToBeOpened = new List<string>();

            if (singleOrMultipleArtefacts == "Single")
            {
                switch (dto.ArtefactTypeToOpen)
                {
                    case ArtefactTypeToOpen.File:
                        switch (keyToExecutableEnum)
                        {
                            case KeyToExecutableEnum.FirefoxDeveloperEdition:
                            case KeyToExecutableEnum.Gimp:
                            case KeyToExecutableEnum.MSPaint:
                            case KeyToExecutableEnum.Opera:
                            case KeyToExecutableEnum.OperaDeveloperEdition:
                            case KeyToExecutableEnum.PaintDotNet:
                            case KeyToExecutableEnum.TreeSizeFree:
                            case KeyToExecutableEnum.Vivaldi:
                            case KeyToExecutableEnum.VS2015:
                            case KeyToExecutableEnum.VS2017Community:
                            case KeyToExecutableEnum.WinDirStat:
                                artefactsToBeOpened = new List<string> { @"D:\Temp\2.jpg" };
                                //artefactsToBeOpened = new List<string> { @"C:\Temp\1.jpg" };
                                break;
                            default:
                                artefactsToBeOpened = new List<string> { @"D:\Temp\a.txt" };
                                //artefactsToBeOpened = new List<string> { @"C:\Temp\a.txt" };
                                break;
                        }
                        break;
                    case ArtefactTypeToOpen.Folder:
                        artefactsToBeOpened = new List<string> { @"D:\Temp\" };
                        //artefactsToBeOpened = new List<string> { @"C:\Temp\" };
                        break;
                }
            }
            else
            {
                switch (dto.ArtefactTypeToOpen)
                {
                    case ArtefactTypeToOpen.File:
                        switch (keyToExecutableEnum)
                        {
                            case KeyToExecutableEnum.Gimp:
                            case KeyToExecutableEnum.MSPaint:
                            case KeyToExecutableEnum.PaintDotNet:
                                artefactsToBeOpened = artefactsToBeOpened_ImageFiles;
                                break;
                            default:
                                artefactsToBeOpened = artefactsToBeOpened_TextFiles;
                                break;
                        }
                        break;
                    case ArtefactTypeToOpen.Folder:
                        artefactsToBeOpened = artefactsToBeOpened_Folders;
                        break;
                }
            }

            // Act
            OpenInAppHelper.InvokeCommand(artefactsToBeOpened, executableFullPath, dto.SeparateProcessPerFileToBeOpened, dto.UseShellExecute, dto.ArtefactTypeToOpen, dto.ProcessWithinProcess);
        }

        private List<string> artefactsToBeOpened_TextFiles = new List<string>
                    {
                        @"D:\Temp\a.txt",
                        @"D:\Temp\b.txt",
                        //@"C:\Temp\a.txt",
                        //@"C:\Temp\b.txt",
                    };

        private List<string> artefactsToBeOpened_ImageFiles = new List<string>
                    {
                        @"D:\Temp\1.jpg",
                        @"D:\Temp\2.jpg",
                        //@"C:\Temp\1.jpg",
                        //@"C:\Temp\2.jpg",
                    };

        private List<string> artefactsToBeOpened_Folders = new List<string>
                    {
                        @"D:\Temp\",
                        @"D:\Temp\Test",
                        //@"C:\Temp\",
                        //@"C:\Temp\Test",
                    };

        //Open in intellij
        //open in rider
        //Open in “My Exe”
        //Open in IE 11 – check at spur
        //open in sublime text vs2012/vs2013?
        //examdiff
        //jetbrains webstorm
        //screentogif
        //gvim ?
        //fresh paint
        //http://www.jedsoft.org/jed/
        //http://texteditors.org/cgi-bin/wiki.pl?ACE
        //http://texteditors.org/cgi-bin/wiki.pl?UltraEdit
        //http://texteditors.org/cgi-bin/wiki.pl?Zeus
        //http://texteditors.org/cgi-bin/wiki.pl?ZendStudio
        //http://texteditors.org/cgi-bin/wiki.pl?Brainfck_Center
        //https://sourceforge.net/projects/e7bfc/
        //frontpage
        //homesite
        //BEATEN TO IT - HAPPILY OPENS BOTH FILES [TestCase(@"C:\Windows\system32\notepad.exe", true, false)]
        //BEATEN TO IT - HAPPILY OPENS BOTH FILES [TestCase(@"C:\Program Files (x86)\Vim\vim80\gvim.exe", true, null)]//with mouse - graphical vim
        //[TestCase(@"C:\Users\gtrev\AppData\Local\atom\app-1.18.0\atom.exe", false, null)]
        //nothing happens [TestCase(@"C:\Program Files (x86)\LINQPad4\LPRun.exe", false, null)]
        //fails with 1 arg prob 2 args also [TestCase(@"C:\Program Files (x86)\LINQPad4\LINQPad.exe", false, null)]
        //fails with 1 and 2 arguments [TestCase(@"C:\Program Files (x86)\LINQPad5\LINQPad.exe", false, null)]
        //fails with 1 and 2 arguments [TestCase(@"C:\Program Files\Windows NT\Accessories\wordpad.exe", false, null)]
        //nothing happens [TestCase(@"C:\Program Files (x86)\Vim\vim80\vim.exe", false, null)]//without mouse
        //todo C:\Users\greg\Desktop\ZZZ open in\eclipse-cpp-neon-2-win32-x86_64\eclipse\eclipse.exe
        //todo C:\Users\greg\Desktop\ZZZ open in\eclipse-java-neon-2-win32-x86_64\eclipse\eclipse.exe
        //todo C:\Users\greg\Desktop\ZZZ open in\eclipse-jee-neon-2-win32-x86_64\eclipse\eclipse.exe
        //todo C:\Users\greg\Desktop\ZZZ open in\Z this is emacs _ eclipse-php-neon-2-win32-x86_64\eclipse\eclipse.exe
        //works with 2 files, 1 browser window 2 tabs but opens canary        [TestCase(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", null)]
        //works with 2 files, 1 browser window 2 tabs but opens aurora         [TestCase(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe", null)]
        //works but ignores the args, when 2 argsat least  [TestCase(@"C:\Program Files (x86)\Internet Explorer\iexplore.exe", null)]
        //nothing happens [TestCase(@"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdge.exe", null)]
        //nothing happens [TestCase(@"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdge.exe", false)]
        //nothing happens [TestCase(@"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdgeCP.exe", null)]// cp = content process
        //nothing happens [TestCase(@"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdgeCP.exe", false)]// cp = content process
        //works with multiple args, file or folder, but only uses the final argument [TestCase(@"C:\Program Files (x86)\FastStone Image Viewer\FSViewer.exe", true, null)]
        //works but args ignored even if single arg that is a directory [TestCase(@"C:\Program Files (x86)\DeDup\DeDup.exe", false)]
        //works but args ignored even if single arg that is a directory or jpg [TestCase(@"C:\Program Files (x86)\Windows Live\Photo Gallery\WLXPhotoGallery.exe", null)]
        //nothing happens [TestCase(@"C:\Program Files (x86)\DeDup\DeDup.exe", null)]
        //works, but needs testing with files actually locked [TestCase(@"C:\Program Files\Unlocker\Unlocker.exe", null)]
        //opens app but even with just 1 arg containing folder name the app doesnt use the argument [TestCase(@"C:\Program Files (x86)\File Renamer\FileRenamer.exe", null)]
        //nothing happens even just 1 file [TestCase(@"C:\Program Files (x86)\Windows Media Player\wmplayer.exe", null)]
        //works, with 1 file at least, but video is black! [TestCase(@"C:\Program Files (x86)\Windows Media Player\wmplayer.exe", false)]
    }
}