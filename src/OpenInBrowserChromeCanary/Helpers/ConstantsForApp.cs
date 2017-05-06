using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInChromeCanary.Helpers
{
    public class ConstantsForApp 
    {

        //gregtgregt delete excess comments here

        public const string AppFolderName = "Google";//C:\Users\greg\AppData\Local\Google  \Chrome SxS  \Application \chrome.exe
                                                     //C:\Users\greg\AppData\Local\Vivaldi \Application \vivaldi.exe
        public const string AppSubFolderName = "Chrome SxS";
        public const string ExecutableFileToBrowseFor = "chrome.exe";
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
