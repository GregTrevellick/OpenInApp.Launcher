using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using OpenInApp.Common.Helpers;
using OpenInAppAltovaXmlSpy.Helpers;
using System;
using System.ComponentModel.Design;
using System.Linq;

namespace OpenInAppAltovaXmlSpy.Commands
{
    internal sealed class OpenInAppCommand
    {
        private string Caption { get { return new FileHelper().Caption; } }
        public readonly Guid CommandSet = new Guid(PackageGuids.guidOpenInVsCmdSetString);
        public OpenInAppCommand Instance { get; private set; }

        private readonly Package _package;
        private IServiceProvider ServiceProvider => _package;

        public OpenInAppCommand()
        {
        }

        public void Initialize(Package package)
        {
            Instance = new OpenInAppCommand(package);
        }

        private OpenInAppCommand(Package package)
        {
            Logger.Initialize(ServiceProvider, Caption);

            if (package == null)
            {
                Logger.Log(new ArgumentNullException(nameof(package)));
                OpenInAppHelper.ShowUnexpectedError(Caption);
            }
            else
            {
                _package = package;
                var commandService = ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;

                if (commandService != null)
                {
                    var menuCommandID = new CommandID(CommandSet, PackageIds.OpenInApp);
                    var menuItem = new MenuCommand(MenuItemCallback, menuCommandID);
                    commandService.AddCommand(menuItem);
                }
            }
        }

        private void MenuItemCallback(object sender, EventArgs e)
        {
            var dte = (DTE2)ServiceProvider.GetService(typeof(DTE));

            try
            {
                var actualPathToExeExists = CommonFileHelper.DoesFileExist(VSPackage.Options.ActualPathToExe);

                bool proceedToExecute = true;
                if (!actualPathToExeExists)
                {
                    proceedToExecute = false;
                    new FileHelper().PromptForActualExeFile(VSPackage.Options.ActualPathToExe);
                    var newActualPathToExeExists = CommonFileHelper.DoesFileExist(VSPackage.Options.ActualPathToExe);
                    if (newActualPathToExeExists)
                    {
                        proceedToExecute = true;
                    }
                    else
                    {
                        // User somehow managed to browse/select a new location for the exe that doesn't actually exist - virtually impossible, but you never know...
                        OpenInAppHelper.InformUserMissingFile(Caption, VSPackage.Options.ActualPathToExe);
                    }
                }
                if (proceedToExecute)
                {
                    var actualFilesToBeOpened = CommonFileHelper.GetFileNamesToBeOpened(dte);
                    var actualFilesToBeOpenedExist = CommonFileHelper.DoFilesExist(actualFilesToBeOpened);
                    if (!actualFilesToBeOpenedExist)
                    {
                        var missingFileName = CommonFileHelper.GetMissingFileName(actualFilesToBeOpened);
                        OpenInAppHelper.InformUserMissingFile(Caption, missingFileName);
                    }
                    else
                    {
                        var fileQuantityWarningLimitInt = VSPackage.Options.FileQuantityWarningLimitInt;
                        proceedToExecute = false;
                        if (actualFilesToBeOpened.Count() > fileQuantityWarningLimitInt)
                        {
                            proceedToExecute = OpenInAppHelper.ConfirmProceedToExecute(Caption, CommonConstants.ConfirmOpenFileQuantityExceedsWarningLimit);
                        }
                        else
                        {
                            proceedToExecute = true;
                        }
                        if (proceedToExecute)
                        {
                            var typicalFileExtensionAsList = CommonFileHelper.GetTypicalFileExtensionAsList(VSPackage.Options.TypicalFileExtensions);
                            var areTypicalFileExtensions = CommonFileHelper.AreTypicalFileExtensions(actualFilesToBeOpened, typicalFileExtensionAsList);
                            if (!areTypicalFileExtensions)
                            {
                                if (VSPackage.Options.SuppressTypicalFileExtensionsWarning)
                                {
                                    proceedToExecute = true;
                                }
                                else
                                {
                                    proceedToExecute = OpenInAppHelper.ConfirmProceedToExecute(Caption, CommonConstants.ConfirmOpenNonTypicalFile);
                                }
                            }
                            if (proceedToExecute)
                            {
                                OpenInAppHelper.InvokeCommand(actualFilesToBeOpened, VSPackage.Options.ActualPathToExe);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                OpenInAppHelper.ShowUnexpectedError(Caption);
            }
        }
    }
}