using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System;

namespace OpenInApp.Command
{
    public class InvokeCommandCallBackDto
    {
        public string ActualPathToExe { get; set; }
        public ArtefactTypeToOpen ArtefactTypeToOpen { get; set; }
        public string Caption { get; set; }
        public CommandPlacement CommandPlacement { get; set; }
        public string KeyToExecutableEnumDescription { get; set; } 
        public string FileQuantityWarningLimit { get; set; }
        public KeyToExecutableEnum KeyToExecutableEnum { get; set; }
        public bool SeparateProcessPerFileToBeOpened { get; set; }
        public IServiceProvider ServiceProvider { get; set; }        
        public bool SuppressTypicalFileExtensionsWarning { get; set; }
        public string TypicalFileExtensions { get; set; }
        public bool UseShellExecute { get; set; }
    }
}
