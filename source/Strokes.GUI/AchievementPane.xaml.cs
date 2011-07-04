using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Strokes.Core;
using Strokes.Data;

namespace Strokes.GUI
{
    /// <summary>
    /// Interaction logic for AchievementPane.xaml
    /// </summary>
    public partial class AchievementPane : UserControl
    {
        
        public AchievementPane()
        {
            InitializeComponent();

            InitAchievementList();
        }

        private void InitAchievementList()
        {
            var achievementDescriptorRepository = new AchievementDescriptorRepository();
            var achievs = achievementDescriptorRepository.GetAll(); //Please note that this method returns another object that the AchievementTracker.GetAllAchievementDescriptors(). It needs to be rewritten to run on this new dataobject (Strokes.Core.Model.AchievementDescriptor).

            var achievements = AchievementTracker.GetAllAchievementDescriptors();
                       
            AchievementStack.ItemsSource = achievements;
        }

    }
}
