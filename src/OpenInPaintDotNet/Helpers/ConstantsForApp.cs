using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInAppPaintDotNet.Helpers
{
    public class ConstantsForApp 
    {
        public const string AppFolderName = "Paint.NET";
        public const string AppSubFolderName = null;
        public const string ExecutableFileToBrowseFor = "PaintDotNet.exe";
        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return new List<string>
            {
                //Source(s): http://www.getpaint.net/doc/latest/
                #region Extensions
                "BMP",
                "DDS",
                "GIF",
                "JPEG",
                "JPG",
                "PDN",
                "PNG",
                "TGA",
                "TIFF",
	            #endregion
            };
        }


        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + ExecutableFileToBrowseFor;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = true;
    }
}
