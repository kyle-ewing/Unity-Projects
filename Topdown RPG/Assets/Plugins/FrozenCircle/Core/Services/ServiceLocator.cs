using System;
using System.Collections.Generic;
using System.Linq;
using FrozenCircle.Core.Utils;
using UnityEngine;

namespace FrozenCircle.Core.Services
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, IService> services = new Dictionary<Type, IService>();

        [RuntimeInitializeOnLoadMethod]
        private static async void InitializeServiceLocator()
        {
            Debug.Log("[Service Locator] Initializing");
            Application.quitting += ApplicationOnQuitting;

            var serviceList = TypeUtilities.GetConcreteTypesThatExtend<IService>()
                .Where(x => typeof(IInitializable).IsAssignableFrom(x)).ToList();
            Debug.Log(services.Count);
            serviceList.ForEach(async x =>
            {
                if (!typeof(MonoBehaviour).IsAssignableFrom(x))
                {
                    IService service = TypeUtilities.CreateInstance<IService>(x);
                    if (service is IInitializable initializable)
                    {
                        try
                        {
                            await initializable.Initialize();
                            RegisterService(service);
                        }
                        catch (Exception e)
                        {
                            Debug.LogException(e);
                        }
                    }
                }
            });
        }


        public static void RegisterService<T>(T service)
            where T : IService
        {
            if (services.ContainsKey(typeof(T)))
            {
                throw new Exception($"Service of type {typeof(T)} already registered");
            }

            Debug.Log($"Adding type of: {service.GetType()}");
            services.Add(service.GetType(), service);
        }

        public static void UnregisterService<T>()
            where T : IService
        {
            Type type = typeof(T);
            if (services.ContainsKey(type) && services[type] != null)
            {
                services[type].Dispose();
                services.Remove(type);
            }
        }

        public static T GetService<T>()
            where T : IService
        {
            if (services.ContainsKey(typeof(T)))
            {
                return (T)services[typeof(T)];
            }
            else
            {
                throw new Exception($"Service of type {typeof(T)} not registered");
            }
        }

        private static void ApplicationOnQuitting()
        {
            Application.quitting -= ApplicationOnQuitting;
            foreach (var keyValuePair in services)
            {
                if (keyValuePair.Value != null)
                {
                    keyValuePair.Value.Dispose();
                }
            }
        }
    }
}