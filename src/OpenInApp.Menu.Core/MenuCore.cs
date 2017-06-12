using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenInApp.Menu.Core
{
    public class MenuCore
    {
        public OpenInAppCommand(Package package)
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
                    AddMenuCommand(commandService, PackageIds.CmdIdOpenInAppFolderExplore, CommandPlacement.IDM_VS_CTXT_ITEMNODE);
                    AddMenuCommand(commandService, PackageIds.CmdIdOpenInAppCodeWin, CommandPlacement.IDM_VS_CTXT_CODEWIN);
                    //Comment out to exclude folders / un-comment to include folders 
                    //AddMenuCommand(commandService, PackageIds.CmdIdOpenInAppFolderNode, CommandPlacement.IDM_VS_CTXT_FOLDERNODE);
                }
            }
        }

        private void AddMenuCommand(OleMenuCommandService commandService, int packageId, CommandPlacement commandPlacement)
        {
            var menuCommandID = new CommandID(CommandSet, packageId);

            MenuCommand menuCommand;

            switch (commandPlacement)
            {
                case CommandPlacement.IDM_VS_CTXT_CODEWIN:
                    menuCommand = new MenuCommand(MenuItemCallback_CodeWin, menuCommandID);
                    break;
                case CommandPlacement.IDM_VS_CTXT_ITEMNODE:
                    menuCommand = new MenuCommand(MenuItemCallback_FolderExplore, menuCommandID);
                    break;
                case CommandPlacement.IDM_VS_CTXT_FOLDERNODE:
                    menuCommand = new MenuCommand(MenuItemCallback_FolderNode, menuCommandID);
                    break;
                default:
                    Logger.Log(new ArgumentException("Invalid menuCommandType=" + commandPlacement));
                    menuCommand = null;
                    break;
            }

            commandService.AddCommand(menuCommand);
        }

        private void MenuItemCallback_FolderExplore(object sender, EventArgs e)
        {
            MenuItemCallback(CommandPlacement.IDM_VS_CTXT_ITEMNODE);
        }

        private void MenuItemCallback_CodeWin(object sender, EventArgs e)
        {
            MenuItemCallback(CommandPlacement.IDM_VS_CTXT_CODEWIN);
        }

        private void MenuItemCallback_FolderNode(object sender, EventArgs e)
        {
            MenuItemCallback(CommandPlacement.IDM_VS_CTXT_FOLDERNODE);
        }

        private void MenuItemCallback(CommandPlacement commandPlacement)
        {
            var menuItemCallBackHelper = new MenuItemCallBackHelper();

            var keyToExecutableEnum = GeneralOptions.keyToExecutableEnum;

            var applicationToOpenDto = new ApplicationToOpenHelper().GetApplicationToOpenDto(keyToExecutableEnum);

            var invokeCommandCallBackDto = constantsForAppCommon.GetInvokeCommandCallBackDto(
                VSPackage.Options.ActualPathToExe,
                VSPackage.Options.FileQuantityWarningLimit,
                commandPlacement,
                ServiceProvider,
                VSPackage.Options.SuppressTypicalFileExtensionsWarning,
                VSPackage.Options.TypicalFileExtensions,
                constantsForAppCommon.Caption,
                applicationToOpenDto,
                GeneralOptions.keyToExecutableEnum.Description());

            var persistOptionsDto = menuItemCallBackHelper.InvokeCommandCallBack(invokeCommandCallBackDto);

            if (persistOptionsDto.Persist)
            {
                VSPackage.Options.PersistVSToolOptions(persistOptionsDto.ValueToPersist);
            }
        }
    }
}
