using System;
using System.Collections.Generic;

#nullable disable

namespace RecordsStoreExam
{
    public partial class Record
    {
        public Record()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TracksAmount { get; set; }
        public int PublishingYear { get; set; }
        public decimal PrimeCost { get; set; }
        public decimal Price { get; set; }
        public string PhotoUri { get; set; }
        public int IdBand { get; set; }
        public int IdPublisher { get; set; }
        public int IdGenre { get; set; }

        public virtual Band IdBandNavigation { get; set; }
        public virtual Genre IdGenreNavigation { get; set; }
        public virtual Publisher IdPublisherNavigation { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
