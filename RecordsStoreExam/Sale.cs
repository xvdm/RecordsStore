using System;
using System.Collections.Generic;

#nullable disable

namespace RecordsStoreExam
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int IdRecord { get; set; }
        public int IdUser { get; set; }
        public DateTime DateOfSale { get; set; }

        public virtual Record IdRecordNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
