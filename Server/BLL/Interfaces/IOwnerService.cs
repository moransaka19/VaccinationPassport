﻿using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IOwnerService
    {
        void AddPet(int petId, User owner);
        IEnumerable<User> GetAllOwners();
    }
}
