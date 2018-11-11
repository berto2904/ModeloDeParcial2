using ModeloDeParcial2.Models;
using ModeloDeParcial2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModeloDeParcial2.Controllers
{
    public class MaratonController : Controller
    {
        MaratonService ms = new MaratonService();
        // GET: Maraton
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CrearMaraton()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearMaraton(Maraton maraton)
        {
            ms.CrearMaraton(maraton);
            return RedirectToAction("ListarMaratones");
        }

        public ActionResult ListarMaratones()
        {
            return View(ms.ObtenerListaMaratones());
        }

        public ActionResult Editar(int id)
        {
            Maraton m = ms.GetMaratonById(id);
            return View("CrearMaraton", m);
        }

        [HttpPost]
        public ActionResult Editar(Maraton maraton)
        {
            //Maraton m = ms.GetMaratonById(id);

            ms.EditarMaraton(maraton);
            return RedirectToAction("ListarMaratones");
        }

        public ActionResult Eliminar(int id)
        {
            ms.EliminarMaraton(id);
            return RedirectToAction("ListarMaratones");
        }
    }
}