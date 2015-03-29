using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wavecell.Entities;
using Wavecell.Repository;
using Wavecell.ServiceLayer.Common;

namespace Wavecell.ServiceLayer
{
    public class UserService : ServiceBase<User>, IUserService
    {
 
        public UserService(IUserRepository repository)
            : base(repository)
        {

        }

        public User ValidateUser(string email, string password)
        {
            var info = Repository.Get(x => x.Email.ToLower() == email.ToLower() && x.Password == password);

            return info;
        }

        public User ChangePassword(User info, string oldPassword, string newPassword, string confirmPassword)
        {
            if (IsValid(info, Action.Custom, "ChangePassword", oldPassword, newPassword, confirmPassword))
            {
                info.Password = newPassword;
                return Repository.Update(info);
            }

            return info;
        }

        protected override bool ValidateData(User info, Action action, params string[] args)
        {
            var isValid = ValidationDictionary.IsValid;

            if (action == Action.Create)
            {

                var duplicateEmail = this.Repository.Get(x => x.Email.ToLower() == info.Email.ToLower());

                if (duplicateEmail!=null)
                {
                    ValidationDictionary.AddError("", "Email Address is already registered.");
                    isValid = false;
                }
            }



            if (action == Action.Custom && args.Contains("ChangePassword"))
            {
                var oldPassword = args[1];
                var newPassword = args[2];
                var confirmPassword = args[3];

                if (oldPassword != info.Password)
                {
                    ValidationDictionary.AddError("OldPassword", "The password you have entered is invalid.");
                    isValid = false;
                }

                if (newPassword != confirmPassword && isValid)
                {
                    ValidationDictionary.AddError("ConfirmPassword", "The new password and confirmation password do not match.");
                    isValid = false;
                }
            }

            return isValid;
        }
    }

    public interface IUserService : IService<User>
    {
        User ValidateUser(string username, string password);
        User ChangePassword(User info, string oldPassword, string newPassword, string confirmPassword);
    }
}
