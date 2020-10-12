using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyserClass
    {
        private string message;
        public MoodAnalyserClass(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            if (message.ToUpper().Contains("SAD"))
                return "Sad Mood";
            else
                return "Happy Mood";
        }
    }
}