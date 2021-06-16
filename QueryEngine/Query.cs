using System;
using System.Collections.Generic;
using System.Text;

namespace QueryEngine
{
    internal class Query
    {
        public string Source { get; set; } //From
        public ConditionsSet ConditionsSet { get; set; }  //Where
        public List<string> Fields { get; set; }    //Select
    }
}
