using System;
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
            return serializer.Serialize(jsonOjbect);
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
    }
}
