using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuestBook.Infraestruture;
using GuestBook.Models;

namespace GuestBook.Controllers
{
    public class GuestBookController : Controller
    {
        //
        // GET: /GuestBook/
        //private GuestBookContext ctx = new GuestBookContext();
        private IGuestbookRepository _guestbookRepository;

        public GuestBookController(IGuestbookRepository guestbookRepository)
        {
            _guestbookRepository = guestbookRepository;
        }

        public GuestBookController() : this(new EFGuestbookRepository())
        {
        }


        public ActionResult index() {
            //Listando los 20 primeros
            //uso de linQ
            /*
            var entries = (from e in ctx.Entries 
                           orderby e.DateAdded descending 
                           select e).Take(20); 
            ViewBag.Entries = entries.ToList();*/
            var entries = _guestbookRepository.GetMostRecentEntries();
            return View(entries);
        }

        public ActionResult Create()
        {
            return View();
        }

        //Solo reacciona cuando se invoca al evento Post de un formlario
        [HttpPost]
        public ActionResult Create(GuestBookEntry entry) {
            // Verifica la validacion del GuestbookEntry.cs
            if (ModelState.IsValid)
            {
                _guestbookRepository.AddEntry(entry);
                return RedirectToAction("index");
            }
            else {
                return View(entry);
            }
            
        }
        public ActionResult Show(int id) 
        {
            // El metodo find buscara una cantidad [pr su clave  actua;
            //var entry = ctx.Entries.Find(id);
            var entry = _guestbookRepository.FindById(id);

            // el objeto User.Identity nos da acceso al usuario actualmente logueado y que es
            // fijado por el proveedor de Menbership (No tiene que hacer nada al respecto con
            // esa function por ahora)
            var hasPermissions = User.Identity.Name == entry.Name;
            //ViewData["hasPermissions"] = hasPermissions;
            ViewBag.hasPermissions = hasPermissions;
            // Retorna la vista que muestra los detalles de esa estrda
            return View(entry);

        }

        public ActionResult CommentSummary() 
        {
            var entries = _guestbookRepository.GetCommentSummearies();
            return View(entries);
        }

    }
}
