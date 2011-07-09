using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Strokes.Challenges.Student
{
    public abstract class AbstractChallengeTester<T> where T : class
    {
        public bool TestChallenge(string targetDirectory)
        {
            var assemblies = new List<string>();

            //Some directory listing hackery
            assemblies.AddRange(Directory.GetFiles(targetDirectory, "*.dll", SearchOption.AllDirectories).Where(file => file.IndexOf("vshost") < 0));
            assemblies.AddRange(Directory.GetFiles(targetDirectory, "*.exe", SearchOption.AllDirectories).Where(file => file.IndexOf("vshost") < 0));

            Type calculatorImplType = null;

            foreach (var file in assemblies.Where(c => !c.Contains("Strokes.Challenges.Student")))
            {
                var assembly = Assembly.LoadFrom(file);
                var types = assembly.GetTypes();

                calculatorImplType = types.SingleOrDefault(c => typeof(T).IsAssignableFrom(c));

                if (calculatorImplType != null)
                    break;
            }

            var externalCalculatorImplementation = calculatorImplType != null ? Activator.CreateInstance(calculatorImplType) as T : null;

            //No calculator implementation was found, so return false.
            if (externalCalculatorImplementation == null)
                return false;

            return TestImplementation(externalCalculatorImplementation);
        }
        public abstract bool TestImplementation(T implementation);
    }
}
