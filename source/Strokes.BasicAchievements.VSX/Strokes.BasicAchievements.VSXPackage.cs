using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Strokes_BasicAchievements_VSX;
using Microsoft.VisualStudio.Shell;
using Strokes.Core.Integration;

namespace Strokes.BasicAchievements
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(GuidList.guidStrokes_BasicAchievements_VSXPkgString)]
    //[ProvideAutoLoad("{f1536ef8-92ec-443c-9ed7-fdadf150da82}")] /* Autoload when the a solution is loaded */
    [ProvideAutoLoad("{adfc4e64-0397-11d1-9f4e-00a0c911004f}")]
    public sealed class Strokes_BasicAchievements_VSXPackage : Package
    {
        public Strokes_BasicAchievements_VSXPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        #region Package Members

        protected override void Initialize()
        {
            Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            var als = GetService<IAchevementLibraryService>();
            if (als != null)
            {
                als.RegisterAchievementAssembly(Assembly.GetExecutingAssembly());
            }
        }

        private T GetService<T>() where T : class
        {
            return GetService(typeof(T)) as T;
        }

        #endregion

    }
}
