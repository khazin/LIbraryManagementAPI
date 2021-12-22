using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIbraryManagementAPI.Model
{
    public class RecordModel
    {
        public RecordModel() { }

        public int recId { get; set; }
        public DateTime borrowDate { get; set; }
        public DateTime returnDueDate { get; set; }
        public DateTime returnDate { get; set; }
        public string status { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
    }
}
