using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIbraryManagementAPI.Model
{
    public class Register
    {
        public Register() { }


        public string email { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime birthday { get; set; }
        public int contact { get; set; }

        public string strAddress { get; set; }
        public int buildNo { get; set; }
        public int unitNo { get; set; }
        public int postcode { get; set; }
        public int userId { get; set; }
    }
}
