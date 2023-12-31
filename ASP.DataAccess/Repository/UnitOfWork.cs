﻿using ASP.DataAccess.Data;
using ASP.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public IContactRepository Contact { get; private set; }

        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Contact = new ContactRepository(db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
