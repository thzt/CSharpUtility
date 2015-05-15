using System;
using System.IO;
using System.Net;
using System.Text;

namespace CSharpUtility
{
    /// <summary>
    /// this class will send http request with parameters, and get http response.
    /// </summary>
    public static class HttpTool
    {
        /// <summary>
        /// the only one public method we support.
        /// deal with different http request type, we handle differently.
        /// 1. get: param is as format: a=1&b=2
        /// 2. post: param is as format: {"a":"1","b":"2"}
        /// </summary>
        /// <param name="requestType"></param>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string GetResponse(RequestType requestType, string url, string param)
        {
            switch (requestType)
            {
                case RequestType.GET:
                    return GetResponseOfTypeGet(url, param);

                case RequestType.POST:
                    return GetResponseOfTypePost(url, param);

                default:
                    throw new Exception("Unsupport request type.");
            }
        }

        /// <summary>
        /// deal with http request of type 'get', we add param to url to request url.
        /// param are as format a=1&b=2
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private static string GetResponseOfTypeGet(string url, string param)
        {
            string requestUrl = string.Format("{0}?{1}", url, param);

            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
            httpWebRequest.Method = RequestType.GET.ToString();

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            return GetResponseText(httpWebResponse);
        }

        /// <summary>
        /// deal with http request of type 'post', we write param as request body.
        /// param is as format: {"a":"1","b":"2"}
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private static string GetResponseOfTypePost(string url, string param)
        {
            byte[] requestData = Encoding.UTF8.GetBytes(param);

            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpWebRequest.Method = RequestType.POST.ToString();
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = requestData.Length;

            Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(requestData, 0, requestData.Length);
            requestStream.Close();

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            return GetResponseText(httpWebResponse);
        }

        /// <summary>
        /// this method are shared by upper two method
        /// we use this method to get response text from http response.
        /// </summary>
        /// <param name="httpWebResponse"></param>
        /// <returns></returns>
        private static string GetResponseText(HttpWebResponse httpWebResponse)
        {
            HttpStatusCode responseStatusCode = httpWebResponse.StatusCode;
            if (responseStatusCode != HttpStatusCode.OK)
            {
                throw new Exception(httpWebResponse.StatusDescription);
            }

            return new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8).ReadToEnd();
        }
    }

    public enum RequestType
    {
        GET,
        POST
    }
}
