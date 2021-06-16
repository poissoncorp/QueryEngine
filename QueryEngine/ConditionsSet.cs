using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QueryEngine
{
    public class ConditionsSet
    {
        public List<Condition> Conditions { get; set; }
        public List<bool> AndOr { get; set; }

        public ConditionsSet(string conditionsString)
        {
            string[] conditionStrings = Regex.Split(conditionsString, "( Or )|( And )", RegexOptions.IgnoreCase);
            string[] expressions = new string[conditionStrings.Length / 2 + 1];
            bool[] andOr = new bool[conditionStrings.Length / 2]; // Not implementing an enum - I just have two possibilities - OR/AND, OR = false, AND = true, bool is ok
            for (int i = 0; i < conditionStrings.Length; i++)
            {
                if (i % 2 != 0) 
                    andOr[i / 2] = Regex.IsMatch(conditionStrings[i].Trim(), "(AND)", RegexOptions.IgnoreCase);
                else
                    expressions[i / 2] = conditionStrings[i];
            }
            Conditions = new List<Condition>(from exp in expressions select new Condition(exp));
            AndOr = new List<bool>(andOr); 
        }
    }

}
