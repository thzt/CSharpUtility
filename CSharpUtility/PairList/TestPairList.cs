using System.Collections.Generic;

namespace CSharpUtility
{
    public static class TestPairList
    {
        public static void Test()
        {
            var pairList = new PairList<string, int>();
            pairList["1"] = 1;
            pairList["2"] = 2;

            bool isContain = pairList.ContainsKey("1");
            AssertTool.Assert(isContain);

            List<int> valueList = pairList.ToValueList();

            foreach (KeyValuePair<string, int> item in pairList)
            {
                string key = item.Key;
                int value = item.Value;
            }
        }
    }
}
