using System;

namespace Strokes.Challenges.TwitterChallenge
{
    public interface ITwitter
    {
        // Checks if message is less than 140 characters
        bool CheckMessageLength(string message);

        // Should return string "additionalMessage RT @[originalSender] [originalMessage]" 
        string ComposeRetweetMessage(string originalmessage, string originalSender, string additionalMessage);
    }
}