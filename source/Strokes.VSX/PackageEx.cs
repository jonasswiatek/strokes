using System;
using Microsoft.VisualStudio.Shell;
using System.ComponentModel.Design;
using Strokes.Core.Integration;

namespace Strokes.VSX
{
    /// <summary>
    /// Utility Package extensions.
    /// </summary>
    public abstract class PackageEx : Package
    {
        /// <summary>
        /// Gets type-based services from the VSPackage service container.
        /// </summary>
        /// <typeparam name="T">The type of service to retrieve.</typeparam>
        /// <returns>
        ///     An instance of the requested service, or a null reference if the service could not be found.
        /// </returns>
        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        /// <summary>
        /// Adds the specified service to the service container, 
        /// and optionally promotes the service to parent service containers.
        /// </summary>
        /// <typeparam name="T">The type of service to add.</typeparam>
        /// <param name="serviceInstance">An instance of the service type to add.</param>
        /// <param name="promote">
        ///     <c>true</c> to promote this request to any parent service containers; otherwise, <c>false</c>.
        /// </param>
        public void AddService<T>(T serviceInstance, bool promote = false)
        {
            (this as IServiceContainer).AddService(typeof(T), serviceInstance, promote);
        }

        /// <summary>
        /// Removes the specified service type from the service container, 
        /// and optionally promotes the service to parent service containers.
        /// </summary>
        /// <typeparam name="T">The type of service to remove.</typeparam>
        /// <param name="promote">
        ///     <c>true</c> to promote this request to any parent service containers; otherwise, <c>false</c>.
        /// </param>
        public void RemoveService<T>(bool promote = false)
        {
            (this as IServiceContainer).RemoveService(typeof(T), promote);
        }

        /// <summary>
        /// Gets the tool window corresponding to the specified type and ID.
        /// </summary>
        /// <typeparam name="T">The type of tool window to create.</typeparam>
        /// <param name="id">The tool window ID. This is 0 for a single-instance tool window.</param>
        /// <param name="create">If <c>true</c>, the tool window is created if it does not exist.</param>
        /// <returns>
        ///     An instance of the requested tool window. If create is <c>false</c> 
        ///     and the tool window does not exist, a null reference is returned.
        /// </returns>
        public T FindToolWindow<T>(int id, bool create)
            where T : ToolWindowPane
        {
            return (T)this.FindToolWindow(typeof(T), id, create);
        }
    }

    /// <summary>
    /// StrokesVsxPackage extensions.
    /// </summary>
    public static class StrokesVsxPackageEx
    {
        /// <summary>
        /// Gets a service proffered globally by Visual Studio or one of its packages. 
        /// This is the same as calling GetService() on an instance of a package that proffers no services itself.
        /// </summary>
        /// <typeparam name="T">The type of the service requested.</typeparam>
        /// <returns>
        ///     The service being requested if available, otherwise <c>null</c>.
        /// </returns>
        public static T GetGlobalService<T>()
        {
            return (T)StrokesVsxPackage.GetGlobalService(typeof(T));
        }
    }

    /// <summary>
    /// Utility ServiceProvider extensions.
    /// </summary>
    public static class ServiceProviderEx
    {
        /// <summary>
        /// Gets type-based services from the unmanaged service provider.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of service to retrieve. 
        ///     The GUID of this type is used to obtain the service from the native service provider.
        /// </typeparam>
        /// <param name="provider">A ServiceProvider to retrieve the service from.</param>
        /// <returns>
        ///     The requested service, or a null reference if the service could not be located.
        /// </returns>
        public static T GetService<T>(this ServiceProvider provider)
        {
            return (T)provider.GetService(typeof(T));
        }
    }
}
