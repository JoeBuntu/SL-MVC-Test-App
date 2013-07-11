using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SocketLabs.TestApp.Domain.Abstract;
using SocketLabs.TestApp.Domain.Concrete;
using SocketLabs.TestApp.Domain.Entities;
using System.Web.Mvc;

namespace SocketLabs.TestApp.WebUI.Infrastructure
{
    public class CustomMembershipProvider : MembershipProvider
    {
        private readonly ILoginProvider _LoginProvider;
        private readonly IUserRepository _UserRepository;

        public CustomMembershipProvider()
        {
            _LoginProvider = DependencyResolver.Current.GetService<ILoginProvider>();
            _UserRepository = DependencyResolver.Current.GetService<IUserRepository>();
        }
 
        public override bool ValidateUser(string username, string password)
        { 
            return _LoginProvider.TryLogin(username, password);
        }
 
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            MembershipUser retVal = null;
            User user = _UserRepository.Users.SingleOrDefault(x => x.Name == username);
            if (user != null)
            {
                retVal = new MembershipUser(
                    providerName: GetType().Name,
                    name: user.Name,
                    providerUserKey: user.UserId,
                    email: null,
                    passwordQuestion: null,
                    comment: null,
                    isApproved: false,
                    isLockedOut: false,
                    creationDate: DateTime.MinValue,
                    lastLoginDate: DateTime.MinValue,
                    lastActivityDate: DateTime.MinValue,
                    lastPasswordChangedDate: DateTime.MinValue,
                    lastLockoutDate: DateTime.MinValue
                );
            }
            return retVal; 
        }
 
        //per instructions, user management features not needed
        #region Not Used

        public override string ApplicationName { get; set; }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
 
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}