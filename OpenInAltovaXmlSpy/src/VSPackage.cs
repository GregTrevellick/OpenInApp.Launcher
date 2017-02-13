using Microsoft.VisualStudio.Shell;
using OpenInApp.Common.Helpers;
using OpenInAppAltovaXmlSpy.Commands;
using OpenInAppAltovaXmlSpy.Options.AltovaXmlSpy;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenInAppAltovaXmlSpy
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration(productName: "#110", productDetails: "#112", productId: Vsix.Version, IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.guidOpenInAppPackageString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideOptionPage(typeof(GeneralOptions), Vsix.Name, CommonConstants.CategorySubLevel, 0, 0, true)]
    public sealed class VSPackage : Package 
    {
        public static GeneralOptions Options { get; private set; }

        protected override void Initialize()
        {
            Options = (GeneralOptions)GetDialogPage(typeof(GeneralOptions));

            new OpenInAppCommand().Initialize(this);
            base.Initialize();
        }
    }
}
