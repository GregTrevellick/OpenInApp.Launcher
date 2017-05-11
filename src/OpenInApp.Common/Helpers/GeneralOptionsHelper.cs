using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;
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
            string result = null;

            var pathPrimary = GetPath(actualPathToExeDto.InitialFolderTypePrimary, actualPathToExeDto.SecondaryFilePathSegment, actualPathToExeDto.ExecutableFileToBrowseFor);

            if (File.Exists(pathPrimary))
            {
                result = pathPrimary;
            }
            else
            {
                var pathSecondary = GetPath(actualPathToExeDto.InitialFolderTypeSecondary, actualPathToExeDto.SecondaryFilePathSegment, actualPathToExeDto.ExecutableFileToBrowseFor);

                if (File.Exists(pathSecondary))
                {
                    result = pathSecondary;
                }
                else 
                {
                    if (actualPathToExeDto.SecondaryFilePathSegmentHasMultipleYearNumberVersions)
                    {
                        var paths = GetMultiYearPaths(actualPathToExeDto.SecondaryFilePathSegment);
                        foreach (var path in paths)
                        {
                            if (File.Exists(path))
                            {
                                result = path;
                            }
                        }
                    }
                }
            }

            return result;
        }

        private static IEnumerable<string> GetMultiYearPaths(string secondaryFilePathSegment)//gregt better name this method
        {
            var result = new List<string>();

            for (int i = 2025; i > 1995; i--)
            {
                result.Add(secondaryFilePathSegment.Replace("2016", i));
            }

            return result;
        }

        private static string GetPath(InitialFolderType initialFolderType, string secondaryFilePathSegment, string executableFileToBrowseFor)
        {
            string path = null;

            if (initialFolderType != InitialFolderType.None)
            {
                var specialFolder = (SpecialFolder)initialFolderType;
                var initialFolder = GetFolderPath(specialFolder);
                path = Path.Combine(initialFolder, secondaryFilePathSegment, executableFileToBrowseFor);
            }

            return path;
        }
    }
}
