﻿using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Core.Extensions
{
    public static class MemoryCacheExtendions
    {
        private static readonly Lazy<Func<MemoryCache, object>> GetCoherentState =
       new Lazy<Func<MemoryCache, object>>(() =>
           CreateGetter<MemoryCache, object>(typeof(MemoryCache)
               .GetField("_coherentState", BindingFlags.NonPublic | BindingFlags.Instance)));

        private static readonly Lazy<Func<object, IDictionary>> GetEntries7 =
            new Lazy<Func<object, IDictionary>>(() =>
                CreateGetter<object, IDictionary>(typeof(MemoryCache)
                    .GetNestedType("CoherentState", BindingFlags.NonPublic)
                    .GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance)));

        private static Func<TParam, TReturn> CreateGetter<TParam, TReturn>(FieldInfo field)
        {
            var methodName = $"{field.ReflectedType.FullName}.get_{field.Name}";
            var method = new DynamicMethod(methodName, typeof(TReturn), new[] { typeof(TParam) }, typeof(TParam), true);
            var ilGen = method.GetILGenerator();
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldfld, field);
            ilGen.Emit(OpCodes.Ret);
            return (Func<TParam, TReturn>)method.CreateDelegate(typeof(Func<TParam, TReturn>));
        }

        private static readonly Func<MemoryCache, IDictionary> GetEntries =
            Assembly.GetAssembly(typeof(MemoryCache)).GetName().Version.Major < 7
                ? null
                : cache => (IDictionary)GetEntries7.Value(GetCoherentState.Value(cache));

        public static IEnumerable GetKeys(this IMemoryCache cache)
        {
            if (cache is MemoryCache memoryCache)
                return GetEntries(memoryCache).Keys;
            throw new NotSupportedException();
        }
    }
}
