using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QueryEngine
{
    internal class Condition
    {
        public Condition(string conditionString)
        {
            List<string> parts = new List<string>(Regex.Split(conditionString, "(>=)|(<=)|(<>)|(=)|(>)|(<)|(LIKE)|(IN)|(BETWEEN)",
                RegexOptions.IgnoreCase|RegexOptions.IgnorePatternWhitespace));
            Field = parts[0].Trim();
            Operator = parts[1].Trim();
            string valueString = parts[2].Trim();
            Value = valueString[0] == '"' || valueString[0] == '\'' ? valueString.Substring(1, valueString.Length - 2) : valueString;
        }
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }
}
