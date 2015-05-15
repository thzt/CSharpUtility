using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpUtility
{
    public class RequestCache
    {
        private readonly Hashtable hashtable = new Hashtable();

        public void SetDataList(object cacheKey, List<object> dataList)
        {
            hashtable.Add(cacheKey, dataList);
        }

        public List<object> GetDataList(object cacheKey, int count)
        {
            if (!hashtable.ContainsKey(cacheKey))
            {
                return null;
            }

            var dataList = (List<object>)hashtable[cacheKey];
            count = Math.Min(dataList.Count, count);

            var getDataList = dataList.GetRange(0, count);
            dataList.RemoveRange(0, count);

            if (dataList.Count == 0)
            {
                hashtable.Remove(cacheKey);
                return getDataList;
            }

            return getDataList;
        }
    }
}
