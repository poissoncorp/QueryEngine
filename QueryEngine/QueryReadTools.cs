using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace QueryEngine
{
    public static class QueryReadTools
    {
        internal static Query ReadQueryFromConsole()
        {
            string input = Console.ReadLine();
            string[] split = Regex.Split(input, "(From)|(Where)|(Select)", RegexOptions.IgnoreCase);
            return new Query
            {
                Source = split[2].Trim(),
                ConditionsSet = new ConditionsSet(split[4]),
                Fields = new List<string>(from x in (split[6]).Split(",") select x.Trim()) // -- Split given string with ',' delimiter
            };                                                                             // -- And put the result to the List
        }

        //Read Query from .txt etc...
    }
}
