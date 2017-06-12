using Microsoft.VisualStudio.Shell;
using OpenInApp.Command;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System;
using System.ComponentModel.Design;

namespace OpenInApp.Menu.Core
{
    public class MenuCore
    {
        private string Caption { get { return constantsForAppCommon.Caption; } }
        public readonly Guid CommandSet;
        public OpenInAppCommand Instance { get; private set; }

        private readonly Package _package;
        private IServiceProvider ServiceProvider => _package;
        private ConstantsForAppCommon constantsForAppCommon;
        private string _vsixName;
        private string _vsixVersion;
        private int _packageIdsDotCmdIdOpenInAppFolderExplore;
        private int _packageIdsDotCmdIdOpenInAppCodeWin;
        private int _packageIdsDotCmdIdOpenInAppFolderNode;
        private KeyToExecutableEnum _keyToExecutableEnum;

        //ctor
        public MenuCore
            (
                string vsixName, string vsixVersion, 
                string packageGuidsDotGuidOpenInVsCmdSetString,
                int packageIdsDotCmdIdOpenInAppFolderExplore, int packageIdsDotCmdIdOpenInAppCodeWin, int packageIdsDotCmdIdOpenInAppFolderNode,
                KeyToExecutableEnum keyToExecutableEnum
            )
        {
            _vsixName = vsixName;
            _vsixVersion = vsixVersion;
            constantsForAppCommon = new ConstantsForAppCommon(_vsixName, _vsixVersion);
            CommandSet = new Guid(packageGuidsDotGuidOpenInVsCmdSetString);
            _packageIdsDotCmdIdOpenInAppFolderExplore = packageIdsDotCmdIdOpenInAppFolderExplore;
            _packageIdsDotCmdIdOpenInAppCodeWin = packageIdsDotCmdIdOpenInAppCodeWin;
            _packageIdsDotCmdIdOpenInAppFolderNode = packageIdsDotCmdIdOpenInAppFolderNode;
            _keyToExecutableEnum = keyToExecutableEnum;
        }

        private void OpenInAppCommand(Package package)
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
                    AddMenuCommand(commandService, _packageIdsDotCmdIdOpenInAppFolderExplore, CommandPlacement.IDM_VS_CTXT_ITEMNODE);
                    AddMenuCommand(commandService, _packageIdsDotCmdIdOpenInAppCodeWin, CommandPlacement.IDM_VS_CTXT_CODEWIN);
                    //Comment out to exclude folders / un-comment to include folders 
                    AddMenuCommand(commandService, _packageIdsDotCmdIdOpenInAppFolderNode, CommandPlacement.IDM_VS_CTXT_FOLDERNODE);
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

            var keyToExecutableEnum = _keyToExecutableEnum;

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
