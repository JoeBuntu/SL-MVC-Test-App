using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketLabs.TestApp.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public int ImageViews { get; set; }
    }
}
