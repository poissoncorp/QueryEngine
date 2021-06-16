using System.Collections.Generic;

namespace QueryEngine
{
    public abstract class Query
    {
        public string Source { get; set; } //From
        public List<string> Fields { get; set; }    //Select
    }

    public class SingleConditionalQuery:Query
    {
        public Condition Condition { get; set; }  //Where
    }
    public class MultiConditionalQuery:Query
    {
        public ConditionsSet ConditionsSet { get; set; }  //Where
    }
}
