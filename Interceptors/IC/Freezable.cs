using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Interceptors.IC
{
    public static class Freezable 
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();

        private static readonly IDictionary<object, IFreezable> _freezables = new Dictionary<object, IFreezable>();

        //public bool IsFrozen { get; }
      
        public static bool IsFreezable(object obj)
        {
            return obj != null && _freezables.ContainsKey(obj);
        }

        public static void Freeze(object freezable)
        {
            if (!IsFreezable(freezable))
            {
                throw new Exception("Error");
            }
            _freezables[freezable].Freeze();
        }
        public static bool IsFrozen(object freezable)
        {
            return IsFreezable(freezable) && _freezables[freezable].IsFrozen;
        }

        public static TFreezable MakeFreezable<TFreezable>() where TFreezable : class, new()
        {
            var freezableInterceptor = new FreezableInterceptor();
            var proxy = _generator.CreateClassProxy<TFreezable>(freezableInterceptor);
            _freezables.Add(proxy, freezableInterceptor);
            return proxy;
        }
    }

    public class CallLoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Logging...");
        }
    }
}
