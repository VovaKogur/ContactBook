using ASP.DataAccess.Data;
using ASP.DataAccess.Repository.IRepository;
using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.DataAccess.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly ApplicationDbContext _db;
        public ContactRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Contact contact)
        {
            _db.Contacts.Update(contact);
        }
    }
}
