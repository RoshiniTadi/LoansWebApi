using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace LoansWebApi
{
    public class CustomAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            LoanDataSchemaEntities _db = new LoansWebApi.LoanDataSchemaEntities();
            if (_db.tblUsers.Any(x => x.email == context.UserName && x.password == context.Password))
            {
                if (context.UserName.Contains("@ggktech.com"))
                { var s = _db.tblUsers.Where(x => x.email == context.UserName && x.password == context.Password).FirstOrDefault();
                    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                    identity.AddClaim(new Claim("userID", s.tbUserID.ToString()));
                    context.Validated(identity);
                }
                else 
                {
                    var s = _db.tblUsers.Where(x => x.email == context.UserName && x.password == context.Password).FirstOrDefault();
                    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                    identity.AddClaim(new Claim("userID", s.tbUserID.ToString()));
                    context.Validated(identity);
                }
            }
            else
            {
                context.SetError("Message", "invalid credentials");
            }
        }
    }
}