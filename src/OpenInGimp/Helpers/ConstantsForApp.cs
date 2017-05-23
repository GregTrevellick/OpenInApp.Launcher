using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInAppGimp.Helpers
{
	public class ConstantsForApp 
	{
        internal static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.Gimp;
        private static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        private const string KeyToExecutableConstant = KeyToExecutableString.Gimp;//good enough for now, update to 3.0 when officially released

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
		{
            return ActualPathToExeDto.DefaultTypicalFileExtensions;
		}

		internal static string Caption = Vsix.Name + " " + Vsix.Version;
		internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + KeyToExecutableConstant;
		internal static bool SeparateProcessPerFileToBeOpened = true;
		internal static bool UseShellExecute = true;
	}
}
