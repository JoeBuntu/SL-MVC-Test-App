using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketLabs.TestApp.Domain.Entities;

namespace SocketLabs.TestApp.Domain.Abstract
{
    public interface ILoginProvider
    {
        bool TryLogin(string name, string password);        
    }
}
