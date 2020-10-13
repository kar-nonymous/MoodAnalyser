using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    //UC4
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyserObject(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            var result = Regex.Match(className, pattern);
            if(result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyserType);
                    return res;
                }
                catch(NullReferenceException)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "class not found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "constructor not found");
            }
        }
        //UC 5
        public static object CreateMoodAnalyserParameterisedObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyserClass);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo construct = type.GetConstructor(new[] { typeof(string) });
                    Object obj = construct.Invoke(new object[] { message });
                    return obj;
                }
                else
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CONSTRUCTOR, "constructor not found");
            }
            else
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "class not found");
        }
        //UC6
        public static string InvokeAnalyserMethod(string method, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyser.MoodAnalyserClass");
                MethodInfo methodInfo = type.GetMethod(methodName);
                object moodAnalyserObject = CreateMoodAnalyserParameterisedObject("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass", "happy");
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHOD, "method not found");
            }
        }
    }
}
