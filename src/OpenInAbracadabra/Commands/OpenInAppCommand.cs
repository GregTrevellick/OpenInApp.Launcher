using Microsoft.VisualStudio.Shell;
using OpenInAbracadabra.Options.Abracadabra;
using OpenInApp.Common.Helpers;
using OpenInApp.Menu;
using System;

namespace OpenInAbracadabra.Commands
{
    internal sealed class OpenInAppCommand
    {
        private readonly Package _package;
        private IServiceProvider serviceProvider { get { return _package; } }

        public OpenInAppCommand(Package package)
        {
            _package = package;
        }

        public void Initialize()
        {
            var packageIdCmdIdOpenInAppFolderNode = PackageIds.CmdIdOpenInAppFolderNode == int.MinValue ? null : (int?)PackageIds.CmdIdOpenInAppFolderNode;

            var menuCore = new MenuCore(
                Vsix.Name, 
                Vsix.Version,
                PackageGuids.guidOpenInVsCmdSetString,
                PackageIds.CmdIdOpenInAppFolderExplore,
                PackageIds.CmdIdOpenInAppCodeWin,
                packageIdCmdIdOpenInAppFolderNode,
                GeneralOptions.keyToExecutableEnum,
                VSPackage.Options.ActualPathToExe,
                VSPackage.Options.FileQuantityWarningLimit,
                VSPackage.Options.SuppressTypicalFileExtensionsWarning,
                VSPackage.Options.TypicalFileExtensions,
                GeneralOptions.keyToExecutableEnum.Description(),
                serviceProvider,
                VSPackage.Options);

            menuCore.MenuCoreOpenInAppCommand(_package);
        }
    }
}