using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;

namespace MSTestMoodAnalyser
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSadMoodShouldReturnSad()
        {
            //Arrange
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass("I am in sad mood");
            string expected = "Sad Mood";
            //Act
            string actual = moodAnalyserClass.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenAnyMoodShouldReturnHappy()
        {
            //Arrange
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass("I am in any mood");
            string expected = "Happy Mood";
            //Act
            string actual = moodAnalyserClass.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenNullShouldReturnHappy()
        {
            //Arrange
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(null);
            string expected = "Happy Mood";
            //Act
            string actual = moodAnalyserClass.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual)
        }
    }
}