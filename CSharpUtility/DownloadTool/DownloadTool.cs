using System.IO;
using System.Web.Mvc;

namespace CSharpUtility
{
    public static class DownloadTool
    {
        public static ActionResult Download(Controller controller, string filePath, string saveAsFileName)
        {
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(filePath, FileMode.Open);
                var bytes = new byte[(int)fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);

                var response = controller.Response;

                response.Clear();
                response.ContentType = "application/octet-stream";
                response.AddHeader("Content-Disposition", string.Format("attachment;filename=\"{0}\"", saveAsFileName));
                response.BinaryWrite(bytes);
                response.Flush();
                response.End();

                return null;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }
    }
}