using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInAppPaintDotNet.Helpers
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

        //public const string AppFolderName = "Paint.NET";
        //public const string AppSubFolderName = null;
        public const string ExecutableFileToBrowseFor = "PaintDotNet.exe";

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return new List<string>
            {
                //Source(s): http://www.getpaint.net/doc/latest/
                #region Extensions
                "BMP",
                "DDS",
                "GIF",
                "JPEG",
                "JPG",
                "PDN",
                "PNG",
                "TGA",
                "TIFF",
	            #endregion
            };
        }


        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + ExecutableFileToBrowseFor;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = true;
    }
}
