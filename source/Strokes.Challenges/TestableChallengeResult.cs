using System;
using System.Collections.Generic;

namespace Strokes.Challenges
{
    [Serializable]
    public class TestableChallengeResult
    {
        public bool IsPassed;
        public List<ChallengeFeedbackMessage> Messages = new List<ChallengeFeedbackMessage>();
        public string Error = "";

        public void AddMessage(string messageHeading, string messageBody)
        {
            Messages.Add(new ChallengeFeedbackMessage()
                             {
                                 Heading = messageHeading,
                                 Message = messageBody
                             });
        }
    }

    [Serializable]
    public class ChallengeFeedbackMessage
    {
        public string Heading;
        public string Message;
    }
}