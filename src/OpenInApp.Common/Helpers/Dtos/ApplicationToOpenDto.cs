using System.Collections.Generic;
    
namespace OpenInApp.Common.Helpers.Dtos
{
    public class ApplicationToOpenDto
    {
        public ArtefactTypeToOpen ArtefactTypeToOpen { get; set; }
        public IEnumerable<string> DefaultTypicalFileExtensions { get; set; }
        public IEnumerable<string> ExecutableFilesToBrowseFor { get; set; }
        public bool? OpenIndividualFilesInFolderRatherThanFolderItself { get; set; }
        public string SecondaryFilePathSegment { get; set; }
        public bool SecondaryFilePathSegmentHasMultipleVersions { get; set; }
        public bool SeparateProcessPerFileToBeOpened { get; set; } 
        public bool UseShellExecute { get; set; }
    }
}
