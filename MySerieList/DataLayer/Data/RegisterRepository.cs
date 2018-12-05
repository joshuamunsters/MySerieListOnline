using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class RegisterRepository
    {
        IRegisterContext registerContext = new RegisterContext();

        public void Register(User user)
        {
            registerContext.Register(user);
        }

    }
}
