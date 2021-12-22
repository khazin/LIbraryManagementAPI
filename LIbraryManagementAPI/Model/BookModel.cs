using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIbraryManagementAPI.Model
{
    public class BookModel
    {
        public BookModel() { }
     

        public int bookId { get; set; }
        public string serialNo { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public IFormFile image { get; set; }
        public string author { get; set; }
        public string category { get; set; }
        public string status { get; set; }
    }
}
