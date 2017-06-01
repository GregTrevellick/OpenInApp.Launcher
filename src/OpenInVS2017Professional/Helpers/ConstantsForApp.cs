using OpenInApp.Command;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System;
using System.Collections.Generic;

namespace OpenInVS2017Professional.Helpers
{
    public class ConstantsForApp 
    {
        internal static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.VS2017Professional;
        private static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        private const string KeyToExecutableConstant = KeyToExecutableString.VS2017Professional;

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return ActualPathToExeDto.DefaultTypicalFileExtensions;
        }

        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + KeyToExecutableConstant;
        internal static bool SeparateProcessPerFileToBeOpened = ActualPathToExeDto.SeparateProcessPerFileToBeOpened;
        internal static bool UseShellExecute = ActualPathToExeDto.UseShellExecute;

        internal InvokeCommandCallBackDto GetInvokeCommandCallBackDto(
           string actualPathToExe,
           string fileQuantityWarningLimit,
           CommandPlacement commandPlacement,//bool isFromSolutionExplorer,
           IServiceProvider serviceProvider,
           bool suppressTypicalFileExtensionsWarning,
           string typicalFileExtensions)
        {
            return new InvokeCommandCallBackDto
            {
                ActualPathToExe = actualPathToExe,
                ArtefactTypeToOpen = ActualPathToExeDto.ArtefactTypeToOpen,
                Caption = Caption,
                ExecutableFileToBrowseFor = KeyToExecutableEnum.Description(),
                FileQuantityWarningLimit = fileQuantityWarningLimit,
                CommandPlacement = commandPlacement,//IsFromSolutionExplorer = isFromSolutionExplorer,
                SeparateProcessPerFileToBeOpened = SeparateProcessPerFileToBeOpened,
                ServiceProvider = serviceProvider,
                SuppressTypicalFileExtensionsWarning = suppressTypicalFileExtensionsWarning,
                TypicalFileExtensions = typicalFileExtensions,
                UseShellExecute = UseShellExecute
            };
        }
    }
}
