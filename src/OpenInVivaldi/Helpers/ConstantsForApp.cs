using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInVivaldi.Helpers
{
    public class ConstantsForApp 
    {
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeDto
        {
            ExecutableFileToBrowseFor = "vivaldi.exe",
            InitialFolderTypePrimary = InitialFolderType.LocalApplicationData,
            InitialFolderTypeSecondary = InitialFolderType.None,
            SecondaryFilePathSegment = @"Vivaldi\Application",
            SecondaryFilePathSegmentHasMultipleYearNumberVersions = false,
        };

        //public const string AppFolderName = "Vivaldi";//C:\Users\greg\AppData\Local\Vivaldi\Application\vivaldi.exe
        //public const string AppSubFolderName = "Application";
        //public const string ExecutableFileToBrowseFor = "vivaldi.exe";

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
