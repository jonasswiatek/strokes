using System;

namespace Strokes.Challenges.CalculatorChallenge
{
    public class CalculatorTest : AbstractChallengeTester<ICalculator>
    {
        public override bool TestImplementation(ICalculator implementation)
        {
            //A calculator was implemented in the external project - test it's methods.
            var random = new Random();

            //Some random numbers
            var a = random.Next(1000);
            var b = random.Next(1000);

            try
            {
                //Test ADD method
                if (a + b != implementation.Add(a, b))
                    return false;

                //Test the SUBTRACT method
                if (a - b != implementation.Subtract(a, b))
                    return false;

                //Test the MULTIPLY method
                if (a * b != implementation.Multiply(a, b))
                    return false;

                //Test the DIVIDE method
                var result = (a * 1f) / (b * 1f);
                if (result != implementation.Divide(a, b))
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
