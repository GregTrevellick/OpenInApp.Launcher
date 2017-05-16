using System.Collections.Generic;
    
namespace OpenInApp.Common.Helpers.Dtos
{
    public class ActualPathToExeDto
    {
        public IEnumerable<string> DefaultTypicalFileExtensions { get; set; }
        public string ExecutableFileToBrowseFor { get; set; }
        public InitialFolderType InitialFolderType { get; set; }//gregt do we always look in \ProgFiles anyway, effectively making this redundant ?
        public string SecondaryFilePathSegment { get; set; }
        public bool SecondaryFilePathSegmentHasMultipleYearNumberVersions { get; set; }
        public bool SeparateProcessPerFileToBeOpened { get; set; } //gregt - always true ? ergo can delete this property ?
        public bool UseShellExecute { get; set; }
    }
}
