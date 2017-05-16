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

        /// <summary>
        /// Gets or sets a value indicating whether [separate process per file to be opened].
        /// </summary>
        /// <value>
        /// <c>true</c> if [separate process per file to be opened]; otherwise, <c>false</c>.
        /// </value>
        public bool SeparateProcessPerFileToBeOpened { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [use shell execute].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use shell execute]; otherwise, <c>false</c>.
        /// </value>
        public bool UseShellExecute { get; set; }

    }
}
