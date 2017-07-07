using EnvDTE;
using EnvDTE80;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenInApp.Command
{
    public class MenuItemCallBackHelper
    {
        public PersistOptionsDto InvokeCommandCallBack(InvokeCommandCallBackDto dto)
        {
            var dte = (DTE2)dto.ServiceProvider.GetService(typeof(DTE));
            var persistOptionsDto = new PersistOptionsDto();

            try
            {
                var actualPathToExeExists = ArtefactsHelper.DoesActualPathToExeExist(dto.ActualPathToExe);

                bool proceedToExecute = true;
                if (!actualPathToExeExists)
                {
                    proceedToExecute = false;
                    var fileHelper = new FilePrompterHelper(dto.Caption, dto.ExecutableFileToBrowseFor);
                    var badFilePath = dto.KeyToExecutableEnum.ToString();
                    persistOptionsDto = fileHelper.PromptForActualExeFile(badFilePath);

                    var newActualPathToExeExists = ArtefactsHelper.DoesActualPathToExeExist(dto.ActualPathToExe);
                    if (newActualPathToExeExists)
                    {
                        proceedToExecute = true;
                    }
                    else
                    {
                        // User somehow managed to browse/select a new location for the exe that doesn't actually exist - impossible you'd think, but can happen if path to exe not found, user prompted to browse, they click "yes" to open the file browse dialog, then click "cancel"
                        OpenInAppHelper.InformUserMissingFile(dto.Caption, badFilePath);
                    }
                }
                if (proceedToExecute)
                {
                    var actualArtefactsToBeOpened = ArtefactsToOpenHelper.GetArtefactsToBeOpened(dte, dto.TypicalFileExtensions, dto.CommandPlacement, dto.KeyToExecutableEnum);

                    var actualArtefactsToBeOpenedExistFiles = DoArtefactsExist(actualArtefactsToBeOpened.FilesToBeOpened, dto.CommandPlacement, ArtefactTypeToOpen.File);
                    var actualArtefactsToBeOpenedExistFolders = DoArtefactsExist(actualArtefactsToBeOpened.FoldersToBeOpened, dto.CommandPlacement, ArtefactTypeToOpen.Folder);

                    if (!actualArtefactsToBeOpenedExistFiles || !actualArtefactsToBeOpenedExistFolders)
                    {
                        var missingFileName = GetMissingFileName(actualArtefactsToBeOpened.FilesToBeOpened);
                        if (string.IsNullOrEmpty(missingFileName))
                        {
                            missingFileName = GetMissingFileName(actualArtefactsToBeOpened.FoldersToBeOpened);
                        }
                        OpenInAppHelper.InformUserMissingFile(dto.Caption, missingFileName);
                    }
                    else
                    {
                        int fileQuantityWarningLimitInt;
                        var isInt = int.TryParse(dto.FileQuantityWarningLimit, out fileQuantityWarningLimitInt);
                        if (isInt)
                        {
                            proceedToExecute = false;
                            var actualArtefactsToBeOpenedCount = actualArtefactsToBeOpened.FilesToBeOpened.Count + actualArtefactsToBeOpened.FoldersToBeOpened.Count;
                            if (actualArtefactsToBeOpenedCount > fileQuantityWarningLimitInt)
                            {
                                proceedToExecute = OpenInAppHelper.ConfirmProceedToExecute(dto.Caption, CommonConstants.ConfirmOpenFileQuantityExceedsWarningLimit);
                            }
                            else
                            {
                                proceedToExecute = true;
                            }
                            if (proceedToExecute)
                            {
                                var typicalFileExtensionAsList = CsvHelper.GetTypicalFileExtensionAsList(dto.TypicalFileExtensions);
                                var areTypicalFileExtensions = CsvHelper.AreTypicalFileExtensions(actualArtefactsToBeOpened.FilesToBeOpened, typicalFileExtensionAsList);
                                if (!areTypicalFileExtensions)
                                {
                                    if (dto.SuppressTypicalFileExtensionsWarning)
                                    {
                                        proceedToExecute = true;
                                    }
                                    else
                                    {
                                        proceedToExecute = OpenInAppHelper.ConfirmProceedToExecute(dto.Caption, CommonConstants.ConfirmOpenNonTypicalFile);
                                    }
                                }
                                if (proceedToExecute)
                                {
                                    var actualArtefacts = new List<string>();
                                    if (actualArtefactsToBeOpened.FilesToBeOpened != null && actualArtefactsToBeOpened.FilesToBeOpened.Any())
                                    {
                                        actualArtefacts = actualArtefactsToBeOpened.FilesToBeOpened.ToList();
                                    }
                                    else
                                    {
                                        if (actualArtefactsToBeOpened.FoldersToBeOpened != null && actualArtefactsToBeOpened.FoldersToBeOpened.Any())
                                        {
                                            actualArtefacts = actualArtefactsToBeOpened.FoldersToBeOpened.ToList();
                                        }
                                    }

                                    OpenInAppHelper.InvokeCommand(actualArtefacts, 
                                        dto.ActualPathToExe, 
                                        dto.SeparateProcessPerFileToBeOpened, 
                                        dto.UseShellExecute,
                                        dto.ArtefactTypeToOpen);
                                }
                            }
                        }
                        else
                        {
                            Logger.Log(dto.Caption + " unexpected non-integer value found.");
                            OpenInAppHelper.ShowUnexpectedError(dto.Caption);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                OpenInAppHelper.ShowUnexpectedError(dto.Caption);
            }

            return persistOptionsDto;
        }

        private static bool DoArtefactsExist(IEnumerable<string> fullArtefactNames, CommandPlacement commandPlacement, ArtefactTypeToOpen artefactTypeToOpen)
        {
            if (artefactTypeToOpen == ArtefactTypeToOpen.Folder)
            {
                artefactTypeToOpen = ArtefactTypeToOpen.Folder;
            }
            else
            {
                artefactTypeToOpen = ArtefactTypeToOpen.File;
            }

            return ArtefactsHelper.DoArtefactsExist(fullArtefactNames, artefactTypeToOpen);
        }

        /// <summary>
        /// Gets the name of the first physically non-existant file, from a collection of file names.
        /// </summary>
        /// <param name="fullFileNames">The full file names.</param>
        /// <returns></returns>
        private static string GetMissingFileName(IEnumerable<string> fullFileNames)
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
    }
}