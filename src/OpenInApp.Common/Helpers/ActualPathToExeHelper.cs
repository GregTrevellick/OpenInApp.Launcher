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
                case ExeFileNameConstants.XMLSpy:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Altova\XMLSpy2016";
                    actualPathToExeDto.SecondaryFilePathSegmentHasMultipleYearNumberVersions = true;
                    break;
                case ExeFileNameConstants.Gimp:
                    actualPathToExeDto.SecondaryFilePathSegment = @"GIMP 2\bin";
                    break;
                case ExeFileNameConstants.MarkdownMonster:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Markdown Monster";
                    break;
                case ExeFileNameConstants.VS2012:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 11.0\Common7\IDE";
                    break;
                case ExeFileNameConstants.VS2013:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 12.0\Common7\IDE";
                    break;
                case ExeFileNameConstants.VS2015:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 14.0\Common7\IDE";
                    break;
                case ExeFileNameConstants.VS2017Community:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Community\Common7\IDE";
                    break;
                case ExeFileNameConstants.VS2017Enterprise:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Enterprise\Common7\IDE";
                    break;
                case ExeFileNameConstants.VS2017Professional:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Professional\Common7\IDE";
                    break;
                case ExeFileNameConstants.Opera:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Opera";
                    break;
                case ExeFileNameConstants.PaintDotNet:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Paint.NET";
                    break;
                case ExeFileNameConstants.XamarinStudio:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Xamarin Studio\bin";
                    break;
                case ExeFileNameConstants.FirefoxDeveloperEdition:
                    actualPathToExeDto.SecondaryFilePathSegment = "Firefox Developer Edition";
                    break;
                case ExeFileNameConstants.OperaDeveloperEdition:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Opera developer";
                    break;
                case ExeFileNameConstants.ChromeCanary:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Google\Chrome SxS\Application";
                    actualPathToExeDto.InitialFolderType = InitialFolderType.LocalApplicationData;
                    break;
                case ExeFileNameConstants.Vivaldi:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Vivaldi\Application";
                    actualPathToExeDto.InitialFolderType = InitialFolderType.LocalApplicationData;
                    break;
                case ExeFileNameConstants.Emacs:
                    actualPathToExeDto.SecondaryFilePathSegment = null;
                    actualPathToExeDto.InitialFolderType = InitialFolderType.None;
                    break;
                case ExeFileNameConstants.MSPaint:
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
