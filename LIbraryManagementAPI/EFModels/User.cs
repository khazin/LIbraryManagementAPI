using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LIbraryManagementAPI.EFModels
{
    public class User
    {
        public User()
        {
            this.Records = new HashSet<Record>();
            this.Addresses = new HashSet<Address>();
        }

        [Key]
        public int userId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime birthday { get; set; }
        public int contact { get; set; }
        public string type { get; set; }

        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
