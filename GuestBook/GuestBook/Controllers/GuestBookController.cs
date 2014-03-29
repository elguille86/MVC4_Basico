using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuestBook.Models;

namespace GuestBook.Controllers
{
    public class GuestBookController : Controller
    {
        //
        // GET: /GuestBook/
        private GuestBookContext ctx = new GuestBookContext();

        public ActionResult index() {
            //Listando los 20 primeros
            //uso de linQ
            var entries = (from e in ctx.Entries orderby e.DateAdded descending select e).Take(20); 
            ViewBag.Entries = entries.ToList();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuestBookEntry entry) {
            entry.DateAdded = DateTime.Now;
            ctx.Entries.Add(entry);
            ctx.SaveChanges();
           // return Content("La entrada se envio Correctamente");
            // Se cambia para rediccion a la vista index
            return RedirectToAction("index");
        }

    }
}
