using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Strokes.Core;
using Strokes.GUI.Views;

namespace Strokes.GUI
{
    public class GuiInitializer
    {
        /// <summary>
        /// This method is called by the Strokes Visual Studio Extension when it is loaded.
        /// 
        /// This method should subscribe to the AchievementContext.AchievementsUnlocked-event, 
        /// and appropriately handle those (i.e. display stuff on the screen).
        /// 
        /// All handling of achievement persistance should NO LONGER be handled in this project. 
        /// This project must redact all references to AchievementTracker in Strokes.Core (this class is to be deleted).
        /// </summary>
        public static void Initialize()
        {
            AchievementContext.AchievementsUnlocked += AchievementContext_AchievementsUnlocked;
        }

        /// <summary>
        /// Handles the AchievementsUnlocked event of the AchievementContext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">
        ///     The <see cref="Strokes.Core.AchievementsUnlockedEventArgs"/> instance containing the event data.
        /// </param>
        private static void AchievementContext_AchievementsUnlocked(object sender, AchievementsUnlockedEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("Achievements unlocked: " 
                + string.Join(", ", args.Achievements.Select(a => a.Name)));

            //MainAchievementManyGui many = new MainAchievementManyGui(args.Achievements);
            AchievementNotificationBox.ShowAchievements(args.Achievements);
        }
    }
}