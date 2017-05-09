using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInMSPaint.Helpers
{
    public class ConstantsForApp 
    {
        public const string AppFolderName = "Windows";   
        public const string AppSubFolderName = "system32";
        public const string ExecutableFileToBrowseFor = "mspaint.exe";
        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return new List<string>
            {
                "bmp",
                "dib",
                "gif",
                "ico",
                "jfif",
                "jpe",
                "jpeg",
                "jpg",
                "png",
                "tif",
                "tiff",
            };
        }



        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + ExecutableFileToBrowseFor;
        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = true;
    }
}
