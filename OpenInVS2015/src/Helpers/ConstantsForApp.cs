using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInVS2015.Helpers
{
    public class ConstantsForApp 
    {
        public const string AppFolderName = @"Microsoft Visual Studio 14.0";
        public const string AppSubFolderName = @"Common7\IDE";
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
    }
}
