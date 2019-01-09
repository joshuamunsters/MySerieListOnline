using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class LoginRepository
    {

        ILoginContext loginContext = new LoginContext();

        public User GetUserByEMail(string eMail)
        {
            return loginContext.GetUserByEMail(eMail);
        }

        public bool LoginCheck(string eMail, string passWord)
        {
            return loginContext.LoginCheck(eMail, passWord);
        }

    }
}
