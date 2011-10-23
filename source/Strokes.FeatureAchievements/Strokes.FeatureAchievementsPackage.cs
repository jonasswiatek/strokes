using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Strokes.Core.Integration;
using Strokes.Core.Service;

namespace Strokes.FeatureAchievements
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [ProvideAutoLoad("{adfc4e64-0397-11d1-9f4e-00a0c911004f}")]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(GuidList.guidStrokes_FeatureAchievementsPkgString)]
    public sealed class FeatureAchievementsPackage : Package
    {
        public IdeIntegrationAchievementObserver AchievementObserver;
        public IAchievementService AchievementService;
        #region Package Members
        protected override void Initialize()
        {
            base.Initialize();

            var als = GetService<IAchievementLibraryService>();
            als.RegisterAchievementAssembly(GetType().Assembly);

            /* This is not resolved using StructureMap, but rather Visual Studios internal thingy for this.
             * The reason is that because this is a VSX package, it will be initialized in it's own context and it's own thread.
             */
            AchievementService = GetService<IAchievementService>();
            AchievementObserver = new IdeIntegrationAchievementObserver(this, AchievementService);
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
