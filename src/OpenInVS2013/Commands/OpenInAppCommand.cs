using Microsoft.VisualStudio.Shell;
using OpenInApp.Command;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using OpenInVS2013.Options.VS2013;
using System;
using System.ComponentModel.Design;
using OpenInApp.Menu;

namespace OpenInVS2013.Commands
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