namespace Strokes.Challenges.CaesarChallenge
{
    public class CaesarTest : AbstractChallengeTester<ICaesar>
    {
        public override TestableChallengeResult TestImplementation(ICaesar implementation)
        {
            //A Caesarmodule was implemented in the external project - test it's methods.

            char[] testarray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            try
            {
                for (int key = 0; key < 26; key++)
                {
                    
                    if (!CompareArray(implementation.Encrypt(testarray, key),CaesarEncrypt(testarray, key)))
                        return new TestableChallengeResult();
                    if (!CompareArray(implementation.Decrypt(testarray, key),CaesarDecrypt(testarray, key)))
                        return new TestableChallengeResult();
                }
            }
            catch
            {
                return new TestableChallengeResult();
            }

            //All methods passed, so yay!
            return new TestableChallengeResult() {IsPassed = true};
        }

        private bool CompareArray(char[] p, char[] p_2)
        {
            if (p.Length != p_2.Length)
                return false;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] != p_2[i])
                    return false;
            }
            return true;
        }

        private char[] CaesarDecrypt(char[] testarray, int key)
        {
            char[] result = new char[testarray.Length];

            for (int i = 0; i < testarray.Length; i++)
            {
                result[i] = (char)(testarray[i] - key);
                if (result[i] > 'z')
                    result[i] = (char)(result[i] - 26);
                if (result[i] < 'a')
                    result[i] = (char)(result[i] + 26);
            }
            return result;
        }

        private char[] CaesarEncrypt(char[] testarray, int key)
        {
            char[] result = new char[testarray.Length];

            for (int i = 0; i < testarray.Length; i++)
            {
                result[i]=(char)(testarray[i]+key);
                if(result[i] > 'z')
                    result[i] =(char)(result[i] - 26);
                if(result[i] <'a')
                    result[i] =(char)(result[i] + 26);
            }
            return result;
        }
    }
}
