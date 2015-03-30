using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web.Security;

namespace Wavecell.Security
{
  
    public class UserPrincipal : IPrincipal
    {
        public UserPrincipal(IIdentity identity, string roles,string firstName,string lastName)
        {
            this.Identity = identity;
            this._roles = roles;
            this._firstName = firstName;
            this._lastName = lastName;
        }

        private readonly string _roles;
        private string _firstName;
        private string _lastName;

        public IIdentity Identity { get; set; }

        public string FirstName { get { return _firstName; } }

        public string LastName { get { return _lastName; } }

        public bool IsInRole(string role)
        {
            string[] values = role.Split(',');

            return values.Any(value => _roles.Contains(value));

        }


        public bool HasRole()
        {
            return _roles != "Everyone";
        }

    }
}
