using NUnit.Framework;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class ArtefactsHelperTests100
    {
        [Test()]
        [Category("I")]
        public void DoesActualPathToExeExistTest_Null()
        {
            //Act
            var actual = ArtefactsHelper.DoesActualPathToExeExist(null);

            //Assert
            Assert.IsFalse(actual);
        }

        [Test()]
        [Category("I")]
        public void DoesActualPathToExeExistTest_Empty()
        {
            //Act
            var actual = ArtefactsHelper.DoesActualPathToExeExist(string.Empty);

            //Assert
            Assert.IsFalse(actual);
        }

        [Test()]
        [Category("I")]
        public void DoesActualPathToExeExistTest_NotFound()
        {
            //Act
            var actual = ArtefactsHelper.DoesActualPathToExeExist("abcdefghijklmnopqrstuvwxyz");

            //Assert
            Assert.IsFalse(actual);
        }

        [Test()]
        [TestCase("", "", ArtefactTypeToOpen.File, false)]
        [TestCase("", "", ArtefactTypeToOpen.Folder, false)]
        [TestCase("", "abcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.File, false)]
        [TestCase("", "abcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.Folder, false)]
        [TestCase("abcdefghijklmnopqrstuvwxyz", "abcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.File, false)]
        [TestCase("abcdefghijklmnopqrstuvwxyz", "abcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.Folder, false)]
        [TestCase(@"C:\Temp", "abcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.File, false)]
        [TestCase(@"C:\Temp", "abcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.Folder, false)]
        [TestCase(@"C:\Temp", "", ArtefactTypeToOpen.File, false)]
        [TestCase(@"C:\Temp", "", ArtefactTypeToOpen.Folder, false)]
        [TestCase(@"C:\Temp", @"C:\Temp", ArtefactTypeToOpen.File, false)]
        [TestCase(@"C:\Temp", @"C:\Temp", ArtefactTypeToOpen.Folder, true)]
        [TestCase(@"C:\Temp", @"C:\Tempabcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.Folder, true)]
        [TestCase(@"C:\Temp\pagefile.sys", @"C:\Temp\pagefile.sys", ArtefactTypeToOpen.File, true)]
        [TestCase(@"C:\Temp\pagefile.sys", @"C:\Temp\pagefile.sys", ArtefactTypeToOpen.Folder, false)]
        [TestCase(@"C:\Temp\pagefile.sys", @"C:\Temp\pagefile.sysabcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.File, true)]
        [Category("I")]
        public void DoArtefactsExistTest(string string1, string string2, ArtefactTypeToOpen artefactTypeToOpen, bool expected)
        {
            //Arrange
            var fullArtefactNames = new List<string> { string1, string2 };

            //Act
            var actual = ArtefactsHelper.DoArtefactsExist(fullArtefactNames, artefactTypeToOpen);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
