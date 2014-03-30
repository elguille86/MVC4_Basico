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

        //Solo reacciona cuando se invoca al evento Post de un formlario
        [HttpPost]
        public ActionResult Create(GuestBookEntry entry) {
            // Verifica la validacion del GuestbookEntry.cs
            if (ModelState.IsValid)
            {
                entry.DateAdded = DateTime.Now;
                ctx.Entries.Add(entry);
                ctx.SaveChanges();
                // return Content("La entrada se envio Correctamente");
                // Se cambia para rediccion a la vista index
                return RedirectToAction("index");
            }
            else {
                return View(entry);
            }
            
        }
        public ActionResult Show(int id) 
        {
            // El metodo find buscara una cantidad [pr su clave  actua;
            var entry = ctx.Entries.Find(id);

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
            var entries = from entry in ctx.Entries
                group entry by entry.Name
                    into groupbyName
                    orderby groupbyName.Count()
                    select new ComentSumary()
                    {
                        UserNae = groupbyName.Key,
                        NumberOfComents = groupbyName.Count()
                    };
            return View(entries);
        }

    }
}
