using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansWebApi.Models
{
    public class UserAlertsModel
    {
        public long tbUserID { get; set; }
        public int tbAlertID { get; set; }
        public bool isRead { get; set; }
        public bool isDeleted { get; set; }
        public Alertsmodel alertModel { get; set; }
    }
}