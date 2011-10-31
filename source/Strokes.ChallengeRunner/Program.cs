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

                /* Deep Clone the result into a TestableChallengeResult.
                 * We need to do it like this (instead of just casting it to TestableChallengeResult),
                 * because the TestableChallengeResult type of the invoked result is from another assembly. This is not allowed in .NET Framework.
                 * It will however serialize into a TestableChallengeResult just fine, because they (by the way the solution is structured), can be
                 * guaranteed to be identical */
                testResult = DeepClone<TestableChallengeResult>(invokeResult);
            }
            catch(Exception e)
            {
                testResult.Error = e.Message + "\r\n" + e.StackTrace;
            }

            /* XmlSerialize the challenge result, so it can be transported to the strokes extension via standard output */
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