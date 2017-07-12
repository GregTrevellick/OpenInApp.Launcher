﻿using NUnit.Framework;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class OpenInAppHelperTests100
    {
        [Test()]
        [Category("E2E")]
        public void AltovaXMLSpy()
        {
            InvokeApplication(KeyToExecutableEnum.AltovaXMLSpy);
        }   

        [Test()]
        [Category("E2E")]
        public void FirefoxDeveloperEdition()
        {
            InvokeApplication(KeyToExecutableEnum.FirefoxDeveloperEdition);
        }
   
        [Test()]
        [Category("E2E")]
        public void Gimp()
        {
            InvokeApplication(KeyToExecutableEnum.Gimp);
        }     

        [Test()]
        [Category("E2E")]
        public void MarkdownMonster()
        {
            InvokeApplication(KeyToExecutableEnum.MarkdownMonster);
        }
     
        [Test()]
        [Category("E2E")]
        public void MSPaint()
        {
            InvokeApplication(KeyToExecutableEnum.MSPaint);
        }

        [Test()]
        [Category("E2E")]
        public void Opera()
        {
            InvokeApplication(KeyToExecutableEnum.Opera);
        }

        [Test()]
        [Category("E2E")]
        public void OperaDeveloperEdition()
        {
            InvokeApplication(KeyToExecutableEnum.OperaDeveloperEdition);
        }     

        [Test()]
        [Category("E2E")]
        public void PaintDotNet()
        {
            InvokeApplication(KeyToExecutableEnum.PaintDotNet);
        }

        [Test()]
        [Category("E2E")]
        public void SQLServerManagementStudio()
        {
            InvokeApplication(KeyToExecutableEnum.SQLServerManagementStudio);
        }

        [Test()]
        [Category("E2E")]
        public void TreeSizeFree()
        {
            InvokeApplication(KeyToExecutableEnum.TreeSizeFree);
        }

        [Test()]
        [Category("E2E")]
        public void Vivaldi()
        {
            InvokeApplication(KeyToExecutableEnum.Vivaldi);
        }
     
        [Test()]
        [Category("E2E")]
        public void VS2015()
        {
            InvokeApplication(KeyToExecutableEnum.VS2015);
        }

        [Test()]
        [Category("E2E")]
        public void VS2017Community()
        {
            InvokeApplication(KeyToExecutableEnum.VS2017Community);
        }

        [Test()]
        [Category("E2E")]
        public void WinDirStat()
        {
            InvokeApplication(KeyToExecutableEnum.WinDirStat);
        }

        private void InvokeApplication(KeyToExecutableEnum keyToExecutableEnum)
        {
            SetExecutableFullPath(keyToExecutableEnum);

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

        private string executableFullPath { get; set; }

        private void SetExecutableFullPath(KeyToExecutableEnum keyToExecutableEnum)
        {
            switch (keyToExecutableEnum)
            {
                case KeyToExecutableEnum.AltovaXMLSpy:
                    executableFullPath = @"D:\Program Files (x86)\Altova\XMLSpy2017\XMLSpy.exe";
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
                        executableFullPath = @"D:\Program Files (x86)\Markdown Monster\MarkdownMonster.exe";
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
                //case KeyToExecutableEnum.SQLServerManagementStudio:
                //    executableFullPath =
                //    break;
                case KeyToExecutableEnum.TreeSizeFree:
                    if (Environment.MachineName == "SIS050")
                    {
                        executableFullPath = @"D:\Program Files (x86)\JAM Software\TreeSize Free\TreeSizeFree.exe";
                    }
                    else
                    {
                        executableFullPath = @"C:\Program Files (x86)\JAM Software\TreeSize Free\TreeSizeFree.exe";
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
                default:
                    executableFullPath = @"C:\Temp\NotFound.exe";
                    break;
            }
        
        }

        //////////////////////private const string altovaXMLSpyExePath = @"D:\Program Files (x86)\Altova\XMLSpy2017\XMLSpy.exe";
        //////////////////////private const string firefoxDeveloperEditionExePath = @"C:\Program Files\Firefox Developer Edition\firefox.exe";
        //////////////////////private const string gimpExePath = @"D:\Program Files\GIMP 2\bin\gimp-2.8.exe";
        //////////////////////private const string markdownMonsterExePath = @"D:\Program Files (x86)\Markdown Monster\MarkdownMonster.exe";//private const string markdownMonsterExePath = @"C:\Program Files (x86)\Markdown Monster\MarkdownMonster.exe";
        //////////////////////private const string msPaintExePath = @"C:\Windows\system32\mspaint.exe";
        //////////////////////private const string operaExePath = @"D:\Program Files\Opera\launcher.exe";
        //////////////////////private const string operaDeveloperEditionExePath = @"D:\Program Files\Opera developer\launcher.exe";
        //////////////////////private const string paintDotNetExePath = @"C:\Program Files\paint.net\PaintDotNet.exe";
        //////////////////////private const string sqlServerManagementStudio = @"C:\Program Files\ssms.exe";
        //////////////////////private const string treeSizeFreeExePath = @"D:\Program Files (x86)\JAM Software\TreeSize Free\TreeSizeFree.exe";//private const string vivaldiExePath = @"C:\Users\GregoryT\AppData\Local\Vivaldi\Application\vivaldi.exe";
        //////////////////////private const string vivaldiExePath = @"D:\Users\gtrev\AppData\Local\Vivaldi\Application\vivaldi.exe";
        //////////////////////private const string vs2015ExePath = @"D:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe";
        //////////////////////private const string vs2017CommunityExePath = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.exe";
        //////////////////////private const string winDirStatExePath = @"D:\Program Files (x86)\WinDirStat\windirstat.exe";

        private string testFilesPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

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

        private List<string> GetTestArtefactsToBeOpened_Single_ImageFile()
        {
            return new List<string>
            {
                testFilesPath + @"\OIA\Single_ImageFile1.jpg"
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Single_TextFile()
        {
            return new List<string>
            {
                testFilesPath + @"\OIA\Single_TextFilea.txt"
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Single_Folder()
        {
            return new List<string>
            {
                testFilesPath + @"\OIA\Single_Folder"
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Multiple_TextFiles()
        {
            return new List<string>
            {
                testFilesPath + @"\OIA\Multiple_TextFilesa.txt",
                testFilesPath + @"\OIA\Multiple_TextFilesb.txt",
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Multiple_ImageFiles()
        {
            return new List<string>
            {
                testFilesPath + @"C:\Temp\OIA\Multiple_ImageFiles1.jpg",
                testFilesPath + @"C:\Temp\OIA\Multiple_ImageFiles2.jpg",
            };
        }

        private List<string> GetTestArtefactsToBeOpened_Multiple_Folders()
        {
            return new List<string>
            {
                testFilesPath + @"\OIA\Multiple_Folders",
                testFilesPath + @"\OIA\Multiple_Folders\Test",
            };
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
