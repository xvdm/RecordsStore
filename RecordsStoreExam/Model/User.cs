using System;
using System.Collections.Generic;

#nullable disable

namespace RecordsStoreExam
{
    public partial class User
    {
        public User()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
