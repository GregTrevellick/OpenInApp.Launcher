using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            searchPaths = X86Method(searchPaths);

            foreach (var searchPath in searchPaths)
            {
                if (File.Exists(searchPath))
                {
                    return searchPath;
                }
            }

            return null;
        }

        private static IEnumerable<string> X86Method(IEnumerable<string> searchPaths)//gregtt unit test this
        {
            var result = new List<string>();

            var x86 = " (x86)";

            foreach (var path in searchPaths)
            {
                result.Add(path);
                if (path != null && path.Contains(x86))
                {
                    var pathWithoutx86 = path.Replace(x86, string.Empty);
                    result.Add(pathWithoutx86);
                }
            }

            return result;
        }

        internal static IEnumerable<string> GetSearchPaths(KeyToExecutableEnum keyToExecutableEnum)
        {
            var searchPaths  = new List<string>();
            var actualPathToExeHelper = new ApplicationToOpenHelper();
            var applicationToOpenDto = actualPathToExeHelper.GetApplicationToOpenDto(keyToExecutableEnum);

            var pathPrimary = GetPath(applicationToOpenDto.ExecutableFileToBrowseFor, applicationToOpenDto.InitialFolderType, applicationToOpenDto.SecondaryFilePathSegment);
            searchPaths.Add(pathPrimary);

            if (applicationToOpenDto.SecondaryFilePathSegmentHasMultipleVersions)
            {
                var paths = GetMultipleVersionPaths(applicationToOpenDto.ExecutableFileToBrowseFor, applicationToOpenDto.InitialFolderType, applicationToOpenDto.SecondaryFilePathSegment, keyToExecutableEnum);

                foreach (var path in paths)
                {
                    searchPaths.Add(path);
                }
            }

            searchPaths = X86Method(searchPaths).ToList();

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

        private static IEnumerable<string> GetMultipleVersionPaths(string executableFileToBrowseFor, InitialFolderType initialFolderType, string secondaryFilePathSegment, KeyToExecutableEnum keyToExecutableEnum)//gregtt write unit test for this method
        {
            var result = new List<string>();

            var dto = GetVersionNumberRange(keyToExecutableEnum);

            for (int i = dto.StartVersionNumber; i > dto.EndVersionNumber; i = i - dto.DecrementValue)
            {
                var segment = secondaryFilePathSegment.Replace("9999", i.ToString());//gregtt dedupe
                var path = GetPath(executableFileToBrowseFor, initialFolderType, segment);
                result.Add(path);
            }

            if (keyToExecutableEnum == KeyToExecutableEnum.SQLServerManagementStudio)
            {
                var ssmsAdditionalPaths = GetSsmsAdditionalPaths("ssms.exe", initialFolderType);
                result.AddRange(ssmsAdditionalPaths);
                var ssmseeAdditionalPaths = GetSsmsAdditionalPaths("ssmsee.exe", initialFolderType);
                result.AddRange(ssmseeAdditionalPaths);
            }

            return result;
        }

        private static IEnumerable<string> GetSsmsAdditionalPaths(string executableFileToBrowseFor, InitialFolderType initialFolderType)//gregtt write unit test for this method
        {
            var secondaryFilePathSegment = @"Microsoft SQL Server\9999\Tools\Binn\VSShell\Common7\IDE";
            var result = new List<string>();

            for (int i = 110; i > 20; i = i - 10)
            {
                var segment = secondaryFilePathSegment.Replace("9999", i.ToString());//gregtt dedupe
                var path = GetPath(executableFileToBrowseFor, initialFolderType, segment);
                result.Add(path);
            }

            return result;
        }

        private static VersionNumberRangeDto GetVersionNumberRange(KeyToExecutableEnum keyToExecutableEnum)//gregtt write unit test for this method
        {
            var result = new VersionNumberRangeDto();

            switch (keyToExecutableEnum)
            {
                case KeyToExecutableEnum.AltovaXMLSpy:
                    result.DecrementValue = 1;
                    result.EndVersionNumber = 1995;
                    result.StartVersionNumber = 2020;
                    break;
                case KeyToExecutableEnum.SQLServerManagementStudio:
                    result.DecrementValue = 10;
                    result.EndVersionNumber = 80;
                    result.StartVersionNumber = 170;
                    break;
                default:
                    result.DecrementValue = int.MinValue;
                    result.EndVersionNumber = int.MinValue;
                    result.StartVersionNumber = int.MinValue;
                    break;
            }

            return result;
        }
    }
}
