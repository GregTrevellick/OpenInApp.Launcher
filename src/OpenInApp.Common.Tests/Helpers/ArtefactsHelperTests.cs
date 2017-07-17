using NUnit.Framework;
using OpenInApp.Common.Helpers;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInApp.Common.Tests.Helpers
{
    [TestFixture()]
    public class ArtefactsHelperTests
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
        [TestCase(@"C:\Windows", "abcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.File, false)]
        [TestCase(@"C:\Windows", "abcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.Folder, false)]
        [TestCase(@"C:\Windows", "", ArtefactTypeToOpen.File, false)]
        [TestCase(@"C:\Windows", "", ArtefactTypeToOpen.Folder, false)]
        [TestCase(@"C:\Windows", @"C:\Windows", ArtefactTypeToOpen.File, false)]
        [TestCase(@"C:\Windows", @"C:\Windows", ArtefactTypeToOpen.Folder, true)]
        [TestCase(@"C:\Windows", @"C:\Tempabcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.Folder, false)]
        [TestCase(@"C:\pagefile.sys", @"C:\pagefile.sys", ArtefactTypeToOpen.File, true)]
        [TestCase(@"C:\pagefile.sys", @"C:\pagefile.sys", ArtefactTypeToOpen.Folder, false)]
        [TestCase(@"C:\pagefile.sys", @"C:\pagefile.sysabcdefghijklmnopqrstuvwxyz", ArtefactTypeToOpen.File, false)]
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
