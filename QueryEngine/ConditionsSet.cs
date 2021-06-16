using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace QueryEngine
{
    class ConditionsSet
    {
        public List<Condition> Conditions { get; set; }
        public List<bool> AndOr { get; set; }

        public ConditionsSet(string conditionsString)
        {
            string[] conditionStrings = Regex.Split(conditionsString, "( Or )|( And )", RegexOptions.IgnoreCase);

            if (conditionStrings.Length > 1)
            {
                string[] expressions = new string[conditionStrings.Length / 2 + 1];
                bool[] andOr = new bool[conditionStrings.Length / 2]; // 1 - and, 0 - or

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

            Conditions = new List<Condition>(new[] { new Condition(conditionStrings[0]) });
            AndOr = new List<bool>();
        }

    }
}
