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
        public InitialFolderType InitialFolderTypePrimary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public InitialFolderType InitialFolderTypeSecondary
        //{
        //    get
        //    {
        //        if (InitialFolderTypePrimary == InitialFolderType.
        //        return InitialFolderType.ProgramFilesX86;
        //    }
        //}

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
