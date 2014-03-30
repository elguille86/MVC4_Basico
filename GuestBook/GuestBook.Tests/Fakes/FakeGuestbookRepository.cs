using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuestBook.Infraestruture;
using GuestBook.Models;

namespace GuestBook.Tests.Fakes
{
    public class FakeGuestbookRepository : IGuestbookRepository
    {
        private List<GuestBookEntry> _entries = new List<GuestBookEntry>();
        public IList<GuestBookEntry> GetMostRecentEntries()
        {
            return new List<GuestBookEntry>()
            {
                new GuestBookEntry()
                {
                    DateAdded = new DateTime(2013,10,11),
                    Id = 1,
                    Message = "Test",
                    Name = "Jesus"
                }
            };
        }

        public GuestBookEntry FindById(int id)
        {
            return _entries.SingleOrDefault(e => e.Id == id);
        }

        public IList<CommentSummary> GetCommentSummaries()
        {
            return new List<CommentSummary>()
            {
                new CommentSummary()
                {
                    NumberOfComments = 1,UserName = "Jesus"
                }
            };
        }

        public void AddEntry(GuestBookEntry entry)
        {
            _entries.Add(entry);
        }
    }
}
