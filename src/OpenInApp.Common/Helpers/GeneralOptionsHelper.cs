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
            var searchPaths = GetSearchPathsForThirdPartyExe(keyToExecutableEnum);////////////////////////////////////////////////var searchPaths = GetSearchPaths(keyToExecutableEnum);

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
            ////////////////////////////////////////////////var executableFileToBrowseFor = actualPathToExeHelper.GetExecutableFileToBrowseFor(keyToExecutableEnum);
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

                //foreach special folder, merge in the secondaryFilePathSegment (if exists) + 3rd party exe name
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

        ////////////////////////////////////////internal static IEnumerable<string> GetMultipleVersionPaths(string executableFileToBrowseFor, InitialFolderType initialFolderType, string secondaryFilePathSegment, KeyToExecutableEnum keyToExecutableEnum)//gregtt write unit test for this method
        private static IEnumerable<string> GetMultipleVersionPaths(IEnumerable<string> searchPaths, KeyToExecutableEnum keyToExecutableEnum)
        {
            var searchPathVersions = new List<string>();

            var dto = GetVersionNumberRange(keyToExecutableEnum);

            for (int i = dto.StartVersionNumber; i > dto.EndVersionNumber; i = i - dto.DecrementValue)
            {
                //////////////var segment = secondaryFilePathSegment.Replace("9999", i.ToString());
                //////////////var path = GetPath(executableFileToBrowseFor, initialFolderType, segment);
                //////////////result.Add(path);
                foreach (var searchPath in searchPaths)
                {
                    var searchPathVersioned = searchPath.Replace("9999", i.ToString());
                    searchPathVersions.Add(searchPathVersioned);
                }
            }

            //////////////////if (keyToExecutableEnum == KeyToExecutableEnum.SQLServerManagementStudio)
            //////////////////{
            //////////////////    var additionalPaths = GetSsmsAdditionalPaths("ssms.exe", initialFolderType);
            //////////////////    result.AddRange(additionalPaths);
            //////////////////    additionalPaths = GetSsmsAdditionalPaths("ssmsee.exe", initialFolderType);
            //////////////////    result.AddRange(additionalPaths);
            //////////////////    additionalPaths = GetSsmsAdditionalPaths("SqlWb.exe", initialFolderType);
            //////////////////    result.AddRange(additionalPaths);
            //////////////////}

            return searchPathVersions;
        }

        //private static IEnumerable<string> GetSsmsAdditionalPaths(string executableFileToBrowseFor, InitialFolderType initialFolderType)//gregtt write unit test for this method
        //{
        //    var secondaryFilePathSegment = @"Microsoft SQL Server\9999\Tools\Binn\VSShell\Common7\IDE";
        //    var result = new List<string>();

        //    for (int i = 110; i > 20; i = i - 10)
        //    {
        //        var segment = secondaryFilePathSegment.Replace("9999", i.ToString());//gregtt dedupe
        //        var path = GetPath(executableFileToBrowseFor, initialFolderType, segment);
        //        result.Add(path);
        //    }

        //    return result;
        //}

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

        //////////////////////////////private static IEnumerable<string> X86Method(IEnumerable<string> searchPaths)//gregtt unit test this
        //////////////////////////////{
        //////////////////////////////    var result = new List<string>();

        //////////////////////////////    var x86 = " (x86)";

        //////////////////////////////    foreach (var path in searchPaths)
        //////////////////////////////    {
        //////////////////////////////        result.Add(path);
        //////////////////////////////        if (path != null && path.Contains(x86))
        //////////////////////////////        {
        //////////////////////////////            var pathWithoutx86 = path.Replace(x86, string.Empty);
        //////////////////////////////            result.Add(pathWithoutx86);
        //////////////////////////////        }
        //////////////////////////////    }

        //////////////////////////////    return result;
        //////////////////////////////}

        //////////////////////////////internal static IEnumerable<string> GetSearchPaths(KeyToExecutableEnum keyToExecutableEnum)
        //////////////////////////////{
        //////////////////////////////    var searchPaths = new List<string>();
        //////////////////////////////    var actualPathToExeHelper = new ApplicationToOpenHelper();
        //////////////////////////////    var applicationToOpenDto = actualPathToExeHelper.GetApplicationToOpenDto(keyToExecutableEnum);
        //////////////////////////////    var pathPrimary = GetPath(applicationToOpenDto.ExecutableFileToBrowseFor, applicationToOpenDto.InitialFolderType, applicationToOpenDto.SecondaryFilePathSegment);
        //////////////////////////////    searchPaths.Add(pathPrimary);
        //////////////////////////////    if (applicationToOpenDto.SecondaryFilePathSegmentHasMultipleVersions)
        //////////////////////////////    {
        //////////////////////////////        var paths = GetMultipleVersionPaths(applicationToOpenDto.ExecutableFileToBrowseFor, applicationToOpenDto.InitialFolderType, applicationToOpenDto.SecondaryFilePathSegment, keyToExecutableEnum);

        //////////////////////////////        foreach (var path in paths)
        //////////////////////////////        {
        //////////////////////////////            searchPaths.Add(path);
        //////////////////////////////        }
        //////////////////////////////    }
        //////////////////////////////    searchPaths = X86Method(searchPaths).ToList();
        //////////////////////////////    return searchPaths;
        //////////////////////////////}
    }
}
