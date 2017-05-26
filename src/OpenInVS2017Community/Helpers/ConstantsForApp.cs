using OpenInApp.Command;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System;
using System.Collections.Generic;

namespace OpenInVS2017Community.Helpers
{
    public class ConstantsForApp 
    {
        internal static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.VS2017Community;
        private static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        private const string KeyToExecutableConstant = KeyToExecutableString.VS2017Community;

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return ActualPathToExeDto.DefaultTypicalFileExtensions;
        }

        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + KeyToExecutableConstant;
        internal static bool SeparateProcessPerFileToBeOpened = ActualPathToExeDto.SeparateProcessPerFileToBeOpened;
        internal static bool UseShellExecute = ActualPathToExeDto.UseShellExecute;
    }
}
