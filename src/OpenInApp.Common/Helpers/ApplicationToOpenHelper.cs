using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInApp.Common.Helpers
{
    public class ApplicationToOpenHelper
    {
        public bool GetExcludeBinAndObjFoldersWhenOpeningProjectNode(KeyToExecutableEnum keyToExecutableEnum)
        {
            return GetApplicationToOpenDto(keyToExecutableEnum).ExcludeBinAndObjFoldersWhenOpeningProjectNode;
        }

        public bool? GetOpenIndividualFilesInFolderRatherThanFolderItself(KeyToExecutableEnum keyToExecutableEnum)
        {
            return GetApplicationToOpenDto(keyToExecutableEnum).OpenIndividualFilesInFolderRatherThanFolderItself;
        }

        public string GetSecondaryFilePathSegment(KeyToExecutableEnum keyToExecutableEnum)
        {
            return GetApplicationToOpenDto(keyToExecutableEnum).SecondaryFilePathSegment;
        }

        public bool GetSecondaryFilePathSegmentHasMultipleVersions(KeyToExecutableEnum keyToExecutableEnum)
        {
            return GetApplicationToOpenDto(keyToExecutableEnum).SecondaryFilePathSegmentHasMultipleVersions;
        }
        
        public IEnumerable<string> GetExecutableFilesToBrowseFor(KeyToExecutableEnum keyToExecutableEnum)
        {
            return GetApplicationToOpenDto(keyToExecutableEnum).ExecutableFilesToBrowseFor;
        }

        public ApplicationToOpenDto GetApplicationToOpenDto(KeyToExecutableEnum keyToExecutableEnum)
        {
            var applicationToOpenDto = new ApplicationToOpenDto
            {
                ArtefactTypeToOpen = ArtefactTypeToOpen.File,
                DefaultTypicalFileExtensions = new List<string> { "*" },
                ExcludeBinAndObjFoldersWhenOpeningProjectNode = false,
                ExecutableFilesToBrowseFor = new List<string> { keyToExecutableEnum.Description() },
                ///////////////////////////////InitialFolderType = InitialFolderType.ProgramFilesX86,
                ProcessWithinProcess = false,
                OpenIndividualFilesInFolderRatherThanFolderItself = null,
                SecondaryFilePathSegmentHasMultipleVersions = false,
                SeparateProcessPerFileToBeOpened = true,
                UseShellExecute = true,
            };

            switch (keyToExecutableEnum)
            {
                case KeyToExecutableEnum.Abracadabra:
                    applicationToOpenDto.ArtefactTypeToOpen = ArtefactTypeToOpen.Folder;
                    applicationToOpenDto.SecondaryFilePathSegment = @"WinDirStat";
                    break;
                case KeyToExecutableEnum.AltovaXMLSpy:
                    applicationToOpenDto.ExcludeBinAndObjFoldersWhenOpeningProjectNode = true;
                    applicationToOpenDto.SecondaryFilePathSegment = @"Altova\XMLSpy9999";
                    applicationToOpenDto.SecondaryFilePathSegmentHasMultipleVersions = true;
                    applicationToOpenDto.SeparateProcessPerFileToBeOpened = false;
                    applicationToOpenDto.DefaultTypicalFileExtensions = new List<string>
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
                    applicationToOpenDto.SecondaryFilePathSegment = @"Google\Chrome SxS\Application";
                    ///////////////////////////////applicationToOpenDto.InitialFolderType = InitialFolderType.LocalApplicationData;
                    break;
                case KeyToExecutableEnum.Emacs:
                    applicationToOpenDto.ExcludeBinAndObjFoldersWhenOpeningProjectNode = true;
                    applicationToOpenDto.SecondaryFilePathSegment = null;
                    ///////////////////////////////applicationToOpenDto.InitialFolderType = InitialFolderType.None;
                    break;
                case KeyToExecutableEnum.FirefoxDeveloperEdition:
                    applicationToOpenDto.SecondaryFilePathSegment = "Firefox Developer Edition";
                    applicationToOpenDto.SeparateProcessPerFileToBeOpened = false;
                    break;
                case KeyToExecutableEnum.Gimp:
                    applicationToOpenDto.OpenIndividualFilesInFolderRatherThanFolderItself = true;
                    applicationToOpenDto.SecondaryFilePathSegment = @"GIMP 2\bin";
                    applicationToOpenDto.DefaultTypicalFileExtensions = new List<string>
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
                    applicationToOpenDto.SecondaryFilePathSegment = @"Markdown Monster";
                    applicationToOpenDto.SeparateProcessPerFileToBeOpened = false;
                    applicationToOpenDto.DefaultTypicalFileExtensions = new List<string> { "md" };
                    break;
                case KeyToExecutableEnum.MSPaint:
                    applicationToOpenDto.SecondaryFilePathSegment = "system32";
                    ///////////////////////////////applicationToOpenDto.InitialFolderType = InitialFolderType.Windows;
                    applicationToOpenDto.OpenIndividualFilesInFolderRatherThanFolderItself = true;
                    applicationToOpenDto.UseShellExecute = false;
                    applicationToOpenDto.DefaultTypicalFileExtensions = new List<string>
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
                    ///////////////////////////////applicationToOpenDto.InitialFolderType = InitialFolderType.LocalApplicationData;
                    applicationToOpenDto.ExecutableFilesToBrowseFor = new List<string> { "launcher.exe", "opera.exe" };
                    applicationToOpenDto.SecondaryFilePathSegment = @"Opera";
                    break;
                case KeyToExecutableEnum.OperaDeveloperEdition:
                    applicationToOpenDto.SecondaryFilePathSegment = @"Opera developer";
                    break;
                case KeyToExecutableEnum.PaintDotNet:
                    applicationToOpenDto.OpenIndividualFilesInFolderRatherThanFolderItself = true;
                    applicationToOpenDto.SecondaryFilePathSegment = @"Paint.NET";
                    applicationToOpenDto.DefaultTypicalFileExtensions = new List<string>
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
                case KeyToExecutableEnum.SQLServerManagementStudio:
                    applicationToOpenDto.ExcludeBinAndObjFoldersWhenOpeningProjectNode = true;
                    applicationToOpenDto.ExecutableFilesToBrowseFor = new List<string> { "ssms.exe", "ssmsee.exe", "SqlWb.exe" };
                    applicationToOpenDto.SecondaryFilePathSegment = @"Microsoft SQL Server\9999\Tools\Binn\ManagementStudio";
                    applicationToOpenDto.SecondaryFilePathSegmentHasMultipleVersions = true;
                    applicationToOpenDto.SeparateProcessPerFileToBeOpened = false;
                    applicationToOpenDto.UseShellExecute = true;
                    break;
                case KeyToExecutableEnum.TreeSizeFree:
                    applicationToOpenDto.ArtefactTypeToOpen = ArtefactTypeToOpen.Folder;
                    applicationToOpenDto.OpenIndividualFilesInFolderRatherThanFolderItself = false;
                    applicationToOpenDto.SecondaryFilePathSegment = @"JAM Software\TreeSize Free";
                    break;
                case KeyToExecutableEnum.TreeSizeProfessional:
                    applicationToOpenDto.ArtefactTypeToOpen = ArtefactTypeToOpen.Folder;
                    applicationToOpenDto.OpenIndividualFilesInFolderRatherThanFolderItself = false;
                    applicationToOpenDto.SecondaryFilePathSegment = @"JAM Software\TreeSize";
                    break;
                case KeyToExecutableEnum.Vivaldi:
                    applicationToOpenDto.ProcessWithinProcess = true;
                    applicationToOpenDto.SecondaryFilePathSegment = @"Vivaldi\Application";
                    applicationToOpenDto.SeparateProcessPerFileToBeOpened = false;
                    ///////////////////////////////applicationToOpenDto.InitialFolderType = InitialFolderType.LocalApplicationData;
                    break;
                case KeyToExecutableEnum.VS2012:
                    applicationToOpenDto.ExcludeBinAndObjFoldersWhenOpeningProjectNode = true;
                    applicationToOpenDto.ExecutableFilesToBrowseFor = new List<string> { "devenv.exe" };
                    applicationToOpenDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 11.0\Common7\IDE";
                    applicationToOpenDto.SeparateProcessPerFileToBeOpened = false;
                    applicationToOpenDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.VS2013:
                    applicationToOpenDto.ExcludeBinAndObjFoldersWhenOpeningProjectNode = true;
                    applicationToOpenDto.ExecutableFilesToBrowseFor = new List<string> { "devenv.exe" };
                    applicationToOpenDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 12.0\Common7\IDE";
                    applicationToOpenDto.SeparateProcessPerFileToBeOpened = false;
                    applicationToOpenDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.VS2015:
                    applicationToOpenDto.ExcludeBinAndObjFoldersWhenOpeningProjectNode = true;
                    applicationToOpenDto.ExecutableFilesToBrowseFor = new List<string> { "devenv.exe" };
                    applicationToOpenDto.SecondaryFilePathSegment = @"Microsoft Visual Studio 14.0\Common7\IDE";
                    applicationToOpenDto.SeparateProcessPerFileToBeOpened = false;
                    applicationToOpenDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.VS2017Community:
                    applicationToOpenDto.ExcludeBinAndObjFoldersWhenOpeningProjectNode = true;
                    applicationToOpenDto.ExecutableFilesToBrowseFor = new List<string> { "devenv.exe" };
                    applicationToOpenDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Community\Common7\IDE";
                    applicationToOpenDto.SeparateProcessPerFileToBeOpened = false;
                    applicationToOpenDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.VS2017Enterprise:
                    applicationToOpenDto.ExcludeBinAndObjFoldersWhenOpeningProjectNode = true;
                    applicationToOpenDto.ExecutableFilesToBrowseFor = new List<string> { "devenv.exe" };
                    applicationToOpenDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Enterprise\Common7\IDE";
                    applicationToOpenDto.SeparateProcessPerFileToBeOpened = false;
                    applicationToOpenDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.VS2017Professional:
                    applicationToOpenDto.ExcludeBinAndObjFoldersWhenOpeningProjectNode = true;
                    applicationToOpenDto.ExecutableFilesToBrowseFor = new List<string> { "devenv.exe" };
                    applicationToOpenDto.SecondaryFilePathSegment = @"Microsoft Visual Studio\2017\Professional\Common7\IDE";
                    applicationToOpenDto.SeparateProcessPerFileToBeOpened = false;
                    applicationToOpenDto.UseShellExecute = false;
                    break;
                case KeyToExecutableEnum.WinDirStat:
                    applicationToOpenDto.ArtefactTypeToOpen = ArtefactTypeToOpen.Folder;
                    applicationToOpenDto.OpenIndividualFilesInFolderRatherThanFolderItself = false;
                    applicationToOpenDto.SecondaryFilePathSegment = @"WinDirStat";
                    break;
                case KeyToExecutableEnum.XamarinStudio:
                    applicationToOpenDto.SecondaryFilePathSegment = @"Xamarin Studio\bin";
                    break;
                default:
                    applicationToOpenDto.SecondaryFilePathSegment = null;
                    ///////////////////////////////applicationToOpenDto.InitialFolderType = InitialFolderType.None;
                    break;
            }

            return applicationToOpenDto;
        }
    }
}
