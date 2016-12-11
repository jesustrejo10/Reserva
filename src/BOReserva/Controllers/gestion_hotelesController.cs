using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Servicio.Servicio_Hoteles;

namespace BOReserva.Controllers
{
    public class gestion_hotelesController : Controller
    {
        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_Crear()
        {
            CGestionHoteles_CrearHotel crear = new CGestionHoteles_CrearHotel();
            
            return PartialView(crear);
        }

        [HttpPost]
        public JsonResult crearhotel(CGestionHoteles_CrearHotel crear) {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_ModificarHotel()
        {
            CGestionHoteles_EditarHotel modificar = new CGestionHoteles_EditarHotel();
            return PartialView(modificar);
        }

        [HttpPost]
        public JsonResult editarhotel(CGestionHoteles_EditarHotel modificar)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_Desactivar()
        {
            return PartialView();
        }

        public static List<SelectListItem> pais()
        {
            CManejadorSQL_Hoteles pais = new CManejadorSQL_Hoteles();
            List<SelectListItem> _pais = new List<SelectListItem>();
            String[] paises = pais.MListarpaisesBD();
            int i = 0;
            bool verdad = true;
            while (verdad == true)
            {
                try
                {
                    _pais.Add(new SelectListItem
                    {
                        Text = paises[i].ToString(),
                        Value = i.ToString()
                    });
                    i++;
                }
                catch (Exception e)
                {
                    verdad = false;
                }
            }
            return _pais;
        }

    }


}