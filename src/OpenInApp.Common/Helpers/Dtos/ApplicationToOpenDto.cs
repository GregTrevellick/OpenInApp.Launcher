using System.Collections.Generic;
    
namespace OpenInApp.Common.Helpers.Dtos
{
    public class ApplicationToOpenDto
    {
        public ArtefactTypeToOpen ArtefactTypeToOpen { get; set; }
        public IEnumerable<string> DefaultTypicalFileExtensions { get; set; }
        public string ExecutableFileToBrowseFor { get; set; }
        public InitialFolderType InitialFolderType { get; set; }//gregtt do we always look in \ProgFiles anyway, effectively making this redundant ?
        public string SecondaryFilePathSegment { get; set; }
        public bool SecondaryFilePathSegmentHasMultipleYearNumberVersions { get; set; }
        public bool SeparateProcessPerFileToBeOpened { get; set; } //always true, ergo can delete this property ?
        public bool UseShellExecute { get; set; }
    }
}
