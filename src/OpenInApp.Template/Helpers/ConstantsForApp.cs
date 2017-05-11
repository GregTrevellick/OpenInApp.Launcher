using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInGregtGregt.Helpers
{
    public class ConstantsForApp //gregt convert to an interface
    {
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeDto
        {
            ExecutableFileToBrowseFor = ExecutableFileToBrowseFor, 
            InitialFolderTypePrimary = InitialFolderType.ProgramFilesX86,//@"gregtgregt";
            InitialFolderTypeSecondary = InitialFolderType.ProgramFiles,//@"gregtgregt";
            SecondaryFilePathSegment = @"Markdown Monster",//@"gregtgregt";
            SecondaryFilePathSegmentHasMultipleYearNumberVersions = false,//@"gregtgregt";
        };

        public const string ExecutableFileToBrowseFor = "MarkdownMonster.exe";//"gregtgregt";

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
