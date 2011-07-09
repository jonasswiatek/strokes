using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Strokes.Challenges.Student
{
    public interface ICalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        float Divide(int a, int b);
    }

    public class CalculatorTest
    {
        public static bool TestChallenge(string outputDirectory)
        {
            var assemblies = new List<string>();

            //Some directory listing hackery
            assemblies.AddRange(Directory.GetFiles(outputDirectory, "*.dll", SearchOption.AllDirectories).Where(file => file.IndexOf("vshost") < 0));
            assemblies.AddRange(Directory.GetFiles(outputDirectory, "*.exe", SearchOption.AllDirectories).Where(file => file.IndexOf("vshost") < 0));

            Type calculatorImplType = null;

            foreach (var file in assemblies.Where(c => !c.Contains("Strokes.Challenges.Student")))
            {
                var assembly = Assembly.LoadFrom(file);
                var types = assembly.GetTypes();

                calculatorImplType = types.SingleOrDefault(c => typeof (ICalculator).IsAssignableFrom(c));

                if (calculatorImplType != null)
                    break;
            }

            var externalCalculatorImplementation = calculatorImplType != null ? Activator.CreateInstance(calculatorImplType) as ICalculator : null;

            //No calculator implementation was found, so return false.
            if (externalCalculatorImplementation == null)
                return false;

            //A calculator was implemented in the external project - test it's methods.
            var random = new Random();

            //Some random numbers
            var a = random.Next(1000);
            var b = random.Next(1000);

            try
            {
                //Test ADD method
                if (a + b != externalCalculatorImplementation.Add(a, b))
                    return false;

                //Test the SUBTRACT method
                if (a - b != externalCalculatorImplementation.Subtract(a, b))
                    return false;

                //Test the MULTIPLY method
                if (a * b != externalCalculatorImplementation.Multiply(a, b))
                    return false;

                //Test the DIVIDE method
                var result = (a * 1f) / (b * 1f);
                if (result != externalCalculatorImplementation.Divide(a, b))
                    return false;
            }
            catch
            {
                return false;
            }

            //All methods passed, so yay!
            return true;
        }
    }
}
