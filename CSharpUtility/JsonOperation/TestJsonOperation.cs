namespace CSharpUtility
{
    public static class TestJsonOperation
    {
        public static void Test()
        {
            var testModel = new TestModel
            {
                Key = "1",
                Value = 2
            };

            var json = JsonOperation.Serialize(testModel);

            JsonOperation.Deserialize<TestModel>(json);

            var typeFullName = testModel.GetType().FullName;
            JsonOperation.Deserialize(typeFullName, json);
        }

        public class TestModel
        {
            public string Key { get; set; }
            public int Value { get; set; }
        }
    }
}
