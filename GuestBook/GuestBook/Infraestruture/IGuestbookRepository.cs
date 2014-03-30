using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuestBook.Models;

namespace GuestBook.Infraestruture
{
    public interface IGuestbookRepository
    {
        IList<GuestBookEntry> GetMostRecentEntries();
        GuestBookEntry FindById(int Id);

        IList<CommentSummary> GetCommentSummearies();
        void AddEntry(GuestBookEntry entry);
    }
}
