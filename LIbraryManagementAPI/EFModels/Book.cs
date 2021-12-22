using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIbraryManagementAPI.EFModels
{
    public class Book
    {
        public Book()
        {
            this.Records = new HashSet<Record>();
        }

        [Key]
        public int bookId { get; set; }
        public string serialNo { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string author { get; set; }
        public string category { get; set; }
        public string status { get; set; }
        public virtual ICollection<Record> Records { get; set; }

    }
}
