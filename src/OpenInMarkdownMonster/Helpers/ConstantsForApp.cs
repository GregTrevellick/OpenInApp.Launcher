using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInAppMarkdownMonster.Helpers
{
	public class ConstantsForApp 
	{
        internal static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.MarkdownMonster;
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        private const string KeyToExecutableConstant = KeyToExecutableString.MarkdownMonster;
		
		public IEnumerable<string> GetDefaultTypicalFileExtensions()
		{
            return ActualPathToExeDto.DefaultTypicalFileExtensions;
   //         return new List<string>
			//{
			//	#region Extensions
			//	"md",
			//	#endregion
			//};
		}

		internal static string Caption = Vsix.Name + " " + Vsix.Version;
		internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + KeyToExecutableConstant;
		internal static bool SeparateProcessPerFileToBeOpened = true;
		internal static bool UseShellExecute = true;
	}
}
