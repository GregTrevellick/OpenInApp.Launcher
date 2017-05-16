using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInMSPaint.Helpers
{
    public class ConstantsForApp 
    {
        public static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.MSPaint;
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        //public const string KeyToExecutable = OpenInApp.Common.Helpers.KeyToExecutable.MSPaint;

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
        {
            return ActualPathToExeDto.DefaultTypicalFileExtensions;
            //return new List<string>
            //{
            //    "bmp",
            //    "dib",
            //    "gif",
            //    "ico",
            //    "jfif",
            //    "jpe",
            //    "jpeg",
            //    "jpg",
            //    "png",
            //    "tif",
            //    "tiff",
            //};
        }

        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + "gregtKeyToExecutableEnum.Description()";
        internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal static bool SeparateProcessPerFileToBeOpened = true;
        internal static bool UseShellExecute = false;
    }
}
