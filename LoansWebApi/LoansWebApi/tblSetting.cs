//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoansWebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSetting
    {
        public int tbSettingsID { get; set; }
        public long tbUserID { get; set; }
        public bool isAllSettingsEnabled { get; set; }
        public bool isPushNotificationEnabled { get; set; }
        public bool isAlertEnabled { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}
