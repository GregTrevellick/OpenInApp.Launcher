using NUnit.Framework;
using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class FileHelperTests
    {
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
            var actual = CommonFileHelper.AreTypicalFileExtensions(fullFileNames, typicalFileExtensions);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [Category("I")]
        public void AreTypicalFileExtensionsGenericTest()
        {
            //Act
            var actual = CommonFileHelper.AreTypicalFileExtensions(
                new List<string> { ".", "txt", ".txt", "any.txt", "any.cs" },
                new List<string> { "*" });

            //Assert
            Assert.AreEqual(true, actual);
        }

        [Test()]
        [Category("U")]
        public void GetDefaultTypicalFileExtensionsAsCsvTest()
        {
            //Arrange
            var testList = new List<string> { "a", "b", "c" };

            //Act
            var actual = CommonFileHelper.GetDefaultTypicalFileExtensionsAsCsv(testList);

            //Assert
            Assert.AreEqual("a,b,c", actual);
        }

        [TestCase("a,b,c")]
        [Category("U")]
        public void GetTypicalFileExtensionAsListTest(string csvString)
        {
            //Arrange
            var expected = new List<string> { "a", "b", "c" };

            //Act
            var actual = CommonFileHelper.GetTypicalFileExtensionAsList(csvString);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [Category("I")]
        public void DoesFileExistTest()
        {
            //Act
            var actual = CommonFileHelper.DoesFileExist(null);

            //Assert
            Assert.IsFalse(actual);
        }
    }
}