using OpenInApp.Common.Helpers.Dtos;
using System;

namespace OpenInApp.Command
{
    public class ConstantsForAppCommon
    {
        private string vsixName;
        private string vsixVersion;

        public ConstantsForAppCommon(string vsixName, string vsixVersion)
        {
            this.vsixName = vsixName;
            this.vsixVersion = vsixVersion;
        }

        public string Caption 
        { 
            get 
                { 
                    return vsixName + " " + vsixVersion;
                }
        }

        public InvokeCommandCallBackDto GetInvokeCommandCallBackDto(
           string actualPathToExe,
           string fileQuantityWarningLimit,
           CommandPlacement commandPlacement,
           IServiceProvider serviceProvider,
           bool suppressTypicalFileExtensionsWarning,
           string typicalFileExtensions,
           string Caption,
           ApplicationToOpenDto ApplicationToOpenDto,
           string KeyToExecutableEnumDescription)
        {
            return new InvokeCommandCallBackDto
            {
                ActualPathToExe = actualPathToExe,
                ArtefactTypeToOpen = ApplicationToOpenDto.ArtefactTypeToOpen,
                Caption = Caption,
                ExecutableFileToBrowseFor = KeyToExecutableEnumDescription,
                FileQuantityWarningLimit = fileQuantityWarningLimit,
                CommandPlacement = commandPlacement,
                SeparateProcessPerFileToBeOpened = ApplicationToOpenDto.SeparateProcessPerFileToBeOpened,
                ServiceProvider = serviceProvider,
                SuppressTypicalFileExtensionsWarning = suppressTypicalFileExtensionsWarning,
                TypicalFileExtensions = typicalFileExtensions,
                UseShellExecute = ApplicationToOpenDto.UseShellExecute
            };
        }
    }
}
