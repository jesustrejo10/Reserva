using BOReserva.Models.gestion_seguridad_ingreso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Content.Controllers
{
    public class gestion_seguridad_ingresoController : Controller
    {
        //
        // GET: /gestion_seguridad_ingreso/

        [HttpPost]
        public ActionResult M01_Login(string name, string password)
        {
            
            if ("admin@admin.com".Equals(name) && "123".Equals(password))
            {
                System.Diagnostics.Debug.WriteLine("Nombre " + name + " password " + password);
                Session["Cgestion_seguridad_ingreso"] = new Cgestion_seguridad_ingreso() { _correoCampoTexto = name, _nombreUsuarioTexto = "David Botello" };
                return RedirectToAction("Index", "Home");
            }
            System.Diagnostics.Debug.WriteLine("que retorno");
            return RedirectToAction("M01_Login", "gestion_seguridad_ingreso");
        }

        public ActionResult M01_Login()
        {
            Cgestion_seguridad_ingreso model = new Cgestion_seguridad_ingreso();
            return PartialView(model);
        }

        public ActionResult M01_RecuperarContrasenna()
        {
            Cgestion_seguridad_ingreso model = new Cgestion_seguridad_ingreso();
            return PartialView(model);
        }

        public ActionResult M01_Landing()
        {
            Cgestion_seguridad_ingreso model = new Cgestion_seguridad_ingreso();
            return View("M01_Landing", "~/Views/Shared/_Layout.cshtml",model);
        }




        [HttpPost]
        public JsonResult verificarUsuario(Cgestion_seguridad_ingreso model)
        {
            String prueba = model._correoCampoTexto + " " + model._claveCampoTexto;
            
            return (Json(true, JsonRequestBehavior.AllowGet));
        }













        //
        // GET: /gestion_seguridad_ingreso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /gestion_seguridad_ingreso/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /gestion_seguridad_ingreso/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /gestion_seguridad_ingreso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /gestion_seguridad_ingreso/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /gestion_seguridad_ingreso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /gestion_seguridad_ingreso/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
