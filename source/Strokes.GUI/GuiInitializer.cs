using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Strokes.Core;
using Strokes.Core.Service;
using Strokes.Core.Service.Model;
using Strokes.GUI.Views;
using StructureMap;

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
            var achievementService = ObjectFactory.GetInstance<IAchievementService>();
            achievementService.AchievementsUnlocked += AchievementContext_AchievementsUnlocked;
        }

        public delegate void AchievementClickedHandler(object sender, AchievementClickedEventArgs args);
        public static event AchievementClickedHandler AchievementClicked;

        public static void OnAchievementClicked(object sender, AchievementClickedEventArgs args)
        {
            if (AchievementClicked != null)
            {
                AchievementClicked(sender, args);
            }
        }

        /// <summary>
        /// Handles the AchievementsUnlocked event of the AchievementContext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">
        ///     The <see cref="Strokes.Core.AchievementsUnlockedEventArgs"/> instance containing the event data.
        /// </param>
        private static void AchievementContext_AchievementsUnlocked(object sender, AchievementEventArgs args)
        {
            if (args.UnlockedAchievements.Any())
            {
                Debug.WriteLine(string.Format("Achievements unlocked: {0}",
                    string.Join(", ", args.UnlockedAchievements.Select(a => "[" + a.Name + "]"))));

                AchievementNotificationBox.ShowAchievements(args.UnlockedAchievements);
            }
        }
    }

    public class AchievementClickedEventArgs
    {
        public Achievement AchievementDescriptor
        {
            get;
            set;
        }

        public object UIElement
        {
            get;
            set;
        }
    }
}