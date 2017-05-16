using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInGregtGregt.Helpers
{
    public class ConstantsForApp 
    {
        public static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.MarkdownMonster;
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        //public const string KeyToExecutable = OpenInApp.Common.Helpers.KeyToExecutable.MarkdownMonster;//"gregtgregt";

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return ActualPathToExeDto.DefaultTypicalFileExtensions;
        }

        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + "gregtKeyToExecutableEnum.Description()";
        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = true;
    }
}
