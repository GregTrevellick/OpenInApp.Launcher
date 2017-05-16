using OpenInApp.Common.Helpers.Dtos;

namespace OpenInApp.Common.Helpers
{
    public class ActualPathToExeHelper
    {
        public ActualPathToExeDto GetActualPathToExeDto(KeyToExecutableEnum keyToExecutable)
        {
            var actualPathToExeDto = new ActualPathToExeDto
            {
                ExecutableFileToBrowseFor = keyToExecutable.Description(),
                InitialFolderType = InitialFolderType.ProgramFilesX86,
                SecondaryFilePathSegmentHasMultipleYearNumberVersions = false
            };

            switch (keyToExecutable)
            {
                case KeyToExecutableEnum.XMLSpy:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Altova\XMLSpy2016";
                    actualPathToExeDto.SecondaryFilePathSegmentHasMultipleYearNumberVersions = true;
                    break;
                case KeyToExecutableEnum.Gimp:
                    actualPathToExeDto.SecondaryFilePathSegment = @"GIMP 2\bin";
                    break;
                case KeyToExecutableEnum.MarkdownMonster:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Markdown Monster";
                    break;
                case KeyToExecutableEnum.VS2012:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 11.0\Common7\IDE";
                    break;
                case KeyToExecutableEnum.VS2013:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 12.0\Common7\IDE";
                    break;
                case KeyToExecutableEnum.VS2015:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 14.0\Common7\IDE";
                    break;
                case KeyToExecutableEnum.VS2017Community:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Community\Common7\IDE";
                    break;
                case KeyToExecutableEnum.VS2017Enterprise:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Enterprise\Common7\IDE";
                    break;
                case KeyToExecutableEnum.VS2017Professional:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Professional\Common7\IDE";
                    break;
                case KeyToExecutableEnum.Opera:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Opera";
                    break;
                case KeyToExecutableEnum.PaintDotNet:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Paint.NET";
                    break;
                case KeyToExecutableEnum.XamarinStudio:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Xamarin Studio\bin";
                    break;
                case KeyToExecutableEnum.FirefoxDeveloperEdition:
                    actualPathToExeDto.SecondaryFilePathSegment = "Firefox Developer Edition";
                    break;
                case KeyToExecutableEnum.OperaDeveloperEdition:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Opera developer";
                    break;
                case KeyToExecutableEnum.ChromeCanary:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Google\Chrome SxS\Application";
                    actualPathToExeDto.InitialFolderType = InitialFolderType.LocalApplicationData;
                    break;
                case KeyToExecutableEnum.Vivaldi:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Vivaldi\Application";
                    actualPathToExeDto.InitialFolderType = InitialFolderType.LocalApplicationData;
                    break;
                case KeyToExecutableEnum.Emacs:
                    actualPathToExeDto.SecondaryFilePathSegment = null;
                    actualPathToExeDto.InitialFolderType = InitialFolderType.None;
                    break;
                case KeyToExecutableEnum.MSPaint:
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
