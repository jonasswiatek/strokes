using GalaSoft.MvvmLight.Messaging;

namespace Strokes.GUI
{
    public partial class AchievementPane
    {
        public AchievementPane()
        {
            InitializeComponent();
            
            Messenger.Default.Register<ResetAchievementsMessage>(this, 
                msg =>
                {
                    AchievementsCategoryListBox.SelectedIndex = 0;
                });
        }
    }

    public class ResetAchievementsMessage
    {
        public ResetAchievementsMessage()
        {            
        }
    }
}
