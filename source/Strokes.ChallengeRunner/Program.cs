using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Strokes.Challenges;

namespace Strokes.ChallengeRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var testResult = new TestableChallengeResult();

            try
            {
                if (args.Length != 2)
                {
                    throw new ArgumentException("Two arguments were not supplied");
                }

                var targetDirectory = args[0].Replace("*", " ");
                var targetChallenge = args[1];

                //Load all assemblies in targetDirectory
                var assemblies = new List<string>();

                //Some directory listing hackery
                assemblies.AddRange(Directory.GetFiles(targetDirectory, "*.dll", SearchOption.AllDirectories).Where(file => file.IndexOf("vshost") < 0));
                assemblies.AddRange(Directory.GetFiles(targetDirectory, "*.exe", SearchOption.AllDirectories).Where(file => file.IndexOf("vshost") < 0));

                Type targetType = null;

                //Find targetChallenge-type in the found assemblies
                foreach(var file in assemblies)
                {
                    var assembly = Assembly.LoadFrom(file);
                    var types = assembly.GetTypes();

                    targetType = types.SingleOrDefault(a => a.FullName == targetChallenge);
                    if (targetType != null)
                        break;
                }

                var methodInfo = targetType.GetMethod("TestChallenge");
                if (methodInfo == null)
                {
                    throw new Exception("The TestChallenge method was not found in the target type: " + targetType.FullName);
                }

                var instance = Activator.CreateInstance(targetType);

                var invokeResult = methodInfo.Invoke(instance, new[] { targetDirectory });
                testResult = DeepClone<TestableChallengeResult>(invokeResult);
                //Copy fields from the type in the foreign assembly into the type from this context
                /*var fields = typeof (TestableChallengeResult).GetFields();
                foreach(var field in fields)
                {
                    var foreignField = invokeResult.GetType().GetField(field.Name);
                    var value = foreignField.GetValue(invokeResult);
                    field.SetValue(testResult, value);
                }*/
            }
            catch(Exception e)
            {
                testResult.Error = e.Message + "\r\n" + e.StackTrace;
            }

            var serializer = new XmlSerializer(typeof(TestableChallengeResult));
            serializer.Serialize(Console.Out, testResult);
        }

        public static T DeepClone<T>(object obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}