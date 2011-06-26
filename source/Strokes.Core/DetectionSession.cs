using System;
using System.Collections.Generic;

namespace Strokes.Core
{
    public class DetectionSession
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
    }
}
