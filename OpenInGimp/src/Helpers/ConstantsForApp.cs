using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInAppGimp.Helpers
{
    public class ConstantsForApp 
    {
        public const string AppFolderName = "GIMP 2";
        public const string AppSubFolderName = "bin";
        public const string ExecutableFileToBrowseFor = "gimp-2.8.exe";//good enough for now, update to 3.0 when officially released

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
    }
}
