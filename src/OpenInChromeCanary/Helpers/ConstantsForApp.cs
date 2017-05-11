using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInChromeCanary.Helpers
{
    public class ConstantsForApp 
    {
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeDto
        {
            ExecutableFileToBrowseFor = ExecutableFileToBrowseFor,
            InitialFolderTypePrimary = InitialFolderType.ProgramFilesX86,
            InitialFolderTypeSecondary = InitialFolderType.ProgramFiles,
            SecondaryFilePathSegment = @"Markdown Monster",
            SecondaryFilePathSegmentHasMultipleYearNumberVersions = false,
        };

        //public const string AppFolderName = @"Google\Chrome SxS";//C:\Users\greg\AppData\Local \Google\Chrome SxS  \Application \chrome.exe
        //                                                         //C:\Users\greg\AppData\Local \Vivaldi            \Application \vivaldi.exe
        //public const string AppSubFolderName = "Application";
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
