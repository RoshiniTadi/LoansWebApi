using LoansWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoansWebApi.Controllers
{
    public class AuthenticationController : ApiController
    {

        LoanDataSchemaEntities _db;

        public AuthenticationController()
        {
            _db = new LoanDataSchemaEntities();
        }
       /// <summary>
       /// This method gets all the primary borrowers.
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        [Authorize(Roles ="admin")]
  
        public IEnumerable<LoanDetailsModel> GetLoans(int pageNumber,int size)
        {
            return _db.tblLoans.GroupBy(x => x.ActualLoanid).Select(y => y.FirstOrDefault()).Select(n => new LoanDetailsModel
            {
                ActualLoanid = n.ActualLoanid,
                userModel = new UserModel()
                {
                    Name = n.tblUser.Name,
                    tbUserID = n.tblUser.tbUserID,
                    email = n.tblUser.email,
                    Address = n.tblUser.Address,
                    mobile = n.tblUser.mobile
                },
                roleModel = new RoleModel()
                {
                    Name = n.tblUserLoans.Where(z => z.tbLoanID == n.tbLoanId).FirstOrDefault().tblRole.Name,


                },
                loanstatusModel = new LoanStatusModel()
                {
                     tbStatusID=n.tblLoanStatu.tbStatusID,
                    Description = n.tblLoanStatu.Description,
                     Label=n.tblLoanStatu.Label,   
                 }

            }).ToList().OrderBy(p => p.ActualLoanid).Skip(pageNumber * size).Take(size);
        }
        /// <summary>
        /// This method gets all the data about the primary borrower based on actual loan id
        /// </summary>
        /// <param name="LoanId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<LoanDetailsModel> GetPersonLoanDetails(string LoanId)
        {
            long ActualId = Convert.ToInt64(LoanId);
            return _db.tblLoans.Where(x=>x.ActualLoanid==ActualId&&x.isActive==true).Select(n => new LoanDetailsModel
            {
                ActualLoanid = n.ActualLoanid,
                userModel = new UserModel()
                {
                    Name = n.tblUser.Name,
                    tbUserID = n.tblUser.tbUserID,
                    email = n.tblUser.email,
                    Address = n.tblUser.Address,
                    mobile = n.tblUser.mobile
                },
                roleModel = new RoleModel()
                {
                    Name = n.tblUserLoans.Where(z => z.tbLoanID == n.tbLoanId).FirstOrDefault().tblRole.Name,


                },
                loanstatusModel = new LoanStatusModel()
                {
                    tbStatusID = n.tblLoanStatu.tbStatusID,
                    Description = n.tblLoanStatu.Description,
                    Label = n.tblLoanStatu.Label,
                }

            }).ToList();
        }
        //Add the updation to the settings..
        /// <summary>
        /// This method is used to update the settings of the user based on userid in the data base..
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize (Roles="admin")]
       public HttpResponseMessage PutSettings(SettingsModel Obj)
        {
            int userId = User.Identity.getId();
            tblSetting x = _db.tblSettings.Where(m => m.tbUserID == userId).FirstOrDefault();
            x.isAlertEnabled = Obj.isAlertEnabled;
            x.isAllSettingsEnabled = Obj.isAllSettingsEnabled;
            x.isPushNotificationEnabled = Obj.isPushNotificationEnabled;
            _db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "The changes are updated to the database");
        }
        /// <summary>
        /// This method gets all the settings related to the particular userId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //Get settings
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<SettingsModel>  GetSettings()
        {
            int userId = User.Identity.getId();
            return _db.tblSettings.Where(x => x.tbUserID == userId).Select(y => new SettingsModel()
            {
                tbUserID = userId,
                 isAlertEnabled=y.isAlertEnabled,
                 isAllSettingsEnabled=y.isAllSettingsEnabled,
                 isPushNotificationEnabled=y.isPushNotificationEnabled
            }

                ).ToList();
            
        }
        /// <summary>
        /// This method gets all the alerts related to the particular userId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //Get Alert
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<UserAlertsModel> GetAlerts()
        {

            int userId = User.Identity.getId();
            return _db.tblUserAlerts.Where(x => x.tbUserID == userId).Select(y => new UserAlertsModel()
            {
                tbUserID=userId,
                tbAlertID=y.tbAlertID,
                 isDeleted=y.isDeleted,
                  isRead=y.isRead,
                  alertModel=new Alertsmodel()
                  {
                     
                       Description =y.tblAlert.Description,
                        subject=y.tblAlert.subject,
                         createdAt=y.tblAlert.createdAt,
                          isActive=y.tblAlert.isActive
                          
                  }
            }

   ).ToList();

        }
    }

    }
