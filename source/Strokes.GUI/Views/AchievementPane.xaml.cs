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
                    this.AchievementsCategoryListBox.SelectedIndex = 0;
                });
        }
    }
}
