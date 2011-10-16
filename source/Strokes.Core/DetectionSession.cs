using System;
using System.Linq;
using System.Collections.Generic;

namespace Strokes.Core
{
    public class DetectionSession : IDisposable
    {
        /// <summary>
        /// Lock for syncronizing achievement tests.
        /// </summary>
        private readonly object padLock = new object();

        /// <summary>
        /// Dictionary of the session objects (each representing a <c>IParser</c>).
        /// </summary>
        private readonly IDictionary<Type, object> sessionObjects = new Dictionary<Type, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DetectionSession"/> class.
        /// </summary>
        /// <param name="buildInformation">The build information.</param>
        public DetectionSession(BuildInformation buildInformation)
        {
            BuildInformation = buildInformation;
        }

        /// <summary>
        /// Gets or sets the build information.
        /// </summary>
        public BuildInformation BuildInformation
        {
            get;
            private set;
        }

        /// <summary>
        /// This method is used by achievement implementations to share some type.
        /// In the BasicAchievements library, this is used to share a collection of parsers 
        /// (one parser per file the achievement is looking in).
        /// </summary>
        /// <typeparam name="T"><c>Type</c> of the object shared.</typeparam>
        /// <returns>A shared or new instance of the defined type.</returns>
        public T GetSessionObjectOfType<T>()
        {
            lock (padLock) // Synchronize access to this collection.
            {
                if (!sessionObjects.ContainsKey(typeof(T)))
                {
                    sessionObjects[typeof(T)] = Activator.CreateInstance<T>();
                }

                return (T)sessionObjects[typeof(T)];
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            //Dispose all disposable children
            foreach (var disposable in sessionObjects.Values.OfType<IDisposable>())
            {
                disposable.Dispose();
            }
        }
    }
}