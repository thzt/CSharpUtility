using System;
using System.Linq;
using System.Collections.Generic;

namespace CSharpUtility
{
    public class Condition
    {
        public Condition(Func<object, object, bool> areEqual = null)
        {
            this.areEqual = areEqual
                ?? ((u, v) => u.Equals(v));
        }

        public void Add(params object[] items)
        {
            var conditions = items.ToList().GetRange(0, items.Length - 1);
            var result = items[items.Length - 1];

            var matchIndex = FindIndex(conditions.ToArray());
            if (matchIndex == -1)
            {
                table.Add(items.ToList());
                return;
            }

            var row = table[matchIndex];
            row[row.Count - 1] = result;
        }

        public object Find(params object[] conditions)
        {
            var matchIndex = FindIndex(conditions);
            if (matchIndex == -1)
            {
                return null;
            }

            var row = table[matchIndex];
            return row[row.Count - 1];
        }

        public void Remove(params object[] conditions)
        {
            var matchIndex = FindIndex(conditions);
            if (matchIndex == -1)
            {
                return;
            }

            table.RemoveAt(matchIndex);
        }

        public void Clear()
        {
            table.Clear();
        }

        #region private tools

        private readonly Func<object, object, bool> areEqual;

        private readonly List<List<object>> table = new List<List<object>>();

        private int FindIndex(params object[] conditions)
        {
            for (var i = 0; i < table.Count; i++)
            {
                if (table[i].Count != conditions.Length + 1)
                {
                    continue;
                }

                int j;
                for (j = 0; j < conditions.Length; j++)
                {
                    if (!areEqual(table[i][j], conditions[j]))
                    {
                        break;
                    }
                }

                if (j != conditions.Length)
                {
                    continue;
                }

                return i;
            }

            return -1;
        }

        #endregion
    }
}
