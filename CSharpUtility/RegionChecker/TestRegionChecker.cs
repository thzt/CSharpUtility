using System;
using System.Threading;

namespace CSharpUtility
{
    public static class TestFirstTimeFallIntoRegionChecker
    {
        public static void Test()
        {
            var regionChecker = new FirstTimeFallIntoRegionChecker();

            var left = DateTime.Now;
            var right = left.AddSeconds(5000);
            regionChecker.ChangeBoundary(left, right);

            Thread.Sleep(1000);
            bool isFallInto = regionChecker.Check(DateTime.Now);
            AssertTool.Assert(isFallInto);

            Thread.Sleep(1000);
            isFallInto = regionChecker.Check(DateTime.Now);
            AssertTool.Assert(!isFallInto);
        }
    }
}
