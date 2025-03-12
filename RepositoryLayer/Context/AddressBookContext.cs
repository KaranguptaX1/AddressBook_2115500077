using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
namespace RepositoryLayer.Context
{
    public class AddressBookContext: DbContext
    {
        public AddressBookContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Contact> Contacts { get; set; }

    }
}
