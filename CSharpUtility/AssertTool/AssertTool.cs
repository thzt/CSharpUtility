using System;

namespace CSharpUtility
{
    public static class AssertTool
    {
        public static void Assert(bool isTrue)
        {
            if (isTrue)
            {
                return;
            }

            throw new Exception("Assert Failed");
        }
    }
}
