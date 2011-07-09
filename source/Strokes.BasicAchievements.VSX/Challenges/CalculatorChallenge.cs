using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strokes.Core;

namespace Strokes.BasicAchievements.Challenges
{
    [AchievementDescription("Calculator", AchievementDescription = "Implement the ICalculator interface", AchievementCategory = "Challenges")]
    public class CalculatorChallenge : Challenge
    {
        public CalculatorChallenge() : base("Strokes.Challenges.Student.CalculatorTest") // Strokes.Challenges.Student.CalculatorTest is the class in Strokes.Challenges.Student that can test the challenge implementation.
        {
        }
    }
}
