using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuestBook.Models
{
    public class GuestBookEntry
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Message { get; set; }

        public DateTime DateAdded { get; set; }
    }
}