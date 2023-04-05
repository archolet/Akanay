using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Core.Utilities.Interceptors.Autofac
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true,Inherited =true)]
    public class MethodInterceptionBaseAttribute:Attribute,IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
        }


        public virtual void OnBefore(IInvocation invocation)
        {
        }
        public virtual void OnAfter(IInvocation invocation)
        {
        }
        public virtual void OnException(IInvocation invocation, System.Exception e)
        {
        }
        public virtual void OnSuccess(IInvocation invocation)
        {
        }
    }
}
