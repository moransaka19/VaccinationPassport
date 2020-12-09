﻿using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        bool IsLoginTaken(string login);
        bool IsNameTaken(string name);
        void Register(string login, string name, string password, bool isDoctor);
        User Authenticate(User model);
    }
}
