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
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenNullShouldGiveCustomException()
        {
            try
            {
                //Arrange
                MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(null);
                //Act
                string actual = moodAnalyserClass.AnalyseMood();
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("Mood should not be null", exception.Message);
            }
        }
        [TestMethod]
        public void GivenEmptyShouldGiveCustomException()
        {
            //Arrange
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(" ");
            string expected = "Mood should not be empty";
            //Act
            string actual = moodAnalyserClass.AnalyseMood();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenMoodAnalyserClassNameShouldReturnMoodAnalyserObject()
        {
            //Arrange
            var expected = new MoodAnalyserClass();
            //Act
            object result = MoodAnalyserFactory.CreateMoodAnalyserObject("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");
            //Assert
            expected.Equals(result);
        }
        [TestMethod]
        public void GivenImproperClassNameShouldThrowMoodAnalysisException()
        {
            try
            {
                //Act
                object result = MoodAnalyserFactory.CreateMoodAnalyserParameterisedObject("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass", "I'm happy");
            }
            catch (MoodAnalyserCustomException exception)
            {
                //Assert
                Assert.AreEqual("class not found", exception.Message);
            }
        }
    }
}