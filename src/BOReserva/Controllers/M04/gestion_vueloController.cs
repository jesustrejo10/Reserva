using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using BOReserva.Models.gestion_vuelo;
using BOReserva.Servicio.Servicio_Vuelos;
using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.Model;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones.M04;

namespace BOReserva.Controllers
{
    /// <summary>
    /// Clase que emite las respuestas de los eventos AJAX
    /// </summary>
    public class gestion_vueloController : Controller
    {
        //
        // GET: /gestion_vuelo/
        public static String _origen;
        public static String _destino;
        public static String _avion;

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
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error cargando la pagina visualizar desde la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido cargando la pagina visualizar, contacte con el administrador.";
                return Json(error);
            }
            return PartialView(listaVuelos);
        }



        //VISTA-CREAR: dlstatusvuelo() sera el metodo para llenar el DropdownList del status de vuelo
        public string[] dlstatusvuelo()
        {
            string[] _listaEstados = new String[2];
            _listaEstados[0] = "activo";
            _listaEstados[1] = "inactivo";
            return _listaEstados;
        }

        /// <summary>
        /// GET vista M04_GestionVuelo_Crear
        /// </summary>
        /// <returns>Vista parcial</returns>
        public ActionResult M04_GestionVuelo_CW1()
        {
            List<Entidad> listaCiudadOrigen;
            VueloViewModel modelo;
            try
            {
                Command<List<Entidad>> comando = FabricaComando.ConsultarM04_LugarOrigen();
                listaCiudadOrigen = comando.ejecutar();
                modelo = FabricaViewModelVuelo.instanciarCrearVueloVM();
                modelo._ciudadesOrigen = listaCiudadOrigen.Select(x => new SelectListItem
                                        {
                                            Value = x._id.ToString(),
                                            Text = ((Ciudad)x)._nombre
                                        });

            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error ingresando a la base de datos para la pagina agregar.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido ingresando a la pagina agregar, contacte con el administrador.";
                return Json(error);
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
                String error = "Error consultando los aviones disponibles para la ruta.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando los aviones disponibles, contacte con el administrador.";
                return Json(error);
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
            Vuelo dataAterrizaje;
            try
            {
                model.setFechaDespegue();
                comando = FabricaComando.ConsultarM04_DatosAterrizaje(model._idAvion, model._idRuta, model.fechaDespegue);
                dataAterrizaje = (Vuelo)comando.ejecutar();
                model._fechaDespegue = model.fechaDespegue.ToString(RecursoAvionCO.FormatoFecha);
                model._fechaAterrizaje = dataAterrizaje.FechaAterrizaje.ToString(RecursoAvionCO.FormatoFecha);
                model._horaAterrizaje = dataAterrizaje.FechaAterrizaje.ToString(RecursoAvionCO.FormatoHora);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando los aviones disponibles para la ruta.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando los aviones disponibles, contacte con el administrador.";
                return Json(error);
            }

            return PartialView("M04_GestionVuelo_CW3", model);
        }

        public ActionResult M04_GuardarVuelo(CrearVueloMO model)
        {
            Command<Boolean> comando;
            Entidad vuelo;
            Entidad avion;
            Ruta ruta;
            try
            {
                model.setFechaDespegue();
                avion = new Avion(model._idAvion, "", "", 0, 0, 0, 0, 0, 0, 0, 0);
                ruta = new Ruta(model._idRuta, "", "", "", "", 0);
                vuelo = FabricaEntidad.InstanciarVuelo(model._idAvion,
                                                       model._codigoVuelo,
                                                       ruta,
                                                       model.fechaDespegue,
                                                       model._statusVuelo,
                                                       model.getFechaAterrizaje(),
                                                       (Avion)avion);
                comando = FabricaComando.crearM04_AgregarVuelo(vuelo);
                comando.ejecutar();
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando los aviones disponibles para la ruta.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando los aviones disponibles, contacte con el administrador.";
                return Json(error);
            }

            return PartialView("M04_GestionVuelo_CW3", model);
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
                vModelo = (CrearVueloMO)FabricaViewModelVuelo.instanciarCrearVueloVM();
                vModelo._ciudadesOrigen = listaCiudadOrigen.Select(x => new SelectListItem
                {
                    Value = x._id.ToString(),
                    Text = ((Ciudad)x)._nombre,
                });
                vModelo._ciudadOrigen = ((Vuelo)vuelo).getRuta.origenRuta;
                vModelo._ciudadDestino = ((Vuelo)vuelo).getRuta.destinoRuta;
                vModelo._codigoVuelo = ((Vuelo)vuelo).CodigoVuelo;
                vModelo._idRuta = ((Vuelo)vuelo).getRuta.idRuta;
                vModelo._fechaDespegue = ((Vuelo)vuelo).FechaDespegue.ToString(RecursoAvionCO.FormatoFecha);
                vModelo._horaDespegue = ((Vuelo)vuelo).FechaDespegue.ToString(RecursoAvionCO.FormatoHora);
                vModelo._idAvion = ((Vuelo)vuelo).getAvion._id;
                vModelo._idVuelo = id;
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error ingresando a la base de datos para la pagina agregar.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido ingresando a la pagina agregar, contacte con el administrador.";
                return Json(error);
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
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando los aviones disponibles para la ruta.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando los aviones disponibles, contacte con el administrador.";
                return Json(error);
            }

            return PartialView("M04_GestionVuelo_MW2", model);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult M04_GestionVuelo_MW3(CrearVueloMO model)
        {
            Command<Entidad> comando;
            Vuelo dataAterrizaje;
            try
            {
                model.setFechaDespegue();
                comando = FabricaComando.ConsultarM04_DatosAterrizaje(model._idAvion, model._idRuta, model.fechaDespegue);
                dataAterrizaje = (Vuelo)comando.ejecutar();
                model._fechaAterrizaje = dataAterrizaje.FechaAterrizaje.ToString("dd/MM/yyyy");
                model._horaAterrizaje = dataAterrizaje.FechaAterrizaje.ToString("HH:mm");
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando los aviones disponibles para la ruta.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando los aviones disponibles, contacte con el administrador.";
                return Json(error);
            }

            return PartialView("M04_GestionVuelo_MW3", model);
        }


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
                ruta = new Ruta(model._idRuta, "", "", "", "", 0);
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
                TempData["message"] = ex.Message;
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando los aviones disponibles para la ruta.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando los aviones disponibles, contacte con el administrador.";
                return Json(error);
            }

            return PartialView("M04_GestionVuelo_CW3", model);
        }





        //eliminar si hay que hacerlo
        public ActionResult M04_DatosAterrizaje(int idAvion)
        {
            Entidad vuelo;
            try
            {
                /*model.setFechaDespegue();
                Command<Entidad> comando = FabricaComando.ConsultarM04_DatosAterrizaje(model._idAvion, model._idRuta, model.fechaDespegue);
                vuelo = comando.ejecutar();*/

            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error ingresando a la base de datos para la pagina agregar.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido ingresando a la pagina agregar, contacte con el administrador.";
                return Json(error);
            }
            return (Json(idAvion, JsonRequestBehavior.AllowGet));
        }








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
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error cargando los destinos desde la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido cargando los destinos, contacte con el administrador.";
                return Json(error);
            }

            return (Json(lugaresDestino, JsonRequestBehavior.AllowGet));
        }
        //Evento POST de la view de crear vuelo

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult validarAviones(int idRuta)
        {
            VueloViewModel model;
            Command<List<Entidad>> comando;
            List<Entidad> rutaAviones;
            try
            {
                model = FabricaViewModelVuelo.instanciarCrearVueloVM();
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
                String error = "Error desconocido consultando los aviones disponibles, contacte con el administrador.";
                return Json(error);
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult validarCodigo(String codVuelo)
        {
            try
            {
                Command<Boolean> comando = FabricaComando.ConsultarM04_CodigoVuelo(codVuelo);
                return Json(comando.ejecutar());
            }
            catch (ReservaExceptionM04 ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido consultando los aviones disponibles, contacte con el administrador.";
                return Json(error);
            }
        }


        /*
        [HttpPost]
        public JsonResult guardarVuelo(CrearVueloViewModel model)
        {
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();
            if ((model._matriculaAvion == null) || (model._codigoVuelo == null) || (model._ciudadOrigen == null)
                || (model._ciudadDestino == null) || (model._statusVuelo == null) || (model._fechaDespegue == null) || (model._horaDespegue == null))
            {
                //Creo el codigo de error de respuesta
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, campos obligatorios vacios";
                //Retorno el error
                return Json(error);
            }

            try // intento consultar en BD si el Codigo de vuelo ya fue previamente registrado
            {
                int repetido = sql.codVueloUnico(model._codigoVuelo);// llamo a BD
                if (repetido == 1)// vale 1 si ya fue registrado
                {
                    //Creo el codigo de error de respuesta
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //Agrego mi error
                    String error = "El codigo de vuelo ya esta registrado";
                    //Retorno el error
                    return Json(error);
                }
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error verificando el codigo de vuelo en la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido verificando el codigo de vuelo, contacte con el administrador.";
                return Json(error);
            }
         



        //    if ((model._fechaAterrizaje == null) || (model._horaAterrizaje == null))
        //    {
        //        //Creo el codigo de error de respuesta
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        //Agrego mi error
        //        String error = "Error en el calculo de la fecha de aterrizaje. Por favor intente nuevamente y complete los campos obligatorios";
        //        //Retorno el error
        //        return Json(error);
        //    }


            string resultadoFechaAterrizaje = "";
            string resultadoFechaDespegue = "";

            //tomo todas la variables que se introducieron en la vista
            String codigoVuelo = model._codigoVuelo;
            String ciudadOrigen = model._ciudadOrigen;
            String ciudadDestino = model._ciudadDestino;
            String fechaDespegue = model._fechaDespegue;
            String horaDespegue = model._horaDespegue;
            String matriculaAvion = model._matriculaAvion;
            String statusAvion = model._statusVuelo;


            //convierto fecha y hora en formato que acepte la BD
            resultadoFechaDespegue = "" + fechaDespegue + " " + horaDespegue;

            try
            {
                //metodo para calcular la fecha y hora de aterrizaje del vuelo, que luego llama a Stored Procedure
                resultadoFechaAterrizaje = sql.fechaVuelo(fechaDespegue, horaDespegue, ciudadOrigen, ciudadDestino, matriculaAvion);
                //procedo a insertar en la tabla Vuelo de la BD
                bool resultado = sql.insertarVuelo(codigoVuelo, ciudadOrigen, ciudadDestino, resultadoFechaDespegue, statusAvion, resultadoFechaAterrizaje, matriculaAvion);
                //envio una respuesta dependiendo del resultado del insert
                if (resultadoFechaAterrizaje != null)
                {
                    //elimino caracteres sobrantes para insert correcto
                    resultadoFechaAterrizaje = Regex.Replace(resultadoFechaAterrizaje, ":00", "");
                }
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando el vuelo en la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido insertando el vuelo, contacte con el administrador.";
                return Json(error);
            }


            return (Json(true, JsonRequestBehavior.AllowGet));
            
        }


        

      

        public ActionResult M04_GestionVuelo_Mostrar(int id)
        {
            manejadorSQL_Vuelos buscarvuelo = new manejadorSQL_Vuelos();
            CVuelo vuelo = new CVuelo();
            try
            {
               vuelo = buscarvuelo.MMostrarvueloBD(id); //BUSCA EL VUELO A MOSTRAR
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error cargando el vualo a mostrar desde la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido cargando el vuelo a mostrar, contacte con el administrador.";
                return Json(error);
            }
                                                                  
            return PartialView(vuelo);
        }*/




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
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error activando el vuelo en la base de datos.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido activando el vuelo, contacte con el administrador.";
                return Json(error);
            }

            return null;
        }




        [HttpPost]
        public ActionResult revisarCodVuelo(String codVuelo)
        {
            manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();
            int existe = 0;
            try
            {
                existe = sql.codVueloUnico(codVuelo);
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error ingresando a la base de datos para verificar el codigo.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido verificando codigo, contacte con el administrador.";
                return Json(error);
            }
            return Json(existe);
        }

    } 
}
