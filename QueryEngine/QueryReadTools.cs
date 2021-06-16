﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QueryEngine
{
    public static class QueryReadTools
    {
        internal static Query ReadQueryFromConsole(bool slowMode)
        {
            if (slowMode)
            {
                return new Query()
                {
                    Source = Console.ReadLine()?[5..],
                    ConditionsSet = new ConditionsSet(Console.ReadLine()?[6..]),
                    Fields = new List<string>(from fieldStr in Console.ReadLine()?[7..].Split(",")
                        select fieldStr.Trim())
                };
            }
            
            string input = Console.ReadLine();
            if (input == null) throw new FormatException();
            string[] split = Regex.Split(input, "(From)|(Where)|(Select)", RegexOptions.IgnoreCase);
            return new Query
            {
                Source = split[2].Trim(),
                ConditionsSet = new ConditionsSet(split[4]),
                Fields = new List<string>(from fieldStr in (split[6]).Split(",") select fieldStr.Trim()) // -- Split given string with ',' delimiter
            };                                                                                                        // -- And put the result to the List
        }

        //Read Query from .txt etc...
    }
}
