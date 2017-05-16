using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInVS2015.Helpers
{
    public class ConstantsForApp 
    {
        public static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.VS2015;
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        public const string KeyToExecutableConstant = KeyToExecutableString.VS2015;

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return ActualPathToExeDto.DefaultTypicalFileExtensions;
        }

        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + KeyToExecutableConstant;
        internal static bool SeparateProcessPerFileToBeOpened = ActualPathToExeDto.SeparateProcessPerFileToBeOpened;//true;
        internal static bool UseShellExecute = ActualPathToExeDto.UseShellExecute;//false;
    }
}
