using NUnit.Framework;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System;
using System.Collections.Generic;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class OpenInAppHelperTests100NEW
    {
        [Test()]
        [Category("E2E")]
        public void AltovaXMLSpy()
        {
            InvokeApplication(KeyToExecutableEnum.AltovaXMLSpy, altovaXMLSpyExePath);
        }   

        [Test()]
        [Category("E2E")]
        public void FirefoxDeveloperEdition()
        {
            InvokeApplication(KeyToExecutableEnum.FirefoxDeveloperEdition, firefoxDeveloperEditionExePath);
        }
   
        [Test()]
        [Category("E2E")]
        public void Gimp()
        {
            InvokeApplication(KeyToExecutableEnum.Gimp, gimpExePath);
        }     

        [Test()]
        [Category("E2E")]
        public void MarkdownMonster()
        {
            InvokeApplication(KeyToExecutableEnum.MarkdownMonster, markdownMonsterExePath);
        }
     
        [Test()]
        [Category("E2E")]
        public void MSPaint()
        {
            InvokeApplication(KeyToExecutableEnum.MSPaint, msPaintExePath);
        }

        [Test()]
        [Category("E2E")]
        public void Opera()
        {
            InvokeApplication(KeyToExecutableEnum.Opera, operaExePath);
        }

        [Test()]
        [Category("E2E")]
        public void OperaDeveloperEdition()
        {
            InvokeApplication(KeyToExecutableEnum.OperaDeveloperEdition, operaDeveloperEditionExePath);
        }     

        [Test()]
        [Category("E2E")]
        public void PaintDotNet()
        {
            InvokeApplication(KeyToExecutableEnum.PaintDotNet, paintDotNetExePath);
        }

        [Test()]
        [Category("E2E")]
        public void TreeSizeFree()
        {
            InvokeApplication(KeyToExecutableEnum.TreeSizeFree, treeSizeFreeExePath);
        }

        [Test()]
        [Category("E2E")]
        public void Vivaldi()
        {
            InvokeApplication(KeyToExecutableEnum.Vivaldi, vivaldiExePath);
        }
     
        [Test()]
        [Category("E2E")]
        public void VS2015()
        {
            InvokeApplication(KeyToExecutableEnum.VS2015, vs2015ExePath);
        }

        [Test()]
        [Category("E2E")]
        public void VS2017Community()
        {
            InvokeApplication(KeyToExecutableEnum.VS2017Community, vs2017CommunityExePath);
        }

        [Test()]
        [Category("E2E")]
        public void WinDirStat()
        {
            InvokeApplication(KeyToExecutableEnum.WinDirStat, winDirStatExePath);
        }

        private void InvokeApplication(KeyToExecutableEnum keyToExecutableEnum, string executableFullPath)
        {
            InvokeApplication(keyToExecutableEnum, executableFullPath, "Single", ArtefactTypeToOpen.File, "Text");
            InvokeApplication(keyToExecutableEnum, executableFullPath, "Single", ArtefactTypeToOpen.File, "Image");
            InvokeApplication(keyToExecutableEnum, executableFullPath, "Single", ArtefactTypeToOpen.Folder, null);
            InvokeApplication(keyToExecutableEnum, executableFullPath, "Multiple", ArtefactTypeToOpen.File, "Text");
            InvokeApplication(keyToExecutableEnum, executableFullPath, "Multiple", ArtefactTypeToOpen.File, "Image");
            InvokeApplication(keyToExecutableEnum, executableFullPath, "Multiple", ArtefactTypeToOpen.Folder, null);
        }

        private void InvokeApplication(KeyToExecutableEnum keyToExecutableEnum, string executableFullPath, string singleOrMultipleArtefacts, ArtefactTypeToOpen artefactTypeToOpen, string typ)
        {
            // Arrange
            var dto = new ApplicationToOpenHelper().GetApplicationToOpenDto(keyToExecutableEnum);
            var artefactsToBeOpened = new List<string>();

            artefactsToBeOpened = GetTestArtefactsToBeOpened(singleOrMultipleArtefacts, typ, dto, artefactsToBeOpened);

            // Act
            OpenInAppHelper.InvokeCommand(artefactsToBeOpened, executableFullPath, dto.SeparateProcessPerFileToBeOpened, dto.UseShellExecute, dto.ArtefactTypeToOpen, dto.ProcessWithinProcess);
        }

        private const string altovaXMLSpyExePath = @"D:\Program Files (x86)\Altova\XMLSpy2017\XMLSpy.exe";
        private const string firefoxDeveloperEditionExePath = @"C:\Program Files\Firefox Developer Edition\firefox.exe";
        private const string gimpExePath = @"D:\Program Files\GIMP 2\bin\gimp-2.8.exe";
        //private const string markdownMonsterExePath = @"C:\Program Files (x86)\Markdown Monster\MarkdownMonster.exe";
        private const string markdownMonsterExePath = @"D:\Program Files (x86)\Markdown Monster\MarkdownMonster.exe";
        private const string msPaintExePath = @"C:\Windows\system32\mspaint.exe";
        private const string operaExePath = @"D:\Program Files\Opera\launcher.exe";
        private const string operaDeveloperEditionExePath = @"D:\Program Files\Opera developer\launcher.exe";
        private const string paintDotNetExePath = @"C:\Program Files\paint.net\PaintDotNet.exe";
        private const string treeSizeFreeExePath = @"D:\Program Files (x86)\JAM Software\TreeSize Free\TreeSizeFree.exe";
        //private const string vivaldiExePath = @"C:\Users\GregoryT\AppData\Local\Vivaldi\Application\vivaldi.exe";
        private const string vivaldiExePath = @"D:\Users\gtrev\AppData\Local\Vivaldi\Application\vivaldi.exe";
        private const string vs2015ExePath = @"D:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe";
        private const string vs2017CommunityExePath = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe";
        private const string winDirStatExePath = @"D:\Program Files (x86)\WinDirStat\windirstat.exe";

        private List<string> GetTestArtefactsToBeOpened(string singleOrMultipleArtefacts, string typ, ApplicationToOpenDto dto, List<string> artefactsToBeOpened)
        {
            if (singleOrMultipleArtefacts == "Single")
            {
                switch (dto.ArtefactTypeToOpen)
                {
                    case ArtefactTypeToOpen.File:
                        if (typ == "Text")
                        {
                            artefactsToBeOpened = GetTestArtefactsToBeOpened_Single_TextFile();
                        }
                        else
                        {
                            artefactsToBeOpened = GetTestArtefactsToBeOpened_Single_ImageFile();
                        }
                        break;
                    case ArtefactTypeToOpen.Folder:
                        artefactsToBeOpened = GetTestArtefactsToBeOpened_Single_Folder();
                        break;
                }
            }
            else
            {
                switch (dto.ArtefactTypeToOpen)
                {
                    case ArtefactTypeToOpen.File:
                        if (typ == "Text")
                        {
                            artefactsToBeOpened = GetTestArtefactsToBeOpened_Multiple_TextFiles();
                        }
                        else
                        {
                            artefactsToBeOpened = GetTestArtefactsToBeOpened_Multiple_ImageFiles();
                        }
                        break;
                    case ArtefactTypeToOpen.Folder:
                        artefactsToBeOpened = GetTestArtefactsToBeOpened_Multiple_Folders();
                        break;
                }
            }

            return artefactsToBeOpened;
        }

        private static List<string> GetTestArtefactsToBeOpened_Single_ImageFile()
        {
            List<string> artefactsToBeOpened;
            if (Environment.MachineName == "SIS050")
            {
                artefactsToBeOpened = new List<string> { @"C:\Temp\1.jpg" };
            }
            else
            {
                artefactsToBeOpened = new List<string> { @"D:\Temp\2.jpg" };
            }

            return artefactsToBeOpened;
        }

        private static List<string> GetTestArtefactsToBeOpened_Single_TextFile()
        {
            List<string> artefactsToBeOpened;
            if (Environment.MachineName == "SIS050")
            {
                artefactsToBeOpened = new List<string> { @"C:\Temp\a.txt" };
            }
            else
            {
                artefactsToBeOpened = new List<string> { @"D:\Temp\a.txt" };
            }

            return artefactsToBeOpened;
        }

        private static List<string> GetTestArtefactsToBeOpened_Single_Folder()
        {
            List<string> artefactsToBeOpened;
            if (Environment.MachineName == "SIS050")
            {
                artefactsToBeOpened = new List<string> { @"C:\Temp\" };
            }
            else
            {
                artefactsToBeOpened = new List<string> { @"D:\Temp\" };
            }

            return artefactsToBeOpened;
        }

        private List<string> GetTestArtefactsToBeOpened_Multiple_TextFiles()
        {
            if (Environment.MachineName == "SIS050")
            {
                return new List<string>
                    {
                        @"C:\Temp\a.txt",
                        @"C:\Temp\b.txt",
                    };
            }
            else
            {
                return new List<string>
                    {
                        @"D:\Temp\a.txt",
                        @"D:\Temp\b.txt",
                    };
            }
        }

        private List<string> GetTestArtefactsToBeOpened_Multiple_ImageFiles()
        {
            if (Environment.MachineName == "SIS050")
            {
                return new List<string>
                    {
                        @"C:\Temp\1.jpg",
                        @"C:\Temp\2.jpg",
                    };
            }
            else
            {
                return new List<string>
                    {
                        @"D:\Temp\1.jpg",
                        @"D:\Temp\2.jpg",
                    };
            }
        }

        private List<string> GetTestArtefactsToBeOpened_Multiple_Folders()
        {
            if (Environment.MachineName == "SIS050")
            {
                return new List<string>
                    {
                        @"C:\Temp\",
                        @"C:\Temp\Test",
                    };
            }
            else
            {
                return new List<string>
                    {
                        @"D:\Temp\",
                        @"D:\Temp\Test",
                    };
            }
        }

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


//private void InvokeApplication(KeyToExecutableEnum keyToExecutableEnum, string executableFullPath, string singleOrMultipleArtefacts)
//{
//    // Arrange
//    var dto = new ApplicationToOpenHelper().GetApplicationToOpenDto(keyToExecutableEnum);
//    var artefactsToBeOpened = new List<string>();

//    if (singleOrMultipleArtefacts == "Single")
//    {
//        switch (dto.ArtefactTypeToOpen)
//        {
//            case ArtefactTypeToOpen.File:
//                switch (keyToExecutableEnum)
//                {
//                    case KeyToExecutableEnum.FirefoxDeveloperEdition:
//                    case KeyToExecutableEnum.Gimp:
//                    case KeyToExecutableEnum.MSPaint:
//                    case KeyToExecutableEnum.Opera:
//                    case KeyToExecutableEnum.OperaDeveloperEdition:
//                    case KeyToExecutableEnum.PaintDotNet:
//                    case KeyToExecutableEnum.Vivaldi:
//                    case KeyToExecutableEnum.VS2015:
//                    case KeyToExecutableEnum.VS2017Community:
//                        if (Environment.MachineName == "SIS050")
//                        {
//                            artefactsToBeOpened = new List<string> { @"C:\Temp\1.jpg" };
//                        }
//                        else
//                        {
//                            artefactsToBeOpened = new List<string> { @"D:\Temp\2.jpg" };
//                        }
//                        break;
//                    default:
//                        if (Environment.MachineName == "SIS050")
//                        {
//                            artefactsToBeOpened = new List<string> { @"C:\Temp\a.txt" };
//                        }
//                        else
//                        {
//                            artefactsToBeOpened = new List<string> { @"D:\Temp\a.txt" };
//                        }
//                        break;
//                }
//                break;
//            case ArtefactTypeToOpen.Folder:
//                if (Environment.MachineName == "SIS050")
//                {
//                    artefactsToBeOpened = new List<string> { @"C:\Temp\" };
//                }
//                else
//                {
//                    artefactsToBeOpened = new List<string> { @"D:\Temp\" };
//                }
//                break;
//        }
//    }
//    else
//    {
//        switch (dto.ArtefactTypeToOpen)
//        {
//            case ArtefactTypeToOpen.File:
//                switch (keyToExecutableEnum)
//                {
//                    case KeyToExecutableEnum.Gimp:
//                    case KeyToExecutableEnum.MSPaint:
//                    case KeyToExecutableEnum.PaintDotNet:
//                        artefactsToBeOpened = GetArtefactsToBeOpened_Multiple_ImageFiles();
//                        break;
//                    default:
//                        artefactsToBeOpened = GetArtefactsToBeOpened_Multiple_TextFiles();
//                        break;
//                }
//                break;
//            case ArtefactTypeToOpen.Folder:
//                artefactsToBeOpened = GetArtefactsToBeOpened_Multiple_Folders();
//                break;
//        }
//    }

//    // Act
//    OpenInAppHelper.InvokeCommand(artefactsToBeOpened, executableFullPath, dto.SeparateProcessPerFileToBeOpened, dto.UseShellExecute, dto.ArtefactTypeToOpen, dto.ProcessWithinProcess);
//}
