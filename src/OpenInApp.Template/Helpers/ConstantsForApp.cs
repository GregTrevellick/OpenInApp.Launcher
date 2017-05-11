using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInGregtGregt.Helpers
{
    public class ConstantsForApp //gregt convert to an interface
    {
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





        ////NEW=============================
        //public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeDto
        //{
        //    ExecutableFileToBrowseFor = "MarkdownMonster.exe",
        //    InitialFolderTypePrimary = InitialFolderType.ProgramFilesX86,
        //    InitialFolderTypeSecondary = InitialFolderType.ProgramFiles,
        //    SecondaryFilePathSegment = @"Markdown Monster",
        //    SecondaryFilePathSegmentHasMultipleYearNumberVersions = false,
        //};
        ////NEW=============================

        ////NEW=============================
        //public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeDto
        //{
        //    ExecutableFileToBrowseFor = "vivaldi.exe",
        //    InitialFolderTypePrimary = InitialFolderType.LocalApplicationData,
        //    InitialFolderTypeSecondary = InitialFolderType.None,
        //    SecondaryFilePathSegment = @"Vivaldi\Application",
        //    SecondaryFilePathSegmentHasMultipleYearNumberVersions = false,
        //};
        ////NEW=============================

        //NEW=============================
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeDto
        {
            ExecutableFileToBrowseFor = "mspaint.exe",
            InitialFolderTypePrimary = InitialFolderType.Windows,
            InitialFolderTypeSecondary = InitialFolderType.None,
            SecondaryFilePathSegment = @"system32",
            SecondaryFilePathSegmentHasMultipleYearNumberVersions = false,
        };
        //NEW=============================







        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + ExecutableFileToBrowseFor;
        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = true;//typically true for MM/PDN/Altova/Gimp & false for devenv.exe//gregtgregt;
    }
}
