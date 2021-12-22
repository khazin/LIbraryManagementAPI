using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIbraryManagementAPI.EFModels
{
    public class Address
    {
        public Address()
        {
        }

        [Key]
        public int Addrid { get; set; }
        public string strAddress { get; set; }
        public int buildNo { get; set; }
        public int unitNo { get; set; }
        public int postcode { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
    }
}
