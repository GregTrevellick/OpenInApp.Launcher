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
        public Guid CommandSet;

        private bool _suppressTypicalFileExtensionsWarning;
        private ConstantsForAppCommon _constantsForAppCommon;
        private IGeneralOptionsBase _generalOptions;
        private int _cmdIdOpenInAppCodeWin;
        private int _cmdIdOpenInAppItemNode;
        private readonly int? _cmdIdOpenInAppFolderNode;
        private readonly int? _cmdIdOpenInAppProjNode;
        private IServiceProvider _serviceProvider;
        private KeyToExecutableEnum _keyToExecutableEnum;
        private string _actualPathToExe;
        private string _fileQuantityWarningLimit;
        private string _keyToExecutableEnumDescription;
        private string _typicalFileExtensions;
        private string _vsixName;
        private string _vsixVersion;

        public MenuCore(
                string vsixName,
                string vsixVersion, 
                string guidOpenInVsCmdSetString,
                int cmdIdOpenInAppItemNode, 
                int cmdIdOpenInAppCodeWin, 
                KeyToExecutableEnum keyToExecutableEnum,
                string actualPathToExe,
                string fileQuantityWarningLimit,
                bool suppressTypicalFileExtensionsWarning,
                string typicalFileExtensions,
                string keyToExecutableEnumDescription,
                IServiceProvider serviceProvider,
                IGeneralOptionsBase generalOptions)
        {
            Initialize(vsixName, vsixVersion, guidOpenInVsCmdSetString, cmdIdOpenInAppItemNode, cmdIdOpenInAppCodeWin, keyToExecutableEnum, actualPathToExe, fileQuantityWarningLimit, suppressTypicalFileExtensionsWarning, typicalFileExtensions, keyToExecutableEnumDescription, serviceProvider, generalOptions);
            _cmdIdOpenInAppFolderNode = null;
            _cmdIdOpenInAppProjNode = null;
        }

        public MenuCore(
            string vsixName,
            string vsixVersion,
            string guidOpenInVsCmdSetString,
            int cmdIdOpenInAppItemNode,
            int cmdIdOpenInAppCodeWin,
            int cmdIdOpenInAppFolderNode,
            int cmdIdOpenInAppProjNode,
            KeyToExecutableEnum keyToExecutableEnum,
            string actualPathToExe,
            string fileQuantityWarningLimit,
            bool suppressTypicalFileExtensionsWarning,
            string typicalFileExtensions,
            string keyToExecutableEnumDescription,
            IServiceProvider serviceProvider,
            IGeneralOptionsBase generalOptions)
        {
            Initialize(vsixName, vsixVersion, guidOpenInVsCmdSetString, cmdIdOpenInAppItemNode, cmdIdOpenInAppCodeWin, keyToExecutableEnum, actualPathToExe, fileQuantityWarningLimit, suppressTypicalFileExtensionsWarning, typicalFileExtensions, keyToExecutableEnumDescription, serviceProvider, generalOptions);
            _cmdIdOpenInAppFolderNode = cmdIdOpenInAppFolderNode;
            _cmdIdOpenInAppProjNode = cmdIdOpenInAppProjNode;
        }

        private void Initialize(string vsixName, string vsixVersion, string guidOpenInVsCmdSetString, int cmdIdOpenInAppItemNode,
            int cmdIdOpenInAppCodeWin, KeyToExecutableEnum keyToExecutableEnum, string actualPathToExe,
            string fileQuantityWarningLimit, bool suppressTypicalFileExtensionsWarning, string typicalFileExtensions,
            string keyToExecutableEnumDescription, IServiceProvider serviceProvider, IGeneralOptionsBase generalOptions)
        {
            _actualPathToExe = actualPathToExe;
            _cmdIdOpenInAppCodeWin = cmdIdOpenInAppCodeWin;
            _cmdIdOpenInAppItemNode = cmdIdOpenInAppItemNode;
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
                    AddMenuCommand(commandService, _cmdIdOpenInAppCodeWin, CommandPlacement.IDM_VS_CTXT_CODEWIN);

                    if (_cmdIdOpenInAppFolderNode.HasValue)
                    {
                        AddMenuCommand(commandService, _cmdIdOpenInAppFolderNode.Value, CommandPlacement.IDM_VS_CTXT_FOLDERNODE);
                    }

                    AddMenuCommand(commandService, _cmdIdOpenInAppItemNode, CommandPlacement.IDM_VS_CTXT_ITEMNODE);
                    
                    if (_cmdIdOpenInAppProjNode.HasValue)
                    {
                        AddMenuCommand(commandService, _cmdIdOpenInAppProjNode.Value, CommandPlacement.IDM_VS_CTXT_PROJNODE);
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
                case CommandPlacement.IDM_VS_CTXT_PROJNODE:
                    menuCommand = new MenuCommand(MenuItemCallback_ProjNode, menuCommandId);
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

        private void MenuItemCallback_ProjNode(object sender, EventArgs e)
        {
            MenuItemCallback(CommandPlacement.IDM_VS_CTXT_PROJNODE);
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
                _keyToExecutableEnumDescription,
                keyToExecutableEnum);

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
            string keyToExecutableEnumDescription,
            KeyToExecutableEnum keyToExecutableEnum)
        {
            return new InvokeCommandCallBackDto
            {
                ActualPathToExe = actualPathToExe,
                ArtefactTypeToOpen = applicationToOpenDto.ArtefactTypeToOpen,
                Caption = caption,
                CommandPlacement = commandPlacement,
                KeyToExecutableEnumDescription = keyToExecutableEnumDescription,
                FileQuantityWarningLimit = fileQuantityWarningLimit,
                KeyToExecutableEnum = keyToExecutableEnum,
                SeparateProcessPerFileToBeOpened = applicationToOpenDto.SeparateProcessPerFileToBeOpened,
                ServiceProvider = serviceProvider,
                SuppressTypicalFileExtensionsWarning = suppressTypicalFileExtensionsWarning,
                TypicalFileExtensions = typicalFileExtensions,
                UseShellExecute = applicationToOpenDto.UseShellExecute,
            };
        }
    }
}
