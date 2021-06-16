using System;
using System.Collections.Generic;
using System.Text;

namespace QueryEngine
{
    internal class Query
    {
        public string Source { get; set; }
        public ConditionsSet ConditionsSet { get; set; }
        public List<string> Fields { get; set; }
    }
}
