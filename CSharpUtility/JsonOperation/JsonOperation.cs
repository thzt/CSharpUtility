using System;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace CSharpUtility
{
    /// <summary>
    /// we wrap JavaScriptSerializer to support transplantable facade
    /// </summary>
    public class JsonOperation
    {
        private static JavaScriptSerializer serializer = new JavaScriptSerializer();

        public static string Serialize(object jsonOjbect)
        {
            string jsonString = serializer.Serialize(jsonOjbect);

            return DecodeUnicode(jsonString);
        }

        public static T Deserialize<T>(string jsonString)
        {
            return serializer.Deserialize<T>(jsonString);
        }

        //use type full name to deserialize json to object
        //so we can deserialize all json passed from client.
        public static object Deserialize(string typeFullName, string json)
        {
            Type type = Type.GetType(typeFullName);

            return typeof(JsonOperation)
                .GetMethod("Deserialize", new[] { typeof(string) })
                .MakeGenericMethod(type)
                .Invoke(null, new object[] { json });
        }

        /// <summary>
        /// JavaScriptSerializer.Serialize will auto change <, >... to unicode.
        /// and this unicode send to wechat will display as \uXXXX
        /// so use this function to decode unicode to string.
        /// </summary>
        /// <param name="unicode"></param>
        /// <returns></returns>
        private static string DecodeUnicode(string unicode)
        {
            Regex regexp = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
            return regexp.Replace(unicode, match =>
                ((char)Convert.ToInt32(match.Groups[1].Value, 16)).ToString());
        }
    }
}
