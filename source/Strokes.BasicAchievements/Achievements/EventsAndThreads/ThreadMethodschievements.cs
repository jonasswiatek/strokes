using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using Strokes.BasicAchievements.NRefactory;
using Strokes.BasicAchievements.NRefactory.CodeBaseAnalysis;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;

namespace Strokes.BasicAchievements.Achievements
{
    [AchievementDescriptor("{cf9be271-1adb-4d4a-beaa-a5a83c6c9393}", "@StartThreadAchievementName",
        AchievementDescription = "@StartThreadAchievementDescription",
        HintUrl = "http://msdn.microsoft.com/en-us/library/system.threading.thread.aspx",
        AchievementCategory = "@EventsThreads")]
    public class StartThreadAchievement : AbstractSystemTypeUsage
    {
        public StartThreadAchievement() : base(typeof(System.Threading.Thread), "Start")
        {
        }
    }

    [AchievementDescriptor("{5dc86ab1-b723-4504-bd97-3473ab3ec149}", "@JoinThreadAchievementName",
        AchievementDescription = "@JoinThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class JoinThreadAchievement : AbstractSystemTypeUsage
    {
        public JoinThreadAchievement() : base(typeof(System.Threading.Thread), "Join")
        {
        }
    }


    [AchievementDescriptor("{4c5a6472-0a60-46d9-979b-c72746b76b7e}", "@AbortThreadAchievementName",
        AchievementDescription = "@AbortThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class AbortThreadAchievement : AbstractSystemTypeUsage
    {
        public AbortThreadAchievement() : base(typeof(System.Threading.Thread), "Abort")
        {
        }
    }

    [AchievementDescriptor("{B45780D7-0112-403D-9076-3DFB1E462D3C}", "@SleepThreadAchievementName",
        AchievementDescription = "@SleepThreadAchievementDescription",
        AchievementCategory = "@EventsThreads")]
    public class SleepThreadAchievement : AbstractSystemTypeUsage
    {
        public SleepThreadAchievement() : base(typeof(System.Threading.Thread), "Sleep")
        {
        }
    }
}