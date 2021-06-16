using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QueryEngine
{
    internal class Condition
    {
        public Condition(string conditionString) //conditionString is a three-part sequence - [field] [operator] [value] e.g. Age > 20
        {
            List<string> parts = new List<string>(Regex.Split(conditionString, "(>=)|(<=)|(<>)|(=)|(>)|(<)|(LIKE)|(BETWEEN)",
                RegexOptions.IgnorePatternWhitespace)); // Break the string to extract these parts
            Field = parts[0].Trim();
            Operator = parts[1].Trim();
            string valueString = parts[2].Trim();
            Value = valueString[0] == '"' || valueString[0] == '\'' ? valueString.Substring(1, valueString.Length - 2) : valueString;
        }
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }

        internal bool Check(object entry)
        {
            string fieldValue = entry.GetType().GetField(Field)?.GetValue(entry)?.ToString();
            if (fieldValue == null) return false;
            switch (Operator)
            {
                case "=":
                    if (fieldValue != Value) return false;
                    break;
                case ">":
                    if (Double.Parse(fieldValue) <= Double.Parse(Value)) return false;
                    break;

                case "<":
                    if (Double.Parse(fieldValue) >= Double.Parse(Value)) return false;
                    break;

                case ">=":
                    if (Double.Parse(fieldValue) < Double.Parse(Value)) return false;
                    break;

                case "<=":
                    if (Double.Parse(fieldValue) > Double.Parse(Value)) return false;
                    break;

                case "<>":
                    if (fieldValue == Value) return false;
                    break;

                case "LIKE":
                case "BETWEEN":
                    throw new NotImplementedException();

                default:
                    Console.WriteLine("Unexpected operation!");
                    return false;
            }

            return true;

        }
    }
}
