using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInAppMarkdownMonster.Helpers
{
	public class ConstantsForApp 
	{
        public static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.MarkdownMonster;
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        //public const string KeyToExecutable = OpenInApp.Common.Helpers.KeyToExecutable.MarkdownMonster;
		
		public IEnumerable<string> GetDefaultTypicalFileExtensions()
		{
			return new List<string>
			{
				#region Extensions
				"md",
				#endregion
			};
		}

		internal static string Caption = Vsix.Name + " " + Vsix.Version;
		internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + "gregtKeyToExecutableEnum.Description()";
		internal static bool SeparateProcessPerFileToBeOpened = true;
		internal static bool UseShellExecute = true;
	}
}
