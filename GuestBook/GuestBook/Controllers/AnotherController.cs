using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuestBook.Controllers
{
    public class AnotherController : Controller
    {
        //
        // GET: /Another/

        public void Index()
        {
            //return View();
            Response.Write("<h1>Soy un simple comprolador</h1>");
        }
        public string Other()
        {
            return "<h1>Soy un simple Controlador</h1>";       
        }

        [NonAction]
        public ContentResult otherResult()
        {
            return Content("<h1>Soy un simple Controlador</h1>");
        }

    }
}
