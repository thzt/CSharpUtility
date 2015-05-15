namespace CSharpUtility
{
    public static class TestReflectionTool
    {
        public static void Test()
        {
            var tool = new ReflectionTool();

            object result = tool.InvokeStaticMethod("CSharpUtility.AssertTool", "Assert", true);
        }
    }
}
