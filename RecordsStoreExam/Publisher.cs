using System;
using System.Collections.Generic;

#nullable disable

namespace RecordsStoreExam
{
    public partial class Publisher
    {
        public Publisher()
        {
            Records = new HashSet<Record>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Record> Records { get; set; }
    }
}
