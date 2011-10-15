using System;
using System.Linq;
using System.Collections.Generic;

namespace Strokes.Core
{
    public class DetectionSession : IDisposable
    {
        private readonly object _padLock = new object();
        public BuildInformation BuildInformation { get; private set; }
        private readonly IDictionary<Type, object> _sessionObjects = new Dictionary<Type, object>();

        public DetectionSession(BuildInformation buildInformation)
        {
            BuildInformation = buildInformation;
        }

        /// <summary>
        /// This method is used by achievement implementations to share some type.
        /// In the BasicAchievements library, this is used to share a collection of parsers (one parser per file the achievement is looking in).
        /// </summary>
        /// <typeparam name="T">Type of the object shared</typeparam>
        /// <returns>A shared or new instance of the defined type</returns>
        public T GetSessionObjectOfType<T>()
        {
            lock (_padLock) //Synchronize access to this collection.
            {
                if (!_sessionObjects.ContainsKey(typeof(T)))
                {
                    _sessionObjects[typeof(T)] = Activator.CreateInstance<T>();
                }

                return (T)_sessionObjects[typeof(T)];                
            }
        }

        public void Dispose()
        {
            //Dispose all disposable children
            foreach(var disposable in _sessionObjects.Values.OfType<IDisposable>())
            {
                disposable.Dispose();
            }
        }
    }
}