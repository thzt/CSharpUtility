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
            var request = context.Request;
            var response = context.Response;

            var headers = request.Headers;
            var isAjax = headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                response.Write(string.Format(
                    @"<script>
                        alert({0});
                    </script>",
                    JsonOperation.Serialize(ex.Message)
                ));

                return;
            }

            context.Response.Write(ex.Message);
        }

        private void WriteLog(Exception ex)
        {

        }
    }
}