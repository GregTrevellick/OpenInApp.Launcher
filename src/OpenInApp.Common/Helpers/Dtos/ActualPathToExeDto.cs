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
        public string ExecutableFileToBrowseFor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public InitialFolderType InitialFolderType { get; set; }

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
