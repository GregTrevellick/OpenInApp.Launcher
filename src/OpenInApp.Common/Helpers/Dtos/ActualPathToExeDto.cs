namespace OpenInApp.Common.Helpers.Dtos
{
    /// <summary>
    /// Dto for file browsing in the file system
    /// </summary>
    public class ActualPathToExeDto
    {
        public string ExecutableFileToBrowseFor { get; set; }//gregt rename to ExecutableFileName
        public InitialFolderType InitialFolderTypePrimary { get; set; }
        public InitialFolderType InitialFolderTypeSecondary { get; set; }
        public bool SecondaryFilePathSegmentHasMultipleYearNumberVersions { get; set; }
        public string SecondaryFilePathSegment { get; set; }
    }
}
