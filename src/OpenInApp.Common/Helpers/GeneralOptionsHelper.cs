using OpenInApp.Common.Helpers.Dtos;
using System.IO;
using static System.Environment;

namespace OpenInApp.Common.Helpers
{
    /// <summary>
    /// Helper class for Visual Studio | Tools | Options
    /// </summary>
    public class GeneralOptionsHelper
    {
        /// <summary>
        /// Returns path to specified executable file, within the the specified folder and sub-folder names, within Program Files directory.
        /// </summary>
        /// <param name="actualPathToExeDto">Dto containing segmented names of the file path.</param>
        /// <returns></returns>
        public static string GetActualPathToExe(ActualPathToExeDto actualPathToExeDto)
        {
            var pathPrimary = GetPath(actualPathToExeDto.InitialFolderTypePrimary, actualPathToExeDto.SecondaryFilePathSegment, actualPathToExeDto.ExecutableFileToBrowseFor);
            if (File.Exists(pathPrimary))
            {
                return pathPrimary;
            }
            else
            {
                var pathSecondary = GetPath(actualPathToExeDto.InitialFolderTypeSecondary, actualPathToExeDto.SecondaryFilePathSegment, actualPathToExeDto.ExecutableFileToBrowseFor);
                if (File.Exists(pathSecondary))
                {
                    return pathSecondary;
                }
            }

            return null;
        }

        private static string GetPath(InitialFolderType initialFolderType, string secondaryFilePathSegment, string executableFileToBrowseFor)
        {
            var specialFolder = (SpecialFolder)initialFolderType;
            var initialFolder = GetFolderPath(specialFolder);
            var path = Path.Combine(initialFolder, secondaryFilePathSegment, executableFileToBrowseFor);
            return path;
        }
    }
}
