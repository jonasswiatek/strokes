using System;
using System.Collections.Generic;
using Strokes.Challenges.TwitterChallenge;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using System.Text;

namespace $rootnamespace$
{
	public class $safeitemrootname$ : ITwitter
	{
        //Checks if message is less than 140 characters
        public bool CheckMessageLength(string message)
	    {
	        throw new NotImplementedException();
	    }

        //Should return string "additionalMessage RT @[originalSender] [originalMessage]" 
        public string ComposeRetweetMessage(string  originalmessage, string originalSender, string additionalMessage)
	    {
	        throw new NotImplementedException();
	    }
	}
}
