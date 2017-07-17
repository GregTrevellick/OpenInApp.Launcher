﻿using EnvDTE;
using EnvDTE80;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenInApp.Common.Helpers
{
    public class ArtefactsToOpenHelper
    {
        public static ArtefactsToBeOpened GetArtefactsToBeOpened(DTE2 dte, string typicalFileExtensions, CommandPlacement commandPlacement, KeyToExecutableEnum keyToExecutableEnum)
        {
            var allowedFileExtensions = CsvHelper.GetTypicalFileExtensionAsList(typicalFileExtensions);

            var result = new ArtefactsToBeOpened
            {
                FilesToBeOpened = new List<string>(),
                FoldersToBeOpened = new List<string>()
            };

            bool itemsNotFolder = ItemsNotFolder(keyToExecutableEnum);

            switch (commandPlacement)
            {
                case CommandPlacement.IDM_VS_CTXT_CODEWIN:
                    var fileName = GetActiveDocumentArtefactName(dte);
                    result.FilesToBeOpened.Add(fileName);
                    break;
                case CommandPlacement.IDM_VS_CTXT_FOLDERNODE:
                    if (itemsNotFolder)
                    {
                        result.FilesToBeOpened = GetFolderItems(dte);
                        result.FilesToBeOpened = RemoveDisallowedSuffixes(result.FilesToBeOpened, allowedFileExtensions);
                    }
                    else
                    {
                        result.FoldersToBeOpened = GetFolderName(dte);
                    }
                    break;
                case CommandPlacement.IDM_VS_CTXT_ITEMNODE:
                    if (itemsNotFolder)
                    {
                        result.FilesToBeOpened = GetItems(dte);
                    }
                    else
                    {
                        result.FoldersToBeOpened = GetItemFolderName(dte);
                    }
                    break;
                case CommandPlacement.IDM_VS_CTXT_PROJNODE:
                    if (itemsNotFolder)
                    { 
                        result.FilesToBeOpened = GetProjectFolderItems(dte);
                        result.FilesToBeOpened = RemoveDisallowedSuffixes(result.FilesToBeOpened, allowedFileExtensions);
                        if (ExcludeBinAndObjFoldersWhenOpeningProjectNode(keyToExecutableEnum))
                        {
                            result.FilesToBeOpened = RemoveDisallowedFolders(result.FilesToBeOpened);
                        }
                    }
                    else
                    {
                        result.FoldersToBeOpened = GetProjectFolderName(dte);
                    }
                    break;
                default:
                    // TODO log as a failed save (to the output window) ? 
                    break;
            }

            result.FilesToBeOpened = result.FilesToBeOpened.Distinct().ToList();
            result.FoldersToBeOpened = result.FoldersToBeOpened.Distinct().ToList();

            return result;
        }

        private static string GetActiveDocumentArtefactName(DTE2 dte)
        {
            dte.ActiveDocument.Save();
            return dte.ActiveDocument.FullName;
        }

        private static IList<string> GetItems(DTE2 dte)
        {
            var result = new List<string>();
            foreach (SelectedItem selectedItem in dte.SelectedItems)
            {
                var itemName = selectedItem.ProjectItem.FileNames[0];
                result.Add(itemName);
            }
            return result;
        }

        private static IList<string> GetItemFolderName(DTE2 dte)
        {
            var result = new List<string>();
            foreach (SelectedItem selectedItem in dte.SelectedItems)
            {
                var itemName = selectedItem.ProjectItem.FileNames[0];
                var itemNameFolder = Path.GetDirectoryName(itemName);
                result.Add(itemNameFolder);
            }
            return result;
        }

        private static IList<string> GetFolderItems(DTE2 dte)
        {
            var result = new List<string>();
            foreach (SelectedItem selectedItem in dte.SelectedItems)
            {
                var folderName = selectedItem.ProjectItem.FileNames[0];
                var itemsInFolder = Directory.GetFiles(folderName, "*.*", SearchOption.AllDirectories);
                foreach (var item in itemsInFolder)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private static IList<string> GetProjectFolderItems(DTE2 dte)
        {
            var result = new List<string>();
            foreach (SelectedItem selectedItem in dte.SelectedItems)
            {
                var projectFileName = selectedItem.Project.FileName;
                var projectFolder = Path.GetDirectoryName(projectFileName);
                var itemsInProjectFolder = Directory.GetFiles(projectFolder, "*.*", SearchOption.AllDirectories);
                foreach (var item in itemsInProjectFolder)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private static IList<string> GetFolderName(DTE2 dte)
        {
            var result = new List<string>();
            foreach (SelectedItem selectedItem in dte.SelectedItems)
            {
                var folderName = selectedItem.ProjectItem.FileNames[0];
                result.Add(folderName);
            }
            return result;
        }

        private static IList<string> GetProjectFolderName(DTE2 dte)
        {
            var result = new List<string>();
            foreach (SelectedItem selectedItem in dte.SelectedItems)
            {
                var projectFileName = selectedItem.Project.FileName;
                var projectFolder = Path.GetDirectoryName(projectFileName);
                result.Add(projectFolder);
            }
            return result;
        }

        private static bool ItemsNotFolder(KeyToExecutableEnum keyToExecutableEnum)
        {
            bool itemsNotFolder = true;
            var applicationToOpenHelper = new ApplicationToOpenHelper();
            var openIndividualFilesInFolderRatherThanFolderItself = applicationToOpenHelper.GetOpenIndividualFilesInFolderRatherThanFolderItself(keyToExecutableEnum);
            itemsNotFolder = 
                (
                    (!openIndividualFilesInFolderRatherThanFolderItself.HasValue) ||
                    (openIndividualFilesInFolderRatherThanFolderItself.HasValue && openIndividualFilesInFolderRatherThanFolderItself.Value)
                );
            return itemsNotFolder;
        }

        private static bool ExcludeBinAndObjFoldersWhenOpeningProjectNode(KeyToExecutableEnum keyToExecutableEnum)
        {
            var applicationToOpenHelper = new ApplicationToOpenHelper();
            var excludeBinAndObjFoldersWhenOpeningProjectNode = applicationToOpenHelper.GetExcludeBinAndObjFoldersWhenOpeningProjectNode(keyToExecutableEnum);
            return excludeBinAndObjFoldersWhenOpeningProjectNode;
        }

        private static IList<string> RemoveDisallowedSuffixes(IList<string> filesToBeOpened, IEnumerable<string> allowedFileExtensions)
        {
            var result = filesToBeOpened.ToList();

            if (filesToBeOpened != null &&
                filesToBeOpened.Any() &&
                allowedFileExtensions != null &&
                allowedFileExtensions.Any() &&
                allowedFileExtensions.First() != "*")
            {
                var allowedFileExtensionsUpper = new List<string>();
                foreach (var allowedFileExtension in allowedFileExtensions)
                {
                    allowedFileExtensionsUpper.Add(allowedFileExtension.ToUpper());
                }

                foreach (var file in filesToBeOpened)
                {
                    var extension = Path.GetExtension(file);
                    if (!allowedFileExtensionsUpper.Contains(extension.ToUpper().Replace(".","")))
                    {
                        result.Remove(file);
                    }
                }
            }
            
            return result;
        }

        private static IList<string> RemoveDisallowedFolders(IList<string> filesToBeOpened)
        {
            var result = filesToBeOpened.ToList();

            if (filesToBeOpened != null &&
                filesToBeOpened.Any())
            {
                foreach (var file in filesToBeOpened)
                {
                    if (file.Contains("\\obj\\") ||
                        file.Contains("\\bin\\"))
                    {
                        result.Remove(file);
                    }
                }
            }

            return result;
        }

    }
}
