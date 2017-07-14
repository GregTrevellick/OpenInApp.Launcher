using Microsoft.VisualStudio.Shell;
using OpenInApp.Common.Helpers;
using OpenInApp.Menu;
using OpenInVS2012.Options.VS2012;
using System;

namespace OpenInVS2012.Commands
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
            var menuCore = new MenuCore(
                Vsix.Name,
                Vsix.Version,
                PackageGuids.guidOpenInVsCmdSetString,
                PackageIds.CmdIdOpenInAppItemNode,
                PackageIds.CmdIdOpenInAppCodeWin,
                PackageIds.CmdIdOpenInAppFolderNode,
                PackageIds.CmdIdOpenInAppProjNode,
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