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
        private string Caption { get { return constantsForAppCommon.Caption; } }
        public readonly Guid CommandSet;

        private bool _suppressTypicalFileExtensionsWarning;
        private ConstantsForAppCommon constantsForAppCommon;
        private IGeneralOptionsBase _generalOptions;
        private int _cmdIdOpenInAppCodeWin;
        private int _cmdIdOpenInAppFolderExplore;
        private int? _cmdIdOpenInAppFolderNode;
        private IServiceProvider _serviceProvider;
        private KeyToExecutableEnum _keyToExecutableEnum;
        private string _actualPathToExe;
        private string _fileQuantityWarningLimit;
        private string _keyToExecutableEnumDotDescription;
        private string _typicalFileExtensions;
        private string _vsixName;
        private string _vsixVersion;

        //ctor
        public MenuCore(
                string vsixName,
                string vsixVersion, 
                string packageGuidsDotGuidOpenInVsCmdSetString,
                int cmdIdOpenInAppFolderExplore, 
                int cmdIdOpenInAppCodeWin, 
                int? cmdIdOpenInAppFolderNode,
                KeyToExecutableEnum keyToExecutableEnum,
                string actualPathToExe,
                string fileQuantityWarningLimit,
                bool suppressTypicalFileExtensionsWarning,
                string typicalFileExtensions,
                string keyToExecutableEnumDotDescription,
                IServiceProvider serviceProvider,
                IGeneralOptionsBase generalOptions)
        {
            _actualPathToExe = actualPathToExe;
            _cmdIdOpenInAppCodeWin = cmdIdOpenInAppCodeWin;
            _cmdIdOpenInAppFolderExplore = cmdIdOpenInAppFolderExplore;
            _cmdIdOpenInAppFolderNode = cmdIdOpenInAppFolderNode;
            _fileQuantityWarningLimit = fileQuantityWarningLimit;
            _generalOptions = generalOptions;
            _keyToExecutableEnum = keyToExecutableEnum;
            _keyToExecutableEnumDotDescription = keyToExecutableEnumDotDescription;
            _serviceProvider = serviceProvider;
            _suppressTypicalFileExtensionsWarning = suppressTypicalFileExtensionsWarning;
            _typicalFileExtensions = typicalFileExtensions;
            _vsixName = vsixName;
            _vsixVersion = vsixVersion;
            CommandSet = new Guid(packageGuidsDotGuidOpenInVsCmdSetString);
            constantsForAppCommon = new ConstantsForAppCommon(_vsixName, _vsixVersion);
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
                    AddMenuCommand(commandService, _cmdIdOpenInAppFolderExplore, CommandPlacement.IDM_VS_CTXT_ITEMNODE);
                    AddMenuCommand(commandService, _cmdIdOpenInAppCodeWin, CommandPlacement.IDM_VS_CTXT_CODEWIN);
                    //Comment out to exclude folders / un-comment to include folders 
                    if (_cmdIdOpenInAppFolderNode.HasValue)
                    {
                        AddMenuCommand(commandService, _cmdIdOpenInAppFolderNode.Value, CommandPlacement.IDM_VS_CTXT_FOLDERNODE);
                    }
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
                case CommandPlacement.IDM_VS_CTXT_FOLDERNODE:
                    menuCommand = new MenuCommand(MenuItemCallback_FolderNode, menuCommandID);
                    break;
                case CommandPlacement.IDM_VS_CTXT_ITEMNODE:
                    menuCommand = new MenuCommand(MenuItemCallback_ItemNode, menuCommandID);
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
                constantsForAppCommon.Caption,
                applicationToOpenDto,
                _keyToExecutableEnumDotDescription);

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
