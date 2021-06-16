using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace QueryEngine
{
    class QueryEngine
    {
        public void RunConsoleQuery(Data data, Query query)
        {
            var table = (IEnumerable)data.GetType().GetField(query.Source).GetValue(data);              // -- Get type of the variable and look if there's field of given name
            foreach (object entry in table)                                                             // -- Take value of the field (collection) of the Data object passed in arguments
                if (IsMatching(entry, query.ConditionsSet))                                             // -- If collection record field values fits
                    foreach (var queryField in query.Fields)                                         //  given conditions, print selected fields
                        Console.WriteLine(entry.GetType().GetField(queryField).GetValue(entry));
        }

        private bool IsMatching(object entry, ConditionsSet set)
        {
            foreach (Condition c in set.Conditions) 
            {
                string fieldValue = entry.GetType().GetField(c.Field).GetValue(entry).ToString();
                switch (c.Operator)
                {
                    case "=":
                        if (fieldValue != c.Value) return false;
                        break;
                    case ">":
                        if (Double.Parse(fieldValue) <= Double.Parse(c.Value)) return false;
                        break;

                    case "<":
                        if (Double.Parse(fieldValue) >= Double.Parse(c.Value)) return false;
                        break;

                    case ">=":
                        if (Double.Parse(fieldValue) < Double.Parse(c.Value)) return false;
                        break;

                    case "<=":
                        if (Double.Parse(fieldValue) > Double.Parse(c.Value)) return false;
                        break;

                    case "<>":
                        if (fieldValue == c.Value) return false;
                        break;

                    case "IN":
                    case "LIKE":
                    case "BETWEEN":
                        throw new NotImplementedException();

                    default:
                        Console.WriteLine("Unexpected operation!");
                        return false;
                }
            }
            return true;
        }
    }
}
