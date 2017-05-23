﻿using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInAppAltovaXmlSpy.Helpers
{
	public class ConstantsForApp 
	{
        internal static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.AltovaXMLSpy;
        private static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        private const string KeyToExecutableConstant = KeyToExecutableString.AltovaXMLSpy;

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
		{
            return ActualPathToExeDto.DefaultTypicalFileExtensions;
        }

		internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + KeyToExecutableConstant;
        internal static bool SeparateProcessPerFileToBeOpened = ActualPathToExeDto.SeparateProcessPerFileToBeOpened;
		internal static bool UseShellExecute = true;
	}
}
