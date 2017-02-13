using System;
using System.IO;

namespace OpenInApp.Common.Helpers
{
    /// <summary>
    /// Helper class for Visual Studio | Tools | Options
    /// </summary>
    public class GeneralOptionsHelper
    {
        /// <summary>
        /// Returns path to specified executable file, within the the specified folder name, within Program Files directory.
        /// </summary>
        /// <param name="appFolderName">Name of the application folder.</param>
        /// <param name="executableFileToBrowseFor">The executable file to browse for.</param>
        /// <returns></returns>
        public static string GetActualPathToExe(string appFolderName, string executableFileToBrowseFor)
        {
            return GetActualPathToExe(appFolderName, null, executableFileToBrowseFor);
        }

        /// <summary>
        /// Returns path to specified executable file, within the the specified folder and sub-folder names, within Program Files directory.
        /// </summary>
        /// <param name="appFolderName">Name of the application folder.</param>
        /// <param name="appSubFolderName">Name of the application sub folder.</param>
        /// <param name="executableFileToBrowseFor">The executable file to browse for.</param>
        /// <returns></returns>
        public static string GetActualPathToExe(string appFolderName, string appSubFolderName, string executableFileToBrowseFor)
        {
            var programFiles = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            var programFilesFolders = programFiles.Parent.GetDirectories(programFiles.Name.Replace(" (x86)", string.Empty) + "*");

            foreach (DirectoryInfo programFilesFolder in programFilesFolders)
            {
                var appParentFolderPaths = programFilesFolder.GetDirectories(appFolderName);
                foreach (DirectoryInfo appParentFolderPath in appParentFolderPaths)
                {
                    if (string.IsNullOrEmpty(appSubFolderName))
                    {
                        var path = Path.Combine(appParentFolderPath.FullName, executableFileToBrowseFor);
                        if (File.Exists(path))
                        {
                            return path;
                        }
                    }
                    else
                    {
                        try
                        {
                            var appFolderPaths = appParentFolderPath.GetDirectories(appSubFolderName + "*");

                            foreach (DirectoryInfo appFolderPath in appFolderPaths)
                            {
                                var path = Path.Combine(appFolderPath.FullName, executableFileToBrowseFor);
                                if (File.Exists(path))
                                {
                                    return path;
                                }
                            }
                        }
                        catch (DirectoryNotFoundException)
                        {
                            return null;
                        }
                    }
                }
            }

            return null;
        }
    }
}
