using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.Domain;
using BOReserva.Models.gestion_cruceros;
using BOReserva.Models.gestion_ruta_comercial;
using System;
using System.Net;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers
{
    public class gestion_crucerosController : Controller
    {
        // GET: gestion_cruceros
        public ActionResult M24_GestionCruceros()
        {
            return PartialView();
        }

        /// <summary>
        /// M�todo de la vista parcial M24_AgregarCabinas
        /// </summary>
        /// <returns>Retorna la vista parcial M24_AgregarCabinas en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_AgregarCabinas()
        {

            CGestion_cabina cabina = new CGestion_cabina();
            List<String> lista = new List<string>();
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarCruceros();
            Dictionary<int, Entidad> listaCruceros = comando.ejecutar();

            try
            {
                foreach (var crucero in listaCruceros)
                {
                    BOReserva.DataAccess.Domain.Crucero c = (BOReserva.DataAccess.Domain.Crucero)crucero.Value;
                    lista.Add(c._nombreCrucero);
                }
                cabina._listaCruceros = lista.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                }); 
                return PartialView(cabina);
            }
            catch (SqlException e)
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, no se pudo conectar con la base de datos";
                //Retorno el error
                return PartialView(error);
            }
        }





        public ActionResult M24_AgregarItinerario()
        {
            CGestion_itinerario itinerario = new CGestion_itinerario();
            List<String> lista = new List<string>();
            List<String> listal = new List<string>();
            listal.Add("Seleccione una ruta origen");
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarCruceros();
            Dictionary<int, Entidad> listaCruceros = comando.ejecutar();

            try
            {
                foreach (var crucero in listaCruceros)
                {
                    BOReserva.DataAccess.Domain.Crucero c = (BOReserva.DataAccess.Domain.Crucero)crucero.Value;
                    lista.Add(c._nombreCrucero);
                }
                itinerario._listaCruceros = lista.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });
                itinerario._listaOrigen = listal    .Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });

                return PartialView(itinerario);
            }
            catch (SqlException e)
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, no se pudo conectar con la base de datos";
                //Retorno el error
                return PartialView(error);
            } 
        }





        /// <summary>
        /// M�todo de la vista parcial M24_AgregarCamarote
        /// </summary>
        /// <returns>Retorna la vista parcial M24_AgregarCamarote en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_AgregarCamarote()
        {
            CGestion_camarote camarote = new CGestion_camarote();
            List<String> lista = new List<string>();
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarCruceros();
            Dictionary<int, Entidad> listaCruceros = comando.ejecutar();

            try
            {
                foreach (var crucero in listaCruceros)
                {
                    BOReserva.DataAccess.Domain.Crucero c = (BOReserva.DataAccess.Domain.Crucero)crucero.Value;
                    lista.Add(c._nombreCrucero);
                }
                camarote._listaCruceros = lista.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });
                return PartialView(camarote);
            }
            catch (SqlException e)
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, no se pudo conectar con la base de datos";
                //Retorno el error
                return PartialView(error);
            }
            
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult cargarCabinas(string crucero)
        {
            CGestion_camarote camarote = new CGestion_camarote();
            List<String> lista = new List<string>();
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarCabinasCrucero(crucero);
            Dictionary<int, Entidad> listaCabinas = comando.ejecutar();

            try
            {
                foreach (var cabina in listaCabinas)
                {
                    BOReserva.DataAccess.Domain.Cabina c = (BOReserva.DataAccess.Domain.Cabina) cabina.Value;
                    lista.Add(c._nombreCabina);
                }
                camarote._listaCabinas = lista.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });
                if (lista != null)
                {
                    return (Json(camarote._listaCabinas, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    String error = "Error accediendo a la BD";
                    return Json(error);
                }

            }
            catch (SqlException e)
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, no se pudo conectar con la base de datos";
                //Retorno el error
                return Json(error);
            }
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult cargarRutasO(string crucero)
        {
            CGestion_itinerario itinerario = new CGestion_itinerario();            
            List<String> lista = new List<string>();
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarRutasCrucero();
            Dictionary<int, Entidad> listaRutas = comando.ejecutar();

            try
            {
                foreach (var ruta in listaRutas)
                {
                    BOReserva.DataAccess.Domain.Ruta c = (BOReserva.DataAccess.Domain.Ruta)ruta.Value;                    
                    lista.Add(c._origenRuta);
                }                
                itinerario._listaOrigen = lista.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });
                if (lista != null)
                {
                    return (Json(itinerario._listaOrigen, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    String error = "Error accediendo a la BD";
                    return Json(error);
                }

            }
            catch (SqlException e)
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, no se pudo conectar con la base de datos";
                //Retorno el error
                return Json(error);
            }


        }



        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult cargarRutasD(string ciudadO)
        {
            CGestion_itinerario itinerario = new CGestion_itinerario();
            List<String> lista = new List<string>();
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarRutasCrucero(ciudadO);
            Dictionary<int, Entidad> listaRutas = comando.ejecutar();

            try
            {
                foreach (var rutas in listaRutas)
                {
                    BOReserva.DataAccess.Domain.Ruta c = (BOReserva.DataAccess.Domain.Ruta)rutas.Value;
                    lista.Add(c._destinoRuta);
                }
                itinerario._listaDestino = lista.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });
                if (lista != null)
                {
                    return (Json(itinerario._listaDestino, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    String error = "Error accediendo a la BD";
                    return Json(error);
                }

            }
            catch (SqlException e)
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, no se pudo conectar con la base de datos";
                //Retorno el error
                return Json(error);
            }


        }





        public JsonResult M24_ListarCamarotes(int id)
        {
            ConexionBD cbd = new ConexionBD();
            var listaCamarotes = cbd.listarCamarotes(id);
            return (Json(listaCamarotes, JsonRequestBehavior.AllowGet));
        }

        /// <summary>
        /// M�todo de la vista parcial M24ListarCruceros
        /// </summary>
        /// <returns>Retorna la vista parcial M24_ListarCruceros en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_ListarCruceros()
        {
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarCruceros();
            Dictionary<int, Entidad> listaCruceros = comando.ejecutar();
            return PartialView(listaCruceros);
        }

        /// <summary>
        /// M�todo de la vista parcial M24ListarItinerarios
        /// </summary>
        /// <returns>Retorna la vista parcial M24_ListarItinerarios en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_ListarItinerario()
        {
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14Visualizaritinerario();
            Dictionary<int, Entidad> listaItinerario = comando.ejecutar();
            return PartialView(listaItinerario);
        }

        /// <summary>
        /// M�todo de la vista parcial M24ListarCabinas
        /// </summary>
        /// <returns>Retorna la vista parcial M24_ListarCcabinas en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_ListarCabinas(int id)
        {
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarCabinas(id);
            Dictionary<int, Entidad> listaCabinas = comando.ejecutar();
            return PartialView(listaCabinas);
        }

        [HttpPost]
        public JsonResult guardarCrucero(CGestion_crucero model)
        {
            
            Entidad nuevoCrucero = FabricaEntidad.InstanciarCrucero(model);            
            Command<String> comando = FabricaComando.crearM14AgregarCrucero(nuevoCrucero);
            String result = comando.ejecutar();
            return (Json(result));            
        }        
        
        [HttpPost]
        public JsonResult guardarCabina(CGestion_cabina model)
        {
            if (model._cruceroNombre == null || model._nombreCabina == null)
                {
                    //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //Agrego mi error
                    String error = "Error, no ha seleccionado un origen/destino valido";
                    //Retorno el error
                    return Json(error);

                }
            else if (model._precioCabina <= 0 || model._precioCabina >= 999999)
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, precio de cabina invalido";
                //Retorno el error
                return Json(error);
            }
            else
            {

                Entidad nuevaCabina = FabricaEntidad.InstanciarCabinaN(model);
                Command<String> comando = FabricaComando.crearM14AgregarCabina(nuevaCabina);
                String result = comando.ejecutar();
                return (Json(result));
            }
            
            
        }
        
        

        [HttpPost]
        public JsonResult guardarCamarote(CGestion_camarote model)
        {
            Entidad nuevoCamarote= FabricaEntidad.InstanciarCamaroteN(model);
            Command<String> comando = FabricaComando.crearM14AgregarCamarote(nuevoCamarote);
            String result = comando.ejecutar();
            return (Json(result));
        }


        [HttpPost]
        public JsonResult guardarItinerario(CGestion_itinerario model)
        {
            Entidad nuevoItinerario = FabricaEntidad.InstanciarItinerarioN(model);
            Command<String> comando = FabricaComando.crearM14AgregaItinerario(nuevoItinerario);
            String result = comando.ejecutar();
            return (Json(result));
        }

        public JsonResult cambioEstatusCabina(int id_cabina)
        {
            CGestion_cabina cabina = new CGestion_cabina();
            cabina.cambioEstatusCabina(id_cabina);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult cambiarEstatusCrucero(int id_crucero)
        {
            CGestion_crucero crucero = new CGestion_crucero();
            crucero.cambiarEstatusCruceros(id_crucero);
            Console.WriteLine(id_crucero);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult cambiarEstatusItinerario(String fechaInicio, int fkCrucero, int fkRuta)
        {
            DateTime pty = Convert.ToDateTime(fechaInicio);
            CGestion_itinerario itinerario = new CGestion_itinerario();
            itinerario.cambiarEstatusItinerario(pty, fkCrucero, fkRuta);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        public JsonResult cambioEstatusCamarote(int id_camarote)
        {
            CGestion_camarote camarote = new CGestion_camarote();
            camarote.cambioEstatusCamarote(id_camarote);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult modificarCrucero(CGestion_crucero model)
        {
            int _idCrucero = model._idCrucero;
            String _nombreCrucero = model._nombreCrucero;
            String _companiaCrucero = model._companiaCrucero;
            int _capacidadCrucero = model._capacidadCrucero;
            CGestion_crucero crucero = new CGestion_crucero(_idCrucero, _nombreCrucero, _companiaCrucero, _capacidadCrucero);
            crucero.ModificarCrucero(crucero);

            return (Json(crucero, JsonRequestBehavior.AllowGet));
        }

        public ActionResult M24_ModificarCrucero(int id)
        {
            try
            {
                ConexionBD cbd = new ConexionBD();
                CGestion_crucero crucero = new CGestion_crucero();
                crucero = cbd.consultarCruceroID(id);
                //crucero.cabinas = cbd.listarCabinas(id);
                return PartialView("M24_ModificarCrucero", crucero);
            }
            catch (Exception ex)
            {
                return PartialView("M24_ModificarCrucero");
            }
        }
    }
}