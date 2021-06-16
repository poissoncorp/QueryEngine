using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QueryEngine
{
    public static class QueryReadTools
    {
        internal static Query ReadQueryFromConsole(bool SlowMode)
        {
            string from, where, select;
            if (SlowMode)
            {
                from = Console.ReadLine()?[5..];
                where = Console.ReadLine()?[6..];
                select = Console.ReadLine()?[7..];
                
            }
            else
            {
                string input = Console.ReadLine();
                if (input == null) throw new FormatException();
                string[] split = Regex.Split(input, "(From)|(Where)|(Select)", RegexOptions.IgnoreCase);
                from = split[2].Trim();
                where = split[4].Trim();
                select = split[6].Trim();
            }
            return QueryFactory.Create(from, where, select);
        }
        

        //Read Query from .txt etc...
    }
}
