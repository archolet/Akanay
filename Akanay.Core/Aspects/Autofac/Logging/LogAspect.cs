using Akanay.Core.CrossCuttingConcerns.Logging;
using Akanay.Core.CrossCuttingConcerns.Logging.Log4Net;
using Akanay.Core.Utilities.Interceptors.Autofac;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Core.Aspects.Autofac.Logging
{
    public class LogAspect:MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception("Wrong logger type");
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = invocation.Arguments.Select(x => new LogParameter
            {
                Value = x,
                Type = x.GetType().Name,
            }).ToList();
            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;


            //var logParameters = new List<LogParameter>();
            //for (int i = 0; i < invocation.Arguments.Length; i++)
            //{
            //    logParameters.Add(new LogParameter
            //    {
            //        Name = invocation.Method.GetParameters()[i].Name,
            //        Value = invocation.Arguments[i],
            //        Type = invocation.Arguments[i].GetType().Name
            //    });
            //}
            //var logDetail = new LogDetail
            //{
            //    MethodName = invocation.Method.Name,
            //    LogParameters = logParameters
            //};
            //return logDetail;
        }
    }
}
