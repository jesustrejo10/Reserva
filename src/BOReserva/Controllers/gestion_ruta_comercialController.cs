﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_ruta_comercial;
using System.Net;
using System.Data.SqlClient;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;

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
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM03_ListarLugares();
            Dictionary < int, Entidad > listaLugares = comando.ejecutar();

            //CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();

            try
            {
                foreach (var origen in listaLugares)
                {
                    BOReserva.DataAccess.Domain.Ciudad r = (BOReserva.DataAccess.Domain.Ciudad)origen.Value;
                    lista.Add(r._nombre);
                }
                //lista = sql.listarLugares();

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
           
            CAgregarRuta ruta = new CAgregarRuta();
            List<String> lista = new List<String>();
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM03_ConsultarDestinos();
            Dictionary<int, Entidad> listaLugares = comando.ejecutar();
            //CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();                       

            try
            {
                foreach (var destino in listaLugares)
                {
                    BOReserva.DataAccess.Domain.Ciudad r = (BOReserva.DataAccess.Domain.Ciudad)destino.Value;
                    lista.Add(r._nombre);
                }
                //lista = sql.listarLugares();

                ruta._ldestinoRuta = lista.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });

                if (lista != null)
                {
                    return (Json(ruta._ldestinoRuta, JsonRequestBehavior.AllowGet));
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

            Command<Entidad> comando = FabricaComando.crearM03_MostrarRuta(idRuta);
            Ruta buscarRuta = (Ruta)comando.ejecutar();
            CAgregarRuta Route = new CAgregarRuta();
            Route._idRuta = idRuta;
            Route._destinoRuta = buscarRuta._destinoRuta;
            Route._distanciaRuta = buscarRuta._distancia;
            Route._estadoRuta = buscarRuta._status;
            Route._origenRuta = buscarRuta._origenRuta;
            Route._tipoRuta = buscarRuta._tipo;
        

            try
            {
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
            List<CRuta> listarutas = new List<CRuta>();
            // CManejadorSQL_Rutas ruta = new CManejadorSQL_Rutas();
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM03_MListarRutasBD();
            Dictionary<int, Entidad> listaRutas = comando.ejecutar();
            try
            {
                foreach (var ruta in listaRutas)
                {
                    BOReserva.DataAccess.Domain.Ruta r = (BOReserva.DataAccess.Domain.Ruta)ruta.Value;
                    CRuta rutaV = new CRuta();
                    rutaV.idRuta = r._idRuta;
                    rutaV.estadoRuta = r._status;
                    rutaV.tipoRuta = r._tipo;
                    rutaV.origenRuta = r._origenRuta;
                    rutaV.destinoRuta = r._destinoRuta;
                    rutaV.distanciaRuta = r._distancia;
                    listarutas.Add(rutaV);
                }

               // List<CRuta> listarutas = ruta.MListarRutasBD();
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
   //         CManejadorSQL_Rutas buscarRuta = new CManejadorSQL_Rutas();

            try 
            {
                Command<Entidad> comando = FabricaComando.crearM03_MostrarRuta(idRuta);
                Ruta buscarRuta = (Ruta)comando.ejecutar();
                CAgregarRuta Route = new CAgregarRuta();
                Route._idRuta = idRuta;
                Route._destinoRuta = buscarRuta._destinoRuta;
                Route._distanciaRuta = buscarRuta._distancia;
                Route._estadoRuta = buscarRuta._status;
                Route._origenRuta = buscarRuta._origenRuta;
                Route._tipoRuta = buscarRuta._tipo;
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
        public JsonResult guardarRuta(CAgregarRuta ruta)
        {
            
           // CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();
            //realizo el insert
            
                if (ruta._origenRuta == null || ruta._destinoRuta == null)
                {
                    //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //Agrego mi error
                    String error = "Error, no ha seleccionado un origen/destino valido";
                    //Retorno el error
                    return Json(error);

                }
                else if (ruta._distanciaRuta <= 0 || ruta._distanciaRuta == 999999 || ruta._distanciaRuta == null)
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
                        Entidad nuevaRuta = FabricaEntidad.InstanciarRuta(ruta);

                        Command<String> comando = FabricaComando.crearM03_AgregarRuta(nuevaRuta);
                        String agrego_si_no = comando.ejecutar();

                        if (agrego_si_no == "1")
                        return (Json(agrego_si_no));
                        else
                        {
                            //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                            Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            //Agrego mi error
                            String error = "Error en la insercion en la base de datos";
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

            //CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();
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

                        Ruta rutaM = new Ruta();
                        rutaM._idRuta = model._idRuta;
                        rutaM._status = model._estadoRuta;
                        rutaM._tipo = model._tipoRuta;
                        rutaM._distancia = model._distanciaRuta;
                        rutaM._destinoRuta = model._destinoRuta;
                        rutaM._origenRuta = model._origenRuta;
                        Command<Boolean> comando = FabricaComando.crearM03_ModificarRuta(rutaM, rutaM._idRuta);
                        Boolean resultado = comando.ejecutar();
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
            try
            {
                Command<Boolean> comando = FabricaComando.crearM03_HabilitarRuta(idRuta);
                Boolean resultado = comando.ejecutar();

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
            try
            {
                Command<Boolean> comando = FabricaComando.crearM03_DeshabilitarRuta(idRuta);
                Boolean resultado = comando.ejecutar();
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
