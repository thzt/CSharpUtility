using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpUtility
{
    public class PairList<KeyType, ValueType> : IEnumerable, IEnumerator
    {
        #region used to support dictionary like method

        private readonly List<KeyValuePair<KeyType, ValueType>> keyValuePairList = new List<KeyValuePair<KeyType, ValueType>>();

        public ValueType this[KeyType key]
        {
            get
            {
                return keyValuePairList.Find(pair => pair.Key.Equals(key)).Value;
            }

            set
            {
                var index = keyValuePairList.FindIndex(pair => pair.Key.Equals(key));
                if (index == -1)
                {
                    keyValuePairList.Add(new KeyValuePair<KeyType, ValueType>(key, value));
                    return;
                }

                keyValuePairList[index] = new KeyValuePair<KeyType, ValueType>(key, value);
            }
        }

        public bool ContainsKey(KeyType key)
        {
            var index = keyValuePairList.FindIndex(pair => pair.Key.Equals(key));
            return index != -1;
        }

        public bool ContainsKey(KeyType key, Func<KeyType, object> convert)
        {
            var index = keyValuePairList.FindIndex(pair => convert(pair.Key).Equals(convert(key)));
            return index != -1;
        }

        public List<ValueType> ToValueList()
        {
            List<ValueType> valueList = new List<ValueType>();
            foreach (KeyValuePair<KeyType, ValueType> item in keyValuePairList)
            {
                valueList.Add(item.Value);
            }

            return valueList;
        }

        #endregion

        //--//

        #region implement IEnumerable/IEnumerator used to foreach

        private int position = -1;

        public object Current
        {
            get
            {
                return keyValuePairList[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            return position < keyValuePairList.Count;
        }

        public void Reset()
        {
            position = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        #endregion
    }
}
