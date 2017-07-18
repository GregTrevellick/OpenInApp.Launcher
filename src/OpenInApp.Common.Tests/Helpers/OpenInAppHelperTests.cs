using NUnit.Framework;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class OpenInAppHelperTests
    {
        [Test()]
        [Category("E2E")]
        public void Test_AltovaXMLSpy()
        {
            InvokeApplication(KeyToExecutableEnum.AltovaXMLSpy, "Text");
        }

        [Test()]
        [Category("E2E")]
        public void Test_Atom()
        {
            InvokeApplication(KeyToExecutableEnum.Atom, "Image");
            InvokeApplication(KeyToExecutableEnum.Atom, "Folder");
            InvokeApplication(KeyToExecutableEnum.Atom, "Text");
        }

        [Test()]
        [Category("E2E")]
        public void Test_FirefoxDeveloperEdition()
        {
            InvokeApplication(KeyToExecutableEnum.FirefoxDeveloperEdition, "Image");
            InvokeApplication(KeyToExecutableEnum.FirefoxDeveloperEdition, "Text");
        }
   
        [Test()]
        [Category("E2E")]
        public void Test_Gimp()
        {
            InvokeApplication(KeyToExecutableEnum.Gimp, "Image");
        }     

        [Test()]
        [Category("E2E")]
        public void Test_MarkdownMonster()
        {
            InvokeApplication(KeyToExecutableEnum.MarkdownMonster, "Text");
        }
     
        [Test()]
        [Category("E2E")]
        public void Test_MSPaint()
        {
            InvokeApplication(KeyToExecutableEnum.MSPaint, "Image");
        }

        [Test()]
        [Category("E2E")]
        public void Test_Opera()
        {
            InvokeApplication(KeyToExecutableEnum.Opera, "Image");
            InvokeApplication(KeyToExecutableEnum.Opera, "Text");
        }

        [Test()]
        [Category("E2E")]
        public void Test_OperaDeveloperEdition()
        {
            InvokeApplication(KeyToExecutableEnum.OperaDeveloperEdition, "Image");
            InvokeApplication(KeyToExecutableEnum.OperaDeveloperEdition, "Text");
        }     

        [Test()]
        [Category("E2E")]
        public void Test_PaintDotNet()
        {
            InvokeApplication(KeyToExecutableEnum.PaintDotNet, "Image");
        }

        [Test()]
        [Category("E2E")]
        public void Test_SQLServerManagementStudio()
        {
            InvokeApplication(KeyToExecutableEnum.SQLServerManagementStudio, "Sequel");
        }

        [Test()]
        [Category("E2E")]
        public void Test_TreeSizeFree()
        {
            InvokeApplication(KeyToExecutableEnum.TreeSizeFree, "Text");
        }

        [Test()]
        [Category("E2E")]
        public void Test_Vivaldi()
        {
            InvokeApplication(KeyToExecutableEnum.Vivaldi, "Image");
            InvokeApplication(KeyToExecutableEnum.Vivaldi, "Text");
        }

        [Test()]
        [Category("E2E")]
        public void Test_VS2015()
        {
            InvokeApplication(KeyToExecutableEnum.VS2015, "Image");
            InvokeApplication(KeyToExecutableEnum.VS2015, "Text");
        }

        [Test()]
        [Category("E2E")]
        public void Test_VS2017Community()
        {
            InvokeApplication(KeyToExecutableEnum.VS2017Community, "Image");
            InvokeApplication(KeyToExecutableEnum.VS2017Community, "Text");
        }

        [Test()]
        [Category("E2E")]
        public void Test_WinDirStat()
        {
            InvokeApplication(KeyToExecutableEnum.WinDirStat, "Text");
        }

        [Test()]
        [Category("E2E")]
        public void Test_XamarinStudio()
        {
            InvokeApplication(KeyToExecutableEnum.XamarinStudio, "Text");
        }

        private void InvokeApplication(KeyToExecutableEnum keyToExecutableEnum, string typ)
        {
            SetExecutableFullPath(keyToExecutableEnum);

            InvokeApplication(keyToExecutableEnum, executableFullPath, "Single", ArtefactTypeToOpen.File, typ);
            InvokeApplication(keyToExecutableEnum, executableFullPath, "Single", ArtefactTypeToOpen.Folder, typ);
            InvokeApplication(keyToExecutableEnum, executableFullPath, "Multiple", ArtefactTypeToOpen.File, typ);
            InvokeApplication(keyToExecutableEnum, executableFullPath, "Multiple", ArtefactTypeToOpen.Folder, typ);
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

        private string executableFullPath { get; set; }

        private void SetExecutableFullPath(KeyToExecutableEnum keyToExecutableEnum)
        {
            switch (keyToExecutableEnum)
            {
                case KeyToExecutableEnum.AltovaXMLSpy:
                    executableFullPath = @"D:\Program Files (x86)\Altova\XMLSpy2017\XMLSpy.exe";
                    break;
                case KeyToExecutableEnum.Atom:
                    executableFullPath = @"C:\Users\gtrev\AppData\Local\atom\atom.exe";
                    break;
                case KeyToExecutableEnum.FirefoxDeveloperEdition:
                    executableFullPath = @"C:\Program Files\Firefox Developer Edition\firefox.exe";
                    break;
                case KeyToExecutableEnum.Gimp:
                    executableFullPath = @"D:\Program Files\GIMP 2\bin\gimp-2.8.exe";
                    break;
                case KeyToExecutableEnum.MarkdownMonster:
                    if (Environment.MachineName == "SIS050")
                    {
                        executableFullPath = @"C:\Program Files (x86)\Markdown Monster\MarkdownMonster.exe";
                    }
                    else
                    {
                        executableFullPath = @"D:\Users\gtrev\AppData\Local\Markdown Monster\MarkdownMonster.exe";//pre 1.4.8 D:\Program Files (x86)\Markdown Monster\MarkdownMonster.exe
                    }
                    break;
                case KeyToExecutableEnum.MSPaint:
                    executableFullPath = @"C:\Windows\system32\mspaint.exe";
                    break;
                case KeyToExecutableEnum.Opera:
                    executableFullPath =@"D:\Program Files\Opera\launcher.exe";
                    break;
                case KeyToExecutableEnum.OperaDeveloperEdition:
                    executableFullPath = @"D:\Program Files\Opera developer\launcher.exe";
                    break;
                case KeyToExecutableEnum.PaintDotNet:
                    executableFullPath = @"C:\Program Files\paint.net\PaintDotNet.exe";
                    break;
                case KeyToExecutableEnum.SQLServerManagementStudio:
                    executableFullPath = @"C:\Program Files (x86)\Microsoft SQL Server\140\Tools\Binn\ManagementStudio\Ssms.exe";
                    break;
                case KeyToExecutableEnum.TreeSizeFree:
                    if (Environment.MachineName == "SIS050")
                    {
                        executableFullPath = @"C:\Program Files (x86)\JAM Software\TreeSize Free\TreeSizeFree.exe";
                    }
                    else
                    {
                        executableFullPath = @"D:\Program Files (x86)\JAM Software\TreeSize Free\TreeSizeFree.exe";
                    }
                    break;
                case KeyToExecutableEnum.Vivaldi:
                    executableFullPath = @"D:\Users\gtrev\AppData\Local\Vivaldi\Application\vivaldi.exe";
                    break;
                case KeyToExecutableEnum.VS2015:
                    executableFullPath = @"D:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe";
                    break;
                case KeyToExecutableEnum.VS2017Community:
                    executableFullPath = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe";
                    break;
                case KeyToExecutableEnum.WinDirStat:
                    executableFullPath = @"D:\Program Files (x86)\WinDirStat\windirstat.exe";
                    break;
                case KeyToExecutableEnum.XamarinStudio:
                    executableFullPath = @"D:\Program Files (x86)\Xamarin Studio\bin\XamarinStudio.exe";
                    break;
                default:
                    executableFullPath = @"C:\Temp\NotFound.exe";
                    break;
            }
        
        }

        private string testFilesPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private List<string> GetTestArtefactsToBeOpened(string singleOrMultipleArtefacts, string typ, ApplicationToOpenDto dto, List<string> artefactsToBeOpened)
        {
            if (singleOrMultipleArtefacts == "Single")
            {
                switch (dto.ArtefactTypeToOpen)
                {
                    case ArtefactTypeToOpen.File:
                        switch (typ)
                        {
                            case "Image":
                                artefactsToBeOpened = GetTestArtefactsToBeOpened_Single_ImageFile();
                                break;
                            case "Sequel":
                                artefactsToBeOpened = GetTestArtefactsToBeOpened_Single_SequelFile();
                                break;
                            case "Text":
                                artefactsToBeOpened = GetTestArtefactsToBeOpened_Single_TextFile();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
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
                        switch (typ)
                        {
                            case "Image":
                                artefactsToBeOpened = GetTestArtefactsToBeOpened_Multiple_ImageFiles();
                                break;
                            case "Sequel":
                                artefactsToBeOpened = GetTestArtefactsToBeOpened_Multiple_SequelFiles();
                                break;
                            case "Text":
                                artefactsToBeOpened = GetTestArtefactsToBeOpened_Multiple_TextFiles();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case ArtefactTypeToOpen.Folder:
                        artefactsToBeOpened = GetTestArtefactsToBeOpened_Multiple_Folders();
                        break;
                }
            }

            return artefactsToBeOpened;
        }

        private List<string> GetTestArtefactsToBeOpened_Single_ImageFile()
        {
            return new List<string>
            {
                testFilesPath + @"\TestFiles\OIA\Single_ImageFile.jpg"
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Single_SequelFile()
        {
            return new List<string>
            {
                testFilesPath + @"\TestFiles\OIA\Single_SequelFile.sql"
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Single_TextFile()
        {
            return new List<string>
            {
                testFilesPath + @"\TestFiles\OIA\Single_TextFile.txt"
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Single_Folder()
        {
            return new List<string>
            {
                testFilesPath + @"\TestFiles\OIA\Single_Folder"
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Multiple_ImageFiles()
        {
            return new List<string>
            {
                testFilesPath + @"\TestFiles\OIA\Multiple_ImageFilesA.jpg",
                testFilesPath + @"\TestFiles\OIA\Multiple_ImageFilesB.jpg",
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Multiple_SequelFiles()
        {
            return new List<string>
            {
                testFilesPath + @"\TestFiles\OIA\Multiple_SequelFilesA.sql",
                testFilesPath + @"\TestFiles\OIA\Multiple_SequelFilesB.sql",
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Multiple_TextFiles()
        {
            return new List<string>
            {
                testFilesPath + @"\TestFiles\OIA\Multiple_TextFilesA.txt",
                testFilesPath + @"\TestFiles\OIA\Multiple_TextFilesB.txt",
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Multiple_Folders()
        {
            return new List<string>
            {
                testFilesPath + @"\TestFiles\OIA\Multiple_Folders",
                testFilesPath + @"\TestFiles\OIA\Multiple_Folders\Test",
            };
        }

        //codepen 
        //jsfiddle
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
        //eclipse C:\Users\greg\Desktop\ZZZ open in\eclipse-cpp-neon-2-win32-x86_64\eclipse\eclipse.exe
        //eclipse C:\Users\greg\Desktop\ZZZ open in\eclipse-java-neon-2-win32-x86_64\eclipse\eclipse.exe
        //eclipse C:\Users\greg\Desktop\ZZZ open in\eclipse-jee-neon-2-win32-x86_64\eclipse\eclipse.exe
        //eclipse C:\Users\greg\Desktop\ZZZ open in\Z this is emacs _ eclipse-php-neon-2-win32-x86_64\eclipse\eclipse.exe
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