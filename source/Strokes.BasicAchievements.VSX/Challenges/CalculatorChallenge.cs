using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using Strokes.Challenges.Student;
using Strokes.Core;

namespace Strokes.BasicAchievements.Challenges
{
    /// <summary>
    /// A proof of concept of a challenge-type achievement.
    /// 
    /// This Proof of Concept needs to be tested further, namely the following issues need to be addressed:
    /// 1) Which assemblies are the build output is completely disorganized. The Strokes.VSX extension should have a "Project build output"-object that specifies these things in greater detail
    /// 2) Optimally, we'll ship a project type template for challenges - this is beneficial for many reasons:
    ///     A) Students don't need to be explained how to reference a dll-file some where on the file system
    ///     B) Makes it more obvious if a project should even be tested for challenges. Testing for a challenge can be a resource intensive process.
    /// </summary>
    [AchievementDescription("Calculator", AchievementDescription = "Implement the ICalculator interface", AchievementCategory = "Challenges")]
    public class CalculatorChallenge : Achievement 
    {
        public override bool DetectAchievement(DetectionSession detectionSession)
        {
            if (string.IsNullOrEmpty(detectionSession.BuildInformation.ContainingProject))
                return false;

            //Some string hackery
            var path = Path.Combine(Path.GetDirectoryName(detectionSession.BuildInformation.ContainingProject), "bin", "debug"); //Should come from project output dir rather than assuming defaults
            var dlls = new List<string>();

            //Some directory listing hackery
            dlls.AddRange(Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories).Where(file => file.IndexOf("vshost") < 0));
            dlls.AddRange(Directory.GetFiles(path, "*.exe", SearchOption.AllDirectories).Where(file => file.IndexOf("vshost") < 0));

            //If the Strokes.Challenges.Student-dll isn't in the build output, this project can with certainty be said to not be a challenge-solve attempt.
            if (!dlls.Any(dll => dll.Contains("Strokes.Challenges.Student.dll")))
                return false;

            /*
             * Subscribe to the AssemblyResolve event - this is required because we need to share the AssemblyContext of the Strokes.Challenges.Student-assembly.
             */
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
                                                           {
                                                               if(args.Name.Contains("Strokes.Challenges.Student"))
                                                               {
                                                                   return typeof (ICalculator).Assembly;
                                                               }

                                                               return null;
                                                           };

            /*
             * Some basic settings for our new app domain. We isolate the test-process in a seperate app domain that can be disposed.
             * If we don't, then the project output of the external project will be locked, and can't compile anymore
             */
            var setup = new AppDomainSetup
                            {
                                ApplicationBase = path,
                                PrivateBinPath = path,
                                ApplicationName = "Calculator Runner"
                            };

            //Create the new domain
            var domain = AppDomain.CreateDomain("CalculatorRunner", null, setup);
            try
            {
                //Get a reference to CalculatorTestRunner inside the new domain (strings are simply required here)
                var calculatorTester = (CalculatorTestRunner)domain.CreateInstanceAndUnwrap("Strokes.Challenges.Student",
                                                                      "Strokes.Challenges.Student.CalculatorTestRunner");

                //Pass all the paths to the external project output, to the Tester inside the new AppDomain
                foreach (var dll in dlls.Where(a => !a.Contains("Strokes.Challenges.Student.dll")))
                {
                    var result = calculatorTester.Run(dll);
                    if(result)
                    {
                        //Yeeeeaaaaaaaa
                        return true;
                    }
                }
            }
            finally
            {
                //unload domain
                AppDomain.Unload(domain);
            }

            //Achievement didn't pass
            return false;
        }
    }
}