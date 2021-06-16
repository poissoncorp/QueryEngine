using System;
using System.Collections;
using System.Collections.Generic;

namespace QueryEngine
{
    public class QueryEngine
    {
        public Data Data { get; set; }

        public QueryEngine(Data data)
        {
            this.Data = data;
        }

        public void RunConsoleQuery(Query query)
        {
            var table = (IEnumerable)typeof(Data).GetField(query.Source)?.GetValue(Data);              // -- Take value of the field (Source - collection) of the Data object 
            Console.WriteLine();
            if (table != null)
            {
                foreach (var entry in table)    //entry is a single Entity in the fetched table
                {
                    var isMatched = (query is MultiConditionalQuery)
                        ? IsMatching(entry, (query as MultiConditionalQuery).ConditionsSet)
                        : IsMatching(entry, (query as SingleConditionalQuery).Condition);

                    if (isMatched)
                    {
                        // -- If record fields values fit given conditions
                        foreach (var queryField in query.Fields) //  -- Print selected fields
                            Console.Write($"{entry.GetType().GetField(queryField)?.GetValue(entry)} ");
                        Console.WriteLine($"\n{new string('-', 64)}");
                    }
                }
            }
        }

        private bool IsMatching(object entry, Condition condition)
        {
            return condition.Check(entry);
        }
        private bool IsMatching(object entry, ConditionsSet set)
        {
            //Grouping "and" logical product groups, that are separated with "or" keywords
            var tupleList =  new List<(int start, int end)>(set.AndOr.Count); 
            var start = 0; 
            int end;
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
            tupleList.Add((start, end));            //List of (start,end) Tuples indicating AND separated conditions groups
            foreach (var valueTuple in tupleList)   //If entry will pass any AND group return true
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
