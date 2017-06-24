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
        /// <param name="dte">The DTE.</param>
        /// <param name="isFromSolutionExplorer">gregt Differentiator for solution explorer versus code editor window.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetArtefactNamesToBeOpened(DTE2 dte, CommandPlacement commandPlacement)
        {
            var artefactNamesToBeOpened = new List<string>();

            //////////////////////////////if (commandPlacement == CommandPlacement.IDM_VS_CTXT_FOLDERNODE ||
            //////////////////////////////    commandPlacement == CommandPlacement.IDM_VS_CTXT_ITEMNODE ||
            //////////////////////////////    commandPlacement == CommandPlacement.IDM_VS_CTXT_PROJNODE)
            //////////////////////////////{
            //////////////////////////////    var selectedItems = dte.SelectedItems;
            //////////////////////////////    foreach (SelectedItem selectedItem in selectedItems)
            //////////////////////////////    {
            //////////////////////////////        try
            //////////////////////////////        {
            //////////////////////////////            selectedItem.ProjectItem.Save();
            //////////////////////////////        }
            //////////////////////////////        catch (Exception)
            //////////////////////////////        {
            //////////////////////////////            // ignored - or log as save failed to output window ? gregtt
            //////////////////////////////        }
            //////////////////////////////        artefactNamesToBeOpened.Add(selectedItem.ProjectItem.FileNames[0]);
            //////////////////////////////    }
            //////////////////////////////}
            //////////////////////////////else //CODEWIN
            //////////////////////////////{
            //////////////////////////////    dte.ActiveDocument.Save();
            //////////////////////////////    artefactNamesToBeOpened.Add(dte.ActiveDocument.FullName);
            //////////////////////////////}

            switch (commandPlacement)
            {
                case CommandPlacement.IDM_VS_CTXT_CODEWIN:
                    SaveArtefactsAndAddToList_CodeWin(dte, artefactNamesToBeOpened);
                    break;
                case CommandPlacement.IDM_VS_CTXT_FOLDERNODE:
                    SaveArtefactsAndAddToList_FolderNode(dte, artefactNamesToBeOpened);
                    break;
                case CommandPlacement.IDM_VS_CTXT_ITEMNODE:
                    SaveArtefactsAndAddToList_ItemNode(dte, artefactNamesToBeOpened);
                    break;
                case CommandPlacement.IDM_VS_CTXT_PROJNODE:
                    SaveArtefactsAndAddToList_ProjNode(dte, artefactNamesToBeOpened);
                    break;
                default:
                    // ignore ? log as a failed save (to the output window) ? gregtt
                    break;
            }

            return artefactNamesToBeOpened;
        }

        private static void SaveArtefactsAndAddToList_CodeWin(DTE2 dte, IEnumerable<string> artefactNamesToBeOpened)
        {
            dte.ActiveDocument.Save();
            ///////////////////////////////artefactNamesToBeOpened.Add(dte.ActiveDocument.FullName);
            AddArtefactToArtefactNamesToBeOpened(artefactNamesToBeOpened, dte.ActiveDocument.FullName);
        }

        private static void SaveArtefactsAndAddToList_FolderNode(DTE2 dte, IEnumerable<string> artefactNamesToBeOpened)
        {
            SaveArtefactsAndAddToList(dte, artefactNamesToBeOpened);
        }

        private static void SaveArtefactsAndAddToList_ItemNode(DTE2 dte, IEnumerable<string> artefactNamesToBeOpened)
        {
            SaveArtefactsAndAddToList(dte, artefactNamesToBeOpened);
        }

        private static void SaveArtefactsAndAddToList_ProjNode(DTE2 dte, IEnumerable<string> artefactNamesToBeOpened)
        {
            SaveArtefactsAndAddToList(dte, artefactNamesToBeOpened);
        }

        private static void SaveArtefactsAndAddToList(DTE2 dte, IEnumerable<string> artefactNamesToBeOpened)
        {
            var selectedItems = dte.SelectedItems;

            foreach (SelectedItem selectedItem in selectedItems)
            {
                try
                {
                    selectedItem.ProjectItem.Save();
                }
                catch (Exception)
                {
                    // ignore ? log as a failed save (to the output window) ? gregtt
                }
                /////////////////////////////artefactNamesToBeOpened.Add(selectedItem.ProjectItem.FileNames[0]);
                AddArtefactToArtefactNamesToBeOpened(artefactNamesToBeOpened, selectedItem.ProjectItem.FileNames[0]);
            }
        }

        private static void AddArtefactToArtefactNamesToBeOpened(IEnumerable<string> artefactNamesToBeOpened, string artefactToAdd)
        {
            artefactNamesToBeOpened.Add(artefactToAdd);
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
        /// <returns></returns>
        public static bool DoesArtefactExist(string fullArtefactName, CommandPlacement commandPlacement)
        {
            return DoArtefactsExist(new List<string> { fullArtefactName }, commandPlacement);
        }

        /// <summary>
        /// Checks if all specified artefacts exists on disc.
        /// </summary>
        /// <param name="fullArtefactNames">The full artefact names.</param>
        /// <returns></returns>
        public static bool DoArtefactsExist(IEnumerable<string> fullArtefactNames, CommandPlacement commandPlacement)
        {
            ArtefactTypeToOpen artefactTypeToOpen = ArtefactTypeToOpen.File;

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
