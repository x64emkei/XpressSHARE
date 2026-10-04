using System;
using System.Collections.Generic;

namespace XpressShare.Core
{
    public static class ServiceRegistry
    {
        private static readonly Dictionary<string, object> _services = new Dictionary<string, object>();

        public static void Register<T>(string key, T instance)
        {
            if (key == null) return;
            _services[key] = instance;
        }

        public static T Resolve<T>(string key) where T : class
        {
            object o;
            if (_services.TryGetValue(key, out o)) return o as T;
            return null;
        }
    }
}
