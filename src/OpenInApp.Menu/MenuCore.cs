using Microsoft.VisualStudio.Shell;
using OpenInApp.Command;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System;
using System.ComponentModel.Design;

namespace OpenInApp.Menu
{
    public class MenuCore
    {
        private string Caption { get { return _constantsForAppCommon.Caption; } }
        public readonly Guid CommandSet;

        private readonly bool _suppressTypicalFileExtensionsWarning;
        private readonly ConstantsForAppCommon _constantsForAppCommon;
        private readonly IGeneralOptionsBase _generalOptions;
        private readonly int _cmdIdOpenInAppCodeWin;
        private readonly int _cmdIdOpenInAppItemNode;
        private readonly int? _cmdIdOpenInAppFolderNode;
        private readonly int? _cmdIdOpenInAppProject;
        private readonly IServiceProvider _serviceProvider;
        private readonly KeyToExecutableEnum _keyToExecutableEnum;
        private readonly string _actualPathToExe;
        private readonly string _fileQuantityWarningLimit;
        private readonly string _keyToExecutableEnumDescription;
        private readonly string _typicalFileExtensions;
        private readonly string _vsixName;
        private readonly string _vsixVersion;

        public MenuCore(
                string vsixName,
                string vsixVersion, 
                string guidOpenInVsCmdSetString,
                int cmdIdOpenInAppItemNode, 
                int cmdIdOpenInAppCodeWin, 
                //int? cmdIdOpenInAppFolderNode,
                KeyToExecutableEnum keyToExecutableEnum,
                string actualPathToExe,
                string fileQuantityWarningLimit,
                bool suppressTypicalFileExtensionsWarning,
                string typicalFileExtensions,
                string keyToExecutableEnumDescription,
                IServiceProvider serviceProvider,
                IGeneralOptionsBase generalOptions)
        {
            _actualPathToExe = actualPathToExe;
            _cmdIdOpenInAppCodeWin = cmdIdOpenInAppCodeWin;
            _cmdIdOpenInAppItemNode = cmdIdOpenInAppItemNode;
            _cmdIdOpenInAppFolderNode = null;
            _cmdIdOpenInAppProject = null;
            _constantsForAppCommon = new ConstantsForAppCommon(_vsixName, _vsixVersion);
            _fileQuantityWarningLimit = fileQuantityWarningLimit;
            _generalOptions = generalOptions;
            _keyToExecutableEnum = keyToExecutableEnum;
            _keyToExecutableEnumDescription = keyToExecutableEnumDescription;
            _serviceProvider = serviceProvider;
            _suppressTypicalFileExtensionsWarning = suppressTypicalFileExtensionsWarning;
            _typicalFileExtensions = typicalFileExtensions;
            _vsixName = vsixName;
            _vsixVersion = vsixVersion;
            CommandSet = new Guid(guidOpenInVsCmdSetString);
        }

        public MenuCore(
            string vsixName,
            string vsixVersion,
            string guidOpenInVsCmdSetString,
            int cmdIdOpenInAppItemNode,
            int cmdIdOpenInAppCodeWin,
            int cmdIdOpenInAppFolderNode,
            int cmdIdOpenInAppProject,
            KeyToExecutableEnum keyToExecutableEnum,
            string actualPathToExe,
            string fileQuantityWarningLimit,
            bool suppressTypicalFileExtensionsWarning,
            string typicalFileExtensions,
            string keyToExecutableEnumDescription,
            IServiceProvider serviceProvider,
            IGeneralOptionsBase generalOptions)
        {
            _actualPathToExe = actualPathToExe;
            _cmdIdOpenInAppCodeWin = cmdIdOpenInAppCodeWin;
            _cmdIdOpenInAppItemNode = cmdIdOpenInAppItemNode;
            _cmdIdOpenInAppFolderNode = cmdIdOpenInAppFolderNode;
            _cmdIdOpenInAppProject = cmdIdOpenInAppProject;
            _constantsForAppCommon = new ConstantsForAppCommon(_vsixName, _vsixVersion);
            _fileQuantityWarningLimit = fileQuantityWarningLimit;
            _generalOptions = generalOptions;
            _keyToExecutableEnum = keyToExecutableEnum;
            _keyToExecutableEnumDescription = keyToExecutableEnumDescription;
            _serviceProvider = serviceProvider;
            _suppressTypicalFileExtensionsWarning = suppressTypicalFileExtensionsWarning;
            _typicalFileExtensions = typicalFileExtensions;
            _vsixName = vsixName;
            _vsixVersion = vsixVersion;
            CommandSet = new Guid(guidOpenInVsCmdSetString);
        }

        public void MenuCoreOpenInAppCommand(Package package)
        {
            Logger.Initialize(_serviceProvider, Caption);

            if (package == null)
            {
                Logger.Log(new ArgumentNullException(nameof(package)));
                OpenInAppHelper.ShowUnexpectedError(Caption);
            }
            else
            {
                var commandService = _serviceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
                if (commandService != null)
                {
                    AddMenuCommand(commandService, _cmdIdOpenInAppItemNode, CommandPlacement.IDM_VS_CTXT_ITEMNODE);
                    AddMenuCommand(commandService, _cmdIdOpenInAppCodeWin, CommandPlacement.IDM_VS_CTXT_CODEWIN);
                    //Comment out to exclude folders / un-comment to include folders 
                    if (_cmdIdOpenInAppFolderNode.HasValue)
                    {
                        AddMenuCommand(commandService, _cmdIdOpenInAppFolderNode.Value, CommandPlacement.IDM_VS_CTXT_FOLDERNODE);
                    }
                    //Comment out to exclude folders / un-comment to include folders 
                    if (_cmdIdOpenInAppProject.HasValue)
                    {
                        AddMenuCommand(commandService, _cmdIdOpenInAppProject.Value, CommandPlacement.IDM_VS_CTXT_PROJECT);
                    }
                }
            }
        }

        private void AddMenuCommand(OleMenuCommandService commandService, int packageId, CommandPlacement commandPlacement)
        {
            var menuCommandId = new CommandID(CommandSet, packageId);

            MenuCommand menuCommand;

            switch (commandPlacement)
            {
                case CommandPlacement.IDM_VS_CTXT_CODEWIN:
                    menuCommand = new MenuCommand(MenuItemCallback_CodeWin, menuCommandId);
                    break;
                case CommandPlacement.IDM_VS_CTXT_FOLDERNODE:
                    menuCommand = new MenuCommand(MenuItemCallback_FolderNode, menuCommandId);
                    break;
                case CommandPlacement.IDM_VS_CTXT_ITEMNODE:
                    menuCommand = new MenuCommand(MenuItemCallback_ItemNode, menuCommandId);
                    break;
                case CommandPlacement.IDM_VS_CTXT_PROJECT:
                    menuCommand = new MenuCommand(MenuItemCallback_Project, menuCommandId);
                    break;
                default:
                    Logger.Log(new ArgumentException("Invalid menuCommandType=" + commandPlacement));
                    menuCommand = null;
                    break;
            }

            commandService.AddCommand(menuCommand);
        }

        private void MenuItemCallback_CodeWin(object sender, EventArgs e)
        {
            MenuItemCallback(CommandPlacement.IDM_VS_CTXT_CODEWIN);
        }

        private void MenuItemCallback_FolderNode(object sender, EventArgs e)
        {
            MenuItemCallback(CommandPlacement.IDM_VS_CTXT_FOLDERNODE);
        }

        private void MenuItemCallback_ItemNode(object sender, EventArgs e)
        {
            MenuItemCallback(CommandPlacement.IDM_VS_CTXT_ITEMNODE);
        }

        private void MenuItemCallback_Project(object sender, EventArgs e)
        {
            MenuItemCallback(CommandPlacement.IDM_VS_CTXT_PROJECT);
        }

        private void MenuItemCallback(CommandPlacement commandPlacement)
        {
            var menuItemCallBackHelper = new MenuItemCallBackHelper();

            var keyToExecutableEnum = _keyToExecutableEnum;

            var applicationToOpenDto = new ApplicationToOpenHelper().GetApplicationToOpenDto(keyToExecutableEnum);

            var invokeCommandCallBackDto = GetInvokeCommandCallBackDto(
                _actualPathToExe,
                _fileQuantityWarningLimit,
                commandPlacement,
                _serviceProvider,
                _suppressTypicalFileExtensionsWarning,
                _typicalFileExtensions,
                _constantsForAppCommon.Caption,
                applicationToOpenDto,
                _keyToExecutableEnumDescription);

            var persistOptionsDto = menuItemCallBackHelper.InvokeCommandCallBack(invokeCommandCallBackDto);

            if (persistOptionsDto.Persist)
            {
                _generalOptions.PersistVSToolOptions(persistOptionsDto.ValueToPersist);
            }
        }

        private InvokeCommandCallBackDto GetInvokeCommandCallBackDto(
            string actualPathToExe,
            string fileQuantityWarningLimit,
            CommandPlacement commandPlacement,
            IServiceProvider serviceProvider,
            bool suppressTypicalFileExtensionsWarning,
            string typicalFileExtensions,
            string caption,
            ApplicationToOpenDto applicationToOpenDto,
            string keyToExecutableEnumDescription)
        {
            return new InvokeCommandCallBackDto
            {
                ActualPathToExe = actualPathToExe,
                FileQuantityWarningLimit = fileQuantityWarningLimit,
                CommandPlacement = commandPlacement,
                ServiceProvider = serviceProvider,
                SuppressTypicalFileExtensionsWarning = suppressTypicalFileExtensionsWarning,
                TypicalFileExtensions = typicalFileExtensions,
                Caption = caption,

                ArtefactTypeToOpen = applicationToOpenDto.ArtefactTypeToOpen,
                SeparateProcessPerFileToBeOpened = applicationToOpenDto.SeparateProcessPerFileToBeOpened,
                UseShellExecute = applicationToOpenDto.UseShellExecute,

                ExecutableFileToBrowseFor = keyToExecutableEnumDescription
            };
        }
    }
}
