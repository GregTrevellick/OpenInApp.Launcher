using NUnit.Framework;
using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class CsvHelperTests
    {
        [Test()]
        [Category("I")]
        public void AreTypicalFileExtensionsGenericTest()
        {
            //Act
            var actual = CsvHelper.AreTypicalFileExtensions(
                new List<string> { ".", "txt", ".txt", "any.txt", "any.cs" },
                new List<string> { "*" });

            //Assert
            Assert.AreEqual(true, actual);
        }

        [Test()]
        [Category("U")]
        public void GetTypicalFileExtensionAsListTest_PopulatedMany()
        {
            //Arrange
            var expected = new List<string> { "a", "b", "c" };
            var csvString = "a,b,c";

            //Act
            var actual = CsvHelper.GetTypicalFileExtensionAsList(csvString);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [Category("U")]
        public void GetTypicalFileExtensionAsListTest_PopulatedSingle()
        {
            //Arrange
            var expected = new List<string> { "abc" };
            var csvString = "abc";

            //Act
            var actual = CsvHelper.GetTypicalFileExtensionAsList(csvString);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [Category("U")]
        public void GetTypicalFileExtensionAsListTest_Empty()
        {
            //Arrange
            var expected = new List<string>();
            var csvString = "";

            //Act
            var actual = CsvHelper.GetTypicalFileExtensionAsList(csvString);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [Category("U")]
        public void GetTypicalFileExtensionAsListTest_Null()
        {
            //Arrange
            var expected = new List<string>();

            //Act
            var actual = CsvHelper.GetTypicalFileExtensionAsList(null);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [Category("U")]
        public void GetFileTypeExtensionsTest_Null()
        {
            //Arrange
            var expected = new List<string>();

            //Act
            var actual = CsvHelper.GetFileTypeExtensions(null);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [Category("U")]
        public void GetFileTypeExtensionsTest_EmptyList()
        {
            //Arrange
            var expected = new List<string>();
            var fullFileNames = new List<string>();

            //Act
            var actual = CsvHelper.GetFileTypeExtensions(fullFileNames);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [Category("U")]
        public void GetFileTypeExtensionsTest_PopulatedList()
        {
            //Arrange
            var expected = new List<string> { ".exe", ".doc" };
            var fullFileNames = new List<string> { "a.exe", "b.doc", "c" };

            //Act
            var actual = CsvHelper.GetFileTypeExtensions(fullFileNames);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [TestCase("", false)]
        [TestCase(".", false)]
        [TestCase(".properties", true)]
        [TestCase(".propertis", false)]
        [TestCase(".xml", true)]
        [TestCase(".xsd", true)]
        [TestCase(".xslt", true)]
        [TestCase("a.properties", true)]
        [TestCase("BartSimpson.fest,wsd", false)]
        [TestCase("FredBloggs.x.ml", false)]
        [TestCase("HillsTrump.vs.DonnieClinton", false)]
        [TestCase("JaneDoe.xslt", true)]
        [TestCase("JoePublic.cs", false)]
        [TestCase("JohnDoe.Xml", true)]
        [TestCase("MadsKristensen.", false)]
        [TestCase("a.xs", false)]
        [TestCase("a.xsd", true)]
        [TestCase("a.xsdd", false)]
        [TestCase(null, false)]
        [Category("I")]
        public void AreTypicalFileExtensionsTest(string fileName, bool expected)
        {
            var fullFileNames = new List<string> { fileName };

            //Act
            var actual = CsvHelper.AreTypicalFileExtensions(fullFileNames, typicalFileExtensions);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private IEnumerable<string> typicalFileExtensions = new List<string>
        {
                "config",
                "csproj",
                "docx",
                "properties",
                "runsettings",
                "settings",
                "vsixmanifest",
                "wsdl",
                "xml",
                "xsd",
                "xslt",
        };

    }
}