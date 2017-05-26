﻿using OpenInApp.Command;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System;
using System.Collections.Generic;

namespace OpenInTreeSizeFree.Helpers
{
    public class ConstantsForApp 
    {
        internal static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.TreeSizeFree;
        private static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        private const string KeyToExecutableConstant = KeyToExecutableString.TreeSizeFree;

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
           bool isFromSolutionExplorer,
           IServiceProvider serviceProvider,
           bool suppressTypicalFileExtensionsWarning,
           string typicalFileExtensions)
        {
            return new InvokeCommandCallBackDto
            {
                ActualPathToExe = actualPathToExe,
                ArtefactToOpen = ActualPathToExeDto.ArtefactToOpen,
                Caption = Caption,
                ExecutableFileToBrowseFor = KeyToExecutableEnum.Description(),
                FileQuantityWarningLimit = fileQuantityWarningLimit,
                IsFromSolutionExplorer = isFromSolutionExplorer,
                SeparateProcessPerFileToBeOpened = SeparateProcessPerFileToBeOpened,
                ServiceProvider = serviceProvider,
                SuppressTypicalFileExtensionsWarning = suppressTypicalFileExtensionsWarning,
                TypicalFileExtensions = typicalFileExtensions,
                UseShellExecute = UseShellExecute
            };
        }
    }
}
