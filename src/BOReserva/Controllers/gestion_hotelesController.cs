using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Servicio.Servicio_Hoteles;
using System.Diagnostics;

namespace BOReserva.Controllers
{
    public class gestion_hotelesController : Controller
    {
        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_Crear()
        {
            CGestionHoteles_CrearHotel crear = new CGestionHoteles_CrearHotel()
            {
                _listaPais = new List<SelectListItem> (pais())
            };

            ViewData["pais"] = pais();

            return PartialView(crear);
        }

        [HttpPost]
        public JsonResult crearhotel(CGestionHoteles_CrearHotel crear)
        {
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

            _pais.Add(new SelectListItem
            {
                Text = "Seleccione País",
                Value = "0"
            });

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

        [HttpPost]
        public JsonResult GetCiudades(string pais)
        {
            Debug.WriteLine("GETCIUDADES");
            List<SelectListItem> _ciudades = new List<SelectListItem>();
            _ciudades = ciudad(pais);

            return Json(new SelectList(_ciudades, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCiudad(string pais)
        {

            CGestionHoteles_CrearHotel crear = new CGestionHoteles_CrearHotel()
            {
                _listaCiudad = new List<SelectListItem>(ciudad(pais))
            };

            return View("Crear Hotel", crear);
        }

        public List<SelectListItem> ciudad(string pais)
        {
            Debug.WriteLine("CIUDAD FILTRADA");
            List<SelectListItem> _ciudades = new List<SelectListItem>();
            CManejadorSQL_Hoteles ciudad = new CManejadorSQL_Hoteles();
            String[] ciudadesBD = ciudad.MListarciudadesBD(pais);

            _ciudades.Add(new SelectListItem
            {
                Text = "Seleccione Ciudad",
                Value = "0"
            });

            int i = 0;
            bool verdad = true;
            while (verdad == true)
            {
                try
                {
                    _ciudades.Add(new SelectListItem
                    {
                        Text = _ciudades[i].ToString(),
                        Value = i.ToString()
                    });
                    i++;
                }
                catch (Exception e)
                {
                    verdad = false;
                }
            }

            return _ciudades;
        }

    }


}