﻿using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class LoginLogic
    {
        LoginContext _logInContext = new LoginContext();

        public bool LoginCheck(string eMail, string passWord)
        {
            return _logInContext.LoginCheck(eMail, passWord);
        }

        public User GetUserByEMail(string eMail)
        {
            return _logInContext.GetUserByEMail(eMail);
        }
    }
}
