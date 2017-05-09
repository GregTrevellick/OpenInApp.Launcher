using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInEmacs.Helpers
{
    public class ConstantsForApp 
    {
        public const string AppFolderName = "emacs-25.1-2-x86_64-w64-mingw32";
        public const string AppSubFolderName = "bin";
        public const string ExecutableFileToBrowseFor = "runemacs.exe";
        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return new List<string>
            {
                "*"
            };
        }



        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + ExecutableFileToBrowseFor;
        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = true;
    }
}
