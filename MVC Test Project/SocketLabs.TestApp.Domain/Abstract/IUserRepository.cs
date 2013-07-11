using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketLabs.TestApp.Domain.Entities;

namespace SocketLabs.TestApp.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        void SaveUser(User user);

        void DeleteUser(User user);
 
    }
}
