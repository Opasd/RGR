using System;
using System.Collections.Generic;

namespace TreeDataGridDemo.ModelDogs
{
    public partial class Result
    {
        public Result()
        {
            Matches = new HashSet<Match>();
        }

        public long Resultsid { get; set; }
        public long? Winner { get; set; }
        public long? Reward { get; set; }

        public virtual Dog WinnerNavigation { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
