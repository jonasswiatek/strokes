using System;

namespace Strokes.Challenges.CalculatorChallenge
{
    public class CalculatorTest : AbstractChallengeTester<ICalculator>
    {
        public override TestableChallengeResult TestImplementation(ICalculator implementation)
        {
            var testResult = new TestableChallengeResult();
            //A calculator was implemented in the external project - test it's methods.
            var random = new Random();

            //Some random numbers
            var a = random.Next(1000);
            var b = random.Next(1000);

            try
            {
                //Test ADD method
                var addResult = implementation.Add(a, b);
                var addPassed = false;
                if (a + b == addResult)
                {
                    addPassed = true;
                }
                else
                {
                    testResult.AddMessage("Add method failed", string.Format("Tested with a = {0} and b = {1}, and yielded result: {2}", a, b, addResult));
                }

                //Test the SUBTRACT method
                var subtractResult = implementation.Subtract(a, b);
                var subtractPassed = false;
                if (a - b == subtractResult)
                {
                    subtractPassed = true;
                }
                else
                {
                    testResult.AddMessage("Subtract method failed", string.Format("Tested with a = {0} and b = {1}, and yielded result: {2}", a, b, subtractResult));
                }

                //Test the MULTIPLY method
                var multiplyResult = implementation.Multiply(a, b);
                var multiplyPassed = false;
                if (a * b == multiplyResult)
                {
                    multiplyPassed = true;
                }
                else
                {
                    testResult.AddMessage("Multiply method failed", string.Format("Tested with a = {0} and b = {1}, and yielded result: {2}", a, b, multiplyResult));
                }

                //Test the DIVIDE method
                var divideResult = implementation.Divide(a, b);
                var dividePassed = false;
                if ((a * 1f) / (b * 1f) == divideResult)
                {
                    dividePassed = true;
                }
                else
                {
                    testResult.AddMessage("Divide method failed", string.Format("Tested with a = {0} and b = {1}, and yielded result: {2}", a, b, divideResult));
                }

                testResult.IsPassed = addPassed && subtractPassed && multiplyPassed && dividePassed;
            }
            catch
            {
                testResult.AddMessage("Challenge testing failed", "One of more methods threw an exception");
            }

            return testResult;
        }
    }
}
