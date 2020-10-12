using System;

namespace MoodAnalyser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to mood analyzer program");
            Console.WriteLine("How are you feeling: Happy or sad");
            string mood = Console.ReadLine();
            MoodAnalyserClass moodAnalyserClass = new MoodAnalyserClass(mood);
            Console.WriteLine("Your current mood: " + moodAnalyserClass.AnalyseMood());
        }
    }
}