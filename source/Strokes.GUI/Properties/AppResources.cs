using System;

namespace Strokes.GUI.Properties
{
    public class AppResources
    {
        private static Resources resources = new Resources();

        public Resources Resources
        {
            get
            {
                return resources;
            }
        }
    }

    public static class GuiResources
    {
        private static Resources resources = new Resources();

        public static Resources Resources
        {
            get
            {
                return resources;
            }
        }
    }
}
