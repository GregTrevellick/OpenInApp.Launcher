using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInApp.Common.Helpers
{
    public class ActualPathToExeHelper
    {
        public ActualPathToExeDto GetActualPathToExeDto(KeyToExecutableEnum keyToExecutableEnum)
        {
            var actualPathToExeDto = new ActualPathToExeDto
            {
                ArtefactToOpen = ArtefactToOpen.File,
                DefaultTypicalFileExtensions = new List<string> { "*" },
                ExecutableFileToBrowseFor = keyToExecutableEnum.Description(),
                InitialFolderType = InitialFolderType.ProgramFilesX86,
                SecondaryFilePathSegmentHasMultipleYearNumberVersions = false,
                SeparateProcessPerFileToBeOpened = true,
                UseShellExecute = true,
            };

            switch (keyToExecutableEnum)
            {
                //gregtt emacs, not found message says cannot find file ""

                case KeyToExecutableEnum.AltovaXMLSpy:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Altova\XMLSpy2016";
                    actualPathToExeDto.SecondaryFilePathSegmentHasMultipleYearNumberVersions = true;
                    actualPathToExeDto.DefaultTypicalFileExtensions = new List<string>
                    {
                        #region Extensions
                        //Source(s) http://manual.altova.com/XMLSpy/spyprofessional/index.html?filetypes.htm
				        "asp",
                        "biz",
                        "cml",
                        "config",
                        "csproj",
                        "css",
                        "dcd",
                        "docm",
                        "docx",
                        "dotm",
                        "dotx",
                        "dtd",
                        "ent",
                        "epub",
                        "fo",
                        "htm",
                        "html",
                        "json",
                        "jsp",
                        "math",
                        "mml",
                        "nuspec",
                        "potm",
                        "potx",
                        "ppam",
                        "ppsm",
                        "ppsx",
                        "pptm",
                        "pptx",
                        "properties",
                        "pxf",
                        "rdf",
                        "runsettings",
                        "settings",
                        "sldm",
                        "sldx",
                        "sln",
                        "smil",
                        "sps",
                        "svg",
                        "testsettings",
                        "thmx",
                        "tld",
                        "txt",
                        "vml",
                        "vsct",
                        "vsix",
                        "vsixmanifest",
                        "vxml",
                        "wml",
                        "wsdl",
                        "xbrl",
                        "xdr",
                        "xhtml",
                        "xlam",
                        "xlsb",
                        "xlsm",
                        "xlsx",
                        "xltm",
                        "xltx",
                        "xml",
                        "xq",
                        "xql",
                        "xqu",
                        "xquery",
                        "xsd",
                        "xsig",
                        "xsl",
                        "xslt",
                        "zip", 
				        #endregion
	         		};
                    break;
                case KeyToExecutableEnum.ChromeCanary:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Google\Chrome SxS\Application";
                    actualPathToExeDto.InitialFolderType = InitialFolderType.LocalApplicationData;
                    break;
                case KeyToExecutableEnum.Emacs:
                    actualPathToExeDto.SecondaryFilePathSegment = null;
                    actualPathToExeDto.InitialFolderType = InitialFolderType.None;
                    break;
                case KeyToExecutableEnum.FirefoxDeveloperEdition:
                    actualPathToExeDto.SecondaryFilePathSegment = "Firefox Developer Edition";
                    break;
                case KeyToExecutableEnum.Gimp:
                    actualPathToExeDto.SecondaryFilePathSegment = @"GIMP 2\bin";
                    actualPathToExeDto.DefaultTypicalFileExtensions = new List<string>
                    {
                        #region Extensions
                        // https://www.gimp.org/features/
                        // http://www.ftgimp.com/help/C/file_formats.html
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
                    break;
                case KeyToExecutableEnum.MarkdownMonster:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Markdown Monster";
                    actualPathToExeDto.DefaultTypicalFileExtensions = new List<string> { "md" };
                    break;
                case KeyToExecutableEnum.MSPaint:
                    actualPathToExeDto.SecondaryFilePathSegment = "system32";
                    actualPathToExeDto.InitialFolderType = InitialFolderType.Windows;
                    actualPathToExeDto.UseShellExecute = false;
                    actualPathToExeDto.DefaultTypicalFileExtensions = new List<string>
                    {
                        #region Extensions
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
                        #endregion
                    };
                    break;
                case KeyToExecutableEnum.Opera:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Opera";
                    break;
                case KeyToExecutableEnum.OperaDeveloperEdition:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Opera developer";
                    break;
                case KeyToExecutableEnum.PaintDotNet:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Paint.NET";
                    actualPathToExeDto.DefaultTypicalFileExtensions = new List<string>
                    {
                        #region Extensions
                        //Source(s): http://www.getpaint.net/doc/latest/
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
                    break;
                case KeyToExecutableEnum.TreeSizeFree:
                    actualPathToExeDto.ArtefactToOpen = ArtefactToOpen.Folder;
                    actualPathToExeDto.SecondaryFilePathSegment = @"JAM Software\TreeSize Free";
                    break;
                case KeyToExecutableEnum.Vivaldi:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Vivaldi\Application";
                    actualPathToExeDto.InitialFolderType = InitialFolderType.LocalApplicationData;
                    break;
                case KeyToExecutableEnum.VS2012:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 11.0\Common7\IDE";
                    actualPathToExeDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.VS2013:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 12.0\Common7\IDE";
                    actualPathToExeDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.VS2015:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 14.0\Common7\IDE";
                    actualPathToExeDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.VS2017Community:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Community\Common7\IDE";
                    actualPathToExeDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.VS2017Enterprise:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Enterprise\Common7\IDE";
                    actualPathToExeDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.VS2017Professional:
                    actualPathToExeDto.ExecutableFileToBrowseFor = "devenv.exe";
                    actualPathToExeDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Professional\Common7\IDE";
                    actualPathToExeDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.XamarinStudio:
                    actualPathToExeDto.SecondaryFilePathSegment = @"Xamarin Studio\bin";
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
