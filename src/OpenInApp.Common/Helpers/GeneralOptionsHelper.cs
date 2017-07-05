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
            var searchPaths = GetSearchPathsForThirdPartyExe(keyToExecutableEnum);

            foreach (var searchPath in searchPaths)
            {
                if (File.Exists(searchPath))
                {
                    return searchPath;
                }
            }

            return null;
        }

        internal static IEnumerable<string> GetSearchPathsForThirdPartyExe(KeyToExecutableEnum keyToExecutableEnum)
        {
            var searchPaths  = new List<string>();
            var actualPathToExeHelper = new ApplicationToOpenHelper();

            var secondaryFilePathSegment = actualPathToExeHelper.GetSecondaryFilePathSegment(keyToExecutableEnum);
            var executableFilesToBrowseFor = actualPathToExeHelper.GetExecutableFilesToBrowseFor(keyToExecutableEnum);
            var secondaryFilePathSegmentHasMultipleVersions = actualPathToExeHelper.GetSecondaryFilePathSegmentHasMultipleVersions(keyToExecutableEnum);

            foreach (var executableFileToBrowseFor in executableFilesToBrowseFor)
            {
                var paths = GetSpecialFoldersPlusThirdPartyExePath(executableFileToBrowseFor, secondaryFilePathSegment).ToList();
                searchPaths.AddRange(paths);
            }
            
            searchPaths = DoubleUpForDDrive(searchPaths).ToList();

            if (secondaryFilePathSegmentHasMultipleVersions)
            {
                searchPaths = GetMultipleVersionPaths(searchPaths, keyToExecutableEnum).ToList();
            }

            var debuggingSortedList = searchPaths; debuggingSortedList.Sort();

            return searchPaths;
        }

        private static IList<string> GetSpecialFoldersPlusThirdPartyExePath(string executableFileToBrowseFor, string secondaryFilePathSegment)
        {
            var paths = new List<string>();

            if (!string.IsNullOrEmpty(executableFileToBrowseFor))
            {
                //set up array of the four special folders
                var initialFolders = new List<InitialFolderType>
                {
                    InitialFolderType.ProgramFilesX86,
                    InitialFolderType.LocalApplicationData,
                    InitialFolderType.Windows
                };
                var initialFolderPaths = new List<string>();
                foreach (var initialFolder in initialFolders)
                {
                    var specialFolder = (SpecialFolder)initialFolder;
                    var initialFolderPath = GetFolderPath(specialFolder);
                    initialFolderPaths.Add(initialFolderPath);
                    //if x86 add in the non-x86 too
                    if (initialFolder == InitialFolderType.ProgramFilesX86)
                    {
                        var x86 = " (x86)";
                        var initialFolderPathshWithoutx86 = initialFolderPath.Replace(x86, string.Empty);
                        initialFolderPaths.Add(initialFolderPathshWithoutx86);
                    }
                }

                foreach (var folderPath in initialFolderPaths)
                {
                    string path;
                    if (string.IsNullOrEmpty(secondaryFilePathSegment))
                    {
                        path = Path.Combine(folderPath, executableFileToBrowseFor);
                    }
                    else
                    {
                        path = Path.Combine(folderPath, secondaryFilePathSegment, executableFileToBrowseFor);
                    }
                    paths.Add(path);
                }
            }

            return paths;
        }

        private static IEnumerable<string> GetMultipleVersionPaths(IEnumerable<string> searchPaths, KeyToExecutableEnum keyToExecutableEnum)
        {
            var searchPathVersions = new List<string>();

            var dto = GetVersionNumberRange(keyToExecutableEnum);

            for (int i = dto.StartVersionNumber; i > dto.EndVersionNumber; i = i - dto.DecrementValue)
            {
                foreach (var searchPath in searchPaths)
                {
                    var searchPathVersioned = searchPath.Replace("9999", i.ToString());
                    searchPathVersions.Add(searchPathVersioned);
                }
            }

            return searchPathVersions;
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

        private static IEnumerable<string> DoubleUpForDDrive(IEnumerable<string> searchPaths)//gregtt unit test this
        {
            var dPaths = new List<string>();

            foreach (var path in searchPaths)
            {
                var dPath = path.Replace("C:", "D:");
                dPaths.Add(dPath);
            }

            var result = searchPaths.Union(dPaths);
            return result;
        }
    }
}
