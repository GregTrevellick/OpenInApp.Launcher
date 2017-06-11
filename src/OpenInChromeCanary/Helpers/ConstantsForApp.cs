//using OpenInApp.Command;
//using OpenInApp.Common.Helpers;
//using OpenInApp.Common.Helpers.Dtos;
//using System;
//using System.Collections.Generic;

//namespace OpenInChromeCanary.Helpers
//{
//    public class ConstantsForApp 
//    {
//        internal static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.ChromeCanary;
//        private static ApplicationToOpenDto ApplicationToOpenDto = new ApplicationToOpenHelper().GetApplicationToOpenDto(KeyToExecutableEnum);
//        private const string KeyToExecutableConstant = KeyToExecutableString.ChromeCanary;

//        public IEnumerable<string> GetDefaultTypicalFileExtensions()
//        {
//            return ApplicationToOpenDto.DefaultTypicalFileExtensions;
//        }

//        internal static string Caption = Vsix.Name + " " + Vsix.Version;
//        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + KeyToExecutableConstant;
//        //internal static bool SeparateProcessPerFileToBeOpened = ApplicationToOpenDto.SeparateProcessPerFileToBeOpened;
//        //internal static bool UseShellExecute = ApplicationToOpenDto.UseShellExecute;

//        internal InvokeCommandCallBackDto GetInvokeCommandCallBackDto(
//           string actualPathToExe,
//           string fileQuantityWarningLimit,
//           CommandPlacement commandPlacement,
//           IServiceProvider serviceProvider,
//           bool suppressTypicalFileExtensionsWarning,
//           string typicalFileExtensions)
//        {
//            return new InvokeCommandCallBackDto
//            {
//                ActualPathToExe = actualPathToExe,
//                ArtefactTypeToOpen = ApplicationToOpenDto.ArtefactTypeToOpen,
//                Caption = Caption,
//                ExecutableFileToBrowseFor = KeyToExecutableEnum.Description(),
//                FileQuantityWarningLimit = fileQuantityWarningLimit,
//                CommandPlacement = commandPlacement,
//                SeparateProcessPerFileToBeOpened = ApplicationToOpenDto.SeparateProcessPerFileToBeOpened,
//                ServiceProvider = serviceProvider,
//                SuppressTypicalFileExtensionsWarning = suppressTypicalFileExtensionsWarning,
//                TypicalFileExtensions = typicalFileExtensions,
//                UseShellExecute = ApplicationToOpenDto.UseShellExecute
//            };
//        }
//    }
//}