using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.CachingAspects
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 120)
        {
            _duration = duration;
            _cacheManager = ServiceHelper
                .ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}");
            var arguments = invocation.Arguments.ToList();
            var key =
                $"{methodName}({string.Join(",", arguments.Select(a => a?.ToString() ?? "<Null>"))})";

            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get<object>(key);
                return;
            }

            invocation.Proceed();

            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
