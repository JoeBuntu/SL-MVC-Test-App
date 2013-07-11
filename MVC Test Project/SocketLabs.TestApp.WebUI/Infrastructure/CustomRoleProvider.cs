using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SocketLabs.TestApp.Domain.Abstract;
using SocketLabs.TestApp.Domain.Concrete;
using System.Web.Mvc;

namespace SocketLabs.TestApp.WebUI.Infrastructure
{
    public class CustomRoleProvider : RoleProvider
    {
        private IUserRepository _UserRepository;
        public CustomRoleProvider()
        {
            _UserRepository = DependencyResolver.Current.GetService<IUserRepository>();
        }
 
        //user is either admin or customer
        public override string[] GetRolesForUser(string username)
        { 
            bool isAdmin = _UserRepository.Users.Where(x => x.Name == username).Any(x => x.IsAdmin);
            return isAdmin ? new [] {"Admin"} : new [] {"Customer"};
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool checkAdmin = roleName == "Admin";
            bool isAdmin = _UserRepository.Users.Where(x => x.Name == username).Any(x => x.IsAdmin == checkAdmin);
            return isAdmin;
        }

        //per instructions, user management features not needed
        #region Not Used

        public override string ApplicationName { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
 
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
 
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}