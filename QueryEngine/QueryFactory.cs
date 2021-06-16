using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QueryEngine
{
    internal static class QueryFactory
    {
        public static Query Create(string fromStr, string whereStr, string selectStr)
        {
            if (Regex.Split(whereStr, "( Or )|( And )").Length > 2)
            {
                return new MultiConditionalQuery()
                {
                    Source = fromStr,
                    ConditionsSet = new ConditionsSet(whereStr),
                    Fields = new List<string>(from fieldStr in selectStr.Split(",") select fieldStr.Trim())
                };
            }

            return new SingleConditionalQuery()
            {
                Source = fromStr,
                Condition = new Condition(whereStr),
                Fields = new List<string>(from fieldStr in selectStr.Split(",") select fieldStr.Trim())
            };
        }
    }
}
