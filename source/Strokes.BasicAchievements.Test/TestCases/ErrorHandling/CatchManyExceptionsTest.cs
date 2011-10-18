using System;
using Strokes.BasicAchievements.Achievements;

namespace Strokes.BasicAchievements.Test.TestCases.ErrorHandling
{
    [ExpectUnlock(typeof(TryCatchStatementAchievement))]
    [ExpectUnlock(typeof(CatchManyExceptionsAchievement))]
    public class CatchManyExceptionsTest
    {
        public void Main()
        {
            try
            {
                var s = "";
            }
            catch(NullReferenceException e)
            {
            }
            catch (ArgumentOutOfRangeException e)
            {
            }
            catch(ArgumentNullException e)
            {
            }
            catch (ArgumentException e)
            {
            }
            catch (AggregateException e)
            {
            }
            catch(Exception e)
            {
            }
        }
    }
}