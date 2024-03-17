using Castle.DynamicProxy;
using Core.ExceptionHandling;
using Core.Services.Messages;

namespace Core.Utils.Interceptors;

public abstract class MethodInterception : MethodInterceptionBaseAttribute
{
    protected virtual void OnBefore(IInvocation invocation)
    {
    }

    protected virtual void OnAfter(IInvocation invocation)
    {
    }

    protected virtual void OnException(IInvocation invocation, Exception ex)
    {
        var type = invocation.Method.ReturnType;
        try
        {
            if (type == typeof(Task))
            {
                var taskSource = new TaskCompletionSource<bool>();
                taskSource.SetException(ex);
                invocation.ReturnValue = taskSource.Task;
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>))
            {
                var resultType = type.GetGenericArguments()[0];
                dynamic result = Activator.CreateInstance(resultType)!;

                if (ex is ValidationException valX)
                    result.Fail(new ErrorMessage(valX.ExceptionCode, valX.Message));
                else
                    result.Fail(ex);

                var taskSourceType = typeof(TaskCompletionSource<>).MakeGenericType(resultType)!;
                dynamic taskSource = Activator.CreateInstance(taskSourceType)!;
                taskSource.SetResult(result);
                invocation.ReturnValue = taskSource.Task;
            }
            else if (type == typeof(void))
            {
                // For void methods, just rethrow the exception.
                throw ex;
            }
            else
            {
                var result = Activator.CreateInstance(type)! as dynamic;
                if (ex is ValidationException valX)
                    result.Fail(new ErrorMessage(valX.ExceptionCode, valX.Message));
                else
                    result.Fail(ex);

                invocation.ReturnValue = result;
            }
        }
        catch
        {
            //do nothing
        }
    }

    protected virtual void OnSuccess(IInvocation invocation)
    {
    }

    public override void Intercept(IInvocation invocation)
    {
        var isSuccess = true;

        try
        {
            OnBefore(invocation);
        }
        catch (Exception ex)
        {
            OnException(invocation, ex);
            OnAfter(invocation);
            return;
        }

        try
        {
            invocation.Proceed();
        }
        catch (Exception e)
        {
            isSuccess = false;
            OnException(invocation, e);
        }
        finally
        {
            if (isSuccess) OnSuccess(invocation);
        }

        OnAfter(invocation);
    }
}