using System;
using System.Collections.Generic;

namespace CSharpUtility
{
    public static class TestRequestCache
    {
        public static void Test()
        {
            RequestCache.SetDataList("Data", new List<object>
            {
                "1",2,3
            });

            var dataList = RequestCache.GetDataList("Data", 2);
            AssertTool.Assert(dataList.Count == 2);
            AssertTool.Assert(dataList[0].ToString() == "1");
            AssertTool.Assert(Convert.ToInt32(dataList[1]) == 2);

            dataList = RequestCache.GetDataList("Data", 2);
            AssertTool.Assert(dataList.Count == 1);
            AssertTool.Assert(Convert.ToInt32(dataList[0]) == 3);
        }
    }
}
