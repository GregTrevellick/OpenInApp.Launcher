using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInAppMarkdownMonster.Helpers
{
    public class ConstantsForApp 
    {
        public const string AppFolderName = "Markdown Monster";
        public const string AppSubFolderName = null;
        public const string ExecutableFileToBrowseFor = "MarkdownMonster.exe";
        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return new List<string>
            {
                #region Extensions
                "md",
	            #endregion
            };
        }


        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + ExecutableFileToBrowseFor;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = true;
    }
}
