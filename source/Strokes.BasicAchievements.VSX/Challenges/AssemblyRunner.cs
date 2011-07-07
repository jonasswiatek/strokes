using System;
using System.IO;
using System.Reflection;
using System.Linq;

namespace Strokes.BasicAchievements.Challenges
{
    /// <summary>
    /// Run a type in an assembly - call static <see cref="RunInNewDomain"/>
    /// </summary>
    /// <remarks>
    /// Note this has to inherit from MarshalByRefObject.
    /// <para/>
    /// Calls a static method named Run.
    /// </remarks>
    /// <example>
    /// <code>
    ///     string typeName = "TestMe.RunMe";
    ///     string assemblyPath = @"C:\TestMe\bin\Debug\TestMe.dll";
    ///     AssemblyRunner.RunInNewDomain(typeName, assemblyPath);
    ///     //calls TestMe.RunMe.Start();
    /// </code>
    /// </example>
    [Serializable]
    public class AssemblyRunner : MarshalByRefObject
    {

        /// <summary>
        /// Runs the specified type name in a new domain.
        /// </summary>
        /// <param name="assemblyPath">The assembly path.</param>
        /// <param name="typeName">Name of the type.</param>
        public static void RunInNewDomain(string assemblyPath, string typeName)
        {
            if (!File.Exists(assemblyPath))
                throw new FileNotFoundException("File not found", assemblyPath);

            //create a new domain with a config
            var setup = new AppDomainSetup();

            //directory where the dll and dependencies are
            setup.ApplicationBase = Path.GetDirectoryName(assemblyPath);
            setup.ApplicationName = "AssemblyRunner";

            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
                                                           {
                                                               if (args.Name.Contains("BasicAchievements"))
                                                               {
                                                                   return Assembly.GetExecutingAssembly();
                                                               }

                                                               return null;
                                                           };

            //Create the new domain
            var domain = AppDomain.CreateDomain("AssemblyRunner", null, setup);
            try
            {
                var location = Assembly.GetExecutingAssembly().Location;

                //load this assembly/ type into the new domain
                var runner = (AssemblyRunner)domain.CreateInstanceFromAndUnwrap(location, typeof(AssemblyRunner).FullName);

                //other instance of this class in new domain loads dll
                runner.LoadDll(assemblyPath, typeName);
            }
            finally
            {
                //unload domain
                AppDomain.Unload(domain);
                
            }
        }

        private string _oldConfigPath;

        /// <summary>
        /// Loads the DLL (this should be run in a different domain)
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="typeName">Name of the type.</param>
        public void LoadDll(string filePath, string typeName)
        {
            if (!File.Exists(filePath)) return;

            string location = Path.GetDirectoryName(filePath);

            //resolve any dependencies
            AppDomain.CurrentDomain.AssemblyResolve +=
                delegate(object sender, ResolveEventArgs args)
                {
                    string findName = args.Name;
                    string simpleName = new AssemblyName(findName).Name;
                    string assemblyPath = Path.Combine(location, simpleName) + ".dll";

                    if (File.Exists(assemblyPath))
                        return Assembly.LoadFrom(assemblyPath);

                    //can't find it
                    return null;
                };

            //load the assembly into bytes and load it
            byte[] assemblyBytes = File.ReadAllBytes(filePath);
            var a = Assembly.Load(assemblyBytes);

            //find the type in the assembly
            var t = a.GetType(typeName, true);

            //find the method "Run"
            var test = t.GetMethod("Test");
            var result = test.Invoke(null, new []{location});

            var bla = "";
        }
    }
}
