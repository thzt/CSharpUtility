using System;
using System.Web;
using System.Web.Mvc;

namespace CSharpUtility
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            exceptionContext.ExceptionHandled = true;

            var ex = exceptionContext.Exception;
            WriteErrorLog(ex);

            var context = exceptionContext.RequestContext.HttpContext;
            var isAjax = context.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                HandleAjaxRequest(context.Response, ex);
                return;
            }

            HandleNormalRequest(context.Response, ex);
        }

        private void WriteErrorLog(Exception ex)
        {

        }

        private void HandleAjaxRequest(HttpResponseBase response, Exception ex)
        {
            response.Write(string.Format(
                @"<script>
                    $&&$.sendAjax&&$.sendAjax.handleError&&$.sendAjax.handleError({0});
                </script>",
                JsonOperation.Serialize(ex.Message)
            ));
        }

        private void HandleNormalRequest(HttpResponseBase response, Exception ex)
        {
            response.Write(ex.Message);
        }
    }
}