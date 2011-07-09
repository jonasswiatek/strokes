using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Strokes.ChallengeRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var targetDirectory = args[0];
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
                return;

            var result = (bool)methodInfo.Invoke(null, new[] {targetDirectory});

            Console.WriteLine(result ? "OK" : "FAILED");
        }
    }
}