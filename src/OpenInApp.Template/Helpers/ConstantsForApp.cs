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





        //NEW=============================
        public ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeDto
        {
            ExecutableFileToBrowseFor = "XMLSpy.exe",
            InitialFolderTypePrimary = InitialFolderType.ProgramFilesX86,
            InitialFolderTypeSecondary = InitialFolderType.ProgramFiles,
            SecondaryFilePathSegment = @"Altova\XMLSpy2016",
            SecondaryFilePathSegmentHasMultipleYearNumberVersions = true,
        };
        //NEW=============================






        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + ExecutableFileToBrowseFor;
        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = true;//typically true for MM/PDN/Altova/Gimp & false for devenv.exe//gregtgregt;
    }
}
