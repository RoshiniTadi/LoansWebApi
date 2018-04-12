using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoansWebApi.Models
{
    public class SettingsModel
    {
        public long tbUserID { get; set; }
        public bool isAllSettingsEnabled { get; set; }
        public bool isPushNotificationEnabled { get; set; }
        public bool isAlertEnabled { get; set; }

    }
}