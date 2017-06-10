using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System;
using System.Collections.Generic;

namespace OpenInApp.Command
{
    public class ConstantsForAppCommon
    {
        private string _vsixName;
        private string _vsixVersion;

        public ConstantsForAppCommon()
        {
        }

        public ConstantsForAppCommon(string vsixName, string vsixVersion)
        {
            _vsixName = vsixName;
            _vsixVersion = vsixVersion;
        }

        public string Caption 
        { 
            get 
                { 
                    return _vsixName + " " + _vsixVersion;
                }
        }

        public IEnumerable<string> GetDefaultTypicalFileExtensions(KeyToExecutableEnum keyToExecutableEnum)
        {
            return new ApplicationToOpenHelper().GetApplicationToOpenDto(keyToExecutableEnum).DefaultTypicalFileExtensions;
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
