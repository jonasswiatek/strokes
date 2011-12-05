using System;
using System.Globalization;
using System.ComponentModel;

namespace Strokes.GUI.Properties
{
    public class AppResources : INotifyPropertyChanged
    {
        private static AppResources instance;

        private AppResources()
        {
            this.Resources = new Resources();
        }

        public static AppResources Instance
        {
            get
            {
                if (instance == null)
                    instance = new AppResources();

                return instance;
            }
        }

#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public Resources Resources
        {
            get;
            set;
        }
    }
}
