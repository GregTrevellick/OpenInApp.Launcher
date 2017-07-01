using EnvDTE;
using EnvDTE80;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenInApp.Common.Helpers
{
    public class CommonFileHelper
    {
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
                result.Add(SelectedItemHelper.GetFolderSelectedFullPath(selectedItem));
            }

            return result;
        }

        private static IEnumerable<string> SetArtefactNamesToBeOpened_FolderNode_ProjNode(DTE2 dte, string typicalFileExtensions, bool? openIndividualFilesInFolderRatherThanFolderItself, CommandPlacement commandPlacement)
        {
            List<string> result;

            // Open selected individual file(s) OR all individual files within a selected folder OR all individual files within a selected project's folder
            // i.e. Paint.Net etc 
            if (openIndividualFilesInFolderRatherThanFolderItself.HasValue && openIndividualFilesInFolderRatherThanFolderItself.Value)
            {
                var fileFullPathNamesOfCorrectSuffix = GetFileFullPathNamesOfCorrectSuffix(dte, typicalFileExtensions).ToList();
                result = AddArtefactsToList(fileFullPathNamesOfCorrectSuffix).ToList();
            }
            // Open selected individual file(s) folders OR the selected folder OR the selected project's folder
            // i.e. WinDirStat etc
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
                var folderFullPath = SelectedItemHelper.GetFolderSelectedFullPath(selectedItem);
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
      
        private static IEnumerable<string> GetFileFullPathNamesOfCorrectSuffixInFolder(string folderSelectedFullPath, string typicalFileExtensions)//gregtt unit test required
        {
            var fileFullPathNamesOfCorrectSuffix = new List<string>();

            var typicalFileExtensionAsList = CsvHelper.GetTypicalFileExtensionAsList(typicalFileExtensions);

            var filesInFolderFullPathNames = Directory.GetFiles(folderSelectedFullPath, "*.*", SearchOption.AllDirectories);

            foreach (var fileInFolderFullPathName in filesInFolderFullPathNames)
            {
                var isTypicalFileExtension = CsvHelper.AreTypicalFileExtensions(new List<string> { fileInFolderFullPathName }, typicalFileExtensionAsList);
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

        private static bool DoArtefactsExist(IEnumerable<string> fullArtefactNames, CommandPlacement commandPlacement, IArtefactsHelper artefactsHelper)
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
            
            return artefactsHelper.DoArtefactsExist(fullArtefactNames, artefactTypeToOpen);
        }
    }
}
