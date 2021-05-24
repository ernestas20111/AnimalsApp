﻿using AnimalsAppBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsAppBackend.DataAccess
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }

        Task SaveChangesAsync();
    }
}
