using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIbraryManagementAPI.EFModels
{
    public class Record
    {
        [Key]
        public int recId { get; set; }
        public DateTime borrowDate { get; set; }
        public DateTime returnDueDate { get; set; }
        public DateTime returnDate { get; set; }
        public string status { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
