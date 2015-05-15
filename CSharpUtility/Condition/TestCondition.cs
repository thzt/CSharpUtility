namespace CSharpUtility
{
    public static class TestCondition
    {
        public static void Test()
        {
            var condition = new Condition();

            condition.Add(1, 2, 3, "a");
            condition.Add(1, 3, 2, "b");

            object result = condition.Find(1, 2);
            AssertTool.Assert(result.ToString() == "a");

            condition.Remove(1, 3, 2);
            result = condition.Find(1, 3);
            AssertTool.Assert(result == null);

            condition.Clear();
            result = condition.Find(1, 2);
            AssertTool.Assert(result == null);
        }
    }
}
