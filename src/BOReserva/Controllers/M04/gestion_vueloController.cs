using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using BOReserva.Models.gestion_vuelo;
using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.Model;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones.M04;
using BOReserva.Excepciones;

namespace BOReserva.Controllers
{
    /// <summary>
    /// Clase que para controlar las peticiones 
    /// </summary>
    public class gestion_vueloController : Controller
    {
 

        /// <summary>
        /// Metodo GET para la ventana de visualizar todos los vuelos
        /// </summary>
        /// <returns>Partial View con la lista de vuelos</returns>
        public ActionResult M04_GestionVuelo_Visualizar()
        {
            List<Entidad> listaVuelos;
            try
            {
                Command<List<Entidad>> comando = FabricaComando.ConsultarM04_ConsultarTodos();
                listaVuelos = comando.ejecutar();
                return PartialView(listaVuelos);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorBD, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// GET vista M04_GestionVuelo_Crear
        /// </summary>
        /// <returns>Vista parcial</returns>
        public ActionResult M04_GestionVuelo_CW1()
        {
            List<Entidad> listaCiudadOrigen;
            CrearVueloMO modelo;
            try
            {
                Command<List<Entidad>> comando = FabricaComando.ConsultarM04_LugarOrigen();
                listaCiudadOrigen = comando.ejecutar();
                modelo = new CrearVueloMO();
                modelo._ciudadesOrigen = listaCiudadOrigen.Select(x => new SelectListItem
                                        {
                                            Value = x._id.ToString(),
                                            Text = ((Ciudad)x)._nombre
                                        });

            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorBD, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }
            return PartialView(modelo);
        }

        /// <summary>
        /// Action result que llama al Wizzard Crear 2
        /// </summary>
        /// <param name="model">modelo de la vista crear 1</param>
        /// <returns>partial view a la vista crear 2</returns>
        public ActionResult M04_GestionVuelo_CW2(CrearVueloMO model)
        {
            Command<List<Entidad>> comando;
            List<Entidad> rutaAviones;
            try
            {
                model.setFechaDespegue();
                comando = FabricaComando.ConsultarM04_BuscarAvionRuta(model._idRuta);
                rutaAviones = comando.ejecutar();
                model._matriculasAvion = new SelectList(rutaAviones,
                                                        RecursoAvionCO.ParametroIdSelect,
                                                        RecursoAvionCO.ParametroMatSelect
                                                        );
                return PartialView(RecursoAvionCO.PartialViewCW2, model);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorBD, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }

            return PartialView(RecursoAvionCO.PartialViewCW2, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult M04_GestionVuelo_CW3(CrearVueloMO model)
        {
            Command<Entidad> comando;
            Entidad dataAterrizaje;
            Entidad avion;
            try
            {
                comando = FabricaComando.crearM02ConsultarAvion(model._idAvion);
                avion = comando.ejecutar();
                model.setFechaDespegue();
                comando = FabricaComando.ConsultarM04_DatosAterrizaje(model._idAvion, model._idRuta, model.fechaDespegue);
                dataAterrizaje = (Vuelo)comando.ejecutar();
                model._matriculaAvion = ((Avion)avion)._matricula;
                model._fechaDespegue = model.fechaDespegue.ToString(RecursoAvionCO.FormatoFecha);
                model._fechaAterrizaje = ((Vuelo)dataAterrizaje).FechaAterrizaje.ToString(RecursoAvionCO.FormatoFecha);
                model._horaAterrizaje = ((Vuelo)dataAterrizaje).FechaAterrizaje.ToString(RecursoAvionCO.FormatoHora);
                model._modelo = ((Avion)avion)._modelo;
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message ,JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }

            return PartialView("M04_GestionVuelo_CW3", model);
        }

        /// <summary>
        /// Action que se encarga de guardar un vuelo
        /// </summary>
        /// <param name="model"></param>
        /// <returns>vista parcial</returns>
        public ActionResult M04_GuardarVuelo(CrearVueloMO model)
        {
            Command<Boolean> comando;
            Entidad vuelo;
            Entidad avion;
            Entidad ruta;
            try
            {
                model.setFechaDespegue();
                avion = FabricaEntidad.InstanciarAvion(model._idAvion, "", "", 0, 0, 0, 0, 0, 0, 0, 0);
                avion._id = model._idAvion;
                ruta = FabricaEntidad.InstanciarRuta(model._idRuta, 0, "", "", "", "");
                vuelo = FabricaEntidad.InstanciarVuelo(model._idAvion,
                                                       model._codigoVuelo,
                                                       (Ruta)ruta,
                                                       model.fechaDespegue,
                                                       model._statusVuelo,
                                                       model.getFechaAterrizaje(),
                                                       (Avion)avion);
                comando = FabricaComando.crearM04_AgregarVuelo(vuelo);
                comando.ejecutar();
            }
            catch (ReservaExceptionM04 ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("M04_GestionVuelo_Visualizar");
        }

        /// <summary>
        /// GET vista M04_GestionVuelo_MW1
        /// </summary>
        /// <param name="model"></param>
        /// <returns>La primera vista del wizzard modificar</returns>
        public ActionResult M04_GestionVuelo_MW1(int id)
        {
            List<Entidad> listaCiudadOrigen;
            CrearVueloMO vModelo;
            Entidad vuelo;
            try
            {
                Command<List<Entidad>> comando = FabricaComando.ConsultarM04_LugarOrigen();
                listaCiudadOrigen = comando.ejecutar();
                Command<Entidad> coBuscar = FabricaComando.ConsultarM04_Vuelo(id);
                vuelo = coBuscar.ejecutar();
                vModelo = new CrearVueloMO(); 
                vModelo._ciudadesOrigen = listaCiudadOrigen.Select(x => new SelectListItem
                {
                    Value = x._id.ToString(),
                    Text = ((Ciudad)x)._nombre,
                });
                vModelo._ciudadOrigen = ((Vuelo)vuelo).getRuta._origenRuta;
                vModelo._ciudadDestino = ((Vuelo)vuelo).getRuta._destinoRuta;
                vModelo._codigoVuelo = ((Vuelo)vuelo).CodigoVuelo;
                vModelo._idRuta = ((Vuelo)vuelo).getRuta._idRuta;
                vModelo._fechaDespegue = ((Vuelo)vuelo).FechaDespegue.ToString(RecursoAvionCO.FormatoFecha);
                vModelo._horaDespegue = ((Vuelo)vuelo).FechaDespegue.ToString(RecursoAvionCO.FormatoHora);
                vModelo._idAvion = ((Vuelo)vuelo).getAvion._id;
                vModelo._idVuelo = id;
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorBD, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }
            return PartialView("M04_GestionVuelo_MW1", vModelo);

        }

        /// <summary>
        /// Action result que llama al Wizzard Crear 2
        /// </summary>
        /// <param name="model">modelo de la vista crear 1</param>
        /// <returns>partial view a la vista crear 2</returns>
        public ActionResult M04_GestionVuelo_MW2(CrearVueloMO model)
        {
            Command<List<Entidad>> comando;
            List<Entidad> rutaAviones;
            try
            {
                model.setFechaDespegue();
                comando = FabricaComando.ConsultarM04_BuscarAvionRuta(model._idRuta);
                rutaAviones = comando.ejecutar();

                model._matriculasAvion = new SelectList(rutaAviones, "_id ", "_matricula");
                return PartialView("M04_GestionVuelo_MW2", model);
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorBD, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult M04_GestionVuelo_MW3(CrearVueloMO model)
        {
            Command<Entidad> comando;
            Entidad dataAterrizaje;
            Entidad avion;
            try
            {
                comando = FabricaComando.crearM02ConsultarAvion(model._idAvion);
                avion = comando.ejecutar();
                model.setFechaDespegue();
                comando = FabricaComando.ConsultarM04_DatosAterrizaje(model._idAvion, model._idRuta, model.fechaDespegue);
                dataAterrizaje = (Vuelo)comando.ejecutar();
                model._matriculaAvion = ((Avion)avion)._matricula;
                model._fechaAterrizaje = ((Vuelo)dataAterrizaje).FechaAterrizaje.ToString(RecursoAvionCO.FormatoFecha);
                model._horaAterrizaje = ((Vuelo)dataAterrizaje).FechaAterrizaje.ToString(RecursoAvionCO.FormatoHora);
                model._modelo = ((Avion)avion)._modelo;
                model._matriculaAvion = ((Avion)avion)._matricula;
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }

            return PartialView("M04_GestionVuelo_MW3", model);
        }

        /// <summary>
        /// Action Result para modificar un vuelo
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Partial View</returns>
        public ActionResult M04_ModificarVuelo(CrearVueloMO model)
        {
            Command<Entidad> comando;
            Entidad vuelo;
            Entidad avion;
            Ruta ruta;
            try
            {
                model.setFechaDespegue();
                avion = new Avion(model._idAvion, "", "", 0, 0, 0, 0, 0, 0, 0, 0);
                ruta = new Ruta(model._idRuta, 0, "", "", "", "");
                vuelo = FabricaEntidad.InstanciarVuelo(model._idVuelo,
                                                       model._codigoVuelo,
                                                       ruta,
                                                       model.fechaDespegue,
                                                       model._statusVuelo,
                                                       model.getFechaAterrizaje(),
                                                       (Avion)avion);
                comando = FabricaComando.ModificarM04_ModificarVuelo(vuelo);
                comando.ejecutar();
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorBD, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }

            return RedirectToAction("M04_GestionVuelo_Visualizar");
        }

        /// <summary>
        /// Datos del avion
        /// </summary>
        /// <param name="idAvion"></param>
        /// <returns></returns>
        public ActionResult M04_DatosAterrizaje(int idAvion)
        {
            Avion avion;
            Command<Entidad> comando;
            CrearVueloMO vM;
            try
            {
                vM = new CrearVueloMO();
                comando = FabricaComando.crearM02ConsultarAvion(idAvion);
                avion = (Avion)comando.ejecutar();
                vM._distanciaMaxima = avion._distanciaMaximaVuelo.ToString();
                vM._velocidadMaxima = avion._velocidadMaxima.ToString();
                vM._pasajerosAvion = (avion._capacidadEjecutiva + avion._capacidadEquipaje + avion._capacidadTurista).ToString();
                vM._modeloAvion = avion._modelo;
                return (Json(vM, JsonRequestBehavior.AllowGet));
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Metodo para cargar los destinos segun la ruta y ciudad de origen
        /// </summary>
        /// <param name="ciudadO">ciudad origen</param>
        /// <returns>lista de posibles ciudades destino</returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult cargarDestinos(int ciudadO)
        {
            Command<List<Entidad>> comando;
            List<Entidad> entidad;
            SelectList lugaresDestino;
            try
            {
                comando = FabricaComando.ConsultarM04_LugarDestino(ciudadO);
                entidad = comando.ejecutar();
                lugaresDestino = new SelectList(entidad, "_id", "_nombre");
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = ex.Message;
                return Json(error,  JsonRequestBehavior.AllowGet);
            }

            return (Json(lugaresDestino, JsonRequestBehavior.AllowGet));
        }

        /// <summary>
        /// Valida que existan aviones capaces de volar la ruta especificada
        /// </summary>
        /// <param name="idRuta">id de la ruta</param>
        /// <returns>Lista de aviones que pueden volar esa ruta</returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult validarAviones(int idRuta)
        {
            CrearVueloMO model;
            Command<List<Entidad>> comando;
            List<Entidad> rutaAviones;
            try
            {
                model = new CrearVueloMO();
                comando = FabricaComando.ConsultarM04_BuscarAvionRuta(idRuta);
                rutaAviones = comando.ejecutar();
                model._matriculasAvion = new SelectList(rutaAviones, "_id ", "_matricula");
                return (Json(model._matriculasAvion, JsonRequestBehavior.AllowGet));
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Metodo para validar que el codigo del vuelo seleccionado es unico
        /// </summary>
        /// <param name="codVuelo"></param>
        /// <returns>exception en caso de que no sea unico</returns>
        [HttpPost]
        public ActionResult validarCodigo(String codVuelo)
        {
            try
            {
                Command<Boolean> comando = FabricaComando.ConsultarM04_CodigoVuelo(codVuelo);
                return Json(comando.ejecutar(), JsonRequestBehavior.AllowGet);
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Cambiar status del vuelo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult M04_Cambiar_Status(int idVuelo)
        {
            try
            {
                Command<Boolean> comando = FabricaComando.M04_CambiarStatus(idVuelo);
                comando.ejecutar();
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        /// <summary>
        /// Action result para la vista ver vuelo
        /// </summary>
        /// <param name="idVuelo"></param>
        /// <returns></returns>
        public ActionResult M04_Ver_Vuelo(int idVuelo)
        {
            Entidad vuelo;
            Command<Entidad> comando;
            CrearVueloMO model;
            try
            {
                comando = FabricaComando.ConsultarM04_Vuelo(idVuelo);
                vuelo = comando.ejecutar();
                model = new CrearVueloMO();
                model._codigoVuelo = ((Vuelo)vuelo).CodigoVuelo;
                model._ciudadOrigen = ((Vuelo)vuelo).getRuta._origenRuta;
                model._ciudadDestino = ((Vuelo)vuelo).getRuta._destinoRuta;
                model._fechaDespegue = ((Vuelo)vuelo).FechaDespegue.ToString("g");
                model._fechaAterrizaje = ((Vuelo)vuelo).FechaAterrizaje.ToString("g");
                model._statusVuelo = ((Vuelo)vuelo).StatusVuelo;
                model._matriculaAvion = ((Vuelo)vuelo).getAvion._matricula;
                return PartialView("M04_GestionVuelo_Mostrar", model);
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Cambiar status del vuelo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult M04_Eliminar_Vuelo(int idVuelo)
        {
            try
            {
                Command<Boolean> comando = FabricaComando.EliminarM04_Vuelo(idVuelo);
                comando.ejecutar();
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(RecursoAvionCO.MensajeErrorGeneral, JsonRequestBehavior.AllowGet);
            }

            return RedirectToAction("M04_GestionVuelo_Visualizar");
        }
    } 
}
