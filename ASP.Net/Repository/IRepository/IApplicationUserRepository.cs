﻿using ASP.Net.Data;
using ASP.Net.DataAccess.Repository.IRepository;
using ASP.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net.DataAccess.Repository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
    }
}
