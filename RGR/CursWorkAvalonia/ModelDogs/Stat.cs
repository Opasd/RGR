using System;
using System.Collections.Generic;

namespace TreeDataGridDemo.ModelDogs
{
    public partial class Stat
    {
        public Stat()
        {
            Dogs = new HashSet<Dog>();
        }

        public long Statsid { get; set; }
        public long? Wins { get; set; }
        public long? Races { get; set; }
        public long? Windist { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
