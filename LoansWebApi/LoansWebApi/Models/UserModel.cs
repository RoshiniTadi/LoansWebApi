using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansWebApi.Models
{
    public class UserModel
    {
        public long tbUserID { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }

        public string Address { get; set; }

    }
}