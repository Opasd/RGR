using System;
using System.Collections.Generic;

namespace TreeDataGridDemo.ModelDogs
{
    public partial class Dog
    {
        public Dog()
        {
            Results = new HashSet<Result>();
        }

        public long Dogid { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public long? Stats { get; set; }

        public virtual Stat StatsNavigation { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
