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

        //////public InvokeCommandCallBackDto GetInvokeCommandCallBackDto(
        //////   string actualPathToExe,
        //////   string fileQuantityWarningLimit,
        //////   CommandPlacement commandPlacement,
        //////   IServiceProvider serviceProvider,
        //////   bool suppressTypicalFileExtensionsWarning,
        //////   string typicalFileExtensions,
        //////   string caption,
        //////   ApplicationToOpenDto applicationToOpenDto,
        //////   string keyToExecutableEnumDescription)
        //////{
        //////    return new InvokeCommandCallBackDto
        //////    {
        //////        ActualPathToExe = actualPathToExe,
        //////        FileQuantityWarningLimit = fileQuantityWarningLimit,
        //////        CommandPlacement = commandPlacement,
        //////        ServiceProvider = serviceProvider,
        //////        SuppressTypicalFileExtensionsWarning = suppressTypicalFileExtensionsWarning,
        //////        TypicalFileExtensions = typicalFileExtensions,
        //////        Caption = caption,

        //////        ArtefactTypeToOpen = applicationToOpenDto.ArtefactTypeToOpen,
        //////        SeparateProcessPerFileToBeOpened = applicationToOpenDto.SeparateProcessPerFileToBeOpened,
        //////        UseShellExecute = applicationToOpenDto.UseShellExecute,

        //////        ExecutableFileToBrowseFor = keyToExecutableEnumDescription
        //////    };
        //////}
    }
}
