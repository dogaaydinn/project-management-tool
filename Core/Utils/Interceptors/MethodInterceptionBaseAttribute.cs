using Castle.DynamicProxy;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Core.Utils.Interceptors;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
{
    public int Priority { get; set; }

    public virtual void Intercept(IInvocation invocation)
    {
    }

    protected MethodType GetDelegateType(IInvocation invocation)
    {
        var returnType = invocation.Method.ReturnType;
        if (returnType == typeof(Task))
            return MethodType.AsyncAction;
        if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
            return MethodType.AsyncFunction;
        return MethodType.Synchronous;
    }

    protected enum MethodType
    {
        Synchronous,
        AsyncAction,
        AsyncFunction
    }
}