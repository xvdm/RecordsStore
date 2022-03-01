using System;
using System.Collections.Generic;

#nullable disable

namespace RecordsStoreExam
{
    public partial class Genre
    {
        public Genre()
        {
            Records = new HashSet<Record>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Record> Records { get; set; }
    }
}
