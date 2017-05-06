using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInOpera.Helpers
{
    public class ConstantsForApp //gregt convert to an interface
    {
        // gregtgregt delete this comment - must retain 'AppFolderName' & 'AppSubFolderName' for altova 2009-2016 file system 
        public const string AppFolderName = "Markdown Monster";//@"gregtgregt";
        public const string AppSubFolderName = null;
        public const string ExecutableFileToBrowseFor = "MarkdownMonster.exe";//"gregtgregt";
        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return new List<string>
            {
                //Source: gregtgregt 
                "*"
            };
        }



        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + ExecutableFileToBrowseFor;
        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = true;//typically true for MM/PDN/Altova/Gimp & false for devenv.exe//gregtgregt;
    }
}
