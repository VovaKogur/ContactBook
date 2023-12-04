﻿using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.DataAccess.Repository.IRepository
{
    public interface IContactRepository: IRepository<Contact>
    {
        void Update(Contact product);
    }
}
