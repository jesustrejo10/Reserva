using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_ruta_comercial;
using BOReserva.Servicio.Servicio_Rutas;
using System.Net;
using System.Data.SqlClient;

namespace BOReserva.Controllers
{
    public class gestion_ruta_comercialController : Controller
    {
        //
        // GET: gestion_ruta_comercial/AgregarRutasComerciales
        public ActionResult AgregarRutasComerciales()
        {
            List<String> lista = new List<string>();
            
            CAgregarRuta ruta = new CAgregarRuta();
            
            CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();

            try
            {
                lista = sql.listarLugares();

                ruta._lorigenRuta = lista.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });
                return PartialView(ruta);
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
        public JsonResult cargarDestinos(string ciudadO)
        {
            CAgregarRuta model = new CAgregarRuta();
            List<String> resultado = new List<String>();
            CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();                       

            try
            {
                resultado = sql.consultarDestinos(ciudadO);

                model._ldestinoRuta = resultado.Select(m => new SelectListItem
                {
                    Value = m,
                    Text = m
                });

                if (resultado != null)
                {
                    return (Json(model._ldestinoRuta, JsonRequestBehavior.AllowGet));
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


        // GET: gestion_ruta_comercial/ModificarRutasComerciales
        public ActionResult ModificarRutasComerciales(int idRuta)
        {
            
            CManejadorSQL_Rutas buscarRuta = new CManejadorSQL_Rutas();
            try
            {
                CAgregarRuta Route = buscarRuta.MMostrarRutaBD(idRuta);
                Route._idRuta = idRuta;
                CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();
                List<String> lista = new List<string>();



                lista = sql.listarLugares();

                Route._lorigenRuta = lista.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });
                return PartialView(Route);
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


        // GET: gestion_ruta_comercial/VisualizarRutasComerciales
        public PartialViewResult VisualizarRutasComerciales()
        {
            
            CManejadorSQL_Rutas ruta = new CManejadorSQL_Rutas();
            try
            {
                List<CRuta> listarutas = ruta.MListarRutasBD();
                return PartialView(listarutas);
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

        // GET: gestion_ruta_comercial/DetalleRutasComerciales
        public ActionResult DetalleRutasComerciales(int idRuta)
        {
            CManejadorSQL_Rutas buscarRuta = new CManejadorSQL_Rutas();
            try 
            {
                CAgregarRuta Route = buscarRuta.MMostrarRutaBD(idRuta);
                Route._idRuta = idRuta;
                return PartialView(Route);
 
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


        [HttpPost]
        public JsonResult guardarRuta(CAgregarRuta model)
        {
            
            CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();
            //realizo el insert
            
                if (model._origenRuta == null || model._destinoRuta == null)
                {
                    //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //Agrego mi error
                    String error = "Error, no ha seleccionado un origen/destino valido";
                    //Retorno el error
                    return Json(error);

                }
                else if (model._distanciaRuta <= 0 || model._distanciaRuta == 999999 || model._distanciaRuta == null)
                {
                    //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //Agrego mi error
                    String error = "Error, distancia de ruta invalida";
                    //Retorno el error
                    return Json(error);
                }
                else
                {
                     try
                    {
                       bool resultado = sql.InsertarRuta(model);
                       if (resultado)
                       {
                           return (Json(true, JsonRequestBehavior.AllowGet));
                       }
                       else
                       {
                           //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                           Response.StatusCode = (int)HttpStatusCode.BadRequest;
                           //Agrego mi error
                           String error = "Error, ruta existente";
                           //Retorno el error
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
        }



        [HttpPost]
        public JsonResult modificarRuta(CAgregarRuta model)
        {

            CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();
            //realizo el insert


                if (model._distanciaRuta <= 0 || model._distanciaRuta == 999999 || model._distanciaRuta == null)
                {
                    //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //Agrego mi error
                    String error = "Error, distancia de ruta invalida";
                    //Retorno el error
                    return Json(error);
                }
                else
                {

                     try
                    {

                       bool resultado = sql.MModificarRuta(model);
                       if (resultado)
                       {
                           return null;
                       }
                       else
                       {
                           //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                           Response.StatusCode = (int)HttpStatusCode.BadRequest;
                           //Agrego mi error
                           String error = "Error, la ruta no pudo ser modificada";
                           //Retorno el error
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



        }

        /// <summary>
        /// Método para cambiar a "Activa" el status de una ruta
        /// </summary>
        /// <param name="idRuta">Id de la Ruta a la que se le cambiará el estatus</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult HabilitarRuta(int idRuta)
        {
            CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();
            try
            {
                Boolean resultado = sql.habilitarRuta(idRuta);
                if (resultado)
                {
                    return (Json(true, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)  
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //Agrego mi error  
                    String error = "Error en la base de datos";
                    //Retorno el error  
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

        /// <summary>
        /// Método para cambiar a "Inactiva" el status de una ruta
        /// </summary>
        /// <param name="idRuta">Id de la Ruta a la que se le cambiará el estatus</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult InhabilitarRuta(int idRuta)
        {
            CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();
            try
            {
                Boolean resultado = sql.deshabilitarRuta(idRuta);
                if (resultado)
                {
                    return (Json(true, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)  
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //Agrego mi error  
                    String error = "Error en la base de datos";
                    //Retorno el error  
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
    }
}
