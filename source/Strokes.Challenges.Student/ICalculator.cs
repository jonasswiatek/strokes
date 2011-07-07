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

    [Serializable]
    public class CalculatorTester : MarshalByRefObject
    {
        public bool Run(string assemblyToTest)
        {
            //Load the assembly we're testing;
            var assembly = Assembly.Load(File.ReadAllBytes(assemblyToTest), new byte[0]);

            ICalculator externalCalculatorImplementation = null;

            //See if we can find an implementation of ICalculator
            var assemblyTypes = assembly.GetTypes();

            var calculator = assemblyTypes.FirstOrDefault(t => typeof(ICalculator).IsAssignableFrom(t));
            if (calculator != null)
            {
                externalCalculatorImplementation = Activator.CreateInstance(calculator) as ICalculator;
            }

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
