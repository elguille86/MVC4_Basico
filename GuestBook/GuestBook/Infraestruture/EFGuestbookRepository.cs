using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GuestBook.Models;

namespace GuestBook.Infraestruture
{
    public class EFGuestbookRepository: IGuestbookRepository
    {
        private GuestBookContext ctx = new GuestBookContext();
        public IList<Models.GuestBookEntry> GetMostRecentEntries()
        {
          //  throw new NotImplementedException();
            var entries = (from e in ctx.Entries
                           orderby e.DateAdded descending
                           select e).Take(20);
            return entries.ToList();
        }

        public Models.GuestBookEntry FindById(int id)
        {
            //throw new NotImplementedException();
            return ctx.Entries.Find(id);
        }

        public IList<Models.CommentSummary> GetCommentSummearies()
        {
           // throw new NotImplementedException();
            var entries = from entry in ctx.Entries
                          group entry by entry.Name
                              into groupedByName
                              orderby groupedByName.Count() descending
                              select new CommentSummary()
                              {
                                  UserName = groupedByName.Key,
                                  NumberOfComments = groupedByName.Count()
                              };
            return entries.ToList();
        }

        public void AddEntry(Models.GuestBookEntry entry)
        {
            //throw new NotImplementedException();
            entry.DateAdded = DateTime.Now;
            ctx.Entries.Add(entry);
            ctx.SaveChanges();
        }
    }
}