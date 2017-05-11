using OpenInApp.Common.Helpers.Dtos;
using System;
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
        //gregt to be deleted
        ///// <summary>
        ///// Returns path to specified executable file, within the the specified folder name, within Program Files directory.
        ///// </summary>
        ///// <param name="appFolderName">Name of the application folder.</param>
        ///// <param name="executableFileToBrowseFor">The executable file to browse for.</param>
        ///// <returns></returns>
        //public static string GetActualPathToExe(string appFolderName, string executableFileToBrowseFor)
        //{
        //    return GetActualPathToExe(appFolderName, null, executableFileToBrowseFor);
        //}


        /// <summary>
        /// Returns path to specified executable file, within the the specified folder and sub-folder names, within Program Files directory.
        /// </summary>
        /// <param name="appFolderName">Name of the application folder.</param>
        /// <param name="appSubFolderName">Name of the application sub folder.</param>
        /// <param name="executableFileToBrowseFor">The executable file to browse for.</param>
        /// <returns></returns>
        public static string GetActualPathToExe(ActualPathToExeDto actualPathToExeDto)
        {
            var specialFolder = (SpecialFolder)actualPathToExeDto.InitialFolderTypePrimary;
            var initialFolder = GetFolderPath(specialFolder);
            var path = Path.Combine(initialFolder, actualPathToExeDto.SecondaryFilePathSegment, actualPathToExeDto.ExecutableFileToBrowseFor);

            if (File.Exists(path))
            {
                return path;
            }
            else
            {
                //gregt dedupe here
                var specialFolder2 = (SpecialFolder)actualPathToExeDto.InitialFolderTypeSecondary;
                var initialFolder2 = GetFolderPath(specialFolder2);
                var path2 = Path.Combine(initialFolder2, actualPathToExeDto.SecondaryFilePathSegment, actualPathToExeDto.ExecutableFileToBrowseFor);
                if (File.Exists(path2))
                {
                    return path2;
                }
            }
            
            return null;
        }

        ////gregt to be deleted
        ///// <summary>
        ///// Returns path to specified executable file, within the the specified folder and sub-folder names, within Program Files directory.
        ///// </summary>
        ///// <param name="appFolderName">Name of the application folder.</param>
        ///// <param name="appSubFolderName">Name of the application sub folder.</param>
        ///// <param name="executableFileToBrowseFor">The executable file to browse for.</param>
        ///// <returns></returns>
        //public static string GetActualPathToExe(string appFolderName, string appSubFolderName, string executableFileToBrowseFor)
        //{
        //    var foldersToSearch = GetFoldersToSearch();

        //    foreach (DirectoryInfo folder in foldersToSearch)
        //    {
        //        var appParentFolderPaths = folder.GetDirectories(appFolderName);
        //        foreach (DirectoryInfo appParentFolderPath in appParentFolderPaths)
        //        {
        //            if (string.IsNullOrEmpty(appSubFolderName))
        //            {
        //                var path = Path.Combine(appParentFolderPath.FullName, executableFileToBrowseFor);
        //                if (File.Exists(path))
        //                {
        //                    return path;
        //                }
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    var appFolderPaths = appParentFolderPath.GetDirectories(appSubFolderName + "*");

        //                    foreach (DirectoryInfo appFolderPath in appFolderPaths)
        //                    {
        //                        var path = Path.Combine(appFolderPath.FullName, executableFileToBrowseFor);
        //                        if (File.Exists(path))
        //                        {
        //                            return path;
        //                        }
        //                    }
        //                }
        //                catch (DirectoryNotFoundException)
        //                {
        //                    return null;
        //                }
        //            }
        //        }
        //    }

        //    return null;
        //}


        ////gregt to be deleted
        //private static IEnumerable<DirectoryInfo> GetFoldersToSearch()
        //{
        //    var programFiles = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
        //    var programFilesFolders = programFiles.Parent.GetDirectories(programFiles.Name.Replace(" (x86)", string.Empty) + "*");

        //    var userAppData = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        //    var userAppDataFolders = userAppData.Parent.GetDirectories("*");

        //    var foldersToSearch = programFilesFolders.Union(userAppDataFolders);

        //    return foldersToSearch;
        //}
    }
}
