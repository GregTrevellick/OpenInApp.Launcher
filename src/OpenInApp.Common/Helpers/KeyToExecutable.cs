using System.ComponentModel;

namespace OpenInApp.Common.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class KeyToExecutableString
    {
        public const string Abracadabra = "windirstat.exe"; 
        public const string AltovaXMLSpy = "XMLSpy.exe";
        public const string ChromeCanary = "chrome.exe";
        public const string Emacs = "runemacs.exe";
        public const string FirefoxDeveloperEdition = "firefox.exe";
        public const string Gimp = "gimp-2.8.exe";
        public const string MarkdownMonster = "MarkdownMonster.exe";
        public const string MSPaint = "mspaint.exe";
        public const string Opera = "opera.exe";
        public const string OperaDeveloperEdition = "launcher.exe";
        public const string PaintDotNet = "PaintDotNet.exe";
        public const string SequelServerManagementStudio = "ssmsee.exe";
        public const string TreeSizeFree = "TreeSizeFree.exe";
        public const string TreeSizeProfessional = "TreeSize.exe";
        public const string Vivaldi = "vivaldi.exe";
        public const string VS2012 = "devenv.exeVS2012";
        public const string VS2013 = "devenv.exeVS2013";
        public const string VS2015 = "devenv.exeVS2015";
        public const string VS2017Community = "devenv.exeVS2017Community";
        public const string VS2017Enterprise = "devenv.exeVS2017Enterprise";
        public const string VS2017Professional = "devenv.exeVS2017Professional";
        public const string WinDirStat = "windirstat.exe";
        public const string XamarinStudio = "XamarinStudio.exe";
    }

    public enum KeyToExecutableEnum//gregtt auto sync the class above to this
    {
        [Description("windirstat.exe")]
        Abracadabra,

        [Description("XMLSpy.exe")]
        AltovaXMLSpy,

        [Description("chrome.exe")]
        ChromeCanary,
       
        [Description("runemacs.exe")]
        Emacs,
        
        [Description("firefox.exe")]
        FirefoxDeveloperEdition,
        
        [Description("gimp-2.8.exe")]
        Gimp,
        
        [Description("MarkdownMonster.exe")]
        MarkdownMonster,
        
        [Description("mspaint.exe")]
        MSPaint,
        
        [Description("opera.exe")]
        Opera,
        
        [Description("launcher.exe")]
        OperaDeveloperEdition,
        
        [Description("PaintDotNet.exe")]
        PaintDotNet,

        [Description("ssmsee.exe")]
        SequelServerManagementStudio,

        [Description("TreeSizeFree.exe")]
        TreeSizeFree,

        [Description("TreeSize.exe")]
        TreeSizeProfessional,

        [Description("vivaldi.exe")]
        Vivaldi,
        
        [Description("devenv.exe")]
        VS2012,
        
        [Description("devenv.exe")]
        VS2013,
        
        [Description("devenv.exe")]
        VS2015,
        
        [Description("devenv.exe")]
        VS2017Community,
        
        [Description("devenv.exe")]
        VS2017Enterprise,
        
        [Description("devenv.exe")]
        VS2017Professional,

        [Description("windirstat.exe")]
        WinDirStat,

        [Description("XamarinStudio.exe")]
        XamarinStudio,
    }
}
