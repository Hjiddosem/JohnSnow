using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModuloComprasV._1._0.Models;

namespace ModuloComprasV._1._0.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (DBContext db = new DBContext())
            {
                return View(db.Compras.ToList());
            }
        }

        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(CuentaDeUsuario CuentadeUsuario)
        { 
            if (ModelState.IsValid)
            {
                using (DBContext db = new DBContext())
                {
                    db.Compras.Add(CuentadeUsuario);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = CuentadeUsuario.Nombre + " " + CuentadeUsuario + " Registro completado.";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(CuentaDeUsuario User)
        {
            using (DBContext db = new DBContext())
            {
                var usu = db.Compras.Single(u => u.usuario == User.usuario && u.contraseña == User.contraseña);
                if (usu != null)
                {
                    Session["ID"] = usu.UserID.ToString();
                    Session["Usuario"] = usu.usuario.ToString();
                    return RedirectToAction("Logueado");
                }
                else
                {
                    ModelState.AddModelError("", "uy!! Usuario o contraseña mal.");
                }
            }
            return View();
        }
        public ActionResult Logueado()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }

    }
}