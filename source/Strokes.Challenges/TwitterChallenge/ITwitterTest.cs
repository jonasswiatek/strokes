namespace Strokes.Challenges.TwitterChallenge
{
    public class TwitterTest : AbstractChallengeTester<ITwitter>
    {
        public override bool TestImplementation(ITwitter implementation)
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
                    return false;
                if (!implementation.CheckMessageLength(okstring))
                    return false;
                if(!implementation.CheckMessageLength(maxokstring))
                    return false;
                

                //Compose RT
                string rtresult = @"Nice one RT @tdams That's funny";
                if(!implementation.ComposeRetweetMessage("That's funny", "tdams","Nice one").Equals(rtresult))
                    return false;

                return true;
                
            
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
