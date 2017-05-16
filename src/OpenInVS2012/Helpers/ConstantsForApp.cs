using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInVS2012.Helpers
{
    public class ConstantsForApp 
    {
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(ExecutableFileToBrowseFor);
        public const string ExecutableFileToBrowseFor = KeyToExecutable.VS2012;

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return new List<string>
            {
                "*"
            };
        }

        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + ExecutableFileToBrowseFor;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = false;
    }
}
