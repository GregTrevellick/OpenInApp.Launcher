using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInVS2017Community.Helpers
{
    public class ConstantsForApp 
    {
        public static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.VS2017Community;
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        //public const string KeyToExecutable = OpenInApp.Common.Helpers.KeyToExecutable.VS2017Community;

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return ActualPathToExeDto.DefaultTypicalFileExtensions;
        }

        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + "gregtKeyToExecutableEnum.Description()";
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = false;
    }
}
