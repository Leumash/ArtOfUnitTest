using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            // Arrange
            LogAnalyzer logAnalyzer = MakeLogAnalyzer();

            // Act
            bool result = logAnalyzer.IsValidLogFileName("SomeFileWithBadExtension.foo");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionUpperCase_ReturnsTrue()
        {
            // Arrange
            LogAnalyzer logAnalyzer = MakeLogAnalyzer();

            // Act
            bool result = logAnalyzer.IsValidLogFileName("FileWithValidExtension.SLF");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowerCase_ReturnsTrue()
        {
            // Arrange
            LogAnalyzer logAnalyzer = MakeLogAnalyzer();

            // Act
            bool result = logAnalyzer.IsValidLogFileName("FileWithValidExtension.slf");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidFileName_EmptyFilename_Throws()
        {
            LogAnalyzer logAnalyzer = MakeLogAnalyzer();

            var exception = Assert.Catch<Exception>(() => logAnalyzer.IsValidLogFileName(""));

            StringAssert.Contains("Filename must be provided.", exception.Message);
        }

        [TestCase("badFile.foo", false)]
        [TestCase("goodFile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string fileName, bool expected)
        {
            LogAnalyzer logAnalyzer = MakeLogAnalyzer();

            logAnalyzer.IsValidLogFileName(fileName);

            Assert.AreEqual(expected, logAnalyzer.WasLastFileNameValid);
        }

        private LogAnalyzer MakeLogAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}
