﻿using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using static DAL.Interfaces.IBaseRepository;

namespace DAL.Interfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
    }
}
