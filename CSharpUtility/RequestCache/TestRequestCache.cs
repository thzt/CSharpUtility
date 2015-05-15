using System;
using System.Collections.Generic;

namespace CSharpUtility
{
    public static class TestRequestCache
    {
        public static void Test()
        {
            var cache = new RequestCache();

            cache.SetDataList("Data", new List<object>
            {
                "1",2,3
            });

            var dataList = cache.GetDataList("Data", 2);
            AssertTool.Assert(dataList.Count == 2);
            AssertTool.Assert(dataList[0].ToString() == "1");
            AssertTool.Assert(Convert.ToInt32(dataList[1]) == 2);

            dataList = cache.GetDataList("Data", 2);
            AssertTool.Assert(dataList.Count == 1);
            AssertTool.Assert(Convert.ToInt32(dataList[0]) == 3);
        }
    }
}
