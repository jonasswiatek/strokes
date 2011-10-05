using System;

namespace CSharpAchiever.VSX
{
    /// <summary>
    /// List of GUIDs. Must match guids.h
    /// </summary>
    static class GuidList
    {
        public const string guidCSharpAchiever_Achiever_VSIXPkgString = "29f86376-691c-4ffd-a81a-b72937a6d439";
        public const string guidCSharpAchiever_Achiever_VSIXCmdSetString = "a1effc86-962a-4503-8467-af962e7245bb";

        public static readonly Guid guidCSharpAchiever_Achiever_VSIXCmdSet = new Guid(guidCSharpAchiever_Achiever_VSIXCmdSetString);
    };
}