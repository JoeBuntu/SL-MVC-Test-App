using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using SocketLabs.TestApp.Domain.Entities;

namespace SocketLabs.TestApp.Domain.Concrete
{
    public class TestAppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
