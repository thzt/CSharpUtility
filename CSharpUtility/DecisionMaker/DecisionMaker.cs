using System;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace CSharpUtility
{
    public class DecisionMaker
    {
        private readonly XmlDocument xmlDoc = new XmlDocument();

        public DecisionMaker(string decisionFilePath)
        {
            xmlDoc.Load(decisionFilePath);
        }

        public List<string> GetDecision(List<string> conditions)
        {
            foreach (XmlNode node in xmlDoc.SelectNodes("root/case"))
            {
                var conditionItems = node.SelectNodes("condition/item");
                int count = conditionItems.Count;

                int index;
                for (index = 0; index < count; index++)
                {
                    if (conditionItems[index].InnerText != conditions[index])
                    {
                        break;
                    }
                }

                if (index != count)
                {
                    continue;
                }

                return (
                    from XmlNode item in node.SelectNodes("result/item")
                    select item.InnerText
                ).ToList();
            }

            throw new Exception("Failed to get decision");
        }
    }
}