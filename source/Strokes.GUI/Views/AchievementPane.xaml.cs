using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using Strokes.Service.Data;
using StructureMap;

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

    public class ResetAchievementsMessage : MessageBase
    {
    }
}
