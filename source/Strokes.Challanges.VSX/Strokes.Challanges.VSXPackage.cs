using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Strokes.Core.Integration;

namespace Microsoft.Strokes_Challanges_VSX
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideAutoLoad("{f1536ef8-92ec-443c-9ed7-fdadf150da82}")] /* Autoload when the a solution is loaded addin starts  */
    [Guid(GuidList.guidStrokes_Challanges_VSXPkgString)]
    public sealed class Strokes_Challanges_VSXPackage : Package
    {
        public Strokes_Challanges_VSXPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        #region Package Members

        /// <summary>
        /// Because this package auto loads with a soluton in VS.NET (see the ProvideAutoLoad attribute further up), this initialize function will
        /// obtain a reference to the main strokes extension, and register the appropriate assemblies containing Achievement implementations.
        /// 
        /// For achievements that rely on compile time interpretation of source code, all that needs to be done is registration of the assemblies.
        /// 
        /// For achievements that requires more complex determination, another service is provided.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            var als = GetService<IAchevementLibraryService>();
            if(als != null)
            {
                als.RegisterAchievementAssembly(Assembly.GetExecutingAssembly());
            }
        }

        private T GetService<T>() where T : class
        {
            return GetService(typeof (T)) as T;
        }

        #endregion
    }
}
