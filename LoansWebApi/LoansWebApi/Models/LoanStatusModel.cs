using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansWebApi.Models
{
    public class LoanStatusModel
    {
        public int tbStatusID { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
       
    }
}