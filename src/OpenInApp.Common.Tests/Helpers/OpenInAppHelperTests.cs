using NUnit.Framework;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class OpenInAppHelperTests
    {
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


        [Test()]
        [Category("I")]
        //////////BEATEN TO IT - HAPPILY OPENS BOTH FILES [TestCase(@"C:\Windows\system32\notepad.exe", true, false)]
        //////////BEATEN TO IT - HAPPILY OPENS BOTH FILES [TestCase(@"C:\Program Files (x86)\Vim\vim80\gvim.exe", true, null)]//with mouse - graphical vim
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
        public void InvokeCommandTest_TextApps(string executableFullPath, bool separateProcessPerFileToBeOpened, bool useShellExecute)
        {
            // Arrange
            var actualFilesToBeOpened = new List<string>
            {
                @"C:\Temp\a.txt",
                @"C:\Temp\b.txt",
                //@"C:\Temp\a.linq",
                //@"C:\Temp\b.sql",
            };

            // Act
            Act(actualFilesToBeOpened, executableFullPath, separateProcessPerFileToBeOpened, useShellExecute);
        }

        //[Test()]
        //[Category("I")]
        ////works with 2 files, 1 browser window 2 tabs but opens canary        [TestCase(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", null)]
        ////works with 2 files, 1 browser window 2 tabs but opens aurora         [TestCase(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe", null)]
        ////works but ignores the args, when 2 argsat least  [TestCase(@"C:\Program Files (x86)\Internet Explorer\iexplore.exe", null)]
        ////nothing happens [TestCase(@"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdge.exe", null)]
        ////nothing happens [TestCase(@"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdge.exe", false)]
        ////nothing happens [TestCase(@"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdgeCP.exe", null)]// cp = content process
        ////nothing happens [TestCase(@"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdgeCP.exe", false)]// cp = content process
        //public void InvokeCommandTest_BrowserApps(string executableFullPath, bool useShellExecute)
        //{
        //    // Arrange
        //    bool separateProcessPerFileToBeOpened = false;
        //    var actualFilesToBeOpened = new List<string>
        //    {
        //        @"C:\Temp\a.txt",
        //        @"C:\Temp\b.txt"
        //    };

        //    // Act
        //    Act(actualFilesToBeOpened, executableFullPath, separateProcessPerFileToBeOpened, useShellExecute);
        //}

        //[Test()]
        //[Category("I")]
        ////works with multiple args, file or folder, but only uses the final argument [TestCase(@"C:\Program Files (x86)\FastStone Image Viewer\FSViewer.exe", true, null)]
        ////works but args ignored even if single arg that is a directory [TestCase(@"C:\Program Files (x86)\DeDup\DeDup.exe", false)]
        ////works but args ignored even if single arg that is a directory or jpg [TestCase(@"C:\Program Files (x86)\Windows Live\Photo Gallery\WLXPhotoGallery.exe", null)]
        ////nothing happens [TestCase(@"C:\Program Files (x86)\DeDup\DeDup.exe", null)]
        //public void InvokeCommandTest_ImageApps(string executableFullPath, bool separateProcessPerFileToBeOpened, bool useShellExecute)
        //{
        //    // Arrange
        //    var actualFilesToBeOpened = new List<string>
        //    {
        //          @"C:\Temp\a.jpg",
        //          @"C:\Temp\b.jpg",
        //          //@"C:\Temp",
        //    };

        //    // Act
        //    Act(actualFilesToBeOpened, executableFullPath, separateProcessPerFileToBeOpened, useShellExecute);
        //}

        //[Test()]
        //[Category("I")]
        ////works, but needs testing with files actually locked [TestCase(@"C:\Program Files\Unlocker\Unlocker.exe", null)]
        ////opens app but even with just 1 arg containing folder name the app doesnt use the argument [TestCase(@"C:\Program Files (x86)\File Renamer\FileRenamer.exe", null)]
        ////nothing happens even just 1 file [TestCase(@"C:\Program Files (x86)\Windows Media Player\wmplayer.exe", null)]
        ////works, with 1 file at least, but video is black! [TestCase(@"C:\Program Files (x86)\Windows Media Player\wmplayer.exe", false)]
        //public void InvokeCommandTest_TODOCategory(string executableFullPath, bool useShellExecute)
        //{
        //    // Arrange
        //    bool separateProcessPerFileToBeOpened = false;
        //    var actualFilesToBeOpened = new List<string>
        //    {
        //        @"C:\Temp\a.mpg",
        //        //@"C:\Temp\b.mpeg",
        //        //@"C:\Temp\b.txt",
        //        //@"C:\Temp",
        //    };

        //    // Act
        //    Act(actualFilesToBeOpened, executableFullPath, separateProcessPerFileToBeOpened, useShellExecute);
        //}

        private void Act(IEnumerable<string> actualFilesToBeOpened, string executableFullPath, bool separateProcessPerFileToBeOpened, bool useShellExecute)
        {
                OpenInAppHelper.InvokeCommand(actualFilesToBeOpened, executableFullPath, separateProcessPerFileToBeOpened, useShellExecute, ArtefactTypeToOpen.File);
        }
    }
}