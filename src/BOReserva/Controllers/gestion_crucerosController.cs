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
using BOReserva.DataAccess.Domain.M14;

namespace BOReserva.Controllers
{
    public class gestion_crucerosController : Controller
    {

        private static int idCrucero;
        private static int idCabina;
        private static int idCamarote;
        private static int idFkCrucero;
        private static int idFkCabina;

        // GET: gestion_cruceros
        public ActionResult M24_GestionCruceros()
        {
            return PartialView();
        }

        /// <summary>
        /// Método de la vista parcial M24_AgregarCabinas
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
        /// Método de la vista parcial M24_AgregarCamarote
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



        /// <summary>
        /// Método de la vista parcial M24ListarCruceros
        /// </summary>
        /// <returns>Retorna la vista parcial M24_ListarCruceros en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_ListarCruceros()
        {
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarCruceros();
            Dictionary<int, Entidad> listaCruceros = comando.ejecutar();
            return PartialView(listaCruceros);
        }

        /// <summary>
        /// Método de la vista parcial M24ListarItinerarios
        /// </summary>
        /// <returns>Retorna la vista parcial M24_ListarItinerarios en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_ListarItinerario()
        {
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14Visualizaritinerario();
            Dictionary<int, Entidad> listaItinerario = comando.ejecutar();
            return PartialView(listaItinerario);
        }

        /// <summary>
        /// Método de la vista parcial M24ListarCabinas
        /// </summary>
        /// <returns>Retorna la vista parcial M24_ListarCcabinas en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_ListarCabinas(int id)
        {
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarCabinas(id);
            Dictionary<int, Entidad> listaCabinas = comando.ejecutar();
            return PartialView(listaCabinas);
        }

        /// <summary>
        /// Método de la vista parcial M24_ListarCamarotes
        /// </summary>
        /// <returns>Retorna la vista parcial M24_ListarCamarotes en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_ListarCamarotes(int id)
        {
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarCamarote(id);
            Dictionary<int, Entidad> listaCamarotes = comando.ejecutar();
            return PartialView(listaCamarotes);
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


        // <summary>
        /// Método de la vista parcial M24_ModificarCrucero
        /// </summary>
        /// <returns>Retorna la vista parcial M24_ModificarCrucero en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_ModificarCrucero(int id)
        {
            try
            {
                Command<Entidad> comando = FabricaComando.crearM14ConsultarCrucero(id);
                Entidad Crucero = comando.ejecutar();
                Crucero CruceroB = (Crucero)Crucero;
                idCrucero = CruceroB._id;
                CGestion_crucero modelovista = new CGestion_crucero();
                modelovista._nombreCrucero = CruceroB._nombreCrucero;
                modelovista._companiaCrucero = CruceroB._companiaCrucero;
                modelovista._capacidadCrucero = CruceroB._capacidadCrucero;
                modelovista._estatus = CruceroB._estatus;
                return PartialView(modelovista);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Método que se utiliza para modificar un crucero
        /// </summary>
        /// <param name="model">Datos que provienen de un formulario de la vista parcial M24_ModificarCrucero</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult modificarCrucero(CGestion_crucero model)
        {
            try
            {
                Entidad modificarCrucero = FabricaEntidad.InstanciarCrucero(model);
                //con la fabrica instancie al Crucero.
                Command<String> comando = FabricaComando.crearM14ModificarCrucero(modificarCrucero, idCrucero);
                String agrego_si_no = comando.ejecutar();

                return (Json(agrego_si_no));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // <summary>
        /// Método de la vista parcial M24_ModificarCabina
        /// </summary>
        /// <returns>Retorna la vista parcial M24_ModificarCabina en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_ModificarCabina(int id)
        {
            try
            {
                Command<Entidad> comando = FabricaComando.crearM14ConsultarCabina(id);
                Entidad cabina = comando.ejecutar();
                Cabina CabinaB = (Cabina)cabina;
                idCabina = CabinaB._id;
                idFkCrucero = CabinaB._id;
                CGestion_cabina modelovista = new CGestion_cabina();
                modelovista._nombreCabina = CabinaB._nombreCabina;
                modelovista._precioCabina = CabinaB._precioCabina;
                modelovista._estatus = CabinaB._estatus;
                return PartialView(modelovista);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Método que se utiliza para modificar una cabina
        /// </summary>
        /// <param name="model">Datos que provienen de un formulario de la vista parcial M24_ModificarCabina</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult modificarCabina(CGestion_cabina model)
        {
            try
            {
                Entidad modificarCabina = FabricaEntidad.InstanciarCabina(model);
                //con la fabrica instancie la cabina.
                Command<String> comando = FabricaComando.crearM14ModificarCabina(modificarCabina, idCabina, idFkCrucero);
                String agrego_si_no = comando.ejecutar();

                return (Json(agrego_si_no));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // <summary>
        /// Método de la vista parcial M24_ModificarCamarote
        /// </summary>
        /// <returns>Retorna la vista parcial M24_ModificarCamarote en conjunto del Modelo de dicha vista</returns>
        public ActionResult M24_ModificarCamarote(int id)
        {
            try
            {
                Command<Entidad> comando = FabricaComando.crearM14ConsultarCamarote(id);
                Entidad camarote = comando.ejecutar();
                Camarote CabinaB = (Camarote)camarote;
                idCabina = CabinaB._id;
                idFkCabina = CabinaB._fkCabina;
                CGestion_camarote modelovista = new CGestion_camarote();
                modelovista._cabinaNombre = CabinaB._nombreCabina + "-" + CabinaB._id;
                modelovista._cantidadCama = CabinaB._cantidadCama;
                modelovista._tipoCama = CabinaB._tipoCama;
                modelovista._estatus = CabinaB._estatus;
                return PartialView(modelovista);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Método que se utiliza para modificar un crucero
        /// </summary>
        /// <param name="model">Datos que provienen de un formulario de la vista parcial M24_ModificarCabina</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult modificarCamarote(CGestion_camarote model)
        {
            try
            {
                Entidad modificarCamarote = FabricaEntidad.InstanciarCamaroteN(model);
                //con la fabrica instancie la cabina.
                Command<String> comando = FabricaComando.crearM14ModificarCamarote(modificarCamarote, idCamarote, idFkCabina);
                String agrego_si_no = comando.ejecutar();

                return (Json(agrego_si_no));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}