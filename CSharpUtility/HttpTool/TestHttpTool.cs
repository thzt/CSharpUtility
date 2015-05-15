namespace CSharpUtility
{
    public static class TestHttpTool
    {
        public static void Test()
        {
            string url = "";
            string param = "a=1&b=2";

            HttpTool.GetResponse(RequestType.GET, url, param);
            HttpTool.GetResponse(RequestType.POST, url, param);
        }
    }
}
