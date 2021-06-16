using System;
using System.Collections;
using System.Collections.Generic;

namespace QueryEngine
{
    class QueryEngine
    {
        public void RunConsoleQuery(Data data, Query query)
        {
            var table = (IEnumerable)data.GetType().GetField(query.Source)?.GetValue(data);             // -- Get type of the variable and look if there's field of given name
            Console.WriteLine();
            foreach (object entry in table)                                                             // -- Take value of the field (collection) of the Data object passed in arguments
                if (IsMatching(entry, query.ConditionsSet))                                             // -- If collection record field values fit
                {
                    foreach (var queryField in query.Fields)                                      //  given conditions, print selected fields
                        Console.Write($"{entry.GetType().GetField(queryField)?.GetValue(entry)} ");
                    Console.WriteLine($"\n{new string('-',64)}");
                }
            
        }

        private bool IsMatching(object entry, ConditionsSet set)
        {
            //Grouping "and" groups separated with "or" keywords

            var tupleList =  new List<(int start, int end)>(set.AndOr.Count);
            var start = 0;
            var end=0;
            for (var i = 0; i < set.AndOr.Count; i++)
            {
                if (!set.AndOr[i])
                {
                    end = i;
                    tupleList.Add((start, end));
                    start = i+1;
                }
                
            }
            end = set.AndOr.Count;
            tupleList.Add((start, end));

            foreach (var valueTuple in tupleList)
            {
                var smallSuccess = true;
                for (var i = valueTuple.start; i <= valueTuple.end; i++)
                {
                    if (!set.Conditions[i].Check(entry))
                    {
                        smallSuccess=false; 
                        break;
                    }
                }
                if (smallSuccess) return true;
            }
            return false;
        }
    }
}
