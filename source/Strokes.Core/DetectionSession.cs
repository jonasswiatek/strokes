using System;
using System.Linq;
using System.Collections.Generic;

namespace Strokes.Core
{
    public class DetectionSession : IDisposable
    {
        public BuildInformation BuildInformation { get; private set; }
        private readonly IDictionary<Type, object> _sessionObjects = new Dictionary<Type, object>();

        public DetectionSession(BuildInformation buildInformation)
        {
            BuildInformation = buildInformation;
        }

        public T GetSessionObjectOfType<T>()
        {
            if (!_sessionObjects.ContainsKey(typeof(T)))
            {
                _sessionObjects[typeof(T)] = Activator.CreateInstance<T>();
            }

            return (T)_sessionObjects[typeof(T)];
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
