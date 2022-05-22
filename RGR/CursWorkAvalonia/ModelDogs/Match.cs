using System;
using System.Collections.Generic;

namespace TreeDataGridDemo.ModelDogs
{
    public partial class Match
    {
        public long Matchesid { get; set; }
        public long? Results { get; set; }
        public long? Year { get; set; }
        public string Grand { get; set; }

        public virtual Result ResultsNavigation { get; set; }
    }
}
