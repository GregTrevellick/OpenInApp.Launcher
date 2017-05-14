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
        /// <param name="executableFileToBrowseFor">Names of the executable file</param>
        /// <returns></returns>
        public static string GetActualPathToExe(string executableFileToBrowseFor)
        {
            var searchPaths = GetSearchPaths(executableFileToBrowseFor);

            foreach (var searchPath in searchPaths)
            {
                if (File.Exists(searchPath))
                {
                    return searchPath;
                }
            }

            return null;
        }

        public static IEnumerable<string> GetSearchPaths(string executableFileToBrowseFor)
        {
            var searchPaths  = new List<string>();
            var actualPathToExeHelper = new ActualPathToExeHelper();
            var actualPathToExeDto = actualPathToExeHelper.GetActualPathToExeDto(executableFileToBrowseFor);

            var pathPrimary = GetPath(executableFileToBrowseFor, actualPathToExeDto);
            searchPaths.Add(pathPrimary);

            var x86 = " (x86)";
            if (pathPrimary != null && pathPrimary.Contains(x86))
            {
                var pathPrimaryWithoutx86 = pathPrimary.Replace(x86, string.Empty);
                searchPaths.Add(pathPrimaryWithoutx86);
            }

            if (actualPathToExeDto.SecondaryFilePathSegmentHasMultipleYearNumberVersions)
            {
                var paths = GetMultipleYearPaths(actualPathToExeDto.SecondaryFilePathSegment);
                foreach (var path in paths)
                {
                    searchPaths.Add(path);
                }
            }

            return searchPaths;
        }

        private static string GetPath(string executableFileToBrowseFor, ActualPathToExeDto actualPathToExeDto)
        {
            string path = null;

            if (!string.IsNullOrEmpty(executableFileToBrowseFor))
            {
                var initialFolderType = actualPathToExeDto.InitialFolderType;

                if (initialFolderType != InitialFolderType.None)
                {
                    var specialFolder = (SpecialFolder)initialFolderType;
                    var initialFolder = GetFolderPath(specialFolder);
                    path = Path.Combine(initialFolder, actualPathToExeDto.SecondaryFilePathSegment, actualPathToExeDto.ExecutableFileToBrowseFor);
                }
            }

            return path;
        }

        public static IEnumerable<string> GetMultipleYearPaths(string secondaryFilePathSegment)
        {
            var result = new List<string>();

            for (int i = 2020; i > 1995; i--)
            {
                result.Add(secondaryFilePathSegment.Replace("2016", i.ToString()));
            }

            return result;
        }
    }
}
