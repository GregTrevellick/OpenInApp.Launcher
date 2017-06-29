using EnvDTE;
using EnvDTE80;
using OpenInApp.Common.Helpers.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenInApp.Common.Helpers
{
    /// <summary>
    /// Helper class containing generic file-related methods for 'OpenInApp' VS packages
    /// </summary>
    public class CommonFileHelper
    {
        private static IList<string> artefactNamesToBeOpened = new List<string>();//gregtt unused ???

        /// <summary>
        /// Prompts the user to browses for a file on disc and returns details.
        /// </summary>
        /// <param name="executableFileToBrowseFor">The executable file to browse for.</param>
        /// <returns></returns>
        public static FileBrowseOutcomeDto BrowseToFileLocation(string executableFileToBrowseFor)
        {
            var dialog = new OpenFileDialog
            {
                DefaultExt = ".exe",
                FileName = executableFileToBrowseFor,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                CheckFileExists = true
            };

            var dialogResult = dialog.ShowDialog();

            return new FileBrowseOutcomeDto
            {
                FileNameChosen = dialog.FileName,
                DialogResult = dialogResult
            };
        }

        /// <summary>
        /// Gets the selected files to be opened, as chosen in Solution Explorer.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetArtefactNamesToBeOpened(DTE2 dte, CommandPlacement commandPlacement, string typicalFileExtensions, KeyToExecutableEnum keyToExecutableEnum)
        {
            List<string> artefactNamesToBeOpened;

            var actualPathToExeHelper = new ApplicationToOpenHelper();
            var applicationToOpenDto = actualPathToExeHelper.GetApplicationToOpenDto(keyToExecutableEnum);
            bool? openIndividualFilesInFolderRatherThanFolderItself = applicationToOpenDto.OpenIndividualFilesInFolderRatherThanFolderItself;

            switch (commandPlacement)
            {
                case CommandPlacement.IDM_VS_CTXT_CODEWIN:
                    artefactNamesToBeOpened = SetArtefactNamesToBeOpened_CodeWin(dte).ToList();
                    break;
                case CommandPlacement.IDM_VS_CTXT_FOLDERNODE:
                    artefactNamesToBeOpened = SetArtefactNamesToBeOpened_FolderNode_ProjNode(dte, typicalFileExtensions, openIndividualFilesInFolderRatherThanFolderItself, commandPlacement).ToList();
                    break;
                case CommandPlacement.IDM_VS_CTXT_ITEMNODE:
                    artefactNamesToBeOpened = SetArtefactNamesToBeOpened_ItemNode(dte).ToList();
                    break;
                case CommandPlacement.IDM_VS_CTXT_PROJNODE:
                    artefactNamesToBeOpened = SetArtefactNamesToBeOpened_FolderNode_ProjNode(dte, typicalFileExtensions, openIndividualFilesInFolderRatherThanFolderItself, commandPlacement).ToList();
                    break;
                default:
                    artefactNamesToBeOpened = new List<string>();
                    // ignore ? log as a failed save (to the output window) ? gregtt
                    break;
            }

            return artefactNamesToBeOpened;
        }

        private static IEnumerable<string> SetArtefactNamesToBeOpened_CodeWin(DTE2 dte)
        {
            dte.ActiveDocument.Save();

            var result = new List<string>();
            result.Add(dte.ActiveDocument.FullName);

            return result;
        }

        private static IEnumerable<string> SetArtefactNamesToBeOpened_ItemNode(DTE2 dte)
        {
            var result = new List<string>();

            var selectedItems = dte.SelectedItems;

            foreach (SelectedItem selectedItem in selectedItems)
            {
                result.Add(GetFolderSelectedFullPath(selectedItem));
            }

            return result;
        }

        private static IEnumerable<string> SetArtefactNamesToBeOpened_FolderNode_ProjNode(DTE2 dte, string typicalFileExtensions, bool? openIndividualFilesInFolderRatherThanFolderItself, CommandPlacement commandPlacement)
        {
            List<string> result;

            //Paint.Net etc (e.g. open all image files within the folder or project folder)
            if (openIndividualFilesInFolderRatherThanFolderItself.HasValue && openIndividualFilesInFolderRatherThanFolderItself.Value)
            {
                var fileFullPathNamesOfCorrectSuffix = GetFileFullPathNamesOfCorrectSuffix(dte, typicalFileExtensions).ToList();
                result = AddArtefactsToList(fileFullPathNamesOfCorrectSuffix).ToList();
            }
            //WinDirStat etc (e.g. open the folder or project folder only within the target app)
            else
            {
                var projectFolderFullPaths = GetProjectFolderFullPathNames(dte).ToList();
                result = AddArtefactsToList(projectFolderFullPaths).ToList();
            }

            return result;
        }

        private static IEnumerable<string> GetFileFullPathNamesOfCorrectSuffix(DTE2 dte, string typicalFileExtensions) //gregtt unit test required
        {
            var fileFullPathNamesOfCorrectSuffix = new List<string>();

            foreach (SelectedItem selectedItem in dte.SelectedItems)
            {
                var folderFullPath = GetFolderSelectedFullPath(selectedItem);
                var filePathsOfCorrectSuffix = GetFileFullPathNamesOfCorrectSuffixInFolder(folderFullPath, typicalFileExtensions).ToList();
                fileFullPathNamesOfCorrectSuffix.AddRange(filePathsOfCorrectSuffix);
            }

            return fileFullPathNamesOfCorrectSuffix;
        }

        private static IEnumerable<string> GetProjectFolderFullPathNames(DTE2 dte) //gregtt unit test required
        {
            var projectFolderFullPaths = new List<string>();

            foreach (SelectedItem selectedItem in dte.SelectedItems)
            {
                var projectFileNameFullPath = selectedItem.Project.FileName;
                var projectFolderFullPath = Path.GetDirectoryName(projectFileNameFullPath);
                projectFolderFullPaths.Add(projectFolderFullPath);
            }

            return projectFolderFullPaths;
        }

        private static string GetFolderSelectedFullPath(SelectedItem selectedItem)
        {
            return selectedItem.ProjectItem.FileNames[0];
        }

        private static IEnumerable<string> GetFileFullPathNamesOfCorrectSuffixInFolder(string folderSelectedFullPath, string typicalFileExtensions)//gregtt unit test required
        {
            var fileFullPathNamesOfCorrectSuffix = new List<string>();

            var typicalFileExtensionAsList = GetTypicalFileExtensionAsList(typicalFileExtensions);

            var filesInFolderFullPathNames = Directory.GetFiles(folderSelectedFullPath, "*.*", SearchOption.AllDirectories);

            foreach (var fileInFolderFullPathName in filesInFolderFullPathNames)
            {
                var isTypicalFileExtension = AreTypicalFileExtensions(new List<string> { fileInFolderFullPathName }, typicalFileExtensionAsList);
                if (isTypicalFileExtension)
                {
                    fileFullPathNamesOfCorrectSuffix.Add(fileInFolderFullPathName);
                }
            }

            return fileFullPathNamesOfCorrectSuffix;
        }

        private static IEnumerable<string> AddArtefactsToList(IEnumerable<string> artefacts)//gregtt unit test required
        {
            var result = new List<string>();

            foreach (var artefact in artefacts)
            {
                result.Add(artefact);
            }

            return result;
        }

        private static IEnumerable<string> AddArtefactsToList(DTE2 dte)//gregtt never used ???
        {
            var selectedItems = dte.SelectedItems;

            var result = new List<string>();

            foreach (SelectedItem selectedItem in selectedItems)
            {
                result.Add(GetFolderSelectedFullPath(selectedItem));
            }

            return result;
        }

        /// <summary>
        /// Checks if a file extension(s) is a typical file extension for the app, as defined in Tools | Options.
        /// </summary>
        /// <param name="fullFileNames">The full file names.</param>
        /// <param name="typicalFileExtensions">The typical file extensions.</param>
        /// <returns></returns>
        public static bool AreTypicalFileExtensions(IEnumerable<string> fullFileNames, IEnumerable<string> typicalFileExtensions)
        {
            var result = false;

            if (typicalFileExtensions.First() == "*")
            {
                result = true;
            }
            else
            {
                var fileTypeExtensions = GetFileTypeExtensions(fullFileNames);

                foreach (var fileTypeExtension in fileTypeExtensions)
                {
                    if (!string.IsNullOrEmpty(fileTypeExtension))
                    {
                        result = typicalFileExtensions.Contains(fileTypeExtension.TrimStart('.'), StringComparer.CurrentCultureIgnoreCase);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets a collection of file type extensions, from a collection of file names.
        /// </summary>
        /// <param name="fullFileNames">The full file names.</param>
        /// <returns></returns>
        internal static IEnumerable<string> GetFileTypeExtensions(IEnumerable<string> fullFileNames)
        {
            var result = new List<string>();

            foreach (var fullFileName in fullFileNames)
            {
                result.Add(Path.GetExtension(fullFileName));
            }

            return result;
        }

        /// <summary>
        /// Gets the name of the first physically non-existant file, from a collection of file names.
        /// </summary>
        /// <param name="fullFileNames">The full file names.</param>
        /// <returns></returns>
        public static string GetMissingFileName(IEnumerable<string> fullFileNames)
        {
            var result = string.Empty;

            foreach (var fullFileName in fullFileNames)
            {
                if (!File.Exists(fullFileName))
                {
                    result = fullFileName;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the typical file extensions as a CSV string.
        /// </summary>
        /// <param name="defaultExts">The default exts.</param>
        /// <returns></returns>
        public static string GetDefaultTypicalFileExtensionsAsCsv(IEnumerable<string> defaultExts)
        {
            var stringBuilder = new StringBuilder();
            foreach (var defaultExt in defaultExts)
            {
                stringBuilder.Append(defaultExt).Append(',');
            }
            return stringBuilder.ToString().TrimEnd(',');
        }

        /// <summary>
        /// Gets the typical file extension as list, from a CSV string.
        /// </summary>
        /// <param name="typicalFileExtensionsAsCsv">The typical file extensions as CSV.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetTypicalFileExtensionAsList(string typicalFileExtensionsAsCsv)
        {
            return typicalFileExtensionsAsCsv.Split(',');
        }

        /// <summary>
        /// Checks if a specified artefact exists on disc.
        /// </summary>
        /// <param name="fullExecutableFileName">Full name of the artefact.</param>
        /// <returns></returns>
        public static bool DoesActualPathToExeExist(string fullExecutableFileName)
        {
            return DoArtefactsExist(new List<string> { fullExecutableFileName });
        }

        /// <summary>
        /// Checks if a specified artefact exists on disc.
        /// </summary>
        /// <param name="fullArtefactName">Full name of the artefact.</param>
        /// <param name="commandPlacement"></param>
        /// <returns></returns>
        public static bool DoesArtefactExist(string fullArtefactName, CommandPlacement commandPlacement)
        {
            return DoArtefactsExist(new List<string> { fullArtefactName }, commandPlacement);
        }

        /// <summary>
        /// Checks if all specified artefacts exists on disc.
        /// </summary>
        /// <param name="fullArtefactNames">The full artefact names.</param>
        /// /// <param name="commandPlacement"></param>
        /// <returns></returns>
        public static bool DoArtefactsExist(IEnumerable<string> fullArtefactNames, CommandPlacement commandPlacement)
        {
            ArtefactTypeToOpen artefactTypeToOpen;

            switch (commandPlacement)
            {
                case CommandPlacement.IDM_VS_CTXT_FOLDERNODE:
                case CommandPlacement.IDM_VS_CTXT_PROJNODE:
                    artefactTypeToOpen = ArtefactTypeToOpen.Folder;
                    break;
                case CommandPlacement.IDM_VS_CTXT_CODEWIN:
                case CommandPlacement.IDM_VS_CTXT_ITEMNODE:
                default:
                    artefactTypeToOpen = ArtefactTypeToOpen.File;
                    break;
            }

            return DoArtefactsExist(fullArtefactNames, artefactTypeToOpen);
        }

        public static bool DoArtefactsExist(IEnumerable<string> fullArtefactNames, CommandPlacement commandPlacement, ArtefactTypeToOpen artefactTypeToOpen)
        {
            if ((commandPlacement == CommandPlacement.IDM_VS_CTXT_FOLDERNODE ||
                 commandPlacement == CommandPlacement.IDM_VS_CTXT_PROJNODE) &&
                artefactTypeToOpen == ArtefactTypeToOpen.Folder)
            {
                artefactTypeToOpen = ArtefactTypeToOpen.Folder;
            }
            else
            {
                artefactTypeToOpen = ArtefactTypeToOpen.File;
            }

            return DoArtefactsExist(fullArtefactNames, artefactTypeToOpen);
        }

        /// <summary>
        /// Checks if all specified artefacts exists on disc.
        /// </summary>
        /// <param name="fullArtefactNames">The full artefact names.</param>
        /// <returns></returns>
        private static bool DoArtefactsExist(IEnumerable<string> fullArtefactNames, ArtefactTypeToOpen artefactTypeToOpen = ArtefactTypeToOpen.File)
        {
            var result = true;

            foreach (var fullArtefactName in fullArtefactNames)
            {
                if (string.IsNullOrEmpty(fullArtefactName))
                {
                    result = false;
                }
                else
                {
                    switch (artefactTypeToOpen)
                    {
                        case ArtefactTypeToOpen.File:
                            if (!File.Exists(fullArtefactName))
                            {
                                result = false;
                            }
                            break;
                        case ArtefactTypeToOpen.Folder:
                            if (!Directory.Exists(fullArtefactName))
                            {
                                result = false;
                            }
                            break;
                    }
                }
            }

            return result;
        }
    }
}
