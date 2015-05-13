using System;
using System.Web.Mvc;

namespace CSharpUtility
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            exceptionContext.ExceptionHandled = true;

            var ex = exceptionContext.Exception;
            WriteLog(ex);

            var context = exceptionContext.RequestContext.HttpContext;
            var isAjax = context.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            var message = GetErrorMessage(ex, isAjax);

            context.Response.Write(message);
        }

        private void WriteLog(Exception ex)
        {
            
        }

        private string GetErrorMessage(Exception ex, bool isAjax)
        {
            var message = ex.Message;

            if (!isAjax)
            {
                return message;
            }

            return string.Format(
                @"<script>
                    alert({0});
                </script>",
                JsonOperation.Serialize(message)
            );
        }
    }
}