using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Strokes.Core.Integration;

namespace Strokes.FeatureAchievements
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [ProvideAutoLoad("{adfc4e64-0397-11d1-9f4e-00a0c911004f}")]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(GuidList.guidStrokes_FeatureAchievementsPkgString)]
    public sealed class FeatureAchievementsPackage : Package
    {
        #region Package Members
        protected override void Initialize()
        {
            base.Initialize();
            var als = GetService<IAchevementLibraryService>();
            als.RegisterAchievementAssembly(GetType().Assembly);
        }
        #endregion

        #region Tool methods
        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
        #endregion
    }
}
