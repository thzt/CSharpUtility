using System;
using System.IO;
using System.Collections.Generic;

namespace CSharpUtility
{
    public class StateMachine
    {
        public string State { get; set; }
        private readonly Dictionary<string, List<ShiftAction>> dict;

        public StateMachine(string stateFilePath)
        {
            var json = File.ReadAllText(stateFilePath);
            dict = JsonOperation.Deserialize<Dictionary<string, List<ShiftAction>>>(json);
        }

        public string Feed(string value)
        {
            List<ShiftAction> shiftActions = dict[State];
            foreach (ShiftAction item in shiftActions)
            {
                var receive = item.Receive;
                if (receive != value)
                {
                    continue;
                }

                var gotoSate = item.Goto;
                if (!dict.ContainsKey(gotoSate))
                {
                    throw new Exception("Invalid goto state.");
                }

                State = gotoSate;
                return item.Action;
            }

            throw new Exception("Invalid receive value.");
        }
    }

    internal sealed class ShiftAction
    {
        public string Receive { get; set; }
        public string Goto { get; set; }
        public string Action { get; set; }
    }
}
