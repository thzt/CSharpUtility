using System.Collections.Generic;

namespace CSharpUtility
{
    public static class TestDecisionMaker
    {
        public static void Test()
        {
            string filePath = "";

            var decisionMaker = new DecisionMaker(filePath);
            var conditions = new List<string>
            {
                "1",
                "2"
            };

            List<string> results = decisionMaker.GetDecision(conditions);
        }
    }
}