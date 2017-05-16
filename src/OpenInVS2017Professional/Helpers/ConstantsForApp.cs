using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInVS2017Professional.Helpers
{
    public class ConstantsForApp 
    {
        public static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.VS2017Professional;
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        public const string KeyToExecutableConstant = KeyToExecutableString.VS2017Professional;

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
