using System;
using System.Windows;
using CSharpAchiever.GUI.AchievementIndex;
using Strokes.Core;
using Strokes.CSharpCodeGraph.CocoR.Grammars;

namespace Strokes.Console
{
    public class TestFile : Strokes.Console.SomeClass, ISomeInterface, Strokes.Console.ISomeOtherInterface
    {
        public readonly static int aaa = 2, bbb = 4;
        private const int ccc = 5, rofl = 3;
        public static int ddd { get; private set; }
        int eee { get; set; }
        
        string fff = "";
        public TestFile(string someProperty)
        {
            int hhh = 2;
            const int blaaaaa = 2;
        }
    }

    public class SomeClass
    {
        
    }

    public enum Roflmao
    {
        Lol,
        kk
    }

    public struct SomeStruct
    {
        public int someInt;
        private float someFloat;
    }

    public interface ISomeInterface
    {
        
    }

    public interface ISomeOtherInterface : Strokes.Console.IBalls
    {

    }

    public interface IBalls
    {
        
    }
}