using OpenInApp.Common.Helpers.Dtos;

namespace OpenInApp.Common.Helpers
{
    public class ActualPathToExeHelper
    {
        public ActualPathToExeDto GetActualPathToExeDto(string executableFileToBrowseFor)
        {
            var actualPathToExeDto = new ActualPathToExeDto
            {
                ExecutableFileToBrowseFor = executableFileToBrowseFor,
                InitialFolderTypePrimary = InitialFolderType.ProgramFilesX86,
                InitialFolderTypeSecondary = InitialFolderType.ProgramFiles,
                SecondaryFilePathSegmentHasMultipleYearNumberVersions = false
            };

            switch (executableFileToBrowseFor)
            {
                case "MSPaint.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = @"windows\system32";
                    break;
                //etc
                //etc
                //etc
                default:
                    break;
            }

            return actualPathToExeDto;
        }
    }
}
