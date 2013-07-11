using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketLabs.TestApp.Domain.Abstract;
using SocketLabs.TestApp.Domain.Entities;

namespace SocketLabs.TestApp.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private TestAppDBContext _DbContext = new TestAppDBContext();

        public IQueryable<User> Users
        {
            get { return _DbContext.Users; }
        }

        public void SaveUser(User user)
        { 
            if (user.UserId == 0)
            {
                //new
                _DbContext.Users.Add(user);
            }
            else
            {
                //modify existing
                User record = _DbContext.Users.Find(user.UserId);
                if (record != null)
                {
                    _DbContext.Entry(record).CurrentValues.SetValues(user);
                }
            }
            _DbContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            User record = _DbContext.Users.Find(user.UserId);
            if (record != null)
            {
                _DbContext.Users.Remove(record);
                _DbContext.SaveChanges();
            }
        }
    }
}
