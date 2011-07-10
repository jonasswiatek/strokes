namespace Strokes.Challenges.Student.CaesarChallenge
{
    public interface ICaesar
    {
        char[] Encrypt(char[] input, int key);
        char[] Decrypt(char[] input, int key);
    }
}