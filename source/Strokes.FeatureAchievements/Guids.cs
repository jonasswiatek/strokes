// Guids.cs
// MUST match guids.h
using System;

namespace Strokes.FeatureAchievements
{
    static class GuidList
    {
        public const string guidStrokes_FeatureAchievementsPkgString = "332b68ad-b16a-47c7-ac8b-a8d30aade04e";
        public const string guidStrokes_FeatureAchievementsCmdSetString = "5d0265ed-d35f-424a-957f-e6d860e1e14a";

        public static readonly Guid guidStrokes_FeatureAchievementsCmdSet = new Guid(guidStrokes_FeatureAchievementsCmdSetString);
    };
}