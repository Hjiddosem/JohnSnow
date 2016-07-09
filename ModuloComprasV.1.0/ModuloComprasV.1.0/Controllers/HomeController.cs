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

        public ActionResult MarcasPage()
        {
            ModeloVistaMarcas mv = new ModeloVistaMarcas();
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
            else
            {
                foreach (KeyValuePair<string, string> item in vm.ValidacionErrores)
                {
                    ModelState.AddModelError(item.Key, item.Value); 
                }
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult MarcasPage(ModeloVistaMarcas vm)
        {
            vm.EsValido = ModelState.IsValid;
            vm.ManejadorSolicitud();

            if (vm.EsValido)
            {
                ModelState.Clear();
            }
            else
            {
                foreach (KeyValuePair<string, string> item in vm.ValidacionErrores)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            }

            return View(vm);
        }

    }
}