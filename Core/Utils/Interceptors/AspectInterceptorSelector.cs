using System.Reflection;
using Castle.DynamicProxy;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Core.Utils.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
        var methodAttributes = type.GetMethods()!
            .FirstOrDefault(p => p.Name == method.Name && p.GetGenericArguments().GroupBy(p => p.Name).Count() ==
                method.GetGenericArguments()?.GroupBy(p => p.Name).Count())!
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
        classAttributes.AddRange(methodAttributes);

        return classAttributes.OrderBy(x => x.Priority).ToArray();
    }
}