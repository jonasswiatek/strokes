namespace Strokes.Challenges.TwitterChallenge
{
    public class TwitterTest : AbstractChallengeTester<ITwitter>
    {
        public override TestableChallengeResult TestImplementation(ITwitter implementation)
        {
            try
            {
                string testtoolongstring =
                    "This message is just too long to get inside a twit which only allows 140 characters. So this one should definitely give a false back.Let's see.";

                string okstring = "This one should be ok";

                string maxokstring =
                    "This one is right on the maximum but still should be pass. So let's hope our user indeed tested the maximum allowed value. Checking 1 , 2, 3";

                //CheckmessageTest
                if (implementation.CheckMessageLength(testtoolongstring))
                    return new TestableChallengeResult();
                if (!implementation.CheckMessageLength(okstring))
                    return new TestableChallengeResult();
                if(!implementation.CheckMessageLength(maxokstring))
                    return new TestableChallengeResult();
                

                //Compose RT
                string rtresult = @"Nice one RT @tdams That's funny";
                if(!implementation.ComposeRetweetMessage("That's funny", "tdams","Nice one").Equals(rtresult))
                    return new TestableChallengeResult();

                return new TestableChallengeResult() {IsPassed = true};
            }
            catch
            {
                return new TestableChallengeResult();
            }
        }
    }
}
