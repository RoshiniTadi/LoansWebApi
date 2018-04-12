using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansWebApi.Models
{
    public class LoanDetailsModel
    {
        
        public long ActualLoanid { get; set; }
     
      
       public UserModel userModel { get; set; }
       public RoleModel roleModel { get; set; }
        public LoanStatusModel loanstatusModel { get; set; }
    }
}