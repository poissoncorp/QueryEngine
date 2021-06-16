using System.Collections.Generic;

namespace QueryEngine
{
    internal class Query
    {
        public string Source { get; set; } //From
        public ConditionsSet ConditionsSet { get; set; }  //Where
        public List<string> Fields { get; set; }    //Select
    }
}
