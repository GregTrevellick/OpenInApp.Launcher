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
        /// <param name="keyToExecutableEnum"></param>
        /// <returns></returns>
        public static string GetActualPathToExe(KeyToExecutableEnum keyToExecutableEnum)
        {
            var searchPaths = GetSearchPaths(keyToExecutableEnum);

            foreach (var searchPath in searchPaths)
            {
                if (File.Exists(searchPath))
                {
                    return searchPath;
                }
            }

            return null;
        }

        public static IEnumerable<string> GetSearchPaths(KeyToExecutableEnum keyToExecutableEnum)
        {
            var searchPaths  = new List<string>();
            var actualPathToExeHelper = new ApplicationToOpenHelper();
            var applicationToOpenDto = actualPathToExeHelper.GetApplicationToOpenDto(keyToExecutableEnum);

            var pathPrimary = GetPath(applicationToOpenDto.ExecutableFileToBrowseFor, applicationToOpenDto.InitialFolderType, applicationToOpenDto.SecondaryFilePathSegment);
            searchPaths.Add(pathPrimary);

            var x86 = " (x86)";
            if (pathPrimary != null && pathPrimary.Contains(x86))
            {
                var pathPrimaryWithoutx86 = pathPrimary.Replace(x86, string.Empty);
                searchPaths.Add(pathPrimaryWithoutx86);
            }

            if (applicationToOpenDto.SecondaryFilePathSegmentHasMultipleYearNumberVersions)
            {
                var paths = GetMultipleYearPaths(applicationToOpenDto.ExecutableFileToBrowseFor, applicationToOpenDto.InitialFolderType, applicationToOpenDto.SecondaryFilePathSegment);
                foreach (var path in paths)
                {
                    searchPaths.Add(path);
                }
            }

            return searchPaths;
        }

        private static string GetPath(string executableFileToBrowseFor, InitialFolderType initialFolderType, string secondaryFilePathSegment)
        {
            string path = null;

            if (!string.IsNullOrEmpty(executableFileToBrowseFor))
            {
                if (initialFolderType != InitialFolderType.None)
                {
                    var specialFolder = (SpecialFolder)initialFolderType;
                    var initialFolder = GetFolderPath(specialFolder);
                    if (string.IsNullOrEmpty(secondaryFilePathSegment))
                    {
                        path = Path.Combine(initialFolder, executableFileToBrowseFor);
                    }
                    else
                    {
                        path = Path.Combine(initialFolder, secondaryFilePathSegment, executableFileToBrowseFor);
                    }
                }
            }

            return path;
        }

        public static IEnumerable<string> GetMultipleYearPaths(string executableFileToBrowseFor, InitialFolderType initialFolderType, string secondaryFilePathSegment)
        {
            var result = new List<string>();

            for (int i = 2020; i > 1995; i--)
            {
                var segment = secondaryFilePathSegment.Replace("2016", i.ToString());
                var path = GetPath(executableFileToBrowseFor, initialFolderType, segment);
                result.Add(path);
            }

            return result;
        }
    }
}
