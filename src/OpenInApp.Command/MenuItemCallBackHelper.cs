using EnvDTE;
using EnvDTE80;
using OpenInApp.Common.Helpers;
using System;
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
                var actualPathToExeExists = CommonFileHelper.DoesFileExist(dto.ActualPathToExe);

                bool proceedToExecute = true;
                if (!actualPathToExeExists)
                {
                    proceedToExecute = false;
                    var fileHelper = new FilePrompterHelper(dto.Caption, dto.ExecutableFileToBrowseFor);
                    persistOptionsDto = fileHelper.PromptForActualExeFile(dto.ActualPathToExe);

                    var newActualPathToExeExists = CommonFileHelper.DoesFileExist(dto.ActualPathToExe);
                    if (newActualPathToExeExists)
                    {
                        proceedToExecute = true;
                    }
                    else
                    {
                        // User somehow managed to browse/select a new location for the exe that doesn't actually exist - virtually impossible, but you never know...
                        OpenInAppHelper.InformUserMissingFile(dto.Caption, dto.ActualPathToExe);
                    }
                }
                if (proceedToExecute)
                {
                    var actualFilesToBeOpened = CommonFileHelper.GetFileNamesToBeOpened(dte, dto.IsFromSolutionExplorer);
                    var actualFilesToBeOpenedExist = CommonFileHelper.DoFilesExist(actualFilesToBeOpened);
                    if (!actualFilesToBeOpenedExist)
                    {
                        var missingFileName = CommonFileHelper.GetMissingFileName(actualFilesToBeOpened);
                        OpenInAppHelper.InformUserMissingFile(dto.Caption, missingFileName);
                    }
                    else
                    {
                        int fileQuantityWarningLimitInt;
                        var isInt = int.TryParse(dto.FileQuantityWarningLimit, out fileQuantityWarningLimitInt);
                        if (isInt)
                        {
                            proceedToExecute = false;
                            if (actualFilesToBeOpened.Count() > fileQuantityWarningLimitInt)
                            {
                                proceedToExecute = OpenInAppHelper.ConfirmProceedToExecute(dto.Caption, CommonConstants.ConfirmOpenFileQuantityExceedsWarningLimit);
                            }
                            else
                            {
                                proceedToExecute = true;
                            }
                            if (proceedToExecute)
                            {
                                var typicalFileExtensionAsList = CommonFileHelper.GetTypicalFileExtensionAsList(dto.TypicalFileExtensions);
                                var areTypicalFileExtensions = CommonFileHelper.AreTypicalFileExtensions(actualFilesToBeOpened, typicalFileExtensionAsList);
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
                                    /* gregtgregt delete this comment
                                     * true for sublime text, vs code, etc
                                     * false for devenv.exe */
                                    OpenInAppHelper.InvokeCommand(actualFilesToBeOpened, dto.ActualPathToExe, true);
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
    }
}