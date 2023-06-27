using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FrozenCircle.Core.Utils
{
    public static class TypeUtilities
    {
        public static List<Type> GetConcreteTypesThatExtend<T>()
        {
            var baseType = typeof(T);
            var assemblies = 
                AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => !x.IsInterface && !x.IsAbstract && baseType.IsAssignableFrom(x))
                    .ToList();
            return assemblies;
        } 
        
        public static List<Type> GetConcreteTypesThatExtend(Type baseType)
        {
            var assemblies = 
                AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => !x.IsInterface && !x.IsAbstract && baseType.IsAssignableFrom(x))
                    .ToList();
            return assemblies;
        }
        
        
        public static IFinalType CreateInstance<IFinalType>(Type type)
        {
            if (typeof(MonoBehaviour).IsAssignableFrom(type))
            {
                throw new Exception("Cannot create a MonoBehaviour instance with this method.");
            }
            var instance = Activator.CreateInstance(type);
            return (IFinalType) instance;
        }
    }
}