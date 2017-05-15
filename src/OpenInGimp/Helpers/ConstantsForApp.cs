﻿using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInAppGimp.Helpers
{
	public class ConstantsForApp 
	{
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(ExecutableFileToBrowseFor);
        public const string ExecutableFileToBrowseFor = ExeFileNameConstants.Gimp;//good enough for now, update to 3.0 when officially released

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
		{
			return new List<string>
			{
				//Source(s)
				// https://www.gimp.org/features/
				// http://www.ftgimp.com/help/C/file_formats.html
				#region Extensions
				"aa",
				"avi",
				"bmp",
				"bz2",
				"c",
				"cel",
				"fits",
				"fli",
				"gif",
				"gimp",
				"gz",
				"h",
				"hrz",
				"html",
				"jfif",
				"jpeg",
				"jpg",
				"miff",
				"mng",
				"mpeg",
				"pcx",
				"pix",
				"png",
				"pnm",
				"ppm",
				"ps",
				"psd",
				"psp",
				"sgi",
				"sunras",
				"tga",
				"tiff",
				"wmf",
				"xbm",
				"xcf",
				"xpm",
				"xwd",
				"zip",
				#endregion
			};
		}

		internal static string Caption = Vsix.Name + " " + Vsix.Version;
		internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + ExecutableFileToBrowseFor;
		internal static bool SeparateProcessPerFileToBeOpened = true;
		internal static bool UseShellExecute = true;
	}
}
