using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Strokes.Challenges
{
    public abstract class AbstractChallengeTester<T> where T : class
    {
        public TestableChallengeResult TestChallenge(string targetDirectory)
        {
            var assemblies = new List<string>();

            //Some directory listing hackery
            assemblies.AddRange(Directory.GetFiles(targetDirectory, "*.dll", SearchOption.AllDirectories).Where(file => !file.Contains("vshost")));
            assemblies.AddRange(Directory.GetFiles(targetDirectory, "*.exe", SearchOption.AllDirectories).Where(file => !file.Contains("vshost")));

            Type implType = null;

            foreach (var file in assemblies.Where(c => !c.Contains("Strokes.Challenges")))
            {
                var assembly = Assembly.LoadFrom(file);
                var types = assembly.GetTypes();

                implType = types.SingleOrDefault(c => typeof(T).IsAssignableFrom(c));

                if (implType != null)
                    break;
            }

            var externalImplementation = implType != null ? Activator.CreateInstance(implType) as T : null;

            //No calculator implementation was found, so return false.
            if (externalImplementation == null)
                return new TestableChallengeResult();

            return TestImplementation(externalImplementation);
        }

        public abstract TestableChallengeResult TestImplementation(T implementation);
    }
}