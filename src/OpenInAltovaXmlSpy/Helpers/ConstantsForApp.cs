using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInAppAltovaXmlSpy.Helpers
{
	public class ConstantsForApp 
	{
        public static KeyToExecutableEnum KeyToExecutableEnum = KeyToExecutableEnum.XMLSpy;
        public static ActualPathToExeDto ActualPathToExeDto = new ActualPathToExeHelper().GetActualPathToExeDto(KeyToExecutableEnum);
        //public const string KeyToExecutable = OpenInApp.Common.Helpers.KeyToExecutable.XMLSpy;

        public IEnumerable<string> GetDefaultTypicalFileExtensions()
		{
			return new List<string>
			{
				//Source(s) http://manual.altova.com/XMLSpy/spyprofessional/index.html?filetypes.htm
				#region Extensions
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
		}


		internal static string Caption = Vsix.Name + " " + Vsix.Version;
        internal const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + "gregtKeyToExecutableEnum.Description()";
        internal static bool SeparateProcessPerFileToBeOpened = true;
		internal static bool UseShellExecute = true;
	}
}
