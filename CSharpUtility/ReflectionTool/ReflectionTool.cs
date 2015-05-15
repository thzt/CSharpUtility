using System.Reflection;

namespace CSharpUtility
{
    public class ReflectionTool
    {
        private readonly Assembly assembly;

        public ReflectionTool()
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        public ReflectionTool(string assemblyFilePath)
        {
            assembly = Assembly.LoadFrom(assemblyFilePath);
        }

        public ReflectionTool(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public object CreateInstance(string classFullName)
        {
            object instance = assembly.CreateInstance(classFullName);
            return instance;
        }

        public object InvokeMethod(object instance, string methodName, params object[] methodParams)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName);
            object result = method.Invoke(instance, methodParams);

            return result;
        }

        public object InvokeStaticMethod(string classFullName, string methodName, params object[] methodParams)
        {
            MethodInfo method = assembly.GetType(classFullName).GetMethod(methodName);
            object result = method.Invoke(null, methodParams);

            return result;
        }
    }
}
