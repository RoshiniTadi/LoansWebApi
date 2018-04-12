using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansWebApi.Models
{
    public class Alertsmodel
    {
     
        public string subject { get; set; }
        public string Description { get; set; }
        public System.DateTime createdAt { get; set; }
        public bool isActive { get; set; }

    }
}