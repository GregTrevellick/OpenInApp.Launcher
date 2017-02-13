using System;

namespace OpenInApp.Command
{
    public class InvokeCommandCallBackDto
    {
        public string ActualPathToExe { get; set; }
        public string Caption { get; set; }
        public string ExecutableFileToBrowseFor { get; set; }
        public string FileQuantityWarningLimit { get; set; }
        public bool IsFromSolutionExplorer { get; set; }
        public IServiceProvider ServiceProvider { get; set; }        
        public bool SuppressTypicalFileExtensionsWarning { get; set; }
        public string TypicalFileExtensions { get; set; }
    }
}
