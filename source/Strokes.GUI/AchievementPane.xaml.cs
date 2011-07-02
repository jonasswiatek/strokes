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
            var achievements = AchievementTracker.GetAllAchievementDescriptors();
            AchievementStack.ItemsSource = achievements;
        }

    }
}
