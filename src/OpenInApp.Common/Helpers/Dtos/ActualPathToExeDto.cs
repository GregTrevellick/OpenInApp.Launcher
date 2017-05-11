namespace OpenInApp.Common.Helpers.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class ActualPathToExeDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string ExecutableFileToBrowseFor { get; set; }//gregt rename to ExecutableFileName

        /// <summary>
        /// 
        /// </summary>
        public InitialFolderType InitialFolderTypePrimary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public InitialFolderType InitialFolderTypeSecondary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool SecondaryFilePathSegmentHasMultipleYearNumberVersions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SecondaryFilePathSegment { get; set; }
    }
}
