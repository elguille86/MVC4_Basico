using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace GuestBook.Models
{
    public class GuestBookContext: DbContext
    {
        public GuestBookContext(): base("GuestBook")
        {
        
        }
        public DbSet<GuestBookEntry> Entries { get; set; }
    }
}