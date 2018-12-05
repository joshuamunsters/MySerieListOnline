using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class RegisterLogic
    {
        RegisterRepository registerRepository { get; set; } = new RegisterRepository();

        public void Register(User user)
        {
            registerRepository.Register(user);
        }
    }
}
