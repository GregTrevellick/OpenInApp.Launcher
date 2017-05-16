using System.Collections.Generic;
    
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

        /// <summary>
        /// Gets or sets the default typical file extensions.
        /// </summary>
        /// <value>
        /// The default typical file extensions.
        /// </value>
        public IEnumerable<string> DefaultTypicalFileExtensions { get; set; }
    }
}
