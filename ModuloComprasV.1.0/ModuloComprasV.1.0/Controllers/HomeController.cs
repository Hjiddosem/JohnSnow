using MCData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuloComprasV._1._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ModeloVistaProductos mv = new ModeloVistaProductos();
            mv.ManejadorSolicitud();
            return View(mv);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Index(ModeloVistaProductos vm)
        {
            vm.EsValido = ModelState.IsValid;
            vm.ManejadorSolicitud();

            if (vm.EsValido)
            {
                ModelState.Clear();
            }

            return View(vm);
        }


    }
}