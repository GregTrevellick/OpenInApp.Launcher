using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInFirefoxDeveloperEdition.Helpers
{
    public class ConstantsForApp 
    {
        public const string AppFolderName = "Firefox Developer Edition";
        public const string AppSubFolderName = null;
        public const string ExecutableFileToBrowseFor = "firefox.exe";
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
