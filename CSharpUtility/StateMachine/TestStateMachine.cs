using System.Collections.Generic;

namespace CSharpUtility
{
    public static class TestStateMachine
    {
        public static void Test()
        {
            string stateFilePath = "";

            var machine = new StateMachine(stateFilePath);
            string action;

            machine.State = "Begin";
            action = machine.Feed("1");
            AssertTool.Assert(action == "To Intermediate State");
            AssertTool.Assert(machine.State == "Intermediate");
            action = machine.Feed("3");
            AssertTool.Assert(action == "To End State");
            AssertTool.Assert(machine.State == "End");

            machine.State = "Begin";
            action = machine.Feed("2");
            AssertTool.Assert(action == "To End State");
            AssertTool.Assert(machine.State == "End");

            machine.State = "Begin";
            List<string> allReceivedFeedList = machine.GetAllReceivedFeedList();
        }
    }
}
