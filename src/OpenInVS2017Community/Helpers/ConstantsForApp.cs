using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInVS2017Community.Helpers
{
    public class ConstantsForApp 
    {
        public const string AppFolderName = @"Microsoft Visual Studio";
        public const string AppSubFolderName = @"2017\Community\Common7\IDE";
        public const string ExecutableFileToBrowseFor = "devenv.exe";
        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return new List<string>
            {
                "*"
            };
        }


        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + ExecutableFileToBrowseFor;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = false;
    }
}
