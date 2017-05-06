using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInOpera.Helpers
{
    public class ConstantsForApp 
    {
        public const string AppFolderName = "Opera";
        public const string AppSubFolderName = null;
        public const string ExecutableFileToBrowseFor = "opera.exe";
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
