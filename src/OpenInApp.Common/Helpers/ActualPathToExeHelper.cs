using OpenInApp.Common.Helpers.Dtos;

namespace OpenInApp.Common.Helpers
{
    public class ActualPathToExeHelper
    {
        public ActualPathToExeDto GetActualPathToExeDto(string executableFileToBrowseFor)
        {
            var actualPathToExeDto = new ActualPathToExeDto
            {
                ExecutableFileToBrowseFor = executableFileToBrowseFor,
                InitialFolderType = InitialFolderType.ProgramFilesX86,
                SecondaryFilePathSegmentHasMultipleYearNumberVersions = false
            };

            switch (executableFileToBrowseFor)
            {
                case "XMLSpy.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = @"Altova\XMLSpy2016";
                    actualPathToExeDto.SecondaryFilePathSegmentHasMultipleYearNumberVersions = true;
                    break;
                case "gimp-2.8.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = @"GIMP 2\bin";
                    break;
                case "MarkdownMonster.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = @"Markdown Monster";
                    break;
                case "devenv.exeVS2012":
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 11.0\Common7\IDE";
                    break;
                case "devenv.exeVS2013":
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 12.0\Common7\IDE";
                    break;
                case "devenv.exeVS2015":
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 14.0\Common7\IDE";
                    break;
                case "devenv.exeVS2017Community":
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Community\Common7\IDE";
                    break;
                case "devenv.exeVS2017Enterprise":
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Enterprise\Common7\IDE";
                    break;
                case "devenv.exeVS2017Professional":
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Professional\Common7\IDE";
                    break;
                case "opera.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = @"Opera";
                    break;
                case "PaintDotNet.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = @"Paint.NET";
                    break;
                case "XamarinStudio.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = @"Xamarin Studio\bin";
                    break;
                case "firefox.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = "Firefox Developer Edition";
                    break;
                case "launcher.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = @"Opera developer";
                    break;
                case "chrome.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = @"Google\Chrome SxS\Application";
                    actualPathToExeDto.InitialFolderType = InitialFolderType.LocalApplicationData;
                    break;
                case "vivaldi.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = @"Vivaldi\Application";
                    actualPathToExeDto.InitialFolderType = InitialFolderType.LocalApplicationData;
                    break;
                case "runemacs.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = null;
                    actualPathToExeDto.InitialFolderType = InitialFolderType.None;
                    break;
                case "mspaint.exe":
                    actualPathToExeDto.SecondaryFilePathSegment = "system32";
                    actualPathToExeDto.InitialFolderType = InitialFolderType.Windows;
                    break;
                default:
                    actualPathToExeDto.SecondaryFilePathSegment = null;
                    actualPathToExeDto.InitialFolderType = InitialFolderType.None;
                    break;
            }

            return actualPathToExeDto;
        }
    }
}
